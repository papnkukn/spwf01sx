namespace Oxage
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
            this.gbSerialPort = new System.Windows.Forms.GroupBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.cmbPort = new System.Windows.Forms.ComboBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabConsole = new System.Windows.Forms.TabPage();
            this.cmbCommand = new System.Windows.Forms.ComboBox();
            this.chbCRLF = new System.Windows.Forms.CheckBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.lblCommand = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.tabStatus = new System.Windows.Forms.TabPage();
            this.dgStatus = new System.Windows.Forms.DataGridView();
            this.btnStatusRefresh = new System.Windows.Forms.Button();
            this.tabConnection = new System.Windows.Forms.TabPage();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblSecurity = new System.Windows.Forms.Label();
            this.lblSSID = new System.Windows.Forms.Label();
            this.cmbSecurity = new System.Windows.Forms.ComboBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.dgScanResults = new System.Windows.Forms.DataGridView();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnScan = new System.Windows.Forms.Button();
            this.txtSSID = new System.Windows.Forms.TextBox();
            this.tabFiles = new System.Windows.Forms.TabPage();
            this.btnFilesRefresh = new System.Windows.Forms.Button();
            this.dgFiles = new System.Windows.Forms.DataGridView();
            this.tabConfig = new System.Windows.Forms.TabPage();
            this.btnConfigRefresh = new System.Windows.Forms.Button();
            this.dgConfig = new System.Windows.Forms.DataGridView();
            this.tabSystem = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRoam = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPing = new System.Windows.Forms.Button();
            this.txtPingHost = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFirmwareUpgrade = new System.Windows.Forms.Button();
            this.txtFirmware = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnFileSystemUpgrade = new System.Windows.Forms.Button();
            this.txtFileSystem = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.tabEvents = new System.Windows.Forms.TabPage();
            this.btnClearEvents = new System.Windows.Forms.Button();
            this.dgEvents = new System.Windows.Forms.DataGridView();
            this.gbSerialPort.SuspendLayout();
            this.tabs.SuspendLayout();
            this.tabConsole.SuspendLayout();
            this.tabStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgStatus)).BeginInit();
            this.tabConnection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgScanResults)).BeginInit();
            this.tabFiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFiles)).BeginInit();
            this.tabConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgConfig)).BeginInit();
            this.tabSystem.SuspendLayout();
            this.tabEvents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgEvents)).BeginInit();
            this.SuspendLayout();
            // 
            // gbSerialPort
            // 
            this.gbSerialPort.Controls.Add(this.btnTest);
            this.gbSerialPort.Controls.Add(this.cmbPort);
            this.gbSerialPort.Controls.Add(this.btnOpen);
            this.gbSerialPort.Controls.Add(this.btnClose);
            this.gbSerialPort.Location = new System.Drawing.Point(6, 3);
            this.gbSerialPort.Name = "gbSerialPort";
            this.gbSerialPort.Size = new System.Drawing.Size(303, 52);
            this.gbSerialPort.TabIndex = 4;
            this.gbSerialPort.TabStop = false;
            this.gbSerialPort.Text = "Serial port";
            // 
            // btnTest
            // 
            this.btnTest.Enabled = false;
            this.btnTest.Location = new System.Drawing.Point(219, 19);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(69, 23);
            this.btnTest.TabIndex = 5;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // cmbPort
            // 
            this.cmbPort.FormattingEnabled = true;
            this.cmbPort.Location = new System.Drawing.Point(11, 20);
            this.cmbPort.Name = "cmbPort";
            this.cmbPort.Size = new System.Drawing.Size(127, 21);
            this.cmbPort.TabIndex = 3;
            this.cmbPort.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbPort_KeyDown);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(144, 19);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(69, 23);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(144, 19);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(69, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Visible = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tabs
            // 
            this.tabs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabs.Controls.Add(this.tabConsole);
            this.tabs.Controls.Add(this.tabStatus);
            this.tabs.Controls.Add(this.tabConnection);
            this.tabs.Controls.Add(this.tabFiles);
            this.tabs.Controls.Add(this.tabConfig);
            this.tabs.Controls.Add(this.tabSystem);
            this.tabs.Controls.Add(this.tabEvents);
            this.tabs.Location = new System.Drawing.Point(6, 61);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(615, 378);
            this.tabs.TabIndex = 11;
            this.tabs.SelectedIndexChanged += new System.EventHandler(this.tabs_SelectedIndexChanged);
            // 
            // tabConsole
            // 
            this.tabConsole.Controls.Add(this.cmbCommand);
            this.tabConsole.Controls.Add(this.chbCRLF);
            this.tabConsole.Controls.Add(this.btnClear);
            this.tabConsole.Controls.Add(this.btnSend);
            this.tabConsole.Controls.Add(this.lblCommand);
            this.tabConsole.Controls.Add(this.txtLog);
            this.tabConsole.Location = new System.Drawing.Point(4, 22);
            this.tabConsole.Name = "tabConsole";
            this.tabConsole.Size = new System.Drawing.Size(607, 352);
            this.tabConsole.TabIndex = 5;
            this.tabConsole.Text = "Console";
            this.tabConsole.UseVisualStyleBackColor = true;
            // 
            // cmbCommand
            // 
            this.cmbCommand.FormattingEnabled = true;
            this.cmbCommand.Location = new System.Drawing.Point(6, 25);
            this.cmbCommand.Name = "cmbCommand";
            this.cmbCommand.Size = new System.Drawing.Size(434, 21);
            this.cmbCommand.TabIndex = 20;
            this.cmbCommand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCommand_KeyDown);
            // 
            // chbCRLF
            // 
            this.chbCRLF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chbCRLF.AutoSize = true;
            this.chbCRLF.Location = new System.Drawing.Point(508, 7);
            this.chbCRLF.Name = "chbCRLF";
            this.chbCRLF.Size = new System.Drawing.Size(94, 17);
            this.chbCRLF.TabIndex = 19;
            this.chbCRLF.Text = "Show <cr><lf>";
            this.chbCRLF.UseVisualStyleBackColor = true;
            this.chbCRLF.CheckedChanged += new System.EventHandler(this.chbCRLF_CheckedChanged);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(527, 24);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 18;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Location = new System.Drawing.Point(446, 24);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 17;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lblCommand
            // 
            this.lblCommand.AutoSize = true;
            this.lblCommand.Location = new System.Drawing.Point(5, 8);
            this.lblCommand.Name = "lblCommand";
            this.lblCommand.Size = new System.Drawing.Size(70, 13);
            this.lblCommand.TabIndex = 16;
            this.lblCommand.Text = "AT command";
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.SystemColors.Info;
            this.txtLog.Location = new System.Drawing.Point(7, 53);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(595, 294);
            this.txtLog.TabIndex = 14;
            this.txtLog.WordWrap = false;
            // 
            // tabStatus
            // 
            this.tabStatus.Controls.Add(this.dgStatus);
            this.tabStatus.Controls.Add(this.btnStatusRefresh);
            this.tabStatus.Location = new System.Drawing.Point(4, 22);
            this.tabStatus.Name = "tabStatus";
            this.tabStatus.Padding = new System.Windows.Forms.Padding(3);
            this.tabStatus.Size = new System.Drawing.Size(607, 352);
            this.tabStatus.TabIndex = 0;
            this.tabStatus.Text = "Status";
            this.tabStatus.UseVisualStyleBackColor = true;
            // 
            // dgStatus
            // 
            this.dgStatus.AllowUserToAddRows = false;
            this.dgStatus.AllowUserToDeleteRows = false;
            this.dgStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgStatus.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgStatus.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgStatus.Location = new System.Drawing.Point(3, 30);
            this.dgStatus.Name = "dgStatus";
            this.dgStatus.Size = new System.Drawing.Size(601, 319);
            this.dgStatus.TabIndex = 23;
            // 
            // btnStatusRefresh
            // 
            this.btnStatusRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStatusRefresh.Location = new System.Drawing.Point(529, 3);
            this.btnStatusRefresh.Name = "btnStatusRefresh";
            this.btnStatusRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnStatusRefresh.TabIndex = 18;
            this.btnStatusRefresh.Text = "Refresh";
            this.btnStatusRefresh.UseVisualStyleBackColor = true;
            this.btnStatusRefresh.Click += new System.EventHandler(this.btnStatusRefresh_Click);
            // 
            // tabConnection
            // 
            this.tabConnection.Controls.Add(this.lblPassword);
            this.tabConnection.Controls.Add(this.lblSecurity);
            this.tabConnection.Controls.Add(this.lblSSID);
            this.tabConnection.Controls.Add(this.cmbSecurity);
            this.tabConnection.Controls.Add(this.txtPassword);
            this.tabConnection.Controls.Add(this.dgScanResults);
            this.tabConnection.Controls.Add(this.btnConnect);
            this.tabConnection.Controls.Add(this.btnScan);
            this.tabConnection.Controls.Add(this.txtSSID);
            this.tabConnection.Location = new System.Drawing.Point(4, 22);
            this.tabConnection.Name = "tabConnection";
            this.tabConnection.Padding = new System.Windows.Forms.Padding(3);
            this.tabConnection.Size = new System.Drawing.Size(607, 352);
            this.tabConnection.TabIndex = 1;
            this.tabConnection.Text = "Connection";
            this.tabConnection.UseVisualStyleBackColor = true;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(290, 3);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 28;
            this.lblPassword.Text = "Password";
            // 
            // lblSecurity
            // 
            this.lblSecurity.AutoSize = true;
            this.lblSecurity.Location = new System.Drawing.Point(157, 3);
            this.lblSecurity.Name = "lblSecurity";
            this.lblSecurity.Size = new System.Drawing.Size(45, 13);
            this.lblSecurity.TabIndex = 27;
            this.lblSecurity.Text = "Security";
            // 
            // lblSSID
            // 
            this.lblSSID.AutoSize = true;
            this.lblSSID.Location = new System.Drawing.Point(3, 3);
            this.lblSSID.Name = "lblSSID";
            this.lblSSID.Size = new System.Drawing.Size(32, 13);
            this.lblSSID.TabIndex = 26;
            this.lblSSID.Text = "SSID";
            // 
            // cmbSecurity
            // 
            this.cmbSecurity.FormattingEnabled = true;
            this.cmbSecurity.Items.AddRange(new object[] {
            "None",
            "WEP",
            "WPA/WPA2"});
            this.cmbSecurity.Location = new System.Drawing.Point(160, 19);
            this.cmbSecurity.Name = "cmbSecurity";
            this.cmbSecurity.Size = new System.Drawing.Size(127, 21);
            this.cmbSecurity.TabIndex = 25;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(293, 19);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(149, 20);
            this.txtPassword.TabIndex = 24;
            // 
            // dgScanResults
            // 
            this.dgScanResults.AllowUserToAddRows = false;
            this.dgScanResults.AllowUserToDeleteRows = false;
            this.dgScanResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgScanResults.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgScanResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgScanResults.Location = new System.Drawing.Point(3, 46);
            this.dgScanResults.Name = "dgScanResults";
            this.dgScanResults.Size = new System.Drawing.Size(601, 303);
            this.dgScanResults.TabIndex = 22;
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnect.Location = new System.Drawing.Point(448, 17);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 21;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnScan
            // 
            this.btnScan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScan.Location = new System.Drawing.Point(529, 17);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(75, 23);
            this.btnScan.TabIndex = 18;
            this.btnScan.Text = "Scan";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // txtSSID
            // 
            this.txtSSID.Location = new System.Drawing.Point(3, 19);
            this.txtSSID.Name = "txtSSID";
            this.txtSSID.Size = new System.Drawing.Size(151, 20);
            this.txtSSID.TabIndex = 16;
            // 
            // tabFiles
            // 
            this.tabFiles.Controls.Add(this.btnFilesRefresh);
            this.tabFiles.Controls.Add(this.dgFiles);
            this.tabFiles.Location = new System.Drawing.Point(4, 22);
            this.tabFiles.Name = "tabFiles";
            this.tabFiles.Size = new System.Drawing.Size(607, 352);
            this.tabFiles.TabIndex = 3;
            this.tabFiles.Text = "Files";
            this.tabFiles.UseVisualStyleBackColor = true;
            // 
            // btnFilesRefresh
            // 
            this.btnFilesRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFilesRefresh.Location = new System.Drawing.Point(529, 3);
            this.btnFilesRefresh.Name = "btnFilesRefresh";
            this.btnFilesRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnFilesRefresh.TabIndex = 26;
            this.btnFilesRefresh.Text = "Refresh";
            this.btnFilesRefresh.UseVisualStyleBackColor = true;
            this.btnFilesRefresh.Click += new System.EventHandler(this.btnFilesRefresh_Click);
            // 
            // dgFiles
            // 
            this.dgFiles.AllowUserToAddRows = false;
            this.dgFiles.AllowUserToDeleteRows = false;
            this.dgFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgFiles.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFiles.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgFiles.Location = new System.Drawing.Point(3, 30);
            this.dgFiles.Name = "dgFiles";
            this.dgFiles.Size = new System.Drawing.Size(601, 319);
            this.dgFiles.TabIndex = 25;
            // 
            // tabConfig
            // 
            this.tabConfig.Controls.Add(this.btnConfigRefresh);
            this.tabConfig.Controls.Add(this.dgConfig);
            this.tabConfig.Location = new System.Drawing.Point(4, 22);
            this.tabConfig.Name = "tabConfig";
            this.tabConfig.Size = new System.Drawing.Size(607, 352);
            this.tabConfig.TabIndex = 6;
            this.tabConfig.Text = "Config";
            this.tabConfig.UseVisualStyleBackColor = true;
            // 
            // btnConfigRefresh
            // 
            this.btnConfigRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfigRefresh.Location = new System.Drawing.Point(529, 3);
            this.btnConfigRefresh.Name = "btnConfigRefresh";
            this.btnConfigRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnConfigRefresh.TabIndex = 24;
            this.btnConfigRefresh.Text = "Refresh";
            this.btnConfigRefresh.UseVisualStyleBackColor = true;
            this.btnConfigRefresh.Click += new System.EventHandler(this.btnConfigRefresh_Click);
            // 
            // dgConfig
            // 
            this.dgConfig.AllowUserToAddRows = false;
            this.dgConfig.AllowUserToDeleteRows = false;
            this.dgConfig.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgConfig.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgConfig.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgConfig.Location = new System.Drawing.Point(3, 30);
            this.dgConfig.Name = "dgConfig";
            this.dgConfig.Size = new System.Drawing.Size(601, 319);
            this.dgConfig.TabIndex = 23;
            this.dgConfig.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgConfig_CellValueChanged);
            // 
            // tabSystem
            // 
            this.tabSystem.Controls.Add(this.label4);
            this.tabSystem.Controls.Add(this.btnRoam);
            this.tabSystem.Controls.Add(this.label2);
            this.tabSystem.Controls.Add(this.btnPing);
            this.tabSystem.Controls.Add(this.txtPingHost);
            this.tabSystem.Controls.Add(this.label1);
            this.tabSystem.Controls.Add(this.btnFirmwareUpgrade);
            this.tabSystem.Controls.Add(this.txtFirmware);
            this.tabSystem.Controls.Add(this.label3);
            this.tabSystem.Controls.Add(this.btnFileSystemUpgrade);
            this.tabSystem.Controls.Add(this.txtFileSystem);
            this.tabSystem.Controls.Add(this.btnReset);
            this.tabSystem.Location = new System.Drawing.Point(4, 22);
            this.tabSystem.Name = "tabSystem";
            this.tabSystem.Size = new System.Drawing.Size(607, 352);
            this.tabSystem.TabIndex = 4;
            this.tabSystem.Text = "System";
            this.tabSystem.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Administration";
            // 
            // btnRoam
            // 
            this.btnRoam.Location = new System.Drawing.Point(88, 19);
            this.btnRoam.Name = "btnRoam";
            this.btnRoam.Size = new System.Drawing.Size(75, 23);
            this.btnRoam.TabIndex = 24;
            this.btnRoam.Text = "Roam";
            this.btnRoam.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Host to ping";
            // 
            // btnPing
            // 
            this.btnPing.Location = new System.Drawing.Point(313, 75);
            this.btnPing.Name = "btnPing";
            this.btnPing.Size = new System.Drawing.Size(75, 23);
            this.btnPing.TabIndex = 22;
            this.btnPing.Text = "Ping";
            this.btnPing.UseVisualStyleBackColor = true;
            this.btnPing.Click += new System.EventHandler(this.btnPing_Click);
            // 
            // txtPingHost
            // 
            this.txtPingHost.Location = new System.Drawing.Point(7, 77);
            this.txtPingHost.Name = "txtPingHost";
            this.txtPingHost.Size = new System.Drawing.Size(300, 20);
            this.txtPingHost.TabIndex = 21;
            this.txtPingHost.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPingHost_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Firmware upgrade";
            // 
            // btnFirmwareUpgrade
            // 
            this.btnFirmwareUpgrade.Location = new System.Drawing.Point(313, 114);
            this.btnFirmwareUpgrade.Name = "btnFirmwareUpgrade";
            this.btnFirmwareUpgrade.Size = new System.Drawing.Size(75, 23);
            this.btnFirmwareUpgrade.TabIndex = 16;
            this.btnFirmwareUpgrade.Text = "Upgrade";
            this.btnFirmwareUpgrade.UseVisualStyleBackColor = true;
            this.btnFirmwareUpgrade.Click += new System.EventHandler(this.btnFirmwareUpgrade_Click);
            // 
            // txtFirmware
            // 
            this.txtFirmware.Location = new System.Drawing.Point(7, 116);
            this.txtFirmware.Name = "txtFirmware";
            this.txtFirmware.Size = new System.Drawing.Size(300, 20);
            this.txtFirmware.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "File system upgrade";
            // 
            // btnFileSystemUpgrade
            // 
            this.btnFileSystemUpgrade.Location = new System.Drawing.Point(313, 153);
            this.btnFileSystemUpgrade.Name = "btnFileSystemUpgrade";
            this.btnFileSystemUpgrade.Size = new System.Drawing.Size(75, 23);
            this.btnFileSystemUpgrade.TabIndex = 13;
            this.btnFileSystemUpgrade.Text = "Upgrade";
            this.btnFileSystemUpgrade.UseVisualStyleBackColor = true;
            this.btnFileSystemUpgrade.Click += new System.EventHandler(this.btnFileSystemUpgrade_Click);
            // 
            // txtFileSystem
            // 
            this.txtFileSystem.Location = new System.Drawing.Point(7, 155);
            this.txtFileSystem.Name = "txtFileSystem";
            this.txtFileSystem.Size = new System.Drawing.Size(300, 20);
            this.txtFileSystem.TabIndex = 12;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(7, 19);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 11;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // tabEvents
            // 
            this.tabEvents.Controls.Add(this.btnClearEvents);
            this.tabEvents.Controls.Add(this.dgEvents);
            this.tabEvents.Location = new System.Drawing.Point(4, 22);
            this.tabEvents.Name = "tabEvents";
            this.tabEvents.Size = new System.Drawing.Size(607, 352);
            this.tabEvents.TabIndex = 7;
            this.tabEvents.Text = "Events";
            this.tabEvents.UseVisualStyleBackColor = true;
            // 
            // btnClearEvents
            // 
            this.btnClearEvents.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearEvents.Location = new System.Drawing.Point(529, 3);
            this.btnClearEvents.Name = "btnClearEvents";
            this.btnClearEvents.Size = new System.Drawing.Size(75, 23);
            this.btnClearEvents.TabIndex = 26;
            this.btnClearEvents.Text = "Clear";
            this.btnClearEvents.UseVisualStyleBackColor = true;
            this.btnClearEvents.Click += new System.EventHandler(this.btnClearEvents_Click);
            // 
            // dgEvents
            // 
            this.dgEvents.AllowUserToAddRows = false;
            this.dgEvents.AllowUserToDeleteRows = false;
            this.dgEvents.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgEvents.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEvents.Location = new System.Drawing.Point(3, 30);
            this.dgEvents.Name = "dgEvents";
            this.dgEvents.Size = new System.Drawing.Size(601, 319);
            this.dgEvents.TabIndex = 25;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.gbSerialPort);
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "MainForm";
            this.Text = "SPWF01Sx Utility v0.7";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.gbSerialPort.ResumeLayout(false);
            this.tabs.ResumeLayout(false);
            this.tabConsole.ResumeLayout(false);
            this.tabConsole.PerformLayout();
            this.tabStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgStatus)).EndInit();
            this.tabConnection.ResumeLayout(false);
            this.tabConnection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgScanResults)).EndInit();
            this.tabFiles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgFiles)).EndInit();
            this.tabConfig.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgConfig)).EndInit();
            this.tabSystem.ResumeLayout(false);
            this.tabSystem.PerformLayout();
            this.tabEvents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgEvents)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSerialPort;
        private System.Windows.Forms.ComboBox cmbPort;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabStatus;
        private System.Windows.Forms.TabPage tabConnection;
        private System.Windows.Forms.TabPage tabFiles;
        private System.Windows.Forms.TabPage tabSystem;
        private System.Windows.Forms.TabPage tabConsole;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label lblCommand;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.TextBox txtSSID;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnStatusRefresh;
        private System.Windows.Forms.DataGridView dgScanResults;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TabPage tabConfig;
        private System.Windows.Forms.Button btnConfigRefresh;
        private System.Windows.Forms.DataGridView dgConfig;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFirmwareUpgrade;
        private System.Windows.Forms.TextBox txtFirmware;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnFileSystemUpgrade;
        private System.Windows.Forms.TextBox txtFileSystem;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblSecurity;
        private System.Windows.Forms.Label lblSSID;
        private System.Windows.Forms.ComboBox cmbSecurity;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPing;
        private System.Windows.Forms.TextBox txtPingHost;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.CheckBox chbCRLF;
        private System.Windows.Forms.ComboBox cmbCommand;
        private System.Windows.Forms.DataGridView dgStatus;
        private System.Windows.Forms.Button btnFilesRefresh;
        private System.Windows.Forms.DataGridView dgFiles;
        private System.Windows.Forms.Button btnRoam;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabEvents;
        private System.Windows.Forms.Button btnClearEvents;
        private System.Windows.Forms.DataGridView dgEvents;

    }
}

