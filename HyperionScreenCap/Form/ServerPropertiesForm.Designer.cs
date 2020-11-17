namespace HyperionScreenCap
{
    partial class ServerPropertiesForm
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
            if ( disposing && (components != null) )
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerPropertiesForm));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.gbCaptureApi = new System.Windows.Forms.GroupBox();
            this.tblScreenCaptureMethod = new System.Windows.Forms.TableLayoutPanel();
            this.rbcmDx9 = new System.Windows.Forms.RadioButton();
            this.rbcmDx11 = new System.Windows.Forms.RadioButton();
            this.tblDx9Values = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbDx9CaptureWidth = new System.Windows.Forms.TextBox();
            this.tbDx9CaptureHeight = new System.Windows.Forms.TextBox();
            this.tbDx9CaptureInterval = new System.Windows.Forms.TextBox();
            this.cbDx9MonitorIndex = new System.Windows.Forms.ComboBox();
            this.tblDx11Values = new System.Windows.Forms.TableLayoutPanel();
            this.cbDx11MonitorIndex = new System.Windows.Forms.ComboBox();
            this.cbDx11AdapterIndex = new System.Windows.Forms.ComboBox();
            this.tbDx11MaxFps = new System.Windows.Forms.TextBox();
            this.tbDx11FrameCaptureTimeout = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbDx11ImageScalingFactor = new System.Windows.Forms.ComboBox();
            this.gBHyperionServers = new System.Windows.Forms.GroupBox();
            this.dgHyperionAddress = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label10 = new System.Windows.Forms.Label();
            this.clmnProtocol = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.clmnHost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnPort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnPriority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnMessageDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbCaptureApi.SuspendLayout();
            this.tblScreenCaptureMethod.SuspendLayout();
            this.tblDx9Values.SuspendLayout();
            this.tblDx11Values.SuspendLayout();
            this.gBHyperionServers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgHyperionAddress)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbCaptureApi
            // 
            this.gbCaptureApi.Controls.Add(this.tblScreenCaptureMethod);
            this.gbCaptureApi.Location = new System.Drawing.Point(5, 6);
            this.gbCaptureApi.Margin = new System.Windows.Forms.Padding(1);
            this.gbCaptureApi.Name = "gbCaptureApi";
            this.gbCaptureApi.Padding = new System.Windows.Forms.Padding(1);
            this.gbCaptureApi.Size = new System.Drawing.Size(675, 424);
            this.gbCaptureApi.TabIndex = 7;
            this.gbCaptureApi.TabStop = false;
            this.gbCaptureApi.Text = "Screen Capture Method";
            // 
            // tblScreenCaptureMethod
            // 
            this.tblScreenCaptureMethod.ColumnCount = 2;
            this.tblScreenCaptureMethod.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.87982F));
            this.tblScreenCaptureMethod.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.12018F));
            this.tblScreenCaptureMethod.Controls.Add(this.rbcmDx9, 0, 1);
            this.tblScreenCaptureMethod.Controls.Add(this.rbcmDx11, 0, 0);
            this.tblScreenCaptureMethod.Controls.Add(this.tblDx9Values, 1, 1);
            this.tblScreenCaptureMethod.Controls.Add(this.tblDx11Values, 1, 0);
            this.tblScreenCaptureMethod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblScreenCaptureMethod.Location = new System.Drawing.Point(1, 16);
            this.tblScreenCaptureMethod.Margin = new System.Windows.Forms.Padding(1);
            this.tblScreenCaptureMethod.Name = "tblScreenCaptureMethod";
            this.tblScreenCaptureMethod.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.tblScreenCaptureMethod.RowCount = 2;
            this.tblScreenCaptureMethod.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblScreenCaptureMethod.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblScreenCaptureMethod.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tblScreenCaptureMethod.Size = new System.Drawing.Size(673, 407);
            this.tblScreenCaptureMethod.TabIndex = 0;
            // 
            // rbcmDx9
            // 
            this.rbcmDx9.AutoSize = true;
            this.rbcmDx9.Location = new System.Drawing.Point(6, 204);
            this.rbcmDx9.Margin = new System.Windows.Forms.Padding(1);
            this.rbcmDx9.Name = "rbcmDx9";
            this.rbcmDx9.Size = new System.Drawing.Size(122, 84);
            this.rbcmDx9.TabIndex = 7;
            this.rbcmDx9.TabStop = true;
            this.rbcmDx9.Text = "DirectX 9\r\n- Windows XP+\r\n- Moderate CPU\r\n- Low GPU\r\n- Low FPS\r\n";
            this.rbcmDx9.UseVisualStyleBackColor = true;
            // 
            // rbcmDx11
            // 
            this.rbcmDx11.AutoSize = true;
            this.rbcmDx11.Location = new System.Drawing.Point(6, 6);
            this.rbcmDx11.Margin = new System.Windows.Forms.Padding(1);
            this.rbcmDx11.Name = "rbcmDx11";
            this.rbcmDx11.Size = new System.Drawing.Size(133, 84);
            this.rbcmDx11.TabIndex = 1;
            this.rbcmDx11.TabStop = true;
            this.rbcmDx11.Text = "DirectX 11\r\n- Windows 7 SP1+\r\n- Negligible CPU\r\n- Very Low GPU\r\n- High FPS\r\n";
            this.rbcmDx11.UseVisualStyleBackColor = true;
            this.rbcmDx11.CheckedChanged += new System.EventHandler(this.rbcmDx11_CheckedChanged);
            // 
            // tblDx9Values
            // 
            this.tblDx9Values.ColumnCount = 2;
            this.tblDx9Values.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblDx9Values.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblDx9Values.Controls.Add(this.label1, 0, 0);
            this.tblDx9Values.Controls.Add(this.label2, 0, 1);
            this.tblDx9Values.Controls.Add(this.label3, 0, 2);
            this.tblDx9Values.Controls.Add(this.label4, 0, 3);
            this.tblDx9Values.Controls.Add(this.tbDx9CaptureWidth, 1, 1);
            this.tblDx9Values.Controls.Add(this.tbDx9CaptureHeight, 1, 2);
            this.tblDx9Values.Controls.Add(this.tbDx9CaptureInterval, 1, 3);
            this.tblDx9Values.Controls.Add(this.cbDx9MonitorIndex, 1, 0);
            this.tblDx9Values.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblDx9Values.Location = new System.Drawing.Point(223, 204);
            this.tblDx9Values.Margin = new System.Windows.Forms.Padding(1);
            this.tblDx9Values.Name = "tblDx9Values";
            this.tblDx9Values.RowCount = 5;
            this.tblDx9Values.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblDx9Values.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblDx9Values.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblDx9Values.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblDx9Values.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblDx9Values.Size = new System.Drawing.Size(444, 197);
            this.tblDx9Values.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Monitor Index";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 39);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Capture Width";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1, 69);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Capture Height";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1, 99);
            this.label4.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Capture Interval (ms)";
            // 
            // tbDx9CaptureWidth
            // 
            this.tbDx9CaptureWidth.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbDx9CaptureWidth.Location = new System.Drawing.Point(226, 36);
            this.tbDx9CaptureWidth.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbDx9CaptureWidth.MaxLength = 5;
            this.tbDx9CaptureWidth.Name = "tbDx9CaptureWidth";
            this.tbDx9CaptureWidth.Size = new System.Drawing.Size(132, 22);
            this.tbDx9CaptureWidth.TabIndex = 9;
            this.tbDx9CaptureWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PreventNonNumeric_KeyPressEventHandler);
            // 
            // tbDx9CaptureHeight
            // 
            this.tbDx9CaptureHeight.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbDx9CaptureHeight.Location = new System.Drawing.Point(226, 66);
            this.tbDx9CaptureHeight.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbDx9CaptureHeight.MaxLength = 5;
            this.tbDx9CaptureHeight.Name = "tbDx9CaptureHeight";
            this.tbDx9CaptureHeight.Size = new System.Drawing.Size(132, 22);
            this.tbDx9CaptureHeight.TabIndex = 10;
            this.tbDx9CaptureHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PreventNonNumeric_KeyPressEventHandler);
            // 
            // tbDx9CaptureInterval
            // 
            this.tbDx9CaptureInterval.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbDx9CaptureInterval.Location = new System.Drawing.Point(226, 96);
            this.tbDx9CaptureInterval.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbDx9CaptureInterval.MaxLength = 5;
            this.tbDx9CaptureInterval.Name = "tbDx9CaptureInterval";
            this.tbDx9CaptureInterval.Size = new System.Drawing.Size(132, 22);
            this.tbDx9CaptureInterval.TabIndex = 11;
            this.tbDx9CaptureInterval.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PreventNonNumeric_KeyPressEventHandler);
            // 
            // cbDx9MonitorIndex
            // 
            this.cbDx9MonitorIndex.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbDx9MonitorIndex.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbDx9MonitorIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDx9MonitorIndex.FormattingEnabled = true;
            this.cbDx9MonitorIndex.Items.AddRange(new object[] {
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
            this.cbDx9MonitorIndex.Location = new System.Drawing.Point(226, 4);
            this.cbDx9MonitorIndex.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbDx9MonitorIndex.Name = "cbDx9MonitorIndex";
            this.cbDx9MonitorIndex.Size = new System.Drawing.Size(132, 24);
            this.cbDx9MonitorIndex.TabIndex = 8;
            // 
            // tblDx11Values
            // 
            this.tblDx11Values.ColumnCount = 2;
            this.tblDx11Values.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblDx11Values.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblDx11Values.Controls.Add(this.cbDx11MonitorIndex, 1, 1);
            this.tblDx11Values.Controls.Add(this.cbDx11AdapterIndex, 1, 0);
            this.tblDx11Values.Controls.Add(this.tbDx11MaxFps, 1, 4);
            this.tblDx11Values.Controls.Add(this.tbDx11FrameCaptureTimeout, 1, 2);
            this.tblDx11Values.Controls.Add(this.label5, 0, 0);
            this.tblDx11Values.Controls.Add(this.label6, 0, 1);
            this.tblDx11Values.Controls.Add(this.label7, 0, 2);
            this.tblDx11Values.Controls.Add(this.label8, 0, 3);
            this.tblDx11Values.Controls.Add(this.label9, 0, 4);
            this.tblDx11Values.Controls.Add(this.cbDx11ImageScalingFactor, 1, 3);
            this.tblDx11Values.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblDx11Values.Location = new System.Drawing.Point(223, 6);
            this.tblDx11Values.Margin = new System.Windows.Forms.Padding(1);
            this.tblDx11Values.Name = "tblDx11Values";
            this.tblDx11Values.RowCount = 6;
            this.tblDx11Values.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblDx11Values.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblDx11Values.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblDx11Values.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblDx11Values.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblDx11Values.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblDx11Values.Size = new System.Drawing.Size(444, 196);
            this.tblDx11Values.TabIndex = 10;
            // 
            // cbDx11MonitorIndex
            // 
            this.cbDx11MonitorIndex.Anchor = System.Windows.Forms.AnchorStyles.Left;
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
            this.cbDx11MonitorIndex.Location = new System.Drawing.Point(226, 36);
            this.cbDx11MonitorIndex.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbDx11MonitorIndex.Name = "cbDx11MonitorIndex";
            this.cbDx11MonitorIndex.Size = new System.Drawing.Size(132, 24);
            this.cbDx11MonitorIndex.TabIndex = 3;
            // 
            // cbDx11AdapterIndex
            // 
            this.cbDx11AdapterIndex.Anchor = System.Windows.Forms.AnchorStyles.Left;
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
            this.cbDx11AdapterIndex.Location = new System.Drawing.Point(226, 4);
            this.cbDx11AdapterIndex.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbDx11AdapterIndex.Name = "cbDx11AdapterIndex";
            this.cbDx11AdapterIndex.Size = new System.Drawing.Size(132, 24);
            this.cbDx11AdapterIndex.TabIndex = 2;
            // 
            // tbDx11MaxFps
            // 
            this.tbDx11MaxFps.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbDx11MaxFps.Location = new System.Drawing.Point(226, 130);
            this.tbDx11MaxFps.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbDx11MaxFps.MaxLength = 4;
            this.tbDx11MaxFps.Name = "tbDx11MaxFps";
            this.tbDx11MaxFps.Size = new System.Drawing.Size(132, 22);
            this.tbDx11MaxFps.TabIndex = 6;
            this.tbDx11MaxFps.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PreventNonNumeric_KeyPressEventHandler);
            // 
            // tbDx11FrameCaptureTimeout
            // 
            this.tbDx11FrameCaptureTimeout.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbDx11FrameCaptureTimeout.Location = new System.Drawing.Point(226, 68);
            this.tbDx11FrameCaptureTimeout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbDx11FrameCaptureTimeout.MaxLength = 5;
            this.tbDx11FrameCaptureTimeout.Name = "tbDx11FrameCaptureTimeout";
            this.tbDx11FrameCaptureTimeout.Size = new System.Drawing.Size(132, 22);
            this.tbDx11FrameCaptureTimeout.TabIndex = 4;
            this.tbDx11FrameCaptureTimeout.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PreventNonNumeric_KeyPressEventHandler);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1, 8);
            this.label5.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Adapter Index";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1, 40);
            this.label6.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 16);
            this.label6.TabIndex = 1;
            this.label6.Text = "Monitor Index";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1, 71);
            this.label7.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(178, 16);
            this.label7.TabIndex = 2;
            this.label7.Text = "Frame Capture Timeout (ms)";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1, 102);
            this.label8.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(135, 16);
            this.label8.TabIndex = 3;
            this.label8.Text = "Image Scaling Factor";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1, 133);
            this.label9.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 16);
            this.label9.TabIndex = 4;
            this.label9.Text = "Max FPS";
            // 
            // cbDx11ImageScalingFactor
            // 
            this.cbDx11ImageScalingFactor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbDx11ImageScalingFactor.AutoCompleteCustomSource.AddRange(new string[] {
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
            this.cbDx11ImageScalingFactor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbDx11ImageScalingFactor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDx11ImageScalingFactor.FormattingEnabled = true;
            this.cbDx11ImageScalingFactor.Items.AddRange(new object[] {
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
            this.cbDx11ImageScalingFactor.Location = new System.Drawing.Point(226, 98);
            this.cbDx11ImageScalingFactor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbDx11ImageScalingFactor.Name = "cbDx11ImageScalingFactor";
            this.cbDx11ImageScalingFactor.Size = new System.Drawing.Size(132, 24);
            this.cbDx11ImageScalingFactor.TabIndex = 5;
            // 
            // gBHyperionServers
            // 
            this.gBHyperionServers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gBHyperionServers.Controls.Add(this.dgHyperionAddress);
            this.gBHyperionServers.Location = new System.Drawing.Point(697, 6);
            this.gBHyperionServers.Margin = new System.Windows.Forms.Padding(1);
            this.gBHyperionServers.Name = "gBHyperionServers";
            this.gBHyperionServers.Padding = new System.Windows.Forms.Padding(1);
            this.gBHyperionServers.Size = new System.Drawing.Size(667, 391);
            this.gBHyperionServers.TabIndex = 8;
            this.gBHyperionServers.TabStop = false;
            this.gBHyperionServers.Text = "Hyperion Server Configuration";
            // 
            // dgHyperionAddress
            // 
            this.dgHyperionAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgHyperionAddress.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgHyperionAddress.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgHyperionAddress.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnProtocol,
            this.clmnHost,
            this.clmnPort,
            this.clmnPriority,
            this.clmnMessageDuration});
            this.dgHyperionAddress.Location = new System.Drawing.Point(3, 23);
            this.dgHyperionAddress.Margin = new System.Windows.Forms.Padding(1);
            this.dgHyperionAddress.MultiSelect = false;
            this.dgHyperionAddress.Name = "dgHyperionAddress";
            this.dgHyperionAddress.RowHeadersWidth = 46;
            this.dgHyperionAddress.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgHyperionAddress.RowTemplate.Height = 40;
            this.dgHyperionAddress.Size = new System.Drawing.Size(661, 366);
            this.dgHyperionAddress.TabIndex = 12;
            this.dgHyperionAddress.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgHyperionAddress_CellValueChanged);
            this.dgHyperionAddress.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgHyperionAddress_DefaultValuesNeeded);
            this.dgHyperionAddress.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgHyperionAddress_EditingControlShowing);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(505, 1);
            this.btnSave.Margin = new System.Windows.Forms.Padding(1);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(160, 33);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(692, 1);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(1);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(160, 33);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnSave, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 449);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1357, 49);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(713, 409);
            this.label10.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(412, 15);
            this.label10.TabIndex = 12;
            this.label10.Text = "- Use the \"Delete\" key to remove the selected Hyperion server configuration";
            // 
            // clmnProtocol
            // 
            this.clmnProtocol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmnProtocol.DataPropertyName = "Protocol";
            this.clmnProtocol.HeaderText = "Protocol";
            this.clmnProtocol.MinimumWidth = 6;
            this.clmnProtocol.Name = "clmnProtocol";
            this.clmnProtocol.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clmnProtocol.Width = 64;
            // 
            // clmnHost
            // 
            this.clmnHost.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmnHost.DataPropertyName = "Host";
            this.clmnHost.FillWeight = 50F;
            this.clmnHost.HeaderText = "Hostname / IP";
            this.clmnHost.MaxInputLength = 800;
            this.clmnHost.MinimumWidth = 6;
            this.clmnHost.Name = "clmnHost";
            this.clmnHost.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clmnHost.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clmnPort
            // 
            this.clmnPort.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmnPort.DataPropertyName = "Port";
            this.clmnPort.FillWeight = 20F;
            this.clmnPort.HeaderText = "Port";
            this.clmnPort.MaxInputLength = 8;
            this.clmnPort.MinimumWidth = 6;
            this.clmnPort.Name = "clmnPort";
            this.clmnPort.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clmnPort.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clmnPriority
            // 
            this.clmnPriority.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmnPriority.DataPropertyName = "Priority";
            this.clmnPriority.FillWeight = 20F;
            this.clmnPriority.HeaderText = "Priority";
            this.clmnPriority.MaxInputLength = 5;
            this.clmnPriority.MinimumWidth = 6;
            this.clmnPriority.Name = "clmnPriority";
            this.clmnPriority.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clmnPriority.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clmnMessageDuration
            // 
            this.clmnMessageDuration.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmnMessageDuration.DataPropertyName = "MessageDuration";
            this.clmnMessageDuration.FillWeight = 20F;
            this.clmnMessageDuration.HeaderText = "Message Duration (ms)";
            this.clmnMessageDuration.MaxInputLength = 5;
            this.clmnMessageDuration.MinimumWidth = 6;
            this.clmnMessageDuration.Name = "clmnMessageDuration";
            this.clmnMessageDuration.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clmnMessageDuration.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ServerPropertiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1367, 501);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.gBHyperionServers);
            this.Controls.Add(this.gbCaptureApi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ServerPropertiesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Hyperion Screen Capture - Capture Task Details";
            this.Shown += new System.EventHandler(this.ServerPropertiesForm_Shown);
            this.gbCaptureApi.ResumeLayout(false);
            this.tblScreenCaptureMethod.ResumeLayout(false);
            this.tblScreenCaptureMethod.PerformLayout();
            this.tblDx9Values.ResumeLayout(false);
            this.tblDx9Values.PerformLayout();
            this.tblDx11Values.ResumeLayout(false);
            this.tblDx11Values.PerformLayout();
            this.gBHyperionServers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgHyperionAddress)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox gbCaptureApi;
        private System.Windows.Forms.TableLayoutPanel tblScreenCaptureMethod;
        private System.Windows.Forms.RadioButton rbcmDx11;
        private System.Windows.Forms.RadioButton rbcmDx9;
        private System.Windows.Forms.TableLayoutPanel tblDx9Values;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbDx9CaptureWidth;
        private System.Windows.Forms.TextBox tbDx9CaptureHeight;
        private System.Windows.Forms.TextBox tbDx9CaptureInterval;
        private System.Windows.Forms.TableLayoutPanel tblDx11Values;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbDx11MaxFps;
        private System.Windows.Forms.TextBox tbDx11FrameCaptureTimeout;
        private System.Windows.Forms.ComboBox cbDx9MonitorIndex;
        private System.Windows.Forms.ComboBox cbDx11AdapterIndex;
        private System.Windows.Forms.ComboBox cbDx11MonitorIndex;
        private System.Windows.Forms.GroupBox gBHyperionServers;
        private System.Windows.Forms.DataGridView dgHyperionAddress;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox cbDx11ImageScalingFactor;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridViewComboBoxColumn clmnProtocol;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnHost;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnPort;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnPriority;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnMessageDuration;
    }
}