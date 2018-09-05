//
// EliteTradeSearch - Database update software
//
// Elite Dangerous is a game of space exploration and trading between stations.
//
// This program guides you through the downloading of the latest data, and
// keeping a SQLite database updated with this downloaded information.
//
// Copyright 2018 - Julian Brown
//
// MIT License
//
// Original Author: Julian Brown
// Sept 05, 2018
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EliteTradeSearch
{
    public partial class MainForm : Form
    {
        // PersistantConfiguration is a wrapper around the normal .NET persistant
        // settings code, with some convenience routines.

        private PersistantConfiguration myConfiguration;

        // TradeSearachSQL, wraps around the SQL database, currently it only
        // supports SQLite, but could easily be changed to any database
        // including but not limited to SQL Server, MySQL, PostgresSQL
        //

        private TradeSearchSQL myTradeSearch;

        // _initFromConfig - manages the state of the window.   All buttons
        // text boxes, labels etc that need to be set, are set from this
        // method.

        private void _initFromConfig()
        {
            // Start with the data from the configuration

            txtDataDirectory.Text = myConfiguration.DataDir;
            txtDataDirUpdate.Text = myConfiguration.DataDir;

            // These URL's will likely never change, so I do not provide
            // an easy way to change them.   They can be changed by editting
            // the persistant storage file
 
            txtSystemsURL.Text = myConfiguration.SystemsPopulatedURL;
            txtStationsURL.Text = myConfiguration.StationsURL;
            txtPricesURL.Text = myConfiguration.PricesURL;
            txtCommoditiesURL.Text = myConfiguration.CommoditiesURL;

            // Does the configured or chosen data directory exist or not,
            // if so we provide a way to create it.
            // All data is downloaded and the database will reside inside
            // this directory, please be certain you have plenty of data in
            // here.

            if (System.IO.Directory.Exists(myConfiguration.DataDir))
            {
                // This is the case where the directory already exists, we now
                // need to evaluate and set the state of all the buttons and text
                // boxes, and labels.

                lDataDirDoesNotExist.Visible = false;
                btnCreateDataDir.Visible = false;

                btnDownloadSystemsData.Enabled = true;
                btnDownloadStationsData.Enabled = true;
                btnDownloadPricesData.Enabled = true;
                btnDownloadAllData.Enabled = true;
                btnDownloadCommoditiesData.Enabled = true;

                btnCreateDatabase.Enabled = true;
                btnInsertCommodities.Enabled = true;
                btnInsertSystems.Enabled = true;
                btnInsertStations.Enabled = true;
                btnInsertPrices.Enabled = true;

                // If we have a copy of the file or not
                if (System.IO.File.Exists(myConfiguration.SystemsPopulatedFile))
                {
                    FileInfo fi = new FileInfo(myConfiguration.SystemsPopulatedFile);
                    // tell them the date it was downloaded
                    txtSystemsStatus.Text = fi.LastWriteTime.ToShortDateString();
                }
                else
                {
                    // tell them it is not downloaded
                    txtSystemsStatus.Text = "Not downloaded";
                }

                // same for the other data files
                if (System.IO.File.Exists(myConfiguration.StationsFile))
                {
                    FileInfo fi = new FileInfo(myConfiguration.StationsFile);
                    txtStationsStatus.Text = fi.LastWriteTime.ToShortDateString();

                }
                else
                {
                    txtStationsStatus.Text = "Not downloaded";
                }

                if (System.IO.File.Exists(myConfiguration.PricesFile))
                {
                    FileInfo fi = new FileInfo(myConfiguration.PricesFile);
                    txtPricesStatus.Text = fi.LastWriteTime.ToShortDateString();

                }
                else
                {
                    txtPricesStatus.Text = "Not downloaded";
                }

                if (System.IO.File.Exists(myConfiguration.CommoditiesFile))
                {
                    FileInfo fi = new FileInfo(myConfiguration.CommoditiesFile);
                    txtCommoditiesStatus.Text = fi.LastWriteTime.ToShortDateString();

                }
                else
                {
                    txtCommoditiesStatus.Text = "Not downloaded";
                }
            }
            else
            {
                // this is the case where the directory does not exist
                // shutdown everything till it is created

                lDataDirDoesNotExist.Visible = true;
                btnCreateDataDir.Visible = true;

                btnDownloadSystemsData.Enabled = false;
                btnDownloadStationsData.Enabled = false;
                btnDownloadPricesData.Enabled = false;
                btnDownloadAllData.Enabled = false;
                btnDownloadCommoditiesData.Enabled = false;

                btnCreateDatabase.Enabled = false;
                btnInsertCommodities.Enabled = false;
                btnInsertSystems.Enabled = false;
                btnInsertStations.Enabled = false;
                btnInsertPrices.Enabled = false;

                txtSystemsStatus.Text = "Not downloaded";
                txtStationsStatus.Text = "Not downloaded";
                txtPricesStatus.Text = "Not downloaded";
                txtCommoditiesStatus.Text = "Not downloaded";
            }

            txtDataBaseFile.Text = myConfiguration.DataBaseFile;
            if (File.Exists(myConfiguration.DataBaseFile))
            {
                lDataBaseFileExists.Text = "File Exists";
                btnCreateDatabase.Text = "Re-Create Database";

                myTradeSearch.connect();

                DateTime myDBTime = File.GetLastWriteTime(myConfiguration.DataBaseFile);

                if (File.Exists(myConfiguration.CommoditiesFile))
                {
                    DateTime myCommoditiesTime = File.GetLastWriteTime(myConfiguration.CommoditiesFile);
                    if (myCommoditiesTime > myDBTime || myTradeSearch.countCommodities () == 0)
                    {
                        txtInsertCommoditiesStatus.Text = "Needs to be inserted";
                        btnInsertCommodities.Text = "Insert Commodities";
                        btnInsertCommodities.Enabled = true;
                    }
                    else
                    {
                        txtInsertCommoditiesStatus.Text = "Already inserted";
                        btnInsertCommodities.Text = "Re-Insert Commodities";
                        btnInsertCommodities.Enabled = true;
                    }
                }
                else
                {
                    txtInsertCommoditiesStatus.Text = "Needs to be downloaded";
                    btnInsertCommodities.Text = "Insert Commodities";
                    btnInsertCommodities.Enabled = false;
                }

                if (File.Exists(myConfiguration.SystemsPopulatedFile))
                {
                    DateTime mySystemsTime = File.GetLastWriteTime(myConfiguration.SystemsPopulatedFile);
                    if (mySystemsTime > myDBTime || myTradeSearch.countSystems() == 0)
                    {
                        txtInsertSystemsStatus.Text = "Needs to be inserted";
                        btnInsertSystems.Text = "Insert Systems";
                        btnInsertSystems.Enabled = true;
                    }
                    else
                    {
                        txtInsertSystemsStatus.Text = "Already inserted";
                        btnInsertSystems.Text = "Re-Insert Systems";
                        btnInsertSystems.Enabled = true;
                    }
                }
                else
                {
                    txtInsertSystemsStatus.Text = "Needs to be downloaded";
                    btnInsertSystems.Text = "Insert Systems";
                    btnInsertSystems.Enabled = false;
                }

                if (File.Exists(myConfiguration.StationsFile))
                {
                    DateTime myStationsTime = File.GetLastWriteTime(myConfiguration.StationsFile);
                    if (myStationsTime > myDBTime || myTradeSearch.countStations() == 0)
                    {
                        txtInsertStationsStatus.Text = "Needs to be inserted";
                        btnInsertStations.Text = "Insert Stations";
                        btnInsertStations.Enabled = true;
                    }
                    else
                    {
                        txtInsertStationsStatus.Text = "Already inserted";
                        btnInsertStations.Text = "Re-Insert Stations";
                        btnInsertStations.Enabled = true;
                    }
                }
                else
                {
                    txtInsertStationsStatus.Text = "Needs to be downloaded";
                    btnInsertStations.Text = "Insert Stations";
                    btnInsertStations.Enabled = false;
                }

                if (File.Exists(myConfiguration.PricesFile))
                {
                    DateTime myPricesTime = File.GetLastWriteTime(myConfiguration.PricesFile);
                    if (myPricesTime > myDBTime || myTradeSearch.countPrices() == 0)
                    {
                        txtInsertPricesStatus.Text = "Needs to be inserted";
                        btnInsertPrices.Text = "Insert Prices";
                        btnInsertPrices.Enabled = true;
                    }
                    else
                    {
                        txtInsertPricesStatus.Text = "Already inserted";
                        btnInsertPrices.Text = "Re-Insert Prices";
                        btnInsertPrices.Enabled = true;
                    }
                }
                else
                {
                    txtInsertPricesStatus.Text = "Needs to be downloaded";
                    btnInsertPrices.Text = "Insert Stations";
                    btnInsertPrices.Enabled = false;
                }
            }
            else
            {
                lDataBaseFileExists.Text = "File Does Not Exist";
                btnCreateDatabase.Text = "Create Database";

                txtInsertCommoditiesStatus.Text = "Not Inserted";
                btnInsertCommodities.Text = "Insert Commodities";
                btnInsertCommodities.Enabled = false;

                txtInsertPricesStatus.Text = "Not Inserted";
                btnInsertPrices.Text = "Insert Prices";
                btnInsertPrices.Enabled = false;

                txtInsertStationsStatus.Text = "Not Inserted";
                btnInsertStations.Text = "Insert Stations";
                btnInsertStations.Enabled = false;

                txtInsertSystemsStatus.Text = "Not Inserted";
                btnInsertSystems.Text = "Insert Systems";
                btnInsertSystems.Enabled = false;
            }

            // I force an update as some of the places where this is called
            // does not get back to the windows message loop in a timely
            // fashion.

            this.Update();

            // If things are changed close the SQL DB, and be ready for another
            // run.

            myTradeSearch.closeConnection();
        }

        public MainForm()
        {
            InitializeComponent();
            // myConfig is a Singleton, so it can be referenced from anywhere
            myConfiguration = PersistantConfiguration.Instance;
            myTradeSearch = new TradeSearchSQL ();
            _initFromConfig();
        }

        // Here are all the actions when the various buttons are pressed.

        private void btnDataDirBrowse_Click(object sender, EventArgs e)
        {
            // put up a directory browser, so they can pick a directory where to
            // store all this data.

            FolderBrowserDialog myFolderBrowser = new FolderBrowserDialog
            {
                Description = "Choose a Folder that will contain data downloads.",
                SelectedPath = myConfiguration.DataDir
            };

            if (myFolderBrowser.ShowDialog () == System.Windows.Forms.DialogResult.OK)
            {
                myConfiguration.DataDir = myFolderBrowser.SelectedPath;
                _initFromConfig();
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            // Message loop based applications, use this method to quit.
            System.Windows.Forms.Application.Exit();
        }

        private void btnResetConfig_Click(object sender, EventArgs e)
        {
            myConfiguration.ResetConfig();
            _initFromConfig();
        }

        private void btnCreateDataDir_Click(object sender, EventArgs e)
        {
            System.IO.Directory.CreateDirectory(myConfiguration.DataDir);
            _initFromConfig();
        }

        // I separated out the actual file download code, so that it can be called
        // individually from single buttons, or as a group from the download all
        // button.

        private void _downloadSystemsData ()
        {
            lblWorking.Text = "Downloading Systems Data, please wait ...";
            this.Update(); // forces the message loop to update the screen

            // this is downloaded synchronously, later I could use a background
            // thread, but that was overkill for this app.

            // Found this pattern to download a file from a website and store
            // it as in a local file.

            using (var client = new WebClient())
            {
                client.DownloadFile(
                    myConfiguration.SystemsPopulatedURL,
                    myConfiguration.SystemsPopulatedFile);
            }

            lblWorking.Text = "";
            _initFromConfig();
        }

        private void _downloadStationsData()
        {
            lblWorking.Text = "Downloading Stations Data, please wait ...";
            this.Update();

            using (var client = new WebClient())
            {
                client.DownloadFile(
                    myConfiguration.StationsURL,
                    myConfiguration.StationsFile);
            }

            lblWorking.Text = "";
            _initFromConfig();
        }

        private void _downloadPricesData()
        {
            lblWorking.Text = "Downloading Prices Data, please wait ...";
            this.Update();

            using (var client = new WebClient())
            {
                client.DownloadFile(
                    myConfiguration.PricesURL,
                    myConfiguration.PricesFile);
            }

            lblWorking.Text = "";
            _initFromConfig();
        }

        private void _downloadCommoditiesData()
        {
            lblWorking.Text = "Downloading Commodities Data, please wait ...";
            this.Update();

            using (var client = new WebClient())
            {
                client.DownloadFile(
                    myConfiguration.CommoditiesURL,
                    myConfiguration.CommoditiesFile);
            }

            lblWorking.Text = "";
            _initFromConfig();
        }

        private void btnDownloadSystemsData_Click(object sender, EventArgs e)
        {
            _downloadSystemsData();
        }

        private void btnDownloadStationsData_Click(object sender, EventArgs e)
        {
            _downloadStationsData();
        }

        private void btnDownloadPricesData_Click(object sender, EventArgs e)
        {
            _downloadPricesData();
        }

        private void btnDownloadAllData_Click(object sender, EventArgs e)
        {
            _downloadCommoditiesData();
            _downloadSystemsData();
            _downloadStationsData();
            _downloadPricesData();
        }

        private void btnDownloadCommoditiesData_Click(object sender, EventArgs e)
        {
            _downloadCommoditiesData();
        }

        private void btnCreateDatabase_Click(object sender, EventArgs e)
        {
            myTradeSearch.CreateDatabase();
            _initFromConfig();
        }

        private void btnInsertCommodities_Click(object sender, EventArgs e)
        {
            myTradeSearch.insertCommodities();
            _initFromConfig();
        }

        private void btnInsertSystems_Click(object sender, EventArgs e)
        {
            myTradeSearch.insertSystems();
            _initFromConfig();
        }

        private void btnInsertStations_Click(object sender, EventArgs e)
        {
            myTradeSearch.insertStations();
            _initFromConfig();
        }

        private void btnInsertPrices_Click(object sender, EventArgs e)
        {
            myTradeSearch.insertPrices();
            _initFromConfig();
        }
    }
}
