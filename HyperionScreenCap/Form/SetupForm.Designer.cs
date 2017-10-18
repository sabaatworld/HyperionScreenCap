namespace HyperionScreenCap
{
  partial class SetupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetupForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageGeneric = new System.Windows.Forms.TabPage();
            this.btnCheckUpdates = new System.Windows.Forms.Button();
            this.btnViewLogs = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.chkCheckUpdate = new System.Windows.Forms.CheckBox();
            this.chkCaptureOnStartup = new System.Windows.Forms.CheckBox();
            this.chkPauseSuspend = new System.Windows.Forms.CheckBox();
            this.chkPauseUserSwitch = new System.Windows.Forms.CheckBox();
            this.gbCaptureApi = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblDx9Desc = new System.Windows.Forms.Label();
            this.rbcmDx11 = new System.Windows.Forms.RadioButton();
            this.rbcmDx9 = new System.Windows.Forms.RadioButton();
            this.lblDx11Desc = new System.Windows.Forms.Label();
            this.cbMessagePriority = new System.Windows.Forms.ComboBox();
            this.lblMessagePriority = new System.Windows.Forms.Label();
            this.cbNotificationLevel = new System.Windows.Forms.ComboBox();
            this.lblNotificationLevel = new System.Windows.Forms.Label();
            this.tbProtoPort = new System.Windows.Forms.TextBox();
            this.lblProtoPort = new System.Windows.Forms.Label();
            this.tbIPHostName = new System.Windows.Forms.TextBox();
            this.lblIPHostName = new System.Windows.Forms.Label();
            this.tabPageAdvanced = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblApiPort = new System.Windows.Forms.Label();
            this.chkApiEnabled = new System.Windows.Forms.CheckBox();
            this.tbApiPort = new System.Windows.Forms.TextBox();
            this.grpDeactivate = new System.Windows.Forms.GroupBox();
            this.chkApiExcludeTimesEnabled = new System.Windows.Forms.CheckBox();
            this.tbApiExcludeEnd = new System.Windows.Forms.TextBox();
            this.lblEnd = new System.Windows.Forms.Label();
            this.tbApiExcludeStart = new System.Windows.Forms.TextBox();
            this.lblStart = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblShowDisplaysMsg = new System.Windows.Forms.Label();
            this.lblShowDx11Displays = new System.Windows.Forms.LinkLabel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cbDx11MonitorIndex = new System.Windows.Forms.ComboBox();
            this.lblDx11MonitorIndex = new System.Windows.Forms.Label();
            this.tbDx11FrameCaptureTimeout = new System.Windows.Forms.TextBox();
            this.cbDx11AdapterIndex = new System.Windows.Forms.ComboBox();
            this.lblMessageDuration = new System.Windows.Forms.Label();
            this.tbMessageDuration = new System.Windows.Forms.TextBox();
            this.lblCaptureWidth = new System.Windows.Forms.Label();
            this.tbCaptureWidth = new System.Windows.Forms.TextBox();
            this.lblCaptureHeight = new System.Windows.Forms.Label();
            this.tbCaptureHeight = new System.Windows.Forms.TextBox();
            this.lblMonitorIndex = new System.Windows.Forms.Label();
            this.lblCaptureInterval = new System.Windows.Forms.Label();
            this.cbMonitorIndex = new System.Windows.Forms.ComboBox();
            this.tbCaptureInterval = new System.Windows.Forms.TextBox();
            this.lblDx11MaxFps = new System.Windows.Forms.Label();
            this.lblDx11FrameCaptureTimeout = new System.Windows.Forms.Label();
            this.lblDx11ImgScalingFactor = new System.Windows.Forms.Label();
            this.tbDx11MaxFps = new System.Windows.Forms.TextBox();
            this.lblDx11AdapterIndex = new System.Windows.Forms.Label();
            this.cbDx11ImgScalingFactor = new System.Windows.Forms.ComboBox();
            this.tabPageHelp = new System.Windows.Forms.TabPage();
            this.tbHelp = new System.Windows.Forms.TextBox();
            this.btnSaveExit = new System.Windows.Forms.Button();
            this.lblVersion = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPageGeneric.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.gbCaptureApi.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabPageAdvanced.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.grpDeactivate.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabPageHelp.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageGeneric);
            this.tabControl1.Controls.Add(this.tabPageAdvanced);
            this.tabControl1.Controls.Add(this.tabPageHelp);
            this.tabControl1.Location = new System.Drawing.Point(5, 7);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1859, 706);
            this.tabControl1.TabIndex = 99;
            // 
            // tabPageGeneric
            // 
            this.tabPageGeneric.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageGeneric.Controls.Add(this.btnCheckUpdates);
            this.tabPageGeneric.Controls.Add(this.btnViewLogs);
            this.tabPageGeneric.Controls.Add(this.tableLayoutPanel3);
            this.tabPageGeneric.Controls.Add(this.gbCaptureApi);
            this.tabPageGeneric.Controls.Add(this.cbMessagePriority);
            this.tabPageGeneric.Controls.Add(this.lblMessagePriority);
            this.tabPageGeneric.Controls.Add(this.cbNotificationLevel);
            this.tabPageGeneric.Controls.Add(this.lblNotificationLevel);
            this.tabPageGeneric.Controls.Add(this.tbProtoPort);
            this.tabPageGeneric.Controls.Add(this.lblProtoPort);
            this.tabPageGeneric.Controls.Add(this.tbIPHostName);
            this.tabPageGeneric.Controls.Add(this.lblIPHostName);
            this.tabPageGeneric.Location = new System.Drawing.Point(10, 48);
            this.tabPageGeneric.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tabPageGeneric.Name = "tabPageGeneric";
            this.tabPageGeneric.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tabPageGeneric.Size = new System.Drawing.Size(1839, 648);
            this.tabPageGeneric.TabIndex = 0;
            this.tabPageGeneric.Text = "Generic";
            // 
            // btnCheckUpdates
            // 
            this.btnCheckUpdates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckUpdates.Location = new System.Drawing.Point(1246, 573);
            this.btnCheckUpdates.Name = "btnCheckUpdates";
            this.btnCheckUpdates.Size = new System.Drawing.Size(273, 65);
            this.btnCheckUpdates.TabIndex = 26;
            this.btnCheckUpdates.Text = "Check for Updates";
            this.btnCheckUpdates.UseVisualStyleBackColor = true;
            this.btnCheckUpdates.Click += new System.EventHandler(this.btnCheckUpdates_Click);
            // 
            // btnViewLogs
            // 
            this.btnViewLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewLogs.Location = new System.Drawing.Point(1547, 573);
            this.btnViewLogs.Name = "btnViewLogs";
            this.btnViewLogs.Size = new System.Drawing.Size(273, 65);
            this.btnViewLogs.TabIndex = 25;
            this.btnViewLogs.Text = "View Logs";
            this.btnViewLogs.UseVisualStyleBackColor = true;
            this.btnViewLogs.Click += new System.EventHandler(this.btnViewLogs_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.chkCheckUpdate, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.chkCaptureOnStartup, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.chkPauseSuspend, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.chkPauseUserSwitch, 0, 1);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(22, 375);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(628, 251);
            this.tableLayoutPanel3.TabIndex = 20;
            // 
            // chkCheckUpdate
            // 
            this.chkCheckUpdate.AutoSize = true;
            this.chkCheckUpdate.Location = new System.Drawing.Point(8, 157);
            this.chkCheckUpdate.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.chkCheckUpdate.Name = "chkCheckUpdate";
            this.chkCheckUpdate.Size = new System.Drawing.Size(392, 36);
            this.chkCheckUpdate.TabIndex = 20;
            this.chkCheckUpdate.Text = "Check for Updates on Start";
            this.chkCheckUpdate.UseVisualStyleBackColor = true;
            // 
            // chkCaptureOnStartup
            // 
            this.chkCaptureOnStartup.AutoSize = true;
            this.chkCaptureOnStartup.Location = new System.Drawing.Point(8, 7);
            this.chkCaptureOnStartup.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.chkCaptureOnStartup.Name = "chkCaptureOnStartup";
            this.chkCaptureOnStartup.Size = new System.Drawing.Size(496, 36);
            this.chkCaptureOnStartup.TabIndex = 5;
            this.chkCaptureOnStartup.Text = "Start Screen Capture Automatically";
            this.chkCaptureOnStartup.UseVisualStyleBackColor = true;
            // 
            // chkPauseSuspend
            // 
            this.chkPauseSuspend.AutoSize = true;
            this.chkPauseSuspend.Location = new System.Drawing.Point(8, 107);
            this.chkPauseSuspend.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.chkPauseSuspend.Name = "chkPauseSuspend";
            this.chkPauseSuspend.Size = new System.Drawing.Size(394, 36);
            this.chkPauseSuspend.TabIndex = 19;
            this.chkPauseSuspend.Text = "Pause on System Suspend";
            this.chkPauseSuspend.UseVisualStyleBackColor = true;
            // 
            // chkPauseUserSwitch
            // 
            this.chkPauseUserSwitch.AutoSize = true;
            this.chkPauseUserSwitch.Location = new System.Drawing.Point(8, 57);
            this.chkPauseUserSwitch.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.chkPauseUserSwitch.Name = "chkPauseUserSwitch";
            this.chkPauseUserSwitch.Size = new System.Drawing.Size(330, 36);
            this.chkPauseUserSwitch.TabIndex = 18;
            this.chkPauseUserSwitch.Text = "Pause on User Switch";
            this.chkPauseUserSwitch.UseVisualStyleBackColor = true;
            // 
            // gbCaptureApi
            // 
            this.gbCaptureApi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCaptureApi.Controls.Add(this.tableLayoutPanel2);
            this.gbCaptureApi.Location = new System.Drawing.Point(1063, 18);
            this.gbCaptureApi.Name = "gbCaptureApi";
            this.gbCaptureApi.Size = new System.Drawing.Size(757, 356);
            this.gbCaptureApi.TabIndex = 6;
            this.gbCaptureApi.TabStop = false;
            this.gbCaptureApi.Text = "Screen Capture Method";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.23256F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.76744F));
            this.tableLayoutPanel2.Controls.Add(this.lblDx9Desc, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.rbcmDx11, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.rbcmDx9, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblDx11Desc, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 34);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.Padding = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(751, 319);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lblDx9Desc
            // 
            this.lblDx9Desc.AutoSize = true;
            this.lblDx9Desc.Location = new System.Drawing.Point(234, 10);
            this.lblDx9Desc.Name = "lblDx9Desc";
            this.lblDx9Desc.Size = new System.Drawing.Size(348, 96);
            this.lblDx9Desc.TabIndex = 3;
            this.lblDx9Desc.Text = "Moderate CPU usage\r\nLow GPU Usage\r\nLow FPS Desktop Capture\r\n";
            // 
            // rbcmDx11
            // 
            this.rbcmDx11.AutoSize = true;
            this.rbcmDx11.Location = new System.Drawing.Point(13, 162);
            this.rbcmDx11.Name = "rbcmDx11";
            this.rbcmDx11.Size = new System.Drawing.Size(201, 100);
            this.rbcmDx11.TabIndex = 8;
            this.rbcmDx11.Text = "DirectX 11\r\n(Beta)\r\nWin 7 SP1+";
            this.rbcmDx11.UseVisualStyleBackColor = true;
            // 
            // rbcmDx9
            // 
            this.rbcmDx9.AutoSize = true;
            this.rbcmDx9.Location = new System.Drawing.Point(13, 13);
            this.rbcmDx9.Name = "rbcmDx9";
            this.rbcmDx9.Size = new System.Drawing.Size(168, 68);
            this.rbcmDx9.TabIndex = 7;
            this.rbcmDx9.Text = "DirectX 9\r\nWin XP+";
            this.rbcmDx9.UseVisualStyleBackColor = true;
            // 
            // lblDx11Desc
            // 
            this.lblDx11Desc.AutoSize = true;
            this.lblDx11Desc.Location = new System.Drawing.Point(234, 159);
            this.lblDx11Desc.Name = "lblDx11Desc";
            this.lblDx11Desc.Size = new System.Drawing.Size(355, 96);
            this.lblDx11Desc.TabIndex = 2;
            this.lblDx11Desc.Text = "Negligible CPU usage\r\nVery Low GPU usage\r\nHigh FPS Desktop Capture";
            // 
            // cbMessagePriority
            // 
            this.cbMessagePriority.FormattingEnabled = true;
            this.cbMessagePriority.Items.AddRange(new object[] {
            "10",
            "20",
            "50",
            "100",
            "200",
            "500",
            "750",
            "1000"});
            this.cbMessagePriority.Location = new System.Drawing.Point(293, 203);
            this.cbMessagePriority.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.cbMessagePriority.Name = "cbMessagePriority";
            this.cbMessagePriority.Size = new System.Drawing.Size(260, 39);
            this.cbMessagePriority.TabIndex = 3;
            this.cbMessagePriority.Validating += new System.ComponentModel.CancelEventHandler(this.cbMessagePriority_Validating);
            // 
            // lblMessagePriority
            // 
            this.lblMessagePriority.AutoSize = true;
            this.lblMessagePriority.Location = new System.Drawing.Point(16, 210);
            this.lblMessagePriority.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblMessagePriority.Name = "lblMessagePriority";
            this.lblMessagePriority.Size = new System.Drawing.Size(104, 32);
            this.lblMessagePriority.TabIndex = 17;
            this.lblMessagePriority.Text = "Priority";
            // 
            // cbNotificationLevel
            // 
            this.cbNotificationLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNotificationLevel.FormattingEnabled = true;
            this.cbNotificationLevel.Items.AddRange(new object[] {
            "Info",
            "Error",
            "None"});
            this.cbNotificationLevel.Location = new System.Drawing.Point(293, 286);
            this.cbNotificationLevel.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.cbNotificationLevel.Name = "cbNotificationLevel";
            this.cbNotificationLevel.Size = new System.Drawing.Size(260, 39);
            this.cbNotificationLevel.TabIndex = 4;
            // 
            // lblNotificationLevel
            // 
            this.lblNotificationLevel.AutoSize = true;
            this.lblNotificationLevel.Location = new System.Drawing.Point(16, 293);
            this.lblNotificationLevel.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblNotificationLevel.Name = "lblNotificationLevel";
            this.lblNotificationLevel.Size = new System.Drawing.Size(233, 32);
            this.lblNotificationLevel.TabIndex = 13;
            this.lblNotificationLevel.Text = "Notification level:";
            // 
            // tbProtoPort
            // 
            this.tbProtoPort.Location = new System.Drawing.Point(293, 119);
            this.tbProtoPort.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tbProtoPort.Name = "tbProtoPort";
            this.tbProtoPort.Size = new System.Drawing.Size(260, 38);
            this.tbProtoPort.TabIndex = 2;
            this.tbProtoPort.Validating += new System.ComponentModel.CancelEventHandler(this.tbProtoPort_Validating);
            // 
            // lblProtoPort
            // 
            this.lblProtoPort.AutoSize = true;
            this.lblProtoPort.Location = new System.Drawing.Point(16, 124);
            this.lblProtoPort.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblProtoPort.Name = "lblProtoPort";
            this.lblProtoPort.Size = new System.Drawing.Size(75, 32);
            this.lblProtoPort.TabIndex = 11;
            this.lblProtoPort.Text = "Port:";
            // 
            // tbIPHostName
            // 
            this.tbIPHostName.Location = new System.Drawing.Point(293, 36);
            this.tbIPHostName.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tbIPHostName.Name = "tbIPHostName";
            this.tbIPHostName.Size = new System.Drawing.Size(260, 38);
            this.tbIPHostName.TabIndex = 1;
            // 
            // lblIPHostName
            // 
            this.lblIPHostName.AutoSize = true;
            this.lblIPHostName.Location = new System.Drawing.Point(16, 41);
            this.lblIPHostName.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblIPHostName.Name = "lblIPHostName";
            this.lblIPHostName.Size = new System.Drawing.Size(200, 32);
            this.lblIPHostName.TabIndex = 9;
            this.lblIPHostName.Text = "IP / Hostname:";
            // 
            // tabPageAdvanced
            // 
            this.tabPageAdvanced.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageAdvanced.Controls.Add(this.tableLayoutPanel4);
            this.tabPageAdvanced.Controls.Add(this.tableLayoutPanel1);
            this.tabPageAdvanced.Location = new System.Drawing.Point(10, 48);
            this.tabPageAdvanced.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tabPageAdvanced.Name = "tabPageAdvanced";
            this.tabPageAdvanced.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tabPageAdvanced.Size = new System.Drawing.Size(1839, 648);
            this.tabPageAdvanced.TabIndex = 1;
            this.tabPageAdvanced.Text = "Advanced";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 0, 1);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(903, 19);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 233F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 331F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(925, 623);
            this.tableLayoutPanel4.TabIndex = 23;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblApiPort);
            this.panel1.Controls.Add(this.chkApiEnabled);
            this.panel1.Controls.Add(this.tbApiPort);
            this.panel1.Controls.Add(this.grpDeactivate);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(919, 227);
            this.panel1.TabIndex = 0;
            // 
            // lblApiPort
            // 
            this.lblApiPort.AutoSize = true;
            this.lblApiPort.Location = new System.Drawing.Point(25, 8);
            this.lblApiPort.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblApiPort.Name = "lblApiPort";
            this.lblApiPort.Size = new System.Drawing.Size(127, 32);
            this.lblApiPort.TabIndex = 12;
            this.lblApiPort.Text = "API Port:";
            // 
            // chkApiEnabled
            // 
            this.chkApiEnabled.AutoSize = true;
            this.chkApiEnabled.Location = new System.Drawing.Point(360, 8);
            this.chkApiEnabled.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.chkApiEnabled.Name = "chkApiEnabled";
            this.chkApiEnabled.Size = new System.Drawing.Size(195, 36);
            this.chkApiEnabled.TabIndex = 16;
            this.chkApiEnabled.Text = "Enable API";
            this.chkApiEnabled.UseVisualStyleBackColor = true;
            // 
            // tbApiPort
            // 
            this.tbApiPort.Location = new System.Drawing.Point(159, 5);
            this.tbApiPort.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tbApiPort.Name = "tbApiPort";
            this.tbApiPort.Size = new System.Drawing.Size(153, 38);
            this.tbApiPort.TabIndex = 15;
            this.tbApiPort.Validating += new System.ComponentModel.CancelEventHandler(this.tbApiPort_Validating);
            // 
            // grpDeactivate
            // 
            this.grpDeactivate.Controls.Add(this.chkApiExcludeTimesEnabled);
            this.grpDeactivate.Controls.Add(this.tbApiExcludeEnd);
            this.grpDeactivate.Controls.Add(this.lblEnd);
            this.grpDeactivate.Controls.Add(this.tbApiExcludeStart);
            this.grpDeactivate.Controls.Add(this.lblStart);
            this.grpDeactivate.Location = new System.Drawing.Point(15, 59);
            this.grpDeactivate.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.grpDeactivate.Name = "grpDeactivate";
            this.grpDeactivate.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.grpDeactivate.Size = new System.Drawing.Size(774, 162);
            this.grpDeactivate.TabIndex = 17;
            this.grpDeactivate.TabStop = false;
            this.grpDeactivate.Text = "Disable API control during specified time range";
            // 
            // chkApiExcludeTimesEnabled
            // 
            this.chkApiExcludeTimesEnabled.AutoSize = true;
            this.chkApiExcludeTimesEnabled.Location = new System.Drawing.Point(16, 55);
            this.chkApiExcludeTimesEnabled.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.chkApiExcludeTimesEnabled.Name = "chkApiExcludeTimesEnabled";
            this.chkApiExcludeTimesEnabled.Size = new System.Drawing.Size(159, 36);
            this.chkApiExcludeTimesEnabled.TabIndex = 18;
            this.chkApiExcludeTimesEnabled.Text = "Enabled";
            this.chkApiExcludeTimesEnabled.UseVisualStyleBackColor = true;
            // 
            // tbApiExcludeEnd
            // 
            this.tbApiExcludeEnd.Location = new System.Drawing.Point(513, 110);
            this.tbApiExcludeEnd.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tbApiExcludeEnd.Name = "tbApiExcludeEnd";
            this.tbApiExcludeEnd.Size = new System.Drawing.Size(127, 38);
            this.tbApiExcludeEnd.TabIndex = 20;
            this.tbApiExcludeEnd.Text = "21:00";
            this.tbApiExcludeEnd.Validating += new System.ComponentModel.CancelEventHandler(this.tbExcludeEnd_Validating);
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Location = new System.Drawing.Point(339, 117);
            this.lblEnd.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(74, 32);
            this.lblEnd.TabIndex = 2;
            this.lblEnd.Text = "End:";
            // 
            // tbApiExcludeStart
            // 
            this.tbApiExcludeStart.Location = new System.Drawing.Point(513, 50);
            this.tbApiExcludeStart.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tbApiExcludeStart.Name = "tbApiExcludeStart";
            this.tbApiExcludeStart.Size = new System.Drawing.Size(127, 38);
            this.tbApiExcludeStart.TabIndex = 19;
            this.tbApiExcludeStart.Text = "8:00";
            this.tbApiExcludeStart.Validating += new System.ComponentModel.CancelEventHandler(this.tbExcludeStart_Validating);
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(339, 57);
            this.lblStart.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(83, 32);
            this.lblStart.TabIndex = 0;
            this.lblStart.Text = "Start:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblShowDisplaysMsg);
            this.panel2.Controls.Add(this.lblShowDx11Displays);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 567);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(919, 53);
            this.panel2.TabIndex = 1;
            // 
            // lblShowDisplaysMsg
            // 
            this.lblShowDisplaysMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblShowDisplaysMsg.AutoSize = true;
            this.lblShowDisplaysMsg.Location = new System.Drawing.Point(567, 9);
            this.lblShowDisplaysMsg.Name = "lblShowDisplaysMsg";
            this.lblShowDisplaysMsg.Size = new System.Drawing.Size(337, 32);
            this.lblShowDisplaysMsg.TabIndex = 22;
            this.lblShowDisplaysMsg.Text = "to view monitors for DX11";
            // 
            // lblShowDx11Displays
            // 
            this.lblShowDx11Displays.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblShowDx11Displays.AutoSize = true;
            this.lblShowDx11Displays.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblShowDx11Displays.Location = new System.Drawing.Point(433, 10);
            this.lblShowDx11Displays.Name = "lblShowDx11Displays";
            this.lblShowDx11Displays.Size = new System.Drawing.Size(141, 32);
            this.lblShowDx11Displays.TabIndex = 21;
            this.lblShowDx11Displays.TabStop = true;
            this.lblShowDx11Displays.Text = "Click here";
            this.lblShowDx11Displays.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblShowDx11Displays_LinkClicked);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 236);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 4;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 124F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(919, 325);
            this.tableLayoutPanel5.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.29426F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.70574F));
            this.tableLayoutPanel1.Controls.Add(this.cbDx11MonitorIndex, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.lblDx11MonitorIndex, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.tbDx11FrameCaptureTimeout, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.cbDx11AdapterIndex, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.lblMessageDuration, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbMessageDuration, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblCaptureWidth, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbCaptureWidth, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblCaptureHeight, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbCaptureHeight, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblMonitorIndex, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblCaptureInterval, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.cbMonitorIndex, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.tbCaptureInterval, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblDx11MaxFps, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblDx11FrameCaptureTimeout, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblDx11ImgScalingFactor, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.tbDx11MaxFps, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblDx11AdapterIndex, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.cbDx11ImgScalingFactor, 1, 7);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(11, 19);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(838, 623);
            this.tableLayoutPanel1.TabIndex = 19;
            // 
            // cbDx11MonitorIndex
            // 
            this.cbDx11MonitorIndex.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbDx11MonitorIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDx11MonitorIndex.FormattingEnabled = true;
            this.cbDx11MonitorIndex.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.cbDx11MonitorIndex.Location = new System.Drawing.Point(521, 478);
            this.cbDx11MonitorIndex.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.cbDx11MonitorIndex.Name = "cbDx11MonitorIndex";
            this.cbDx11MonitorIndex.Size = new System.Drawing.Size(260, 39);
            this.cbDx11MonitorIndex.TabIndex = 10;
            // 
            // lblDx11MonitorIndex
            // 
            this.lblDx11MonitorIndex.AutoSize = true;
            this.lblDx11MonitorIndex.Location = new System.Drawing.Point(8, 471);
            this.lblDx11MonitorIndex.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblDx11MonitorIndex.Name = "lblDx11MonitorIndex";
            this.lblDx11MonitorIndex.Size = new System.Drawing.Size(272, 32);
            this.lblDx11MonitorIndex.TabIndex = 23;
            this.lblDx11MonitorIndex.Text = "DX11 Monitor Index:";
            // 
            // tbDx11FrameCaptureTimeout
            // 
            this.tbDx11FrameCaptureTimeout.Location = new System.Drawing.Point(521, 320);
            this.tbDx11FrameCaptureTimeout.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tbDx11FrameCaptureTimeout.Name = "tbDx11FrameCaptureTimeout";
            this.tbDx11FrameCaptureTimeout.Size = new System.Drawing.Size(260, 38);
            this.tbDx11FrameCaptureTimeout.TabIndex = 7;
            this.tbDx11FrameCaptureTimeout.Validating += new System.ComponentModel.CancelEventHandler(this.tbDx11FrameCaptureTimeout_Validating);
            // 
            // cbDx11AdapterIndex
            // 
            this.cbDx11AdapterIndex.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbDx11AdapterIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDx11AdapterIndex.FormattingEnabled = true;
            this.cbDx11AdapterIndex.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.cbDx11AdapterIndex.Location = new System.Drawing.Point(521, 425);
            this.cbDx11AdapterIndex.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.cbDx11AdapterIndex.Name = "cbDx11AdapterIndex";
            this.cbDx11AdapterIndex.Size = new System.Drawing.Size(260, 39);
            this.cbDx11AdapterIndex.TabIndex = 9;
            // 
            // lblMessageDuration
            // 
            this.lblMessageDuration.AutoSize = true;
            this.lblMessageDuration.Location = new System.Drawing.Point(8, 0);
            this.lblMessageDuration.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblMessageDuration.Name = "lblMessageDuration";
            this.lblMessageDuration.Size = new System.Drawing.Size(318, 32);
            this.lblMessageDuration.TabIndex = 0;
            this.lblMessageDuration.Text = "Message duration (ms): ";
            // 
            // tbMessageDuration
            // 
            this.tbMessageDuration.Location = new System.Drawing.Point(521, 7);
            this.tbMessageDuration.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tbMessageDuration.Name = "tbMessageDuration";
            this.tbMessageDuration.Size = new System.Drawing.Size(260, 38);
            this.tbMessageDuration.TabIndex = 1;
            this.tbMessageDuration.Validating += new System.ComponentModel.CancelEventHandler(this.tbMessageDuration_Validating);
            // 
            // lblCaptureWidth
            // 
            this.lblCaptureWidth.AutoSize = true;
            this.lblCaptureWidth.Location = new System.Drawing.Point(8, 52);
            this.lblCaptureWidth.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblCaptureWidth.Name = "lblCaptureWidth";
            this.lblCaptureWidth.Size = new System.Drawing.Size(260, 32);
            this.lblCaptureWidth.TabIndex = 2;
            this.lblCaptureWidth.Text = "DX9 Capture width:";
            // 
            // tbCaptureWidth
            // 
            this.tbCaptureWidth.Location = new System.Drawing.Point(521, 59);
            this.tbCaptureWidth.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tbCaptureWidth.Name = "tbCaptureWidth";
            this.tbCaptureWidth.Size = new System.Drawing.Size(260, 38);
            this.tbCaptureWidth.TabIndex = 2;
            this.tbCaptureWidth.Validating += new System.ComponentModel.CancelEventHandler(this.tbCaptureWidth_Validating);
            // 
            // lblCaptureHeight
            // 
            this.lblCaptureHeight.AutoSize = true;
            this.lblCaptureHeight.Location = new System.Drawing.Point(8, 104);
            this.lblCaptureHeight.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblCaptureHeight.Name = "lblCaptureHeight";
            this.lblCaptureHeight.Size = new System.Drawing.Size(272, 32);
            this.lblCaptureHeight.TabIndex = 4;
            this.lblCaptureHeight.Text = "DX9 Capture height:";
            // 
            // tbCaptureHeight
            // 
            this.tbCaptureHeight.Location = new System.Drawing.Point(521, 111);
            this.tbCaptureHeight.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tbCaptureHeight.Name = "tbCaptureHeight";
            this.tbCaptureHeight.Size = new System.Drawing.Size(260, 38);
            this.tbCaptureHeight.TabIndex = 3;
            this.tbCaptureHeight.Validating += new System.ComponentModel.CancelEventHandler(this.tbCaptureHeight_Validating);
            // 
            // lblMonitorIndex
            // 
            this.lblMonitorIndex.AutoSize = true;
            this.lblMonitorIndex.Location = new System.Drawing.Point(8, 156);
            this.lblMonitorIndex.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblMonitorIndex.Name = "lblMonitorIndex";
            this.lblMonitorIndex.Size = new System.Drawing.Size(256, 32);
            this.lblMonitorIndex.TabIndex = 17;
            this.lblMonitorIndex.Text = "DX9 Monitor index:";
            // 
            // lblCaptureInterval
            // 
            this.lblCaptureInterval.AutoSize = true;
            this.lblCaptureInterval.Location = new System.Drawing.Point(8, 209);
            this.lblCaptureInterval.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblCaptureInterval.Name = "lblCaptureInterval";
            this.lblCaptureInterval.Size = new System.Drawing.Size(348, 32);
            this.lblCaptureInterval.TabIndex = 6;
            this.lblCaptureInterval.Text = "DX9 Capture interval (ms):";
            // 
            // cbMonitorIndex
            // 
            this.cbMonitorIndex.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbMonitorIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMonitorIndex.FormattingEnabled = true;
            this.cbMonitorIndex.Location = new System.Drawing.Point(521, 163);
            this.cbMonitorIndex.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.cbMonitorIndex.Name = "cbMonitorIndex";
            this.cbMonitorIndex.Size = new System.Drawing.Size(260, 39);
            this.cbMonitorIndex.TabIndex = 4;
            this.cbMonitorIndex.Validating += new System.ComponentModel.CancelEventHandler(this.cbMonitorIndex_Validating);
            // 
            // tbCaptureInterval
            // 
            this.tbCaptureInterval.Location = new System.Drawing.Point(521, 216);
            this.tbCaptureInterval.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tbCaptureInterval.Name = "tbCaptureInterval";
            this.tbCaptureInterval.Size = new System.Drawing.Size(260, 38);
            this.tbCaptureInterval.TabIndex = 5;
            this.tbCaptureInterval.Validating += new System.ComponentModel.CancelEventHandler(this.tbCaptureInterval_Validating);
            // 
            // lblDx11MaxFps
            // 
            this.lblDx11MaxFps.AutoSize = true;
            this.lblDx11MaxFps.Location = new System.Drawing.Point(8, 261);
            this.lblDx11MaxFps.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblDx11MaxFps.Name = "lblDx11MaxFps";
            this.lblDx11MaxFps.Size = new System.Drawing.Size(285, 32);
            this.lblDx11MaxFps.TabIndex = 19;
            this.lblDx11MaxFps.Text = "DX11 Maximum FPS:";
            // 
            // lblDx11FrameCaptureTimeout
            // 
            this.lblDx11FrameCaptureTimeout.AutoSize = true;
            this.lblDx11FrameCaptureTimeout.Location = new System.Drawing.Point(8, 313);
            this.lblDx11FrameCaptureTimeout.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblDx11FrameCaptureTimeout.Name = "lblDx11FrameCaptureTimeout";
            this.lblDx11FrameCaptureTimeout.Size = new System.Drawing.Size(462, 32);
            this.lblDx11FrameCaptureTimeout.TabIndex = 20;
            this.lblDx11FrameCaptureTimeout.Text = "DX11 Frame Capture Timeout (ms):";
            // 
            // lblDx11ImgScalingFactor
            // 
            this.lblDx11ImgScalingFactor.AutoSize = true;
            this.lblDx11ImgScalingFactor.Location = new System.Drawing.Point(8, 365);
            this.lblDx11ImgScalingFactor.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblDx11ImgScalingFactor.Name = "lblDx11ImgScalingFactor";
            this.lblDx11ImgScalingFactor.Size = new System.Drawing.Size(368, 32);
            this.lblDx11ImgScalingFactor.TabIndex = 21;
            this.lblDx11ImgScalingFactor.Text = "DX11 Image Scaling Factor:";
            // 
            // tbDx11MaxFps
            // 
            this.tbDx11MaxFps.Location = new System.Drawing.Point(521, 268);
            this.tbDx11MaxFps.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tbDx11MaxFps.Name = "tbDx11MaxFps";
            this.tbDx11MaxFps.Size = new System.Drawing.Size(260, 38);
            this.tbDx11MaxFps.TabIndex = 6;
            this.tbDx11MaxFps.Validating += new System.ComponentModel.CancelEventHandler(this.tbDx11MaxFps_Validating);
            // 
            // lblDx11AdapterIndex
            // 
            this.lblDx11AdapterIndex.AutoSize = true;
            this.lblDx11AdapterIndex.Location = new System.Drawing.Point(8, 418);
            this.lblDx11AdapterIndex.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblDx11AdapterIndex.Name = "lblDx11AdapterIndex";
            this.lblDx11AdapterIndex.Size = new System.Drawing.Size(277, 32);
            this.lblDx11AdapterIndex.TabIndex = 22;
            this.lblDx11AdapterIndex.Text = "DX11 Adapter Index:";
            // 
            // cbDx11ImgScalingFactor
            // 
            this.cbDx11ImgScalingFactor.AutoCompleteCustomSource.AddRange(new string[] {
            "1",
            "2",
            "4",
            "8",
            "16",
            "32",
            "64",
            "128",
            "256",
            "512"});
            this.cbDx11ImgScalingFactor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbDx11ImgScalingFactor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDx11ImgScalingFactor.FormattingEnabled = true;
            this.cbDx11ImgScalingFactor.Items.AddRange(new object[] {
            "1",
            "2",
            "4",
            "8",
            "16",
            "32",
            "64",
            "128",
            "256",
            "512"});
            this.cbDx11ImgScalingFactor.Location = new System.Drawing.Point(521, 372);
            this.cbDx11ImgScalingFactor.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.cbDx11ImgScalingFactor.Name = "cbDx11ImgScalingFactor";
            this.cbDx11ImgScalingFactor.Size = new System.Drawing.Size(260, 39);
            this.cbDx11ImgScalingFactor.TabIndex = 8;
            // 
            // tabPageHelp
            // 
            this.tabPageHelp.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageHelp.Controls.Add(this.tbHelp);
            this.tabPageHelp.Location = new System.Drawing.Point(10, 48);
            this.tabPageHelp.Name = "tabPageHelp";
            this.tabPageHelp.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHelp.Size = new System.Drawing.Size(1839, 648);
            this.tabPageHelp.TabIndex = 2;
            this.tabPageHelp.Text = "Help";
            // 
            // tbHelp
            // 
            this.tbHelp.BackColor = System.Drawing.SystemColors.Info;
            this.tbHelp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbHelp.Font = new System.Drawing.Font("Arial", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbHelp.Location = new System.Drawing.Point(3, 3);
            this.tbHelp.Multiline = true;
            this.tbHelp.Name = "tbHelp";
            this.tbHelp.ReadOnly = true;
            this.tbHelp.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbHelp.Size = new System.Drawing.Size(1833, 642);
            this.tbHelp.TabIndex = 0;
            this.tbHelp.TabStop = false;
            this.tbHelp.Text = "<Help content is in SetupFormHelp.txt resource>";
            // 
            // btnSaveExit
            // 
            this.btnSaveExit.Location = new System.Drawing.Point(1501, 727);
            this.btnSaveExit.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnSaveExit.Name = "btnSaveExit";
            this.btnSaveExit.Size = new System.Drawing.Size(352, 107);
            this.btnSaveExit.TabIndex = 100;
            this.btnSaveExit.Text = "Save and close";
            this.btnSaveExit.UseVisualStyleBackColor = true;
            this.btnSaveExit.Click += new System.EventHandler(this.btnSaveExit_Click);
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(24, 765);
            this.lblVersion.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(185, 32);
            this.lblVersion.TabIndex = 11;
            this.lblVersion.Text = "Version: X.X";
            // 
            // SetupForm
            // 
            this.AcceptButton = this.btnSaveExit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1867, 842);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.btnSaveExit);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.MaximizeBox = false;
            this.Name = "SetupForm";
            this.Text = "Hyperion Screen Capture - Setup";
            this.tabControl1.ResumeLayout(false);
            this.tabPageGeneric.ResumeLayout(false);
            this.tabPageGeneric.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.gbCaptureApi.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tabPageAdvanced.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grpDeactivate.ResumeLayout(false);
            this.grpDeactivate.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabPageHelp.ResumeLayout(false);
            this.tabPageHelp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabPageGeneric;
    private System.Windows.Forms.TextBox tbProtoPort;
    private System.Windows.Forms.Label lblProtoPort;
    private System.Windows.Forms.TextBox tbIPHostName;
    private System.Windows.Forms.Label lblIPHostName;
    private System.Windows.Forms.TabPage tabPageAdvanced;
    private System.Windows.Forms.ComboBox cbNotificationLevel;
    private System.Windows.Forms.Label lblNotificationLevel;
    private System.Windows.Forms.ComboBox cbMessagePriority;
    private System.Windows.Forms.Label lblMessagePriority;
    private System.Windows.Forms.TextBox tbMessageDuration;
    private System.Windows.Forms.Label lblMessageDuration;
    private System.Windows.Forms.TextBox tbCaptureHeight;
    private System.Windows.Forms.Label lblCaptureHeight;
    private System.Windows.Forms.TextBox tbCaptureWidth;
    private System.Windows.Forms.Label lblCaptureWidth;
    private System.Windows.Forms.TextBox tbCaptureInterval;
    private System.Windows.Forms.Label lblCaptureInterval;
    private System.Windows.Forms.Button btnSaveExit;
    private System.Windows.Forms.Label lblApiPort;
    private System.Windows.Forms.TextBox tbApiPort;
    private System.Windows.Forms.CheckBox chkApiEnabled;
        private System.Windows.Forms.GroupBox grpDeactivate;
        private System.Windows.Forms.TextBox tbApiExcludeEnd;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.TextBox tbApiExcludeStart;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.CheckBox chkApiExcludeTimesEnabled;
        private System.Windows.Forms.CheckBox chkCaptureOnStartup;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox cbMonitorIndex;
        private System.Windows.Forms.Label lblMonitorIndex;
        private System.Windows.Forms.GroupBox gbCaptureApi;
        private System.Windows.Forms.RadioButton rbcmDx11;
        private System.Windows.Forms.RadioButton rbcmDx9;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblDx9Desc;
        private System.Windows.Forms.Label lblDx11Desc;
        private System.Windows.Forms.TextBox tbDx11FrameCaptureTimeout;
        private System.Windows.Forms.Label lblDx11MaxFps;
        private System.Windows.Forms.Label lblDx11FrameCaptureTimeout;
        private System.Windows.Forms.Label lblDx11ImgScalingFactor;
        private System.Windows.Forms.TextBox tbDx11MaxFps;
        private System.Windows.Forms.ComboBox cbDx11ImgScalingFactor;
        private System.Windows.Forms.Label lblDx11MonitorIndex;
        private System.Windows.Forms.Label lblDx11AdapterIndex;
        private System.Windows.Forms.ComboBox cbDx11MonitorIndex;
        private System.Windows.Forms.ComboBox cbDx11AdapterIndex;
        private System.Windows.Forms.TabPage tabPageHelp;
        private System.Windows.Forms.TextBox tbHelp;
        private System.Windows.Forms.LinkLabel lblShowDx11Displays;
        private System.Windows.Forms.Label lblShowDisplaysMsg;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.CheckBox chkPauseSuspend;
        private System.Windows.Forms.CheckBox chkPauseUserSwitch;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.CheckBox chkCheckUpdate;
        private System.Windows.Forms.Button btnCheckUpdates;
        private System.Windows.Forms.Button btnViewLogs;
    }
}