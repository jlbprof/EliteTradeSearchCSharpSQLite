using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EliteTradeSearch
{
    public partial class MainForm : Form
    {
        private PersistantConfiguration myConfiguration;

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
            }
            else
            {
                lDataBaseFileExists.Text = "File Does Not Exist";
                btnCreateDatabase.Text = "Create Database";
            }

            this.Update();
        }

        public MainForm()
        {
            InitializeComponent();
            myConfiguration = new PersistantConfiguration();
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
    }
}
