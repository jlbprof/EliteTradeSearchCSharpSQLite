﻿//
// Copyright 2018 - Julian Brown
//
// MIT License
//
// Original Author: Julian Brown
// Sept 05, 2018
//

using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;

namespace EliteTradeSearch
{
    // TradeSearchSQL would wrap whatever data engine that you want
    // Later if I have time, I will build other data engines and this
    // one would be renamed TradeSearchSQLite, and then the TradeSearchSQL
    // would be a parent class

    // I may want to make this object a Singleton as well, but at the moment
    // only one other class is calling it, if others were created that needed
    // access to the DB, this should be a Singleton

    class TradeSearchSQL
    {
        // We need a copy of the configuration, to know where to put things

        private PersistantConfiguration myConfiguration = null;

        // this connection is managed by connect and closeConnection
        private SQLiteConnection myConnection = null;

        public TradeSearchSQL()
        {
            myConfiguration = PersistantConfiguration.Instance;
        }

        public void closeConnection()
        {
            if (myConnection != null)
            {
                myConnection.Close();
                myConnection = null;
            }
        }

        public void connect()
        {
            if (myConnection != null)
                return;

            String myDBName = myConfiguration.DataBaseFile;

            String myConnectString = "DataSource=" + myDBName;
            System.Console.WriteLine("DB :" + myConnectString + ":");
            myConnection = new SQLiteConnection(myConnectString);
            myConnection.Open();
        }

        public bool isConnected ()
        {
            if (myConnection == null)
                return false;

            return true;
        }

        private bool doesDBExist
        {
            get {
                if (File.Exists(myConfiguration.DataBaseFile))
                    return true;

                return false;
            }
        }

        // Real simple, delete any existing database, for SQLite just delete the file
        // Create the new data file, and inject the schema

        public void CreateDatabase ()
        {
            closeConnection();

            if (doesDBExist)
                File.Delete(myConfiguration.DataBaseFile);

            // fyi, by connecting to the db, the file is created if it does not already
            // exist

            connect();

            SQLiteCommand createDatabase = new SQLiteCommand(getSchemaSQL, myConnection);
            createDatabase.ExecuteReader();

            closeConnection();
        }

        // Get a count of these various tables, purpose is to find out if any data has been inserted
        // into these tables or not

        public int countCommodities ()
        {
            if (!doesDBExist || !isConnected ())
                return 0;

            SQLiteCommand myCommand = new SQLiteCommand("SELECT COUNT(*) FROM commodities;", myConnection);
            SQLiteDataReader myReader = myCommand.ExecuteReader();

            if (!myReader.HasRows)
                return 0;

            myReader.Read();
            return myReader.GetInt32(0);
        }

        public int countSystems()
        {
            if (!doesDBExist || !isConnected())
                return 0;

            SQLiteCommand myCommand = new SQLiteCommand("SELECT COUNT(*) FROM Systems;", myConnection);
            SQLiteDataReader myReader = myCommand.ExecuteReader();

            if (!myReader.HasRows)
                return 0;

            myReader.Read();
            return myReader.GetInt32(0);
        }

        public int countStations()
        {
            if (!doesDBExist || !isConnected())
                return 0;

            SQLiteCommand myCommand = new SQLiteCommand("SELECT COUNT(*) FROM stations;", myConnection);
            SQLiteDataReader myReader = myCommand.ExecuteReader();

            if (!myReader.HasRows)
                return 0;

            myReader.Read();
            return myReader.GetInt32(0);
        }

        public int countPrices()
        {
            if (!doesDBExist || !isConnected())
                return 0;

            SQLiteCommand myCommand = new SQLiteCommand("SELECT COUNT(*) FROM prices;", myConnection);
            SQLiteDataReader myReader = myCommand.ExecuteReader();

            if (!myReader.HasRows)
                return 0;

            myReader.Read();
            return myReader.GetInt32(0);
        }

        // insert the data from the commodities download and insert them into the db

        public void insertCommodities ()
        {
            if (!doesDBExist)
                return;

            if (!File.Exists(myConfiguration.CommoditiesFile))
                return;

            connect();

            // The data is stored as one large JSON object, read it in and parse it
            // into an object

            String commoditiesJson = File.ReadAllText(myConfiguration.CommoditiesFile);
            dynamic myCommodities = JsonConvert.DeserializeObject(commoditiesJson);

            int count = myCommodities.Count;
            int i;

            // Using one transaction (begin/commit) so that indexing is deferred, this makes this
            // mass insert much faster.   Note we also delete any existing data, as we are really
            // replacing with this new download

            SQLiteCommand myCommand = new SQLiteCommand("BEGIN TRANSACTION; DELETE FROM commodities;", myConnection);
            SQLiteDataReader myReader = myCommand.ExecuteReader();

            // set up the insert pattern
            myCommand = new SQLiteCommand("INSERT INTO commodities (\"id\", \"name\") VALUES (@id, @name);", myConnection);

            for (i = 0; i < count; ++i)
            {
                dynamic working = myCommodities[i];

                String output = "ID :" + working.id + ": Name :" + working.name + ":";

                // using the binding parameters mechanism provided by SQLite

                myCommand.Parameters.Clear();
                myCommand.Parameters.AddWithValue("@id", working.id);
                myCommand.Parameters.AddWithValue("@name", working.name);
                myReader = myCommand.ExecuteReader();
                myReader.Close();

                Debug.Print (output);
            }

            // and commit
            // TBD: put this in a try/catch with a rollback

            myCommand = new SQLiteCommand("COMMIT TRANSACTION;", myConnection);
            myReader = myCommand.ExecuteReader();
        }

