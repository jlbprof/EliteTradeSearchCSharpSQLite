using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteTradeSearch
{
    public sealed class PersistantConfiguration
    {
        private static PersistantConfiguration instance = null;
        private static readonly object padlock = new object();

        public static PersistantConfiguration Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                        instance = new PersistantConfiguration();

                    return instance;
                }
            }
        }

        private String sDataDir;
        private String sSystemsPopulatedURL;
        private String sStationsURL;
        private String sPricesURL;
        private String sCommoditiesURL;

        public String SystemsPopulatedURL
        {
            get { return sSystemsPopulatedURL; }
        }

        public String StationsURL
        {
            get { return sStationsURL; }
        }

        public String PricesURL
        {
            get { return sPricesURL; }
        }

        public String CommoditiesURL
        {
            get { return sCommoditiesURL; }
        }

        public String SystemsPopulatedFile
        {
            get { return sDataDir + "\\systems_popluated.jsonl"; }
        }

        public String StationsFile
        {
            get { return sDataDir + "\\stations.jsonl"; }
        }

        public String PricesFile
        {
            get { return sDataDir + "\\prices.csv"; }
        }

        public String DataBaseFile
        {
            get { return sDataDir + "\\tradesearch.db"; }
        }

        public String CommoditiesFile
        {
            get { return sDataDir + "\\commodities.json"; }
        }

        public String DataDir
        {
            get { return sDataDir; }
            set {
                sDataDir = value;
                Properties.Settings.Default.DataDir = value;
                Properties.Settings.Default.Save();
            }
        }

        private void _InitConfiguration ()
        {
            String myDataDir = Properties.Settings.Default.DataDir;
            if (myDataDir == "_NOTSET_")
            {
                myDataDir = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\EliteTradeSearch";
                Properties.Settings.Default.DataDir = myDataDir;
                Properties.Settings.Default.Save();
            }
            this.sDataDir = myDataDir;

            this.sSystemsPopulatedURL = Properties.Settings.Default.SystemsPopulatedURL;
            this.sStationsURL = Properties.Settings.Default.StationsURL;
            this.sPricesURL = Properties.Settings.Default.PricesURL;
            this.sCommoditiesURL = Properties.Settings.Default.CommoditiesURL;
        }

        private PersistantConfiguration()
        {
            _InitConfiguration();
        }

        public void ResetConfig ()
        {
            DataDir = "_NOTSET_";
            _InitConfiguration();
        }
    }
}