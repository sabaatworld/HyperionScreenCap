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
            this.chkCaptureOnStartup = new System.Windows.Forms.CheckBox();
            this.cbMessagePriority = new System.Windows.Forms.ComboBox();
            this.lblMessagePriority = new System.Windows.Forms.Label();
            this.cbMonitorIndex = new System.Windows.Forms.ComboBox();
            this.lnlMonitorIndex = new System.Windows.Forms.Label();
            this.cbNotificationLevel = new System.Windows.Forms.ComboBox();
            this.lblNotificationLevel = new System.Windows.Forms.Label();
            this.tbProtoPort = new System.Windows.Forms.TextBox();
            this.lblProtoPort = new System.Windows.Forms.Label();
            this.tbIPHostName = new System.Windows.Forms.TextBox();
            this.lblIPHostName = new System.Windows.Forms.Label();
            this.tabPageAdvanced = new System.Windows.Forms.TabPage();
            this.grpDeactivate = new System.Windows.Forms.GroupBox();
            this.chkApiExcludeTimesEnabled = new System.Windows.Forms.CheckBox();
            this.tbApiExcludeEnd = new System.Windows.Forms.TextBox();
            this.lblEnd = new System.Windows.Forms.Label();
            this.tbApiExcludeStart = new System.Windows.Forms.TextBox();
            this.lblStart = new System.Windows.Forms.Label();
            this.lblApiPort = new System.Windows.Forms.Label();
            this.tbApiPort = new System.Windows.Forms.TextBox();
            this.chkApiEnabled = new System.Windows.Forms.CheckBox();
            this.tbReconnectInterval = new System.Windows.Forms.TextBox();
            this.lblReconnectInterval = new System.Windows.Forms.Label();
            this.tbCaptureInterval = new System.Windows.Forms.TextBox();
            this.lblCaptureInterval = new System.Windows.Forms.Label();
            this.tbCaptureHeight = new System.Windows.Forms.TextBox();
            this.lblCaptureHeight = new System.Windows.Forms.Label();
            this.tbCaptureWidth = new System.Windows.Forms.TextBox();
            this.lblCaptureWidth = new System.Windows.Forms.Label();
            this.tbMessageDuration = new System.Windows.Forms.TextBox();
            this.lblMessageDuration = new System.Windows.Forms.Label();
            this.btnSaveExit = new System.Windows.Forms.Button();
            this.lblVersion = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPageGeneric.SuspendLayout();
            this.tabPageAdvanced.SuspendLayout();
            this.grpDeactivate.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageGeneric);
            this.tabControl1.Controls.Add(this.tabPageAdvanced);
            this.tabControl1.Location = new System.Drawing.Point(2, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(697, 296);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPageGeneric
            // 
            this.tabPageGeneric.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageGeneric.Controls.Add(this.chkCaptureOnStartup);
            this.tabPageGeneric.Controls.Add(this.cbMessagePriority);
            this.tabPageGeneric.Controls.Add(this.lblMessagePriority);
            this.tabPageGeneric.Controls.Add(this.cbMonitorIndex);
            this.tabPageGeneric.Controls.Add(this.lnlMonitorIndex);
            this.tabPageGeneric.Controls.Add(this.cbNotificationLevel);
            this.tabPageGeneric.Controls.Add(this.lblNotificationLevel);
            this.tabPageGeneric.Controls.Add(this.tbProtoPort);
            this.tabPageGeneric.Controls.Add(this.lblProtoPort);
            this.tabPageGeneric.Controls.Add(this.tbIPHostName);
            this.tabPageGeneric.Controls.Add(this.lblIPHostName);
            this.tabPageGeneric.Location = new System.Drawing.Point(4, 22);
            this.tabPageGeneric.Name = "tabPageGeneric";
            this.tabPageGeneric.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGeneric.Size = new System.Drawing.Size(689, 270);
            this.tabPageGeneric.TabIndex = 0;
            this.tabPageGeneric.Text = "Generic";
            // 
            // chkCaptureOnStartup
            // 
            this.chkCaptureOnStartup.AutoSize = true;
            this.chkCaptureOnStartup.Location = new System.Drawing.Point(9, 197);
            this.chkCaptureOnStartup.Name = "chkCaptureOnStartup";
            this.chkCaptureOnStartup.Size = new System.Drawing.Size(144, 17);
            this.chkCaptureOnStartup.TabIndex = 19;
            this.chkCaptureOnStartup.Text = "Start capture on first start";
            this.chkCaptureOnStartup.UseVisualStyleBackColor = true;
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
            this.cbMessagePriority.Location = new System.Drawing.Point(110, 85);
            this.cbMessagePriority.Name = "cbMessagePriority";
            this.cbMessagePriority.Size = new System.Drawing.Size(100, 21);
            this.cbMessagePriority.TabIndex = 18;
            this.cbMessagePriority.Validating += new System.ComponentModel.CancelEventHandler(this.cbMessagePriority_Validating);
            // 
            // lblMessagePriority
            // 
            this.lblMessagePriority.AutoSize = true;
            this.lblMessagePriority.Location = new System.Drawing.Point(6, 88);
            this.lblMessagePriority.Name = "lblMessagePriority";
            this.lblMessagePriority.Size = new System.Drawing.Size(38, 13);
            this.lblMessagePriority.TabIndex = 17;
            this.lblMessagePriority.Text = "Priority";
            // 
            // cbMonitorIndex
            // 
            this.cbMonitorIndex.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbMonitorIndex.FormattingEnabled = true;
            this.cbMonitorIndex.Location = new System.Drawing.Point(110, 155);
            this.cbMonitorIndex.Name = "cbMonitorIndex";
            this.cbMonitorIndex.Size = new System.Drawing.Size(100, 21);
            this.cbMonitorIndex.TabIndex = 16;
            this.cbMonitorIndex.Text = "0";
            this.cbMonitorIndex.Validating += new System.ComponentModel.CancelEventHandler(this.cbMonitorIndex_Validating);
            // 
            // lnlMonitorIndex
            // 
            this.lnlMonitorIndex.AutoSize = true;
            this.lnlMonitorIndex.Location = new System.Drawing.Point(6, 158);
            this.lnlMonitorIndex.Name = "lnlMonitorIndex";
            this.lnlMonitorIndex.Size = new System.Drawing.Size(73, 13);
            this.lnlMonitorIndex.TabIndex = 15;
            this.lnlMonitorIndex.Text = "Monitor index:";
            // 
            // cbNotificationLevel
            // 
            this.cbNotificationLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNotificationLevel.FormattingEnabled = true;
            this.cbNotificationLevel.Items.AddRange(new object[] {
            "Info",
            "Error",
            "None"});
            this.cbNotificationLevel.Location = new System.Drawing.Point(110, 120);
            this.cbNotificationLevel.Name = "cbNotificationLevel";
            this.cbNotificationLevel.Size = new System.Drawing.Size(100, 21);
            this.cbNotificationLevel.TabIndex = 3;
            // 
            // lblNotificationLevel
            // 
            this.lblNotificationLevel.AutoSize = true;
            this.lblNotificationLevel.Location = new System.Drawing.Point(6, 123);
            this.lblNotificationLevel.Name = "lblNotificationLevel";
            this.lblNotificationLevel.Size = new System.Drawing.Size(88, 13);
            this.lblNotificationLevel.TabIndex = 13;
            this.lblNotificationLevel.Text = "Notification level:";
            // 
            // tbProtoPort
            // 
            this.tbProtoPort.Location = new System.Drawing.Point(110, 50);
            this.tbProtoPort.Name = "tbProtoPort";
            this.tbProtoPort.Size = new System.Drawing.Size(100, 20);
            this.tbProtoPort.TabIndex = 2;
            this.tbProtoPort.Validating += new System.ComponentModel.CancelEventHandler(this.tbProtoPort_Validating);
            // 
            // lblProtoPort
            // 
            this.lblProtoPort.AutoSize = true;
            this.lblProtoPort.Location = new System.Drawing.Point(6, 52);
            this.lblProtoPort.Name = "lblProtoPort";
            this.lblProtoPort.Size = new System.Drawing.Size(29, 13);
            this.lblProtoPort.TabIndex = 11;
            this.lblProtoPort.Text = "Port:";
            // 
            // tbIPHostName
            // 
            this.tbIPHostName.Location = new System.Drawing.Point(110, 15);
            this.tbIPHostName.Name = "tbIPHostName";
            this.tbIPHostName.Size = new System.Drawing.Size(100, 20);
            this.tbIPHostName.TabIndex = 1;
            // 
            // lblIPHostName
            // 
            this.lblIPHostName.AutoSize = true;
            this.lblIPHostName.Location = new System.Drawing.Point(6, 17);
            this.lblIPHostName.Name = "lblIPHostName";
            this.lblIPHostName.Size = new System.Drawing.Size(79, 13);
            this.lblIPHostName.TabIndex = 9;
            this.lblIPHostName.Text = "IP / Hostname:";
            // 
            // tabPageAdvanced
            // 
            this.tabPageAdvanced.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageAdvanced.Controls.Add(this.grpDeactivate);
            this.tabPageAdvanced.Controls.Add(this.lblApiPort);
            this.tabPageAdvanced.Controls.Add(this.tbApiPort);
            this.tabPageAdvanced.Controls.Add(this.chkApiEnabled);
            this.tabPageAdvanced.Controls.Add(this.tbReconnectInterval);
            this.tabPageAdvanced.Controls.Add(this.lblReconnectInterval);
            this.tabPageAdvanced.Controls.Add(this.tbCaptureInterval);
            this.tabPageAdvanced.Controls.Add(this.lblCaptureInterval);
            this.tabPageAdvanced.Controls.Add(this.tbCaptureHeight);
            this.tabPageAdvanced.Controls.Add(this.lblCaptureHeight);
            this.tabPageAdvanced.Controls.Add(this.tbCaptureWidth);
            this.tabPageAdvanced.Controls.Add(this.lblCaptureWidth);
            this.tabPageAdvanced.Controls.Add(this.tbMessageDuration);
            this.tabPageAdvanced.Controls.Add(this.lblMessageDuration);
            this.tabPageAdvanced.Location = new System.Drawing.Point(4, 22);
            this.tabPageAdvanced.Name = "tabPageAdvanced";
            this.tabPageAdvanced.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAdvanced.Size = new System.Drawing.Size(689, 270);
            this.tabPageAdvanced.TabIndex = 1;
            this.tabPageAdvanced.Text = "Advanced";
            // 
            // grpDeactivate
            // 
            this.grpDeactivate.Controls.Add(this.chkApiExcludeTimesEnabled);
            this.grpDeactivate.Controls.Add(this.tbApiExcludeEnd);
            this.grpDeactivate.Controls.Add(this.lblEnd);
            this.grpDeactivate.Controls.Add(this.tbApiExcludeStart);
            this.grpDeactivate.Controls.Add(this.lblStart);
            this.grpDeactivate.Location = new System.Drawing.Point(395, 53);
            this.grpDeactivate.Name = "grpDeactivate";
            this.grpDeactivate.Size = new System.Drawing.Size(287, 106);
            this.grpDeactivate.TabIndex = 13;
            this.grpDeactivate.TabStop = false;
            this.grpDeactivate.Text = "Disable API control during specified time range";
            // 
            // chkApiExcludeTimesEnabled
            // 
            this.chkApiExcludeTimesEnabled.AutoSize = true;
            this.chkApiExcludeTimesEnabled.Location = new System.Drawing.Point(14, 23);
            this.chkApiExcludeTimesEnabled.Name = "chkApiExcludeTimesEnabled";
            this.chkApiExcludeTimesEnabled.Size = new System.Drawing.Size(65, 17);
            this.chkApiExcludeTimesEnabled.TabIndex = 17;
            this.chkApiExcludeTimesEnabled.Text = "Enabled";
            this.chkApiExcludeTimesEnabled.UseVisualStyleBackColor = true;
            // 
            // tbApiExcludeEnd
            // 
            this.tbApiExcludeEnd.Location = new System.Drawing.Point(76, 75);
            this.tbApiExcludeEnd.Name = "tbApiExcludeEnd";
            this.tbApiExcludeEnd.Size = new System.Drawing.Size(50, 20);
            this.tbApiExcludeEnd.TabIndex = 15;
            this.tbApiExcludeEnd.Text = "21:00";
            this.tbApiExcludeEnd.Validating += new System.ComponentModel.CancelEventHandler(this.tbExcludeEnd_Validating);
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Location = new System.Drawing.Point(11, 78);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(29, 13);
            this.lblEnd.TabIndex = 2;
            this.lblEnd.Text = "End:";
            // 
            // tbApiExcludeStart
            // 
            this.tbApiExcludeStart.Location = new System.Drawing.Point(76, 50);
            this.tbApiExcludeStart.Name = "tbApiExcludeStart";
            this.tbApiExcludeStart.Size = new System.Drawing.Size(50, 20);
            this.tbApiExcludeStart.TabIndex = 14;
            this.tbApiExcludeStart.Text = "8:00";
            this.tbApiExcludeStart.Validating += new System.ComponentModel.CancelEventHandler(this.tbExcludeStart_Validating);
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(11, 53);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(32, 13);
            this.lblStart.TabIndex = 0;
            this.lblStart.Text = "Start:";
            // 
            // lblApiPort
            // 
            this.lblApiPort.AutoSize = true;
            this.lblApiPort.Location = new System.Drawing.Point(395, 17);
            this.lblApiPort.Name = "lblApiPort";
            this.lblApiPort.Size = new System.Drawing.Size(45, 13);
            this.lblApiPort.TabIndex = 12;
            this.lblApiPort.Text = "API port";
            // 
            // tbApiPort
            // 
            this.tbApiPort.Location = new System.Drawing.Point(446, 14);
            this.tbApiPort.Name = "tbApiPort";
            this.tbApiPort.Size = new System.Drawing.Size(60, 20);
            this.tbApiPort.TabIndex = 11;
            this.tbApiPort.Validating += new System.ComponentModel.CancelEventHandler(this.tbApiPort_Validating);
            // 
            // chkApiEnabled
            // 
            this.chkApiEnabled.AutoSize = true;
            this.chkApiEnabled.Location = new System.Drawing.Point(512, 16);
            this.chkApiEnabled.Name = "chkApiEnabled";
            this.chkApiEnabled.Size = new System.Drawing.Size(79, 17);
            this.chkApiEnabled.TabIndex = 10;
            this.chkApiEnabled.Text = "Enable API";
            this.chkApiEnabled.UseVisualStyleBackColor = true;
            // 
            // tbReconnectInterval
            // 
            this.tbReconnectInterval.Location = new System.Drawing.Point(143, 172);
            this.tbReconnectInterval.Name = "tbReconnectInterval";
            this.tbReconnectInterval.Size = new System.Drawing.Size(100, 20);
            this.tbReconnectInterval.TabIndex = 9;
            this.tbReconnectInterval.Validating += new System.ComponentModel.CancelEventHandler(this.tbReconnectInterval_Validating);
            // 
            // lblReconnectInterval
            // 
            this.lblReconnectInterval.AutoSize = true;
            this.lblReconnectInterval.Location = new System.Drawing.Point(10, 175);
            this.lblReconnectInterval.Name = "lblReconnectInterval";
            this.lblReconnectInterval.Size = new System.Drawing.Size(122, 13);
            this.lblReconnectInterval.TabIndex = 8;
            this.lblReconnectInterval.Text = "Reconnect interval (ms):";
            // 
            // tbCaptureInterval
            // 
            this.tbCaptureInterval.Location = new System.Drawing.Point(143, 127);
            this.tbCaptureInterval.Name = "tbCaptureInterval";
            this.tbCaptureInterval.Size = new System.Drawing.Size(100, 20);
            this.tbCaptureInterval.TabIndex = 7;
            this.tbCaptureInterval.Validating += new System.ComponentModel.CancelEventHandler(this.tbCaptureInterval_Validating);
            // 
            // lblCaptureInterval
            // 
            this.lblCaptureInterval.AutoSize = true;
            this.lblCaptureInterval.Location = new System.Drawing.Point(10, 130);
            this.lblCaptureInterval.Name = "lblCaptureInterval";
            this.lblCaptureInterval.Size = new System.Drawing.Size(106, 13);
            this.lblCaptureInterval.TabIndex = 6;
            this.lblCaptureInterval.Text = "Capture interval (ms):";
            // 
            // tbCaptureHeight
            // 
            this.tbCaptureHeight.Location = new System.Drawing.Point(143, 86);
            this.tbCaptureHeight.Name = "tbCaptureHeight";
            this.tbCaptureHeight.Size = new System.Drawing.Size(100, 20);
            this.tbCaptureHeight.TabIndex = 5;
            this.tbCaptureHeight.Validating += new System.ComponentModel.CancelEventHandler(this.tbCaptureHeight_Validating);
            // 
            // lblCaptureHeight
            // 
            this.lblCaptureHeight.AutoSize = true;
            this.lblCaptureHeight.Location = new System.Drawing.Point(7, 89);
            this.lblCaptureHeight.Name = "lblCaptureHeight";
            this.lblCaptureHeight.Size = new System.Drawing.Size(79, 13);
            this.lblCaptureHeight.TabIndex = 4;
            this.lblCaptureHeight.Text = "Capture height:";
            // 
            // tbCaptureWidth
            // 
            this.tbCaptureWidth.Location = new System.Drawing.Point(143, 50);
            this.tbCaptureWidth.Name = "tbCaptureWidth";
            this.tbCaptureWidth.Size = new System.Drawing.Size(100, 20);
            this.tbCaptureWidth.TabIndex = 3;
            this.tbCaptureWidth.Validating += new System.ComponentModel.CancelEventHandler(this.tbCaptureWidth_Validating);
            // 
            // lblCaptureWidth
            // 
            this.lblCaptureWidth.AutoSize = true;
            this.lblCaptureWidth.Location = new System.Drawing.Point(7, 53);
            this.lblCaptureWidth.Name = "lblCaptureWidth";
            this.lblCaptureWidth.Size = new System.Drawing.Size(75, 13);
            this.lblCaptureWidth.TabIndex = 2;
            this.lblCaptureWidth.Text = "Capture width:";
            // 
            // tbMessageDuration
            // 
            this.tbMessageDuration.Location = new System.Drawing.Point(143, 15);
            this.tbMessageDuration.Name = "tbMessageDuration";
            this.tbMessageDuration.Size = new System.Drawing.Size(100, 20);
            this.tbMessageDuration.TabIndex = 1;
            this.tbMessageDuration.Validating += new System.ComponentModel.CancelEventHandler(this.tbMessageDuration_Validating);
            // 
            // lblMessageDuration
            // 
            this.lblMessageDuration.AutoSize = true;
            this.lblMessageDuration.Location = new System.Drawing.Point(7, 17);
            this.lblMessageDuration.Name = "lblMessageDuration";
            this.lblMessageDuration.Size = new System.Drawing.Size(119, 13);
            this.lblMessageDuration.TabIndex = 0;
            this.lblMessageDuration.Text = "Message duration (ms): ";
            // 
            // btnSaveExit
            // 
            this.btnSaveExit.Location = new System.Drawing.Point(563, 305);
            this.btnSaveExit.Name = "btnSaveExit";
            this.btnSaveExit.Size = new System.Drawing.Size(132, 45);
            this.btnSaveExit.TabIndex = 10;
            this.btnSaveExit.Text = "Save and close";
            this.btnSaveExit.UseVisualStyleBackColor = true;
            this.btnSaveExit.Click += new System.EventHandler(this.btnSaveExit_Click);
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(9, 321);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(82, 13);
            this.lblVersion.TabIndex = 11;
            this.lblVersion.Text = "Version: 0.01";
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 353);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.btnSaveExit);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SetupForm";
            this.Text = "Setup";
            this.tabControl1.ResumeLayout(false);
            this.tabPageGeneric.ResumeLayout(false);
            this.tabPageGeneric.PerformLayout();
            this.tabPageAdvanced.ResumeLayout(false);
            this.tabPageAdvanced.PerformLayout();
            this.grpDeactivate.ResumeLayout(false);
            this.grpDeactivate.PerformLayout();
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
    private System.Windows.Forms.ComboBox cbMonitorIndex;
    private System.Windows.Forms.Label lnlMonitorIndex;
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
    private System.Windows.Forms.TextBox tbReconnectInterval;
    private System.Windows.Forms.Label lblReconnectInterval;
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
    }
}