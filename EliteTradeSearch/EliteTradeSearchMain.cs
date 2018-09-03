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
        private PersistantConfiguration myConfiguration;
        private TradeSearchSQL myTradeSearch;

        private void _initFromConfig()
        {
            txtDataDirectory.Text = myConfiguration.DataDir;
            txtDataDirUpdate.Text = myConfiguration.DataDir;
            txtSystemsURL.Text = myConfiguration.SystemsPopulatedURL;
            txtStationsURL.Text = myConfiguration.StationsURL;
            txtPricesURL.Text = myConfiguration.PricesURL;
            txtCommoditiesURL.Text = myConfiguration.CommoditiesURL;

            if (System.IO.Directory.Exists(myConfiguration.DataDir))
            {
                lDataDirDoesNotExist.Visible = false;
                btnCreateDataDir.Visible = false;

                btnDownloadSystemsData.Enabled = true;
                btnDownloadStationsData.Enabled = true;
                btnDownloadPricesData.Enabled = true;
                btnDownloadAllData.Enabled = true;

                if (System.IO.File.Exists(myConfiguration.SystemsPopulatedFile))
                {
                    FileInfo fi = new FileInfo(myConfiguration.SystemsPopulatedFile);
                    txtSystemsStatus.Text = fi.LastWriteTime.ToShortDateString();
                }
                else
                {
                    txtSystemsStatus.Text = "Not downloaded";
                }

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
                lDataDirDoesNotExist.Visible = true;
                btnCreateDataDir.Visible = true;

                btnDownloadSystemsData.Enabled = false;
                btnDownloadStationsData.Enabled = false;
                btnDownloadPricesData.Enabled = false;
                btnDownloadAllData.Enabled = false;

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

            this.Update();

            myTradeSearch.closeConnection();
        }

        public MainForm()
        {
            InitializeComponent();
            myConfiguration = PersistantConfiguration.Instance;
            myTradeSearch = new TradeSearchSQL ();
            _initFromConfig();
        }

        private void btnDataDirBrowse_Click(object sender, EventArgs e)
        {
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

        private void _downloadSystemsData ()
        {
            lblWorking.Text = "Downloading Systems Data, please wait ...";
            this.Update();

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
