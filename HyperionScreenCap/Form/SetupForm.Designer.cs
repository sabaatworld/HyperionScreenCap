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
            this.Enabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnCaptureSource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnHyperionServers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblShowDisplaysMsg = new System.Windows.Forms.Label();
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
            this.tabControl1.Location = new System.Drawing.Point(2, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(880, 323);
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
            this.tabPageGeneric.Location = new System.Drawing.Point(4, 22);
            this.tabPageGeneric.Name = "tabPageGeneric";
            this.tabPageGeneric.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGeneric.Size = new System.Drawing.Size(872, 297);
            this.tabPageGeneric.TabIndex = 0;
            this.tabPageGeneric.Text = "General";
            // 
            // btnEditTaskConfig
            // 
            this.btnEditTaskConfig.Enabled = false;
            this.btnEditTaskConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditTaskConfig.Location = new System.Drawing.Point(4, 259);
            this.btnEditTaskConfig.Margin = new System.Windows.Forms.Padding(1);
            this.btnEditTaskConfig.Name = "btnEditTaskConfig";
            this.btnEditTaskConfig.Size = new System.Drawing.Size(65, 25);
            this.btnEditTaskConfig.TabIndex = 2;
            this.btnEditTaskConfig.Text = "Edit";
            this.btnEditTaskConfig.UseVisualStyleBackColor = true;
            this.btnEditTaskConfig.Click += new System.EventHandler(this.btnEditTaskConfig_Click);
            // 
            // btnRemoveTaskConfig
            // 
            this.btnRemoveTaskConfig.Enabled = false;
            this.btnRemoveTaskConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold);
            this.btnRemoveTaskConfig.Location = new System.Drawing.Point(442, 259);
            this.btnRemoveTaskConfig.Margin = new System.Windows.Forms.Padding(1);
            this.btnRemoveTaskConfig.Name = "btnRemoveTaskConfig";
            this.btnRemoveTaskConfig.Size = new System.Drawing.Size(65, 25);
            this.btnRemoveTaskConfig.TabIndex = 4;
            this.btnRemoveTaskConfig.Text = "Delete";
            this.btnRemoveTaskConfig.UseVisualStyleBackColor = true;
            this.btnRemoveTaskConfig.Click += new System.EventHandler(this.btnRemoveTaskConfig_Click);
            // 
            // btnAddTaskConfig
            // 
            this.btnAddTaskConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold);
            this.btnAddTaskConfig.Location = new System.Drawing.Point(375, 259);
            this.btnAddTaskConfig.Margin = new System.Windows.Forms.Padding(1);
            this.btnAddTaskConfig.Name = "btnAddTaskConfig";
            this.btnAddTaskConfig.Size = new System.Drawing.Size(65, 25);
            this.btnAddTaskConfig.TabIndex = 3;
            this.btnAddTaskConfig.Text = "Add";
            this.btnAddTaskConfig.UseVisualStyleBackColor = true;
            this.btnAddTaskConfig.Click += new System.EventHandler(this.btnAddTaskConfig_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 15);
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
            this.Enabled,
            this.clmnId,
            this.clmnCaptureSource,
            this.clmnHyperionServers});
            this.dgTaskConfig.Location = new System.Drawing.Point(4, 25);
            this.dgTaskConfig.Margin = new System.Windows.Forms.Padding(1);
            this.dgTaskConfig.MultiSelect = false;
            this.dgTaskConfig.Name = "dgTaskConfig";
            this.dgTaskConfig.ReadOnly = true;
            this.dgTaskConfig.RowHeadersWidth = 46;
            this.dgTaskConfig.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgTaskConfig.RowTemplate.Height = 40;
            this.dgTaskConfig.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgTaskConfig.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgTaskConfig.Size = new System.Drawing.Size(503, 222);
            this.dgTaskConfig.TabIndex = 1;
            this.dgTaskConfig.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgTaskConfig_CellDoubleClick);
            this.dgTaskConfig.SelectionChanged += new System.EventHandler(this.dgTaskConfig_SelectionChanged);
            // 
            // Enabled
            // 
            this.Enabled.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Enabled.HeaderText = "Enabled";
            this.Enabled.MinimumWidth = 6;
            this.Enabled.Name = "Enabled";
            this.Enabled.ReadOnly = true;
            this.Enabled.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Enabled.Width = 59;
            // 
            // clmnId
            // 
            this.clmnId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmnId.FillWeight = 15F;
            this.clmnId.HeaderText = "ID";
            this.clmnId.MinimumWidth = 6;
            this.clmnId.Name = "clmnId";
            this.clmnId.ReadOnly = true;
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
            this.clmnCaptureSource.ReadOnly = true;
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
            this.clmnHyperionServers.ReadOnly = true;
            this.clmnHyperionServers.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clmnHyperionServers.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
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
            this.tableLayoutPanel3.Location = new System.Drawing.Point(517, 3);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 6;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(352, 291);
            this.tableLayoutPanel3.TabIndex = 20;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblShowDisplaysMsg);
            this.panel1.Controls.Add(this.lblShowDx11Displays);
            this.panel1.Controls.Add(this.lblApiPort);
            this.panel1.Controls.Add(this.chkApiEnabled);
            this.panel1.Controls.Add(this.tbApiPort);
            this.panel1.Controls.Add(this.grpDeactivate);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1, 137);
            this.panel1.Margin = new System.Windows.Forms.Padding(1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 161);
            this.panel1.TabIndex = 34;
            // 
            // lblShowDisplaysMsg
            // 
            this.lblShowDisplaysMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblShowDisplaysMsg.AutoSize = true;
            this.lblShowDisplaysMsg.Location = new System.Drawing.Point(195, 128);
            this.lblShowDisplaysMsg.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblShowDisplaysMsg.Name = "lblShowDisplaysMsg";
            this.lblShowDisplaysMsg.Size = new System.Drawing.Size(146, 15);
            this.lblShowDisplaysMsg.TabIndex = 37;
            this.lblShowDisplaysMsg.Text = "to view monitors for DX11";
            // 
            // lblShowDx11Displays
            // 
            this.lblShowDx11Displays.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblShowDx11Displays.AutoSize = true;
            this.lblShowDx11Displays.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblShowDx11Displays.Location = new System.Drawing.Point(132, 128);
            this.lblShowDx11Displays.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblShowDx11Displays.Name = "lblShowDx11Displays";
            this.lblShowDx11Displays.Size = new System.Drawing.Size(61, 15);
            this.lblShowDx11Displays.TabIndex = 36;
            this.lblShowDx11Displays.TabStop = true;
            this.lblShowDx11Displays.Text = "Click here";
            this.lblShowDx11Displays.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblShowDx11Displays_LinkClicked);
            // 
            // lblApiPort
            // 
            this.lblApiPort.AutoSize = true;
            this.lblApiPort.Location = new System.Drawing.Point(9, 3);
            this.lblApiPort.Name = "lblApiPort";
            this.lblApiPort.Size = new System.Drawing.Size(53, 15);
            this.lblApiPort.TabIndex = 25;
            this.lblApiPort.Text = "API Port:";
            // 
            // chkApiEnabled
            // 
            this.chkApiEnabled.AutoSize = true;
            this.chkApiEnabled.Location = new System.Drawing.Point(135, 3);
            this.chkApiEnabled.Name = "chkApiEnabled";
            this.chkApiEnabled.Size = new System.Drawing.Size(86, 19);
            this.chkApiEnabled.TabIndex = 27;
            this.chkApiEnabled.Text = "Enable API";
            this.chkApiEnabled.UseVisualStyleBackColor = true;
            // 
            // tbApiPort
            // 
            this.tbApiPort.Location = new System.Drawing.Point(60, 2);
            this.tbApiPort.Name = "tbApiPort";
            this.tbApiPort.Size = new System.Drawing.Size(60, 20);
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
            this.grpDeactivate.Location = new System.Drawing.Point(6, 31);
            this.grpDeactivate.Name = "grpDeactivate";
            this.grpDeactivate.Size = new System.Drawing.Size(320, 84);
            this.grpDeactivate.TabIndex = 28;
            this.grpDeactivate.TabStop = false;
            this.grpDeactivate.Text = "Disable API control during specified time range";
            // 
            // chkApiExcludeTimesEnabled
            // 
            this.chkApiExcludeTimesEnabled.AutoSize = true;
            this.chkApiExcludeTimesEnabled.Location = new System.Drawing.Point(6, 23);
            this.chkApiExcludeTimesEnabled.Name = "chkApiExcludeTimesEnabled";
            this.chkApiExcludeTimesEnabled.Size = new System.Drawing.Size(72, 19);
            this.chkApiExcludeTimesEnabled.TabIndex = 29;
            this.chkApiExcludeTimesEnabled.Text = "Enabled";
            this.chkApiExcludeTimesEnabled.UseVisualStyleBackColor = true;
            // 
            // tbApiExcludeEnd
            // 
            this.tbApiExcludeEnd.Location = new System.Drawing.Point(192, 46);
            this.tbApiExcludeEnd.Name = "tbApiExcludeEnd";
            this.tbApiExcludeEnd.Size = new System.Drawing.Size(50, 20);
            this.tbApiExcludeEnd.TabIndex = 33;
            this.tbApiExcludeEnd.Text = "21:00";
            this.tbApiExcludeEnd.Validating += new System.ComponentModel.CancelEventHandler(this.tbExcludeEnd_Validating);
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Location = new System.Drawing.Point(127, 49);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(32, 15);
            this.lblEnd.TabIndex = 32;
            this.lblEnd.Text = "End:";
            // 
            // tbApiExcludeStart
            // 
            this.tbApiExcludeStart.Location = new System.Drawing.Point(192, 21);
            this.tbApiExcludeStart.Name = "tbApiExcludeStart";
            this.tbApiExcludeStart.Size = new System.Drawing.Size(50, 20);
            this.tbApiExcludeStart.TabIndex = 31;
            this.tbApiExcludeStart.Text = "8:00";
            this.tbApiExcludeStart.Validating += new System.ComponentModel.CancelEventHandler(this.tbExcludeStart_Validating);
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(127, 24);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(35, 15);
            this.lblStart.TabIndex = 30;
            this.lblStart.Text = "Start:";
            // 
            // chkCheckUpdate
            // 
            this.chkCheckUpdate.AutoSize = true;
            this.chkCheckUpdate.Location = new System.Drawing.Point(3, 78);
            this.chkCheckUpdate.Name = "chkCheckUpdate";
            this.chkCheckUpdate.Size = new System.Drawing.Size(171, 19);
            this.chkCheckUpdate.TabIndex = 14;
            this.chkCheckUpdate.Text = "Check for Updates on Start";
            this.chkCheckUpdate.UseVisualStyleBackColor = true;
            // 
            // chkPauseSuspend
            // 
            this.chkPauseSuspend.AutoSize = true;
            this.chkPauseSuspend.Location = new System.Drawing.Point(3, 53);
            this.chkPauseSuspend.Name = "chkPauseSuspend";
            this.chkPauseSuspend.Size = new System.Drawing.Size(173, 19);
            this.chkPauseSuspend.TabIndex = 13;
            this.chkPauseSuspend.Text = "Pause on System Suspend";
            this.chkPauseSuspend.UseVisualStyleBackColor = true;
            // 
            // chkPauseUserSwitch
            // 
            this.chkPauseUserSwitch.AutoSize = true;
            this.chkPauseUserSwitch.Location = new System.Drawing.Point(3, 28);
            this.chkPauseUserSwitch.Name = "chkPauseUserSwitch";
            this.chkPauseUserSwitch.Size = new System.Drawing.Size(146, 19);
            this.chkPauseUserSwitch.TabIndex = 12;
            this.chkPauseUserSwitch.Text = "Pause on User Switch";
            this.chkPauseUserSwitch.UseVisualStyleBackColor = true;
            // 
            // chkCaptureOnStartup
            // 
            this.chkCaptureOnStartup.AutoSize = true;
            this.chkCaptureOnStartup.Location = new System.Drawing.Point(3, 3);
            this.chkCaptureOnStartup.Name = "chkCaptureOnStartup";
            this.chkCaptureOnStartup.Size = new System.Drawing.Size(214, 19);
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 101);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(350, 34);
            this.tableLayoutPanel1.TabIndex = 21;
            // 
            // lblNotificationLevel
            // 
            this.lblNotificationLevel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNotificationLevel.AutoSize = true;
            this.lblNotificationLevel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNotificationLevel.Location = new System.Drawing.Point(3, 9);
            this.lblNotificationLevel.Name = "lblNotificationLevel";
            this.lblNotificationLevel.Size = new System.Drawing.Size(99, 15);
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
            this.cbNotificationLevel.Location = new System.Drawing.Point(122, 6);
            this.cbNotificationLevel.Name = "cbNotificationLevel";
            this.cbNotificationLevel.Size = new System.Drawing.Size(100, 21);
            this.cbNotificationLevel.TabIndex = 16;
            // 
            // tabPageHelp
            // 
            this.tabPageHelp.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageHelp.Controls.Add(this.wbHelpContent);
            this.tabPageHelp.Location = new System.Drawing.Point(4, 22);
            this.tabPageHelp.Margin = new System.Windows.Forms.Padding(1);
            this.tabPageHelp.Name = "tabPageHelp";
            this.tabPageHelp.Padding = new System.Windows.Forms.Padding(1);
            this.tabPageHelp.Size = new System.Drawing.Size(872, 297);
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
            this.wbHelpContent.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbHelpContent.Name = "wbHelpContent";
            this.wbHelpContent.Size = new System.Drawing.Size(870, 295);
            this.wbHelpContent.TabIndex = 0;
            this.wbHelpContent.WebBrowserShortcutsEnabled = false;
            // 
            // btnCheckUpdates
            // 
            this.btnCheckUpdates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckUpdates.Location = new System.Drawing.Point(515, 341);
            this.btnCheckUpdates.Margin = new System.Windows.Forms.Padding(1);
            this.btnCheckUpdates.Name = "btnCheckUpdates";
            this.btnCheckUpdates.Size = new System.Drawing.Size(120, 27);
            this.btnCheckUpdates.TabIndex = 40;
            this.btnCheckUpdates.Text = "Check for Updates";
            this.btnCheckUpdates.UseVisualStyleBackColor = true;
            this.btnCheckUpdates.Click += new System.EventHandler(this.btnCheckUpdates_Click);
            // 
            // btnViewLogs
            // 
            this.btnViewLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewLogs.Location = new System.Drawing.Point(637, 341);
            this.btnViewLogs.Margin = new System.Windows.Forms.Padding(1);
            this.btnViewLogs.Name = "btnViewLogs";
            this.btnViewLogs.Size = new System.Drawing.Size(120, 27);
            this.btnViewLogs.TabIndex = 41;
            this.btnViewLogs.Text = "View Logs";
            this.btnViewLogs.UseVisualStyleBackColor = true;
            this.btnViewLogs.Click += new System.EventHandler(this.btnViewLogs_Click);
            // 
            // btnSaveExit
            // 
            this.btnSaveExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveExit.Location = new System.Drawing.Point(761, 341);
            this.btnSaveExit.Name = "btnSaveExit";
            this.btnSaveExit.Size = new System.Drawing.Size(120, 27);
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
            this.lblVersion.Location = new System.Drawing.Point(14, 348);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(91, 16);
            this.lblVersion.TabIndex = 11;
            this.lblVersion.Text = "Version: X.X";
            // 
            // btnDonate
            // 
            this.btnDonate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDonate.Location = new System.Drawing.Point(393, 341);
            this.btnDonate.Margin = new System.Windows.Forms.Padding(1);
            this.btnDonate.Name = "btnDonate";
            this.btnDonate.Size = new System.Drawing.Size(120, 27);
            this.btnDonate.TabIndex = 100;
            this.btnDonate.Text = "<Placeholder>";
            this.btnDonate.UseVisualStyleBackColor = true;
            this.btnDonate.Click += new System.EventHandler(this.btnDonate_Click);
            // 
            // SetupForm
            // 
            this.AcceptButton = this.btnSaveExit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(882, 374);
            this.Controls.Add(this.btnDonate);
            this.Controls.Add(this.btnViewLogs);
            this.Controls.Add(this.btnCheckUpdates);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.btnSaveExit);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
        private System.Windows.Forms.Label lblShowDisplaysMsg;
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
        private System.Windows.Forms.DataGridViewCheckBoxColumn Enabled;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnCaptureSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnHyperionServers;
        private System.Windows.Forms.WebBrowser wbHelpContent;
    }
}