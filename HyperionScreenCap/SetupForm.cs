using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using SlimDX.Windows;

namespace HyperionScreenCap
{
    public partial class SetupForm : Form
    {
        public SetupForm()
        {
            InitializeComponent();

            // Automatically set the monitor index

            for (int i = 0; i < DisplayMonitor.EnumerateMonitors().Length; i++)
            {
                cbMonitorIndex.Items.Add(i);
            }

            LoadSettings();

            lblVersion.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void LoadSettings()
        {
            try
            {
                Settings.LoadSetttings();
                tbIPHostName.Text = Settings.HyperionServerIp;
                tbProtoPort.Text = Settings.HyperionServerPort.ToString();
                cbMessagePriority.Text = Settings.HyperionMessagePriority.ToString();
                tbMessageDuration.Text = Settings.HyperionMessageDuration.ToString();
                tbCaptureWidth.Text = Settings.HyperionWidth.ToString();
                tbCaptureHeight.Text = Settings.HyperionHeight.ToString();
                tbCaptureInterval.Text = Settings.CaptureInterval.ToString();
                cbMonitorIndex.Text = Settings.MonitorIndex.ToString();
                tbReconnectInterval.Text = Settings.ReconnectInterval.ToString();
                chkCaptureOnStartup.Checked = Settings.CaptureOnStartup;
                tbApiPort.Text = Settings.ApiPort.ToString();
                chkApiEnabled.Checked = Settings.ApiEnabled;
                chkApiExcludeTimesEnabled.Checked = Settings.ApiExcludedTimesEnabled;
                tbApiExcludeStart.Text = Settings.ApiExcludeTimeStart.ToString("HH:mm");
                tbApiExcludeEnd.Text = Settings.ApiExcludeTimeEnd.ToString("HH:mm");

                cbNotificationLevel.Text = Settings.NotificationLevel.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error occcured during LoadSettings(): {ex.Message}");
            }
        }

        private void btnSaveExit_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void SaveSettings()
        {
            try
            {
                // Check if all settngs are valid
                if (ValidatorDateTime(tbApiExcludeStart.Text) == false)
                {
                    MessageBox.Show("Error in excluded API start time", "Error in excluded API start time", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (ValidatorDateTime(tbApiExcludeEnd.Text) == false)
                {
                    MessageBox.Show("Error in excluded API end time", "Error in excluded API end time", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                Settings.HyperionServerIp = tbIPHostName.Text;
                Settings.HyperionServerPort = int.Parse(tbProtoPort.Text);
                Settings.HyperionMessagePriority = int.Parse(cbMessagePriority.Text);
                Settings.HyperionMessageDuration = int.Parse(tbMessageDuration.Text);
                Settings.HyperionWidth = int.Parse(tbCaptureWidth.Text);
                Settings.HyperionHeight = int.Parse(tbCaptureHeight.Text);
                Settings.CaptureInterval = int.Parse(tbCaptureInterval.Text);
                Settings.MonitorIndex = int.Parse(cbMonitorIndex.Text);
                Settings.ReconnectInterval = int.Parse(tbReconnectInterval.Text);
                Settings.CaptureOnStartup = chkCaptureOnStartup.Checked;
                Settings.ApiPort = int.Parse(tbApiPort.Text);
                Settings.ApiEnabled = chkApiEnabled.Checked;
                Settings.ApiExcludedTimesEnabled = chkApiExcludeTimesEnabled.Checked;
                Settings.ApiExcludeTimeStart = DateTime.Parse(tbApiExcludeStart.Text);
                Settings.ApiExcludeTimeEnd = DateTime.Parse(tbApiExcludeEnd.Text);

                Settings.NotificationLevel =
                    (Form1.NotificationLevels) Enum.Parse(typeof(Form1.NotificationLevels), cbNotificationLevel.Text);

                Settings.SaveSettings();
                Form1.Init(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error occcured during SaveSettings(): {ex.Message}");
            }

            Close();
        }

        private static bool ValidatorInt(string input, int minValue, int maxValue, bool validateMaxValue)
        {
            bool isValid = false;
            int value;
            bool isInteger = int.TryParse(input, out value);

            if (isInteger)
            {
                //Only check minValue
                if (validateMaxValue == false && value >= minValue)
                {
                    isValid = true;
                }
                //Check both min/max values
                else
                {
                    if (value >= minValue && value <= maxValue)
                    {
                        isValid = true;
                    }
                }
            }
            return isValid;
        }

        public Boolean ValidatorDateTime(string input)
        {
            DateTime dt;
            Boolean IsValid = false;
            bool isDateTime = DateTime.TryParse(input, out dt);
            if (isDateTime)
            {
                IsValid = true;
            }

            return IsValid;
        }

        private void tbProtoPort_Validating(object sender, CancelEventArgs e)
        {
            const int minValue = 1;
            const int maxValue = 65535;
            if (ValidatorInt(tbProtoPort.Text, minValue, maxValue, false) == false)
            {
                MessageBox.Show(@"Invalid integer filled for port");
            }
        }

        private void cbMessagePriority_Validating(object sender, CancelEventArgs e)
        {
            const int minValue = 0;
            const int maxValue = 0;
            if (ValidatorInt(cbMessagePriority.Text, minValue, maxValue, false) == false)
            {
                MessageBox.Show(@"Invalid integer filled for message priority");
            }
        }

        private void cbMonitorIndex_Validating(object sender, CancelEventArgs e)
        {
            const int minValue = 0;
            const int maxValue = 0;
            if (ValidatorInt(cbMonitorIndex.Text, minValue, maxValue, false) == false)
            {
                MessageBox.Show(@"Invalid integer filled for monitor index");
            }
        }

        private void tbMessageDuration_Validating(object sender, CancelEventArgs e)
        {
            const int minValue = -1;
            const int maxValue = 0;
            if (ValidatorInt(tbMessageDuration.Text, minValue, maxValue, false) == false)
            {
                MessageBox.Show(@"Invalid integer filled for message duration");
            }
        }

        private void tbCaptureWidth_Validating(object sender, CancelEventArgs e)
        {
            const int minValue = 0;
            const int maxValue = 0;
            if (ValidatorInt(tbCaptureWidth.Text, minValue, maxValue, false) == false)
            {
                MessageBox.Show(@"Invalid integer filled for capture width");
            }
        }

        private void tbCaptureHeight_Validating(object sender, CancelEventArgs e)
        {
            const int minValue = 0;
            const int maxValue = 0;
            if (ValidatorInt(tbCaptureHeight.Text, minValue, maxValue, false) == false)
            {
                MessageBox.Show(@"Invalid integer filled for capture height");
            }
        }

        private void tbCaptureInterval_Validating(object sender, CancelEventArgs e)
        {
            const int minValue = 0;
            const int maxValue = 0;
            if (ValidatorInt(tbCaptureInterval.Text, minValue, maxValue, false) == false)
            {
                MessageBox.Show(@"Invalid integer filled for capture interval");
            }
        }

        private void tbReconnectInterval_Validating(object sender, CancelEventArgs e)
        {
            const int minValue = 0;
            const int maxValue = 0;
            if (ValidatorInt(tbReconnectInterval.Text, minValue, maxValue, false) == false)
            {
                MessageBox.Show(@"Invalid integer filled for reconnect interval");
            }
        }

        private void tbApiPort_Validating(object sender, CancelEventArgs e)
        {
            const int minValue = 1;
            const int maxValue = 65535;
            if (ValidatorInt(tbApiPort.Text, minValue, maxValue, false) == false)
            {
                MessageBox.Show(@"Invalid integer filled for port");
            }
        }

        private void tbExcludeStart_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (ValidatorDateTime(tbApiExcludeStart.Text) == false)
            {
                MessageBox.Show("Error in excluded API start time", "Error in excluded API start time", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbExcludeEnd_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (ValidatorDateTime(tbApiExcludeEnd.Text) == false)
            {
                MessageBox.Show("Error in excluded API end time", "Error in excluded API end time", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