        // These all follow similar patterns but the input data is processed differently
        // depending on the input type

        public void insertSystems()
        {
            if (!doesDBExist)
                return;

            if (!File.Exists(myConfiguration.SystemsPopulatedFile))
                return;

            connect();

            StreamReader sr = File.OpenText(myConfiguration.SystemsPopulatedFile);
            String jsonString;

            SQLiteCommand myCommand = new SQLiteCommand("BEGIN TRANSACTION; DELETE FROM Systems;", myConnection);
            SQLiteDataReader myReader = myCommand.ExecuteReader();
            myReader.Close();

            myCommand = new SQLiteCommand("INSERT INTO Systems (\"id\", \"edsm_id\", \"name\", \"x\", \"y\", \"z\", \"needs_permit\") VALUES (@id, @edsm_id, @name, @x, @y, @z, @needs_permit);", myConnection);

            // The input file is a jsonl file, that is each line is a complete json object that can be independantly parsed
            // and inserted.

            while ((jsonString = sr.ReadLine()) != null)
            {
                dynamic mySystem = JsonConvert.DeserializeObject(jsonString);

                // needs_permit, is either true or false in the jsonl, but in the SQLite, I am using
                // 1 or 0, so I am converting it

                int needs_permit = 0;
                if (mySystem.needs_permit == "true")
                {
                    needs_permit = 1;
                    String sDebug = "FOUND NEED_PERMIT :" + mySystem.need_permit + ":";
                    Debug.Print(sDebug);
                }

                myCommand.Parameters.Clear();
                myCommand.Parameters.AddWithValue("@id", mySystem.id);
                myCommand.Parameters.AddWithValue("@edsm_id", mySystem.edsm_id);
                myCommand.Parameters.AddWithValue("@name", mySystem.name);
                myCommand.Parameters.AddWithValue("@x", mySystem.x);
                myCommand.Parameters.AddWithValue("@y", mySystem.y);
                myCommand.Parameters.AddWithValue("@z", mySystem.z);
                myCommand.Parameters.AddWithValue("@needs_permit", needs_permit);
                myReader = myCommand.ExecuteReader();
                myReader.Close();
            }

            myCommand = new SQLiteCommand("COMMIT TRANSACTION;", myConnection);
            myReader = myCommand.ExecuteReader();
        }

        public void insertStations ()
        {
            if (!doesDBExist)
                return;

            if (!File.Exists(myConfiguration.StationsFile))
                return;

            connect();

            StreamReader sr = File.OpenText(myConfiguration.StationsFile);
            String jsonString;

            SQLiteCommand myCommand = new SQLiteCommand("BEGIN TRANSACTION; DELETE FROM Stations;", myConnection);
            SQLiteDataReader myReader = myCommand.ExecuteReader();
            myReader.Close();

            myCommand = new SQLiteCommand("INSERT INTO Stations (\"id\", \"name\", \"system_id\", \"updated_at\", \"max_landing_pad_size\", \"distance_to_star\", \"is_planetary\") VALUES (@id, @name, @system_id, @updated_at, @max_landing_pad_size, @distance_to_star, @is_planetary);", myConnection);

            // this data is also a jsonl file, following the same pattern

            while ((jsonString = sr.ReadLine()) != null)
            {
                dynamic myStation = JsonConvert.DeserializeObject(jsonString);

                // is_planetary is either true or false, convert it to 1 or 0
                int is_planetary = 0;
                if (myStation.is_planetary == "true")
                {
                    is_planetary = 1;
                    String sDebug = "FOUND is_planetary :" + myStation.is_planetary + ":";
                    Debug.Print(sDebug);
                }

                myCommand.Parameters.Clear();
                myCommand.Parameters.AddWithValue("@id", myStation.id);
                myCommand.Parameters.AddWithValue("@name", myStation.name);
                myCommand.Parameters.AddWithValue("@system_id", myStation.system_id);
                myCommand.Parameters.AddWithValue("@updated_at", myStation.updated_at);
                myCommand.Parameters.AddWithValue("@max_landing_pad_size", myStation.max_landing_pad_size);
                myCommand.Parameters.AddWithValue("@distance_to_star", myStation.distance_to_star);
                myCommand.Parameters.AddWithValue("@is_planetary", is_planetary);
                myReader = myCommand.ExecuteReader();
                myReader.Close();
            }

            myCommand = new SQLiteCommand("COMMIT TRANSACTION;", myConnection);
            myReader = myCommand.ExecuteReader();
        }

