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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetupForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageGeneric = new System.Windows.Forms.TabPage();
            this.btnEditTaskConfig = new System.Windows.Forms.Button();
            this.btnRemoveTaskConfig = new System.Windows.Forms.Button();
            this.btnAddTaskConfig = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgTaskConfig = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblShowDx11Displays = new System.Windows.Forms.LinkLabel();
            this.lblApiPort = new System.Windows.Forms.Label();
            this.chkApiEnabled = new System.Windows.Forms.CheckBox();
            this.tbApiPort = new System.Windows.Forms.TextBox();
            this.grpDeactivate = new System.Windows.Forms.GroupBox();
            this.chkApiExcludeTimesEnabled = new System.Windows.Forms.CheckBox();
            this.tbApiExcludeEnd = new System.Windows.Forms.TextBox();
            this.lblEnd = new System.Windows.Forms.Label();
            this.tbApiExcludeStart = new System.Windows.Forms.TextBox();
            this.lblStart = new System.Windows.Forms.Label();
            this.chkCheckUpdate = new System.Windows.Forms.CheckBox();
            this.chkPauseSuspend = new System.Windows.Forms.CheckBox();
            this.chkPauseUserSwitch = new System.Windows.Forms.CheckBox();
            this.chkCaptureOnStartup = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblNotificationLevel = new System.Windows.Forms.Label();
            this.cbNotificationLevel = new System.Windows.Forms.ComboBox();
            this.tabPageHelp = new System.Windows.Forms.TabPage();
            this.wbHelpContent = new System.Windows.Forms.WebBrowser();
            this.btnCheckUpdates = new System.Windows.Forms.Button();
            this.btnViewLogs = new System.Windows.Forms.Button();
            this.btnSaveExit = new System.Windows.Forms.Button();
            this.lblVersion = new System.Windows.Forms.Label();
            this.btnDonate = new System.Windows.Forms.Button();
            this.clmnEnabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnCaptureSource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnHyperionServers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPageGeneric.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTaskConfig)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.grpDeactivate.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabPageHelp.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageGeneric);
            this.tabControl1.Controls.Add(this.tabPageHelp);
            this.tabControl1.Location = new System.Drawing.Point(3, 5);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1173, 398);
            this.tabControl1.TabIndex = 99;
            // 
            // tabPageGeneric
            // 
            this.tabPageGeneric.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageGeneric.Controls.Add(this.btnEditTaskConfig);
            this.tabPageGeneric.Controls.Add(this.btnRemoveTaskConfig);
            this.tabPageGeneric.Controls.Add(this.btnAddTaskConfig);
            this.tabPageGeneric.Controls.Add(this.label1);
            this.tabPageGeneric.Controls.Add(this.dgTaskConfig);
            this.tabPageGeneric.Controls.Add(this.tableLayoutPanel3);
            this.tabPageGeneric.Location = new System.Drawing.Point(4, 25);
            this.tabPageGeneric.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPageGeneric.Name = "tabPageGeneric";
            this.tabPageGeneric.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPageGeneric.Size = new System.Drawing.Size(1165, 369);
            this.tabPageGeneric.TabIndex = 0;
            this.tabPageGeneric.Text = "General";
            // 
            // btnEditTaskConfig
            // 
            this.btnEditTaskConfig.Enabled = false;
            this.btnEditTaskConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditTaskConfig.Location = new System.Drawing.Point(5, 319);
            this.btnEditTaskConfig.Margin = new System.Windows.Forms.Padding(1);
            this.btnEditTaskConfig.Name = "btnEditTaskConfig";
            this.btnEditTaskConfig.Size = new System.Drawing.Size(87, 31);
            this.btnEditTaskConfig.TabIndex = 2;
            this.btnEditTaskConfig.Text = "Edit";
            this.btnEditTaskConfig.UseVisualStyleBackColor = true;
            this.btnEditTaskConfig.Click += new System.EventHandler(this.btnEditTaskConfig_Click);
            // 
            // btnRemoveTaskConfig
            // 
            this.btnRemoveTaskConfig.Enabled = false;
            this.btnRemoveTaskConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold);
            this.btnRemoveTaskConfig.Location = new System.Drawing.Point(589, 319);
            this.btnRemoveTaskConfig.Margin = new System.Windows.Forms.Padding(1);
            this.btnRemoveTaskConfig.Name = "btnRemoveTaskConfig";
            this.btnRemoveTaskConfig.Size = new System.Drawing.Size(87, 31);
            this.btnRemoveTaskConfig.TabIndex = 4;
            this.btnRemoveTaskConfig.Text = "Delete";
            this.btnRemoveTaskConfig.UseVisualStyleBackColor = true;
            this.btnRemoveTaskConfig.Click += new System.EventHandler(this.btnRemoveTaskConfig_Click);
            // 
            // btnAddTaskConfig
            // 
            this.btnAddTaskConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold);
            this.btnAddTaskConfig.Location = new System.Drawing.Point(500, 319);
            this.btnAddTaskConfig.Margin = new System.Windows.Forms.Padding(1);
            this.btnAddTaskConfig.Name = "btnAddTaskConfig";
            this.btnAddTaskConfig.Size = new System.Drawing.Size(87, 31);
            this.btnAddTaskConfig.TabIndex = 3;
            this.btnAddTaskConfig.Text = "Add";
            this.btnAddTaskConfig.UseVisualStyleBackColor = true;
            this.btnAddTaskConfig.Click += new System.EventHandler(this.btnAddTaskConfig_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 16);
            this.label1.TabIndex = 22;
            this.label1.Text = "Capture (DirectX) Settings";
            // 
            // dgTaskConfig
            // 
            this.dgTaskConfig.AllowUserToAddRows = false;
            this.dgTaskConfig.AllowUserToDeleteRows = false;
            this.dgTaskConfig.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgTaskConfig.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTaskConfig.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnEnabled,
            this.clmnId,
            this.clmnCaptureSource,
            this.clmnHyperionServers});
            this.dgTaskConfig.Location = new System.Drawing.Point(5, 31);
            this.dgTaskConfig.Margin = new System.Windows.Forms.Padding(1);
            this.dgTaskConfig.MultiSelect = false;
            this.dgTaskConfig.Name = "dgTaskConfig";
            this.dgTaskConfig.RowHeadersWidth = 46;
            this.dgTaskConfig.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgTaskConfig.RowTemplate.Height = 40;
            this.dgTaskConfig.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgTaskConfig.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgTaskConfig.Size = new System.Drawing.Size(671, 273);
            this.dgTaskConfig.TabIndex = 1;
            this.dgTaskConfig.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgTaskConfig_CellDoubleClick);
            this.dgTaskConfig.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgTaskConfig_RowsAdded);
            this.dgTaskConfig.SelectionChanged += new System.EventHandler(this.dgTaskConfig_SelectionChanged);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.panel1, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.chkCheckUpdate, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.chkPauseSuspend, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.chkPauseUserSwitch, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.chkCaptureOnStartup, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel1, 0, 4);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(692, 4);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 6;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(469, 361);
            this.tableLayoutPanel3.TabIndex = 20;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblShowDx11Displays);
            this.panel1.Controls.Add(this.lblApiPort);
            this.panel1.Controls.Add(this.chkApiEnabled);
            this.panel1.Controls.Add(this.tbApiPort);
            this.panel1.Controls.Add(this.grpDeactivate);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1, 157);
            this.panel1.Margin = new System.Windows.Forms.Padding(1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(467, 215);
            this.panel1.TabIndex = 34;
            // 
            // lblShowDx11Displays
            // 
            this.lblShowDx11Displays.AutoSize = true;
            this.lblShowDx11Displays.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblShowDx11Displays.Location = new System.Drawing.Point(8, 174);
            this.lblShowDx11Displays.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblShowDx11Displays.Name = "lblShowDx11Displays";
            this.lblShowDx11Displays.Size = new System.Drawing.Size(218, 16);
            this.lblShowDx11Displays.TabIndex = 36;
            this.lblShowDx11Displays.TabStop = true;
            this.lblShowDx11Displays.Text = "Click here to view monitors for DX11";
            this.lblShowDx11Displays.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblShowDx11Displays_LinkClicked);
            // 
            // lblApiPort
            // 
            this.lblApiPort.AutoSize = true;
            this.lblApiPort.Location = new System.Drawing.Point(12, 4);
            this.lblApiPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblApiPort.Name = "lblApiPort";
            this.lblApiPort.Size = new System.Drawing.Size(59, 16);
            this.lblApiPort.TabIndex = 25;
            this.lblApiPort.Text = "API Port:";
            // 
            // chkApiEnabled
            // 
            this.chkApiEnabled.AutoSize = true;
            this.chkApiEnabled.Location = new System.Drawing.Point(180, 4);
            this.chkApiEnabled.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkApiEnabled.Name = "chkApiEnabled";
            this.chkApiEnabled.Size = new System.Drawing.Size(94, 20);
            this.chkApiEnabled.TabIndex = 27;
            this.chkApiEnabled.Text = "Enable API";
            this.chkApiEnabled.UseVisualStyleBackColor = true;
            // 
            // tbApiPort
            // 
            this.tbApiPort.Location = new System.Drawing.Point(80, 2);
            this.tbApiPort.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbApiPort.Name = "tbApiPort";
            this.tbApiPort.Size = new System.Drawing.Size(79, 22);
            this.tbApiPort.TabIndex = 26;
            this.tbApiPort.Validating += new System.ComponentModel.CancelEventHandler(this.tbApiPort_Validating);
            // 
            // grpDeactivate
            // 
            this.grpDeactivate.Controls.Add(this.chkApiExcludeTimesEnabled);
            this.grpDeactivate.Controls.Add(this.tbApiExcludeEnd);
            this.grpDeactivate.Controls.Add(this.lblEnd);
            this.grpDeactivate.Controls.Add(this.tbApiExcludeStart);
            this.grpDeactivate.Controls.Add(this.lblStart);
            this.grpDeactivate.Location = new System.Drawing.Point(8, 38);
            this.grpDeactivate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpDeactivate.Name = "grpDeactivate";
            this.grpDeactivate.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpDeactivate.Size = new System.Drawing.Size(427, 103);
            this.grpDeactivate.TabIndex = 28;
            this.grpDeactivate.TabStop = false;
            this.grpDeactivate.Text = "Disable API control during specified time range";
            // 
            // chkApiExcludeTimesEnabled
            // 
            this.chkApiExcludeTimesEnabled.AutoSize = true;
            this.chkApiExcludeTimesEnabled.Location = new System.Drawing.Point(8, 28);
            this.chkApiExcludeTimesEnabled.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkApiExcludeTimesEnabled.Name = "chkApiExcludeTimesEnabled";
            this.chkApiExcludeTimesEnabled.Size = new System.Drawing.Size(78, 20);
            this.chkApiExcludeTimesEnabled.TabIndex = 29;
            this.chkApiExcludeTimesEnabled.Text = "Enabled";
            this.chkApiExcludeTimesEnabled.UseVisualStyleBackColor = true;
            // 
            // tbApiExcludeEnd
            // 
            this.tbApiExcludeEnd.Location = new System.Drawing.Point(256, 57);
            this.tbApiExcludeEnd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbApiExcludeEnd.Name = "tbApiExcludeEnd";
            this.tbApiExcludeEnd.Size = new System.Drawing.Size(65, 22);
            this.tbApiExcludeEnd.TabIndex = 33;
            this.tbApiExcludeEnd.Text = "21:00";
            this.tbApiExcludeEnd.Validating += new System.ComponentModel.CancelEventHandler(this.tbExcludeEnd_Validating);
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Location = new System.Drawing.Point(169, 60);
            this.lblEnd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(35, 16);
            this.lblEnd.TabIndex = 32;
            this.lblEnd.Text = "End:";
            // 
            // tbApiExcludeStart
            // 
            this.tbApiExcludeStart.Location = new System.Drawing.Point(256, 26);
            this.tbApiExcludeStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbApiExcludeStart.Name = "tbApiExcludeStart";
            this.tbApiExcludeStart.Size = new System.Drawing.Size(65, 22);
            this.tbApiExcludeStart.TabIndex = 31;
            this.tbApiExcludeStart.Text = "8:00";
            this.tbApiExcludeStart.Validating += new System.ComponentModel.CancelEventHandler(this.tbExcludeStart_Validating);
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(169, 30);
            this.lblStart.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(38, 16);
            this.lblStart.TabIndex = 30;
            this.lblStart.Text = "Start:";
            // 
            // chkCheckUpdate
            // 
            this.chkCheckUpdate.AutoSize = true;
            this.chkCheckUpdate.Location = new System.Drawing.Point(4, 88);
            this.chkCheckUpdate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkCheckUpdate.Name = "chkCheckUpdate";
            this.chkCheckUpdate.Size = new System.Drawing.Size(186, 20);
            this.chkCheckUpdate.TabIndex = 14;
            this.chkCheckUpdate.Text = "Check for Updates on Start";
            this.chkCheckUpdate.UseVisualStyleBackColor = true;
            // 
            // chkPauseSuspend
            // 
            this.chkPauseSuspend.AutoSize = true;
            this.chkPauseSuspend.Location = new System.Drawing.Point(4, 60);
            this.chkPauseSuspend.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkPauseSuspend.Name = "chkPauseSuspend";
            this.chkPauseSuspend.Size = new System.Drawing.Size(189, 20);
            this.chkPauseSuspend.TabIndex = 13;
            this.chkPauseSuspend.Text = "Pause on System Suspend";
            this.chkPauseSuspend.UseVisualStyleBackColor = true;
            // 
            // chkPauseUserSwitch
            // 
            this.chkPauseUserSwitch.AutoSize = true;
            this.chkPauseUserSwitch.Location = new System.Drawing.Point(4, 32);
            this.chkPauseUserSwitch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkPauseUserSwitch.Name = "chkPauseUserSwitch";
            this.chkPauseUserSwitch.Size = new System.Drawing.Size(157, 20);
            this.chkPauseUserSwitch.TabIndex = 12;
            this.chkPauseUserSwitch.Text = "Pause on User Switch";
            this.chkPauseUserSwitch.UseVisualStyleBackColor = true;
            // 
            // chkCaptureOnStartup
            // 
            this.chkCaptureOnStartup.AutoSize = true;
            this.chkCaptureOnStartup.Location = new System.Drawing.Point(4, 4);
            this.chkCaptureOnStartup.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkCaptureOnStartup.Name = "chkCaptureOnStartup";
            this.chkCaptureOnStartup.Size = new System.Drawing.Size(233, 20);
            this.chkCaptureOnStartup.TabIndex = 11;
            this.chkCaptureOnStartup.Text = "Start Screen Capture Automatically";
            this.chkCaptureOnStartup.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.23545F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.76455F));
            this.tableLayoutPanel1.Controls.Add(this.lblNotificationLevel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbNotificationLevel, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 113);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(467, 42);
            this.tableLayoutPanel1.TabIndex = 21;
            // 
            // lblNotificationLevel
            // 
            this.lblNotificationLevel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNotificationLevel.AutoSize = true;
            this.lblNotificationLevel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNotificationLevel.Location = new System.Drawing.Point(4, 13);
            this.lblNotificationLevel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNotificationLevel.Name = "lblNotificationLevel";
            this.lblNotificationLevel.Size = new System.Drawing.Size(109, 16);
            this.lblNotificationLevel.TabIndex = 15;
            this.lblNotificationLevel.Text = "Notification level:";
            // 
            // cbNotificationLevel
            // 
            this.cbNotificationLevel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbNotificationLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNotificationLevel.FormattingEnabled = true;
            this.cbNotificationLevel.Items.AddRange(new object[] {
            "Info",
            "Error",
            "None"});
            this.cbNotificationLevel.Location = new System.Drawing.Point(163, 9);
            this.cbNotificationLevel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbNotificationLevel.Name = "cbNotificationLevel";
            this.cbNotificationLevel.Size = new System.Drawing.Size(132, 24);
            this.cbNotificationLevel.TabIndex = 16;
            // 
            // tabPageHelp
            // 
            this.tabPageHelp.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageHelp.Controls.Add(this.wbHelpContent);
            this.tabPageHelp.Location = new System.Drawing.Point(4, 25);
            this.tabPageHelp.Margin = new System.Windows.Forms.Padding(1);
            this.tabPageHelp.Name = "tabPageHelp";
            this.tabPageHelp.Padding = new System.Windows.Forms.Padding(1);
            this.tabPageHelp.Size = new System.Drawing.Size(1165, 369);
            this.tabPageHelp.TabIndex = 2;
            this.tabPageHelp.Text = "Help";
            // 
            // wbHelpContent
            // 
            this.wbHelpContent.AllowNavigation = false;
            this.wbHelpContent.AllowWebBrowserDrop = false;
            this.wbHelpContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbHelpContent.IsWebBrowserContextMenuEnabled = false;
            this.wbHelpContent.Location = new System.Drawing.Point(1, 1);
            this.wbHelpContent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.wbHelpContent.MinimumSize = new System.Drawing.Size(27, 25);
            this.wbHelpContent.Name = "wbHelpContent";
            this.wbHelpContent.Size = new System.Drawing.Size(1163, 367);
            this.wbHelpContent.TabIndex = 0;
            this.wbHelpContent.WebBrowserShortcutsEnabled = false;
            // 
            // btnCheckUpdates
            // 
            this.btnCheckUpdates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckUpdates.Location = new System.Drawing.Point(687, 420);
            this.btnCheckUpdates.Margin = new System.Windows.Forms.Padding(1);
            this.btnCheckUpdates.Name = "btnCheckUpdates";
            this.btnCheckUpdates.Size = new System.Drawing.Size(160, 33);
            this.btnCheckUpdates.TabIndex = 40;
            this.btnCheckUpdates.Text = "Check for Updates";
            this.btnCheckUpdates.UseVisualStyleBackColor = true;
            this.btnCheckUpdates.Click += new System.EventHandler(this.btnCheckUpdates_Click);
            // 
            // btnViewLogs
            // 
            this.btnViewLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewLogs.Location = new System.Drawing.Point(849, 420);
            this.btnViewLogs.Margin = new System.Windows.Forms.Padding(1);
            this.btnViewLogs.Name = "btnViewLogs";
            this.btnViewLogs.Size = new System.Drawing.Size(160, 33);
            this.btnViewLogs.TabIndex = 41;
            this.btnViewLogs.Text = "View Logs";
            this.btnViewLogs.UseVisualStyleBackColor = true;
            this.btnViewLogs.Click += new System.EventHandler(this.btnViewLogs_Click);
            // 
            // btnSaveExit
            // 
            this.btnSaveExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveExit.Location = new System.Drawing.Point(1015, 420);
            this.btnSaveExit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSaveExit.Name = "btnSaveExit";
            this.btnSaveExit.Size = new System.Drawing.Size(160, 33);
            this.btnSaveExit.TabIndex = 42;
            this.btnSaveExit.Text = "Save and close";
            this.btnSaveExit.UseVisualStyleBackColor = true;
            this.btnSaveExit.Click += new System.EventHandler(this.btnSaveExit_Click);
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(19, 428);
            this.lblVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(77, 13);
            this.lblVersion.TabIndex = 11;
            this.lblVersion.Text = "Version: X.X";
            // 
            // btnDonate
            // 
            this.btnDonate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDonate.Location = new System.Drawing.Point(524, 420);
            this.btnDonate.Margin = new System.Windows.Forms.Padding(1);
            this.btnDonate.Name = "btnDonate";
            this.btnDonate.Size = new System.Drawing.Size(160, 33);
            this.btnDonate.TabIndex = 100;
            this.btnDonate.Text = "<Placeholder>";
            this.btnDonate.UseVisualStyleBackColor = true;
            this.btnDonate.Click += new System.EventHandler(this.btnDonate_Click);
            // 
            // clmnEnabled
            // 
            this.clmnEnabled.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.clmnEnabled.DataPropertyName = "Enabled";
            this.clmnEnabled.HeaderText = "Enabled";
            this.clmnEnabled.MinimumWidth = 6;
            this.clmnEnabled.Name = "clmnEnabled";
            this.clmnEnabled.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clmnEnabled.Width = 65;
            // 
            // clmnId
            // 
            this.clmnId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmnId.DataPropertyName = "Id";
            this.clmnId.FillWeight = 15F;
            this.clmnId.HeaderText = "ID";
            this.clmnId.MinimumWidth = 6;
            this.clmnId.Name = "clmnId";
            this.clmnId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clmnId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clmnCaptureSource
            // 
            this.clmnCaptureSource.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmnCaptureSource.FillWeight = 45F;
            this.clmnCaptureSource.HeaderText = "Capture Source";
            this.clmnCaptureSource.MinimumWidth = 6;
            this.clmnCaptureSource.Name = "clmnCaptureSource";
            this.clmnCaptureSource.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clmnCaptureSource.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clmnHyperionServers
            // 
            this.clmnHyperionServers.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.clmnHyperionServers.DefaultCellStyle = dataGridViewCellStyle1;
            this.clmnHyperionServers.FillWeight = 45F;
            this.clmnHyperionServers.HeaderText = "Hyperion Servers";
            this.clmnHyperionServers.MinimumWidth = 6;
            this.clmnHyperionServers.Name = "clmnHyperionServers";
            this.clmnHyperionServers.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clmnHyperionServers.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SetupForm
            // 
            this.AcceptButton = this.btnSaveExit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1176, 460);
            this.Controls.Add(this.btnDonate);
            this.Controls.Add(this.btnViewLogs);
            this.Controls.Add(this.btnCheckUpdates);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.btnSaveExit);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "SetupForm";
            this.Text = "Hyperion Screen Capture - Setup";
            this.tabControl1.ResumeLayout(false);
            this.tabPageGeneric.ResumeLayout(false);
            this.tabPageGeneric.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTaskConfig)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grpDeactivate.ResumeLayout(false);
            this.grpDeactivate.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabPageHelp.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabPageGeneric;
    private System.Windows.Forms.ComboBox cbNotificationLevel;
    private System.Windows.Forms.Label lblNotificationLevel;
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
        private System.Windows.Forms.TabPage tabPageHelp;
        private System.Windows.Forms.LinkLabel lblShowDx11Displays;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.CheckBox chkPauseSuspend;
        private System.Windows.Forms.CheckBox chkPauseUserSwitch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkCheckUpdate;
        private System.Windows.Forms.Button btnCheckUpdates;
        private System.Windows.Forms.Button btnViewLogs;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgTaskConfig;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRemoveTaskConfig;
        private System.Windows.Forms.Button btnAddTaskConfig;
        private System.Windows.Forms.Button btnEditTaskConfig;
        private System.Windows.Forms.Button btnDonate;
        private System.Windows.Forms.WebBrowser wbHelpContent;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmnEnabled;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnCaptureSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnHyperionServers;
    }
}