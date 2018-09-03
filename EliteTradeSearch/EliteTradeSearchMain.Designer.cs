namespace EliteTradeSearch
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.FeatureAccess = new System.Windows.Forms.TabControl();
            this.configPage = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCommoditiesURL = new System.Windows.Forms.TextBox();
            this.lCommoditiesURL = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPricesURL = new System.Windows.Forms.TextBox();
            this.lPricesURL = new System.Windows.Forms.Label();
            this.txtStationsURL = new System.Windows.Forms.TextBox();
            this.lStationsURL = new System.Windows.Forms.Label();
            this.txtSystemsURL = new System.Windows.Forms.TextBox();
            this.lSystemsURL = new System.Windows.Forms.Label();
            this.lWarningDataSize = new System.Windows.Forms.Label();
            this.btnDataDirBrowse = new System.Windows.Forms.Button();
            this.txtDataDirectory = new System.Windows.Forms.TextBox();
            this.lDataDirectory = new System.Windows.Forms.Label();
            this.UpdateData = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.btnDownloadCommoditiesData = new System.Windows.Forms.Button();
            this.txtCommoditiesStatus = new System.Windows.Forms.TextBox();
            this.lDataOnCommodities = new System.Windows.Forms.Label();
            this.lblWorking = new System.Windows.Forms.Label();
            this.btnDownloadAllData = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btnDownloadPricesData = new System.Windows.Forms.Button();
            this.txtPricesStatus = new System.Windows.Forms.TextBox();
            this.lDataOnPrices = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnDownloadStationsData = new System.Windows.Forms.Button();
            this.txtStationsStatus = new System.Windows.Forms.TextBox();
            this.lDataOnStations = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDownloadSystemsData = new System.Windows.Forms.Button();
            this.txtSystemsStatus = new System.Windows.Forms.TextBox();
            this.lDataOnSystems = new System.Windows.Forms.Label();
            this.lHorizontalLine001 = new System.Windows.Forms.Label();
            this.btnCreateDataDir = new System.Windows.Forms.Button();
            this.lDataDirDoesNotExist = new System.Windows.Forms.Label();
            this.txtDataDirUpdate = new System.Windows.Forms.TextBox();
            this.lDataDirUpdate = new System.Windows.Forms.Label();
            this.lWarningDataNeedsDownload = new System.Windows.Forms.Label();
            this.InsertData = new System.Windows.Forms.TabPage();
            this.btnInsertPrices = new System.Windows.Forms.Button();
            this.txtInsertPricesStatus = new System.Windows.Forms.TextBox();
            this.lInsertPrices = new System.Windows.Forms.Label();
            this.btnInsertStations = new System.Windows.Forms.Button();
            this.txtInsertStationsStatus = new System.Windows.Forms.TextBox();
            this.lInsertStations = new System.Windows.Forms.Label();
            this.btnInsertSystems = new System.Windows.Forms.Button();
            this.txtInsertSystemsStatus = new System.Windows.Forms.TextBox();
            this.lInsertSystems = new System.Windows.Forms.Label();
            this.btnInsertCommodities = new System.Windows.Forms.Button();
            this.txtInsertCommoditiesStatus = new System.Windows.Forms.TextBox();
            this.lInsertCommodities = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnCreateDatabase = new System.Windows.Forms.Button();
            this.lDataBaseFileExists = new System.Windows.Forms.Label();
            this.txtDataBaseFile = new System.Windows.Forms.TextBox();
            this.lDataBaseFile = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnResetConfig = new System.Windows.Forms.Button();
            this.lWorking = new System.Windows.Forms.Label();
            this.FeatureAccess.SuspendLayout();
            this.configPage.SuspendLayout();
            this.UpdateData.SuspendLayout();
            this.InsertData.SuspendLayout();
            this.SuspendLayout();
            // 
            // FeatureAccess
            // 
            this.FeatureAccess.Controls.Add(this.configPage);
            this.FeatureAccess.Controls.Add(this.UpdateData);
            this.FeatureAccess.Controls.Add(this.InsertData);
            this.FeatureAccess.Location = new System.Drawing.Point(12, 66);
            this.FeatureAccess.Name = "FeatureAccess";
            this.FeatureAccess.SelectedIndex = 0;
            this.FeatureAccess.Size = new System.Drawing.Size(776, 442);
            this.FeatureAccess.TabIndex = 0;
            // 
            // configPage
            // 
            this.configPage.Controls.Add(this.label8);
            this.configPage.Controls.Add(this.txtCommoditiesURL);
            this.configPage.Controls.Add(this.lCommoditiesURL);
            this.configPage.Controls.Add(this.label4);
            this.configPage.Controls.Add(this.label3);
            this.configPage.Controls.Add(this.label2);
            this.configPage.Controls.Add(this.txtPricesURL);
            this.configPage.Controls.Add(this.lPricesURL);
            this.configPage.Controls.Add(this.txtStationsURL);
            this.configPage.Controls.Add(this.lStationsURL);
            this.configPage.Controls.Add(this.txtSystemsURL);
            this.configPage.Controls.Add(this.lSystemsURL);
            this.configPage.Controls.Add(this.lWarningDataSize);
            this.configPage.Controls.Add(this.btnDataDirBrowse);
            this.configPage.Controls.Add(this.txtDataDirectory);
            this.configPage.Controls.Add(this.lDataDirectory);
            this.configPage.Location = new System.Drawing.Point(4, 22);
            this.configPage.Name = "configPage";
            this.configPage.Padding = new System.Windows.Forms.Padding(3);
            this.configPage.Size = new System.Drawing.Size(768, 416);
            this.configPage.TabIndex = 0;
            this.configPage.Text = "Configuration";
            this.configPage.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(114, 128);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(302, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Commodies URL is the list of all commodities sold in the galaxy.";
            // 
            // txtCommoditiesURL
            // 
            this.txtCommoditiesURL.Location = new System.Drawing.Point(117, 91);
            this.txtCommoditiesURL.Name = "txtCommoditiesURL";
            this.txtCommoditiesURL.ReadOnly = true;
            this.txtCommoditiesURL.Size = new System.Drawing.Size(542, 20);
            this.txtCommoditiesURL.TabIndex = 14;
            // 
            // lCommoditiesURL
            // 
            this.lCommoditiesURL.AutoSize = true;
            this.lCommoditiesURL.Location = new System.Drawing.Point(17, 94);
            this.lCommoditiesURL.Name = "lCommoditiesURL";
            this.lCommoditiesURL.Size = new System.Drawing.Size(94, 13);
            this.lCommoditiesURL.TabIndex = 13;
            this.lCommoditiesURL.Text = "Commodities URL:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(114, 330);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(347, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Prices URL is where the data on all the current prices for commodities is.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(114, 258);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(290, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Stations URL is where the data on all the stations is located.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(114, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(342, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Systems URL is where the data on all the populated systems is located.";
            // 
            // txtPricesURL
            // 
            this.txtPricesURL.Location = new System.Drawing.Point(117, 289);
            this.txtPricesURL.Name = "txtPricesURL";
            this.txtPricesURL.ReadOnly = true;
            this.txtPricesURL.Size = new System.Drawing.Size(542, 20);
            this.txtPricesURL.TabIndex = 9;
            // 
            // lPricesURL
            // 
            this.lPricesURL.AutoSize = true;
            this.lPricesURL.Location = new System.Drawing.Point(17, 292);
            this.lPricesURL.Name = "lPricesURL";
            this.lPricesURL.Size = new System.Drawing.Size(64, 13);
            this.lPricesURL.TabIndex = 8;
            this.lPricesURL.Text = "Prices URL:";
            // 
            // txtStationsURL
            // 
            this.txtStationsURL.Location = new System.Drawing.Point(117, 220);
            this.txtStationsURL.Name = "txtStationsURL";
            this.txtStationsURL.ReadOnly = true;
            this.txtStationsURL.Size = new System.Drawing.Size(542, 20);
            this.txtStationsURL.TabIndex = 7;
            // 
            // lStationsURL
            // 
            this.lStationsURL.AutoSize = true;
            this.lStationsURL.Location = new System.Drawing.Point(17, 223);
            this.lStationsURL.Name = "lStationsURL";
            this.lStationsURL.Size = new System.Drawing.Size(73, 13);
            this.lStationsURL.TabIndex = 6;
            this.lStationsURL.Text = "Stations URL:";
            // 
            // txtSystemsURL
            // 
            this.txtSystemsURL.Location = new System.Drawing.Point(117, 159);
            this.txtSystemsURL.Name = "txtSystemsURL";
            this.txtSystemsURL.ReadOnly = true;
            this.txtSystemsURL.Size = new System.Drawing.Size(542, 20);
            this.txtSystemsURL.TabIndex = 5;
            // 
            // lSystemsURL
            // 
            this.lSystemsURL.AutoSize = true;
            this.lSystemsURL.Location = new System.Drawing.Point(17, 162);
            this.lSystemsURL.Name = "lSystemsURL";
            this.lSystemsURL.Size = new System.Drawing.Size(74, 13);
            this.lSystemsURL.TabIndex = 4;
            this.lSystemsURL.Text = "Systems URL:";
            // 
            // lWarningDataSize
            // 
            this.lWarningDataSize.AutoSize = true;
            this.lWarningDataSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lWarningDataSize.Location = new System.Drawing.Point(84, 20);
            this.lWarningDataSize.Name = "lWarningDataSize";
            this.lWarningDataSize.Size = new System.Drawing.Size(465, 16);
            this.lWarningDataSize.TabIndex = 3;
            this.lWarningDataSize.Text = "Warning:  This data directory will have to contain upwards of 50 Gb";
            // 
            // btnDataDirBrowse
            // 
            this.btnDataDirBrowse.Location = new System.Drawing.Point(665, 48);
            this.btnDataDirBrowse.Name = "btnDataDirBrowse";
            this.btnDataDirBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnDataDirBrowse.TabIndex = 2;
            this.btnDataDirBrowse.Text = "Browse";
            this.btnDataDirBrowse.UseVisualStyleBackColor = true;
            this.btnDataDirBrowse.Click += new System.EventHandler(this.btnDataDirBrowse_Click);
            // 
            // txtDataDirectory
            // 
            this.txtDataDirectory.Location = new System.Drawing.Point(117, 51);
            this.txtDataDirectory.Name = "txtDataDirectory";
            this.txtDataDirectory.ReadOnly = true;
            this.txtDataDirectory.Size = new System.Drawing.Size(542, 20);
            this.txtDataDirectory.TabIndex = 1;
            // 
            // lDataDirectory
            // 
            this.lDataDirectory.AutoSize = true;
            this.lDataDirectory.Location = new System.Drawing.Point(17, 58);
            this.lDataDirectory.Name = "lDataDirectory";
            this.lDataDirectory.Size = new System.Drawing.Size(78, 13);
            this.lDataDirectory.TabIndex = 0;
            this.lDataDirectory.Text = "Data Directory:";
            // 
            // UpdateData
            // 
            this.UpdateData.Controls.Add(this.label9);
            this.UpdateData.Controls.Add(this.btnDownloadCommoditiesData);
            this.UpdateData.Controls.Add(this.txtCommoditiesStatus);
            this.UpdateData.Controls.Add(this.lDataOnCommodities);
            this.UpdateData.Controls.Add(this.lblWorking);
            this.UpdateData.Controls.Add(this.btnDownloadAllData);
            this.UpdateData.Controls.Add(this.label7);
            this.UpdateData.Controls.Add(this.btnDownloadPricesData);
            this.UpdateData.Controls.Add(this.txtPricesStatus);
            this.UpdateData.Controls.Add(this.lDataOnPrices);
            this.UpdateData.Controls.Add(this.label6);
            this.UpdateData.Controls.Add(this.btnDownloadStationsData);
            this.UpdateData.Controls.Add(this.txtStationsStatus);
            this.UpdateData.Controls.Add(this.lDataOnStations);
            this.UpdateData.Controls.Add(this.label5);
            this.UpdateData.Controls.Add(this.btnDownloadSystemsData);
            this.UpdateData.Controls.Add(this.txtSystemsStatus);
            this.UpdateData.Controls.Add(this.lDataOnSystems);
            this.UpdateData.Controls.Add(this.lHorizontalLine001);
            this.UpdateData.Controls.Add(this.btnCreateDataDir);
            this.UpdateData.Controls.Add(this.lDataDirDoesNotExist);
            this.UpdateData.Controls.Add(this.txtDataDirUpdate);
            this.UpdateData.Controls.Add(this.lDataDirUpdate);
            this.UpdateData.Controls.Add(this.lWarningDataNeedsDownload);
            this.UpdateData.Location = new System.Drawing.Point(4, 22);
            this.UpdateData.Name = "UpdateData";
            this.UpdateData.Padding = new System.Windows.Forms.Padding(3);
            this.UpdateData.Size = new System.Drawing.Size(768, 416);
            this.UpdateData.TabIndex = 1;
            this.UpdateData.Text = "Download Data";
            this.UpdateData.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(490, 127);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "Download this once.";
            // 
            // btnDownloadCommoditiesData
            // 
            this.btnDownloadCommoditiesData.Location = new System.Drawing.Point(264, 122);
            this.btnDownloadCommoditiesData.Name = "btnDownloadCommoditiesData";
            this.btnDownloadCommoditiesData.Size = new System.Drawing.Size(220, 23);
            this.btnDownloadCommoditiesData.TabIndex = 26;
            this.btnDownloadCommoditiesData.Text = "Download Commodities Data";
            this.btnDownloadCommoditiesData.UseVisualStyleBackColor = true;
            this.btnDownloadCommoditiesData.Click += new System.EventHandler(this.btnDownloadCommoditiesData_Click);
            // 
            // txtCommoditiesStatus
            // 
            this.txtCommoditiesStatus.Location = new System.Drawing.Point(112, 124);
            this.txtCommoditiesStatus.Name = "txtCommoditiesStatus";
            this.txtCommoditiesStatus.ReadOnly = true;
            this.txtCommoditiesStatus.Size = new System.Drawing.Size(146, 20);
            this.txtCommoditiesStatus.TabIndex = 25;
            // 
            // lDataOnCommodities
            // 
            this.lDataOnCommodities.AutoSize = true;
            this.lDataOnCommodities.Location = new System.Drawing.Point(5, 127);
            this.lDataOnCommodities.Name = "lDataOnCommodities";
            this.lDataOnCommodities.Size = new System.Drawing.Size(110, 13);
            this.lDataOnCommodities.TabIndex = 24;
            this.lDataOnCommodities.Text = "Data on Commodities:";
            // 
            // lblWorking
            // 
            this.lblWorking.AutoSize = true;
            this.lblWorking.BackColor = System.Drawing.Color.Red;
            this.lblWorking.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWorking.ForeColor = System.Drawing.SystemColors.Control;
            this.lblWorking.Location = new System.Drawing.Point(15, 354);
            this.lblWorking.Name = "lblWorking";
            this.lblWorking.Size = new System.Drawing.Size(0, 20);
            this.lblWorking.TabIndex = 23;
            // 
            // btnDownloadAllData
            // 
            this.btnDownloadAllData.Location = new System.Drawing.Point(264, 268);
            this.btnDownloadAllData.Name = "btnDownloadAllData";
            this.btnDownloadAllData.Size = new System.Drawing.Size(220, 23);
            this.btnDownloadAllData.TabIndex = 22;
            this.btnDownloadAllData.Text = "Download All Data";
            this.btnDownloadAllData.UseVisualStyleBackColor = true;
            this.btnDownloadAllData.Click += new System.EventHandler(this.btnDownloadAllData_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(490, 235);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Download every day.";
            // 
            // btnDownloadPricesData
            // 
            this.btnDownloadPricesData.Location = new System.Drawing.Point(264, 230);
            this.btnDownloadPricesData.Name = "btnDownloadPricesData";
            this.btnDownloadPricesData.Size = new System.Drawing.Size(220, 23);
            this.btnDownloadPricesData.TabIndex = 20;
            this.btnDownloadPricesData.Text = "Download Prices Data";
            this.btnDownloadPricesData.UseVisualStyleBackColor = true;
            this.btnDownloadPricesData.Click += new System.EventHandler(this.btnDownloadPricesData_Click);
            // 
            // txtPricesStatus
            // 
            this.txtPricesStatus.Location = new System.Drawing.Point(112, 232);
            this.txtPricesStatus.Name = "txtPricesStatus";
            this.txtPricesStatus.ReadOnly = true;
            this.txtPricesStatus.Size = new System.Drawing.Size(146, 20);
            this.txtPricesStatus.TabIndex = 19;
            // 
            // lDataOnPrices
            // 
            this.lDataOnPrices.AutoSize = true;
            this.lDataOnPrices.Location = new System.Drawing.Point(5, 235);
            this.lDataOnPrices.Name = "lDataOnPrices";
            this.lDataOnPrices.Size = new System.Drawing.Size(80, 13);
            this.lDataOnPrices.TabIndex = 18;
            this.lDataOnPrices.Text = "Data on Prices:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(490, 198);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(262, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Download this more frequently than the Systems Data.";
            // 
            // btnDownloadStationsData
            // 
            this.btnDownloadStationsData.Location = new System.Drawing.Point(264, 193);
            this.btnDownloadStationsData.Name = "btnDownloadStationsData";
            this.btnDownloadStationsData.Size = new System.Drawing.Size(220, 23);
            this.btnDownloadStationsData.TabIndex = 16;
            this.btnDownloadStationsData.Text = "Download Stations Data";
            this.btnDownloadStationsData.UseVisualStyleBackColor = true;
            this.btnDownloadStationsData.Click += new System.EventHandler(this.btnDownloadStationsData_Click);
            // 
            // txtStationsStatus
            // 
            this.txtStationsStatus.Location = new System.Drawing.Point(112, 195);
            this.txtStationsStatus.Name = "txtStationsStatus";
            this.txtStationsStatus.ReadOnly = true;
            this.txtStationsStatus.Size = new System.Drawing.Size(146, 20);
            this.txtStationsStatus.TabIndex = 15;
            // 
            // lDataOnStations
            // 
            this.lDataOnStations.AutoSize = true;
            this.lDataOnStations.Location = new System.Drawing.Point(5, 198);
            this.lDataOnStations.Name = "lDataOnStations";
            this.lDataOnStations.Size = new System.Drawing.Size(89, 13);
            this.lDataOnStations.TabIndex = 14;
            this.lDataOnStations.Text = "Data on Stations:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(490, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(271, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Download this once in awhile, it does not change much.";
            // 
            // btnDownloadSystemsData
            // 
            this.btnDownloadSystemsData.Location = new System.Drawing.Point(264, 156);
            this.btnDownloadSystemsData.Name = "btnDownloadSystemsData";
            this.btnDownloadSystemsData.Size = new System.Drawing.Size(220, 23);
            this.btnDownloadSystemsData.TabIndex = 12;
            this.btnDownloadSystemsData.Text = "Download Systems Data";
            this.btnDownloadSystemsData.UseVisualStyleBackColor = true;
            this.btnDownloadSystemsData.Click += new System.EventHandler(this.btnDownloadSystemsData_Click);
            // 
            // txtSystemsStatus
            // 
            this.txtSystemsStatus.Location = new System.Drawing.Point(112, 158);
            this.txtSystemsStatus.Name = "txtSystemsStatus";
            this.txtSystemsStatus.ReadOnly = true;
            this.txtSystemsStatus.Size = new System.Drawing.Size(146, 20);
            this.txtSystemsStatus.TabIndex = 11;
            // 
            // lDataOnSystems
            // 
            this.lDataOnSystems.AutoSize = true;
            this.lDataOnSystems.Location = new System.Drawing.Point(5, 161);
            this.lDataOnSystems.Name = "lDataOnSystems";
            this.lDataOnSystems.Size = new System.Drawing.Size(90, 13);
            this.lDataOnSystems.TabIndex = 10;
            this.lDataOnSystems.Text = "Data on Systems:";
            // 
            // lHorizontalLine001
            // 
            this.lHorizontalLine001.AutoSize = true;
            this.lHorizontalLine001.Location = new System.Drawing.Point(16, 103);
            this.lHorizontalLine001.Name = "lHorizontalLine001";
            this.lHorizontalLine001.Size = new System.Drawing.Size(727, 13);
            this.lHorizontalLine001.TabIndex = 9;
            this.lHorizontalLine001.Text = "_________________________________________________________________________________" +
    "_______________________________________";
            // 
            // btnCreateDataDir
            // 
            this.btnCreateDataDir.Location = new System.Drawing.Point(264, 77);
            this.btnCreateDataDir.Name = "btnCreateDataDir";
            this.btnCreateDataDir.Size = new System.Drawing.Size(220, 23);
            this.btnCreateDataDir.TabIndex = 8;
            this.btnCreateDataDir.Text = "Create Data Directory";
            this.btnCreateDataDir.UseVisualStyleBackColor = true;
            this.btnCreateDataDir.Click += new System.EventHandler(this.btnCreateDataDir_Click);
            // 
            // lDataDirDoesNotExist
            // 
            this.lDataDirDoesNotExist.AutoSize = true;
            this.lDataDirDoesNotExist.BackColor = System.Drawing.Color.Red;
            this.lDataDirDoesNotExist.ForeColor = System.Drawing.SystemColors.Control;
            this.lDataDirDoesNotExist.Location = new System.Drawing.Point(83, 82);
            this.lDataDirDoesNotExist.Name = "lDataDirDoesNotExist";
            this.lDataDirDoesNotExist.Size = new System.Drawing.Size(151, 13);
            this.lDataDirDoesNotExist.TabIndex = 7;
            this.lDataDirDoesNotExist.Text = "Data Directory Does Not Exist!";
            // 
            // txtDataDirUpdate
            // 
            this.txtDataDirUpdate.Location = new System.Drawing.Point(86, 42);
            this.txtDataDirUpdate.Name = "txtDataDirUpdate";
            this.txtDataDirUpdate.ReadOnly = true;
            this.txtDataDirUpdate.Size = new System.Drawing.Size(542, 20);
            this.txtDataDirUpdate.TabIndex = 6;
            // 
            // lDataDirUpdate
            // 
            this.lDataDirUpdate.AutoSize = true;
            this.lDataDirUpdate.Location = new System.Drawing.Point(5, 45);
            this.lDataDirUpdate.Name = "lDataDirUpdate";
            this.lDataDirUpdate.Size = new System.Drawing.Size(75, 13);
            this.lDataDirUpdate.TabIndex = 5;
            this.lDataDirUpdate.Text = "Data Directory";
            // 
            // lWarningDataNeedsDownload
            // 
            this.lWarningDataNeedsDownload.AutoSize = true;
            this.lWarningDataNeedsDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lWarningDataNeedsDownload.Location = new System.Drawing.Point(16, 14);
            this.lWarningDataNeedsDownload.Name = "lWarningDataNeedsDownload";
            this.lWarningDataNeedsDownload.Size = new System.Drawing.Size(515, 16);
            this.lWarningDataNeedsDownload.TabIndex = 4;
            this.lWarningDataNeedsDownload.Text = "Warning:  You need to manually download the data to refresh the data set.";
            // 
            // InsertData
            // 
            this.InsertData.Controls.Add(this.btnInsertPrices);
            this.InsertData.Controls.Add(this.txtInsertPricesStatus);
            this.InsertData.Controls.Add(this.lInsertPrices);
            this.InsertData.Controls.Add(this.btnInsertStations);
            this.InsertData.Controls.Add(this.txtInsertStationsStatus);
            this.InsertData.Controls.Add(this.lInsertStations);
            this.InsertData.Controls.Add(this.btnInsertSystems);
            this.InsertData.Controls.Add(this.txtInsertSystemsStatus);
            this.InsertData.Controls.Add(this.lInsertSystems);
            this.InsertData.Controls.Add(this.btnInsertCommodities);
            this.InsertData.Controls.Add(this.txtInsertCommoditiesStatus);
            this.InsertData.Controls.Add(this.lInsertCommodities);
            this.InsertData.Controls.Add(this.label10);
            this.InsertData.Controls.Add(this.btnCreateDatabase);
            this.InsertData.Controls.Add(this.lDataBaseFileExists);
            this.InsertData.Controls.Add(this.txtDataBaseFile);
            this.InsertData.Controls.Add(this.lDataBaseFile);
            this.InsertData.Location = new System.Drawing.Point(4, 22);
            this.InsertData.Name = "InsertData";
            this.InsertData.Size = new System.Drawing.Size(768, 416);
            this.InsertData.TabIndex = 2;
            this.InsertData.Text = "Insert Data";
            this.InsertData.UseVisualStyleBackColor = true;
            // 
            // btnInsertPrices
            // 
            this.btnInsertPrices.Location = new System.Drawing.Point(317, 211);
            this.btnInsertPrices.Name = "btnInsertPrices";
            this.btnInsertPrices.Size = new System.Drawing.Size(180, 23);
            this.btnInsertPrices.TabIndex = 22;
            this.btnInsertPrices.Text = "Re-Insert Prices";
            this.btnInsertPrices.UseVisualStyleBackColor = true;
            this.btnInsertPrices.Click += new System.EventHandler(this.btnInsertPrices_Click);
            // 
            // txtInsertPricesStatus
            // 
            this.txtInsertPricesStatus.Location = new System.Drawing.Point(94, 214);
            this.txtInsertPricesStatus.Name = "txtInsertPricesStatus";
            this.txtInsertPricesStatus.ReadOnly = true;
            this.txtInsertPricesStatus.Size = new System.Drawing.Size(204, 20);
            this.txtInsertPricesStatus.TabIndex = 21;
            // 
            // lInsertPrices
            // 
            this.lInsertPrices.AutoSize = true;
            this.lInsertPrices.Location = new System.Drawing.Point(19, 217);
            this.lInsertPrices.Name = "lInsertPrices";
            this.lInsertPrices.Size = new System.Drawing.Size(34, 13);
            this.lInsertPrices.TabIndex = 20;
            this.lInsertPrices.Text = "Price:";
            // 
            // btnInsertStations
            // 
            this.btnInsertStations.Location = new System.Drawing.Point(317, 166);
            this.btnInsertStations.Name = "btnInsertStations";
            this.btnInsertStations.Size = new System.Drawing.Size(180, 23);
            this.btnInsertStations.TabIndex = 19;
            this.btnInsertStations.Text = "Re-Insert Stations";
            this.btnInsertStations.UseVisualStyleBackColor = true;
            this.btnInsertStations.Click += new System.EventHandler(this.btnInsertStations_Click);
            // 
            // txtInsertStationsStatus
            // 
            this.txtInsertStationsStatus.Location = new System.Drawing.Point(94, 169);
            this.txtInsertStationsStatus.Name = "txtInsertStationsStatus";
            this.txtInsertStationsStatus.ReadOnly = true;
            this.txtInsertStationsStatus.Size = new System.Drawing.Size(204, 20);
            this.txtInsertStationsStatus.TabIndex = 18;
            // 
            // lInsertStations
            // 
            this.lInsertStations.AutoSize = true;
            this.lInsertStations.Location = new System.Drawing.Point(19, 172);
            this.lInsertStations.Name = "lInsertStations";
            this.lInsertStations.Size = new System.Drawing.Size(48, 13);
            this.lInsertStations.TabIndex = 17;
            this.lInsertStations.Text = "Stations:";
            // 
            // btnInsertSystems
            // 
            this.btnInsertSystems.Location = new System.Drawing.Point(317, 124);
            this.btnInsertSystems.Name = "btnInsertSystems";
            this.btnInsertSystems.Size = new System.Drawing.Size(180, 23);
            this.btnInsertSystems.TabIndex = 16;
            this.btnInsertSystems.Text = "Re-Insert Systems";
            this.btnInsertSystems.UseVisualStyleBackColor = true;
            this.btnInsertSystems.Click += new System.EventHandler(this.btnInsertSystems_Click);
            // 
            // txtInsertSystemsStatus
            // 
            this.txtInsertSystemsStatus.Location = new System.Drawing.Point(94, 127);
            this.txtInsertSystemsStatus.Name = "txtInsertSystemsStatus";
            this.txtInsertSystemsStatus.ReadOnly = true;
            this.txtInsertSystemsStatus.Size = new System.Drawing.Size(204, 20);
            this.txtInsertSystemsStatus.TabIndex = 15;
            // 
            // lInsertSystems
            // 
            this.lInsertSystems.AutoSize = true;
            this.lInsertSystems.Location = new System.Drawing.Point(19, 130);
            this.lInsertSystems.Name = "lInsertSystems";
            this.lInsertSystems.Size = new System.Drawing.Size(49, 13);
            this.lInsertSystems.TabIndex = 14;
            this.lInsertSystems.Text = "Systems:";
            // 
            // btnInsertCommodities
            // 
            this.btnInsertCommodities.Location = new System.Drawing.Point(317, 84);
            this.btnInsertCommodities.Name = "btnInsertCommodities";
            this.btnInsertCommodities.Size = new System.Drawing.Size(180, 23);
            this.btnInsertCommodities.TabIndex = 13;
            this.btnInsertCommodities.Text = "Re-Insert Commodities";
            this.btnInsertCommodities.UseVisualStyleBackColor = true;
            this.btnInsertCommodities.Click += new System.EventHandler(this.btnInsertCommodities_Click);
            // 
            // txtInsertCommoditiesStatus
            // 
            this.txtInsertCommoditiesStatus.Location = new System.Drawing.Point(94, 87);
            this.txtInsertCommoditiesStatus.Name = "txtInsertCommoditiesStatus";
            this.txtInsertCommoditiesStatus.ReadOnly = true;
            this.txtInsertCommoditiesStatus.Size = new System.Drawing.Size(204, 20);
            this.txtInsertCommoditiesStatus.TabIndex = 12;
            // 
            // lInsertCommodities
            // 
            this.lInsertCommodities.AutoSize = true;
            this.lInsertCommodities.Location = new System.Drawing.Point(19, 90);
            this.lInsertCommodities.Name = "lInsertCommodities";
            this.lInsertCommodities.Size = new System.Drawing.Size(69, 13);
            this.lInsertCommodities.TabIndex = 11;
            this.lInsertCommodities.Text = "Commodities:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(727, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "_________________________________________________________________________________" +
    "_______________________________________";
            // 
            // btnCreateDatabase
            // 
            this.btnCreateDatabase.Location = new System.Drawing.Point(542, 10);
            this.btnCreateDatabase.Name = "btnCreateDatabase";
            this.btnCreateDatabase.Size = new System.Drawing.Size(223, 22);
            this.btnCreateDatabase.TabIndex = 3;
            this.btnCreateDatabase.Text = "Create Database";
            this.btnCreateDatabase.UseVisualStyleBackColor = true;
            this.btnCreateDatabase.Click += new System.EventHandler(this.btnCreateDatabase_Click);
            // 
            // lDataBaseFileExists
            // 
            this.lDataBaseFileExists.AutoSize = true;
            this.lDataBaseFileExists.Location = new System.Drawing.Point(417, 15);
            this.lDataBaseFileExists.Name = "lDataBaseFileExists";
            this.lDataBaseFileExists.Size = new System.Drawing.Size(53, 13);
            this.lDataBaseFileExists.TabIndex = 2;
            this.lDataBaseFileExists.Text = "File Exists";
            // 
            // txtDataBaseFile
            // 
            this.txtDataBaseFile.Location = new System.Drawing.Point(88, 12);
            this.txtDataBaseFile.Name = "txtDataBaseFile";
            this.txtDataBaseFile.ReadOnly = true;
            this.txtDataBaseFile.Size = new System.Drawing.Size(323, 20);
            this.txtDataBaseFile.TabIndex = 1;
            // 
            // lDataBaseFile
            // 
            this.lDataBaseFile.AutoSize = true;
            this.lDataBaseFile.Location = new System.Drawing.Point(3, 15);
            this.lDataBaseFile.Name = "lDataBaseFile";
            this.lDataBaseFile.Size = new System.Drawing.Size(79, 13);
            this.lDataBaseFile.TabIndex = 0;
            this.lDataBaseFile.Text = "Data Base File:";
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(662, 514);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(123, 29);
            this.ExitButton.TabIndex = 1;
            this.ExitButton.Text = "Close";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(301, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Welcome to Elite Trade Search";
            // 
            // btnResetConfig
            // 
            this.btnResetConfig.Location = new System.Drawing.Point(512, 514);
            this.btnResetConfig.Name = "btnResetConfig";
            this.btnResetConfig.Size = new System.Drawing.Size(144, 29);
            this.btnResetConfig.TabIndex = 3;
            this.btnResetConfig.Text = "Reset Configuration";
            this.btnResetConfig.UseVisualStyleBackColor = true;
            this.btnResetConfig.Click += new System.EventHandler(this.btnResetConfig_Click);
            // 
            // lWorking
            // 
            this.lWorking.AutoSize = true;
            this.lWorking.Location = new System.Drawing.Point(13, 522);
            this.lWorking.Name = "lWorking";
            this.lWorking.Size = new System.Drawing.Size(59, 13);
            this.lWorking.TabIndex = 4;
            this.lWorking.Text = "Working ...";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 555);
            this.Controls.Add(this.lWorking);
            this.Controls.Add(this.btnResetConfig);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.FeatureAccess);
            this.Name = "MainForm";
            this.Text = "Elite Trade Search";
            this.FeatureAccess.ResumeLayout(false);
            this.configPage.ResumeLayout(false);
            this.configPage.PerformLayout();
            this.UpdateData.ResumeLayout(false);
            this.UpdateData.PerformLayout();
            this.InsertData.ResumeLayout(false);
            this.InsertData.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl FeatureAccess;
        private System.Windows.Forms.TabPage configPage;
        private System.Windows.Forms.TabPage UpdateData;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lDataDirectory;
        private System.Windows.Forms.TextBox txtDataDirectory;
        private System.Windows.Forms.Button btnDataDirBrowse;
        private System.Windows.Forms.Label lWarningDataSize;
        private System.Windows.Forms.Button btnResetConfig;
        private System.Windows.Forms.Label lWarningDataNeedsDownload;
        private System.Windows.Forms.TextBox txtDataDirUpdate;
        private System.Windows.Forms.Label lDataDirUpdate;
        private System.Windows.Forms.Label lDataDirDoesNotExist;
        private System.Windows.Forms.Button btnCreateDataDir;
        private System.Windows.Forms.Label lSystemsURL;
        private System.Windows.Forms.TextBox txtStationsURL;
        private System.Windows.Forms.Label lStationsURL;
        private System.Windows.Forms.TextBox txtSystemsURL;
        private System.Windows.Forms.TextBox txtPricesURL;
        private System.Windows.Forms.Label lPricesURL;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lHorizontalLine001;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDownloadSystemsData;
        private System.Windows.Forms.TextBox txtSystemsStatus;
        private System.Windows.Forms.Label lDataOnSystems;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnDownloadStationsData;
        private System.Windows.Forms.TextBox txtStationsStatus;
        private System.Windows.Forms.Label lDataOnStations;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnDownloadPricesData;
        private System.Windows.Forms.TextBox txtPricesStatus;
        private System.Windows.Forms.Label lDataOnPrices;
        private System.Windows.Forms.Button btnDownloadAllData;
        private System.Windows.Forms.Label lblWorking;
        private System.Windows.Forms.TabPage InsertData;
        private System.Windows.Forms.TextBox txtDataBaseFile;
        private System.Windows.Forms.Label lDataBaseFile;
        private System.Windows.Forms.Label lDataBaseFileExists;
        private System.Windows.Forms.Button btnCreateDatabase;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCommoditiesURL;
        private System.Windows.Forms.Label lCommoditiesURL;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnDownloadCommoditiesData;
        private System.Windows.Forms.TextBox txtCommoditiesStatus;
        private System.Windows.Forms.Label lDataOnCommodities;
        private System.Windows.Forms.Label lInsertCommodities;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnInsertPrices;
        private System.Windows.Forms.TextBox txtInsertPricesStatus;
        private System.Windows.Forms.Label lInsertPrices;
        private System.Windows.Forms.Button btnInsertStations;
        private System.Windows.Forms.TextBox txtInsertStationsStatus;
        private System.Windows.Forms.Label lInsertStations;
        private System.Windows.Forms.Button btnInsertSystems;
        private System.Windows.Forms.TextBox txtInsertSystemsStatus;
        private System.Windows.Forms.Label lInsertSystems;
        private System.Windows.Forms.Button btnInsertCommodities;
        private System.Windows.Forms.TextBox txtInsertCommoditiesStatus;
        private System.Windows.Forms.Label lWorking;
    }
}

