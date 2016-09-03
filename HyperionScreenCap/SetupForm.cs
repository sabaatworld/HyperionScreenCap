using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace HyperionScreenCap
{
  public partial class SetupForm : Form
  {
    public SetupForm()
    {
      InitializeComponent();
      LoadSettings();
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
        Settings.HyperionServerIp = tbIPHostName.Text;
        Settings.HyperionServerPort = int.Parse(tbProtoPort.Text);
        Settings.HyperionMessagePriority = int.Parse(cbMessagePriority.Text);
        Settings.HyperionMessageDuration = int.Parse(tbMessageDuration.Text);
        Settings.HyperionWidth = int.Parse(tbCaptureWidth.Text);
        Settings.HyperionHeight = int.Parse(tbCaptureHeight.Text);
        Settings.CaptureInterval = int.Parse(tbCaptureInterval.Text);
        Settings.MonitorIndex = int.Parse(cbMonitorIndex.Text);
        Settings.ReconnectInterval = int.Parse(tbReconnectInterval.Text);
        Settings.NotificationLevel =
          (Form1.NotifcationLevels) Enum.Parse(typeof(Form1.NotifcationLevels), cbNotificationLevel.Text);

        Settings.SaveSettings();
        Form1.Init(true);
      }
      catch (Exception ex)
      {
        MessageBox.Show($"Error occcured during SaveSettings(): {ex.Message}");
      }

      Close();
    }

    private bool ValidatorInt(string input, int minValue, int maxValue, bool validateMaxValue)
    {
      bool IsValid = false;
      int value;
      bool IsInteger = Int32.TryParse(input, out value);

      if (IsInteger)
      {
        //Only check minValue
        if (validateMaxValue == false && value >= minValue)
        {
          IsValid = true;
        }
        //Check both min/max values
        else
        {
          if (value >= minValue && value <= maxValue)
          {
            IsValid = true;
          }
        }
      }
      return IsValid;
    }

    private void tbProtoPort_Validating(object sender, CancelEventArgs e)
    {
      int minValue = 1;
      int maxValue = 65535;
      if (ValidatorInt(tbProtoPort.Text, minValue, maxValue, false) == false)
      {
        MessageBox.Show("Invalid integer filled for port");
      }
    }

    private void cbMessagePriority_Validating(object sender, CancelEventArgs e)
    {
      int minValue = 0;
      int maxValue = 0;
      if (ValidatorInt(cbMessagePriority.Text, minValue, maxValue, false) == false)
      {
        MessageBox.Show("Invalid integer filled for message priority");
      }
    }

    private void cbMonitorIndex_Validating(object sender, CancelEventArgs e)
    {
      int minValue = 0;
      int maxValue = 0;
      if (ValidatorInt(cbMonitorIndex.Text, minValue, maxValue, false) == false)
      {
        MessageBox.Show("Invalid integer filled for monitor index");
      }
    }

    private void tbMessageDuration_Validating(object sender, CancelEventArgs e)
    {
      int minValue = -1;
      int maxValue = 0;
      if (ValidatorInt(tbMessageDuration.Text, minValue, maxValue, false) == false)
      {
        MessageBox.Show("Invalid integer filled for message duration");
      }
    }

    private void tbCaptureWidth_Validating(object sender, CancelEventArgs e)
    {
      int minValue = 0;
      int maxValue = 0;
      if (ValidatorInt(tbCaptureWidth.Text, minValue, maxValue, false) == false)
      {
        MessageBox.Show("Invalid integer filled for capture width");
      }
    }

    private void tbCaptureHeight_Validating(object sender, CancelEventArgs e)
    {
      int minValue = 0;
      int maxValue = 0;
      if (ValidatorInt(tbCaptureHeight.Text, minValue, maxValue, false) == false)
      {
        MessageBox.Show("Invalid integer filled for capture height");
      }
    }

    private void tbCaptureInterval_Validating(object sender, CancelEventArgs e)
    {
      int minValue = 0;
      int maxValue = 0;
      if (ValidatorInt(tbCaptureInterval.Text, minValue, maxValue, false) == false)
      {
        MessageBox.Show("Invalid integer filled for capture interval");
      }
    }

    private void tbReconnectInterval_Validating(object sender, CancelEventArgs e)
    {
      int minValue = 0;
      int maxValue = 0;
      if (ValidatorInt(tbReconnectInterval.Text, minValue, maxValue, false) == false)
      {
        MessageBox.Show("Invalid integer filled for reconnect interval");
      }
    }
  }
}