        public void insertPrices ()
        {
            if (!doesDBExist)
                return;

            if (!File.Exists(myConfiguration.StationsFile))
                return;

            connect();

            // OK, this one is different, the data is a CSV file.   And I have to throw away
            // the first line, which is a header.
            // Note, I borrowed TextFieldParser from VisualBasic, so shoot me

            TextFieldParser myParser = new TextFieldParser(myConfiguration.PricesFile);
            myParser.SetDelimiters(",");
            myParser.ReadLine(); // Skip header line

            SQLiteCommand myCommand = new SQLiteCommand("BEGIN TRANSACTION; DELETE FROM prices;", myConnection);
            SQLiteDataReader myReader = myCommand.ExecuteReader();
            myReader.Close();

            myCommand = new SQLiteCommand("INSERT INTO prices (\"id\", \"station_id\", \"commodity_id\", \"supply\", \"demand\", \"buy_price\", \"sell_price\", \"collected_at\") VALUES (@id, @station_id, @commodity_id, @supply, @demand, @buy_price, @sell_price, @collected_at);", myConnection);

            while (!myParser.EndOfData)
            {
                // The csv fields is returned an array of strings, just have to know
                // which index is what value.

                String[] fields = myParser.ReadFields();

                myCommand.Parameters.Clear();
                myCommand.Parameters.AddWithValue("@id", fields[0]);
                myCommand.Parameters.AddWithValue("@station_id", fields[1]);
                myCommand.Parameters.AddWithValue("@commodity_id", fields[2]);
                myCommand.Parameters.AddWithValue("@supply", fields[3]);
                myCommand.Parameters.AddWithValue("@buy_price", fields[5]);
                myCommand.Parameters.AddWithValue("@sell_price", fields[6]);
                myCommand.Parameters.AddWithValue("@demand", fields[7]);
                myCommand.Parameters.AddWithValue("@collected_at", fields[9]);

                myReader = myCommand.ExecuteReader();
                myReader.Close();
            }

            myCommand = new SQLiteCommand("COMMIT TRANSACTION;", myConnection);
            myReader = myCommand.ExecuteReader();
        }

        // have the schema be returned from this method, just a convenience for db creation

        public String getSchemaSQL
        {
            get
            {
                return @"CREATE TABLE `Systems` (
	`id`	INTEGER NOT NULL,
	`edsm_id`	INTEGER NOT NULL,
	`name`	TEXT NOT NULL,
	`x`	REAL NOT NULL,
	`y`	REAL NOT NULL,
	`z`	REAL NOT NULL,
	`needs_permit`	INTEGER NOT NULL,
	PRIMARY KEY(`id`)
);
CREATE INDEX `systems_id` ON `Systems` (
	`id`
);
CREATE INDEX `systems_edsm_id` ON `Systems` (
	`edsm_id`
);
CREATE INDEX `systems_name` ON `Systems` (
	`name`
);
CREATE TABLE `stations` (
	`id`	INTEGER NOT NULL,
	`name`	TEXT NOT NULL,
	`system_id`	INTEGER NOT NULL,
	`updated_at`	INTEGER NOT NULL,
	`max_landing_pad_size`	TEXT NOT NULL,
	`distance_to_star`	REAL NOT NULL,
	`is_planetary`	INTEGER NOT NULL,
	PRIMARY KEY(`id`)
);
CREATE INDEX `stations_id` ON `stations` (
	`id`
);
CREATE INDEX `stations_system_id` ON `stations` (
	`system_id`
);
CREATE INDEX `stations_name` ON `Systems` (
	`name`
);
CREATE TABLE `commodities` (
	`id`	INTEGER NOT NULL,
	`name`	TEXT NOT NULL
);
CREATE INDEX `commodities_id` ON `commodities` (
	`id`
);
CREATE INDEX `commodities_name` ON `commodities` (
	`name`
);
CREATE TABLE `prices` (
	`id`	INTEGER NOT NULL,
	`station_id`	INTEGER NOT NULL,
	`commodity_id`	INTEGER NOT NULL,
	`supply`	INTEGER NOT NULL,
	`demand`	INTEGER NOT NULL,
	`buy_price`	INTEGER NOT NULL,
	`sell_price`	INTEGER NOT NULL,
	`collected_at`	INTEGER NOT NULL,
	PRIMARY KEY(`id`)
);
CREATE INDEX `prices_station_id` ON `prices` (
	`station_id`
);
CREATE INDEX `prices_collected_at` ON `prices` (
	`collected_at`
);
CREATE INDEX `prices_commodity_id` ON `prices` (
	`commodity_id`
);
CREATE INDEX `prices_id` ON `prices` (
	`id`,
	`commodity_id`
);";
            }
        }
    }
}
