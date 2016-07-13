using System;
using System.Configuration;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using SlimDX;
using SlimDX.Direct3D9;

namespace HyperionScreenCap
{
  public partial class Form1 : Form
  {
    private static readonly string HyperionServerIp = ConfigurationManager.AppSettings["hyperionServerIP"];

    private static readonly int HyperionMessagePriority =
      int.Parse(ConfigurationManager.AppSettings["hyperionMessagePriority"]);

    public static readonly int HyperionMessageDuration =
      int.Parse(ConfigurationManager.AppSettings["hyperionMessageDuration"]);

    public static readonly int HyperionWidth = int.Parse(ConfigurationManager.AppSettings["width"]);
    public static readonly int HyperionHeight = int.Parse(ConfigurationManager.AppSettings["height"]);
    private static readonly int CaptureInterval = int.Parse(ConfigurationManager.AppSettings["captureInterval"]);
    public static readonly int MonitorIndex = int.Parse(ConfigurationManager.AppSettings["monitorIndex"]);

    private static readonly int HyperionServerPort =
      int.Parse(ConfigurationManager.AppSettings["hyperionServerPort"]);

    private readonly NotifcationLevels NotificationLevel =
      (NotifcationLevels) Enum.Parse(typeof (NotifcationLevels), ConfigurationManager.AppSettings["notificationLevel"]);

    private static DxScreenCapture _d;
    private static ProtoClient _protoClient;

    public static NotifyIcon TrayIcon;
    private static bool CaptureEnabled;

    public enum NotifcationLevels
    {
      None,
      Info,
      Error,
    }

    public Form1()
    {
      InitializeComponent();

      // Create a simple tray menu with only one item.
      var trayMenu = new ContextMenu();
      trayMenu.MenuItems.Add("Exit", OnExit);

      TrayIcon = new NotifyIcon {Text = @"Hyperion Screen Capture (Not Connected)"};
      TrayIcon.DoubleClick += TrayIcon_DoubleClick;
      TrayIcon.Icon = Resources.Hyperion_disabled;

      // Add menu to tray icon and show it.
      TrayIcon.ContextMenu = trayMenu;
      TrayIcon.Visible = true;

      _d = new DxScreenCapture(MonitorIndex);

      _protoClient = new ProtoClient();
      _protoClient.Init(HyperionServerIp, HyperionServerPort, HyperionMessagePriority);

      if (_protoClient.IsConnected())
      {
        if (NotificationLevel == NotifcationLevels.Info)
        {
          Notifications.Info(string.Format("Connected to Hyperion server on {0}!", HyperionServerIp));
        }

        CaptureEnabled = true;
        Thread t = new Thread(StartCapture) {IsBackground = true};
        t.Start();
      }

      TrayIcon.Icon = Resources.Hyperion_enabled;
      TrayIcon.Text = @"Hyperion Screen Capture (Enabled)";
    }


    private void TrayIcon_DoubleClick
      (object sender, EventArgs e)
    {
      if (CaptureEnabled)
      {
        TrayIcon.Icon = Resources.Hyperion_disabled;
        TrayIcon.Text = @"Hyperion Screen Capture (Disabled)";
        _protoClient.ClearPriority(HyperionMessagePriority);
        CaptureEnabled = false;
      }
      else
      {
        TrayIcon.Icon = Resources.Hyperion_enabled;
        TrayIcon.Text = @"Hyperion Screen Capture (Enabled)";
        CaptureEnabled = true;
        Thread.Sleep(50);
        Thread t = new Thread(StartCapture) {IsBackground = true};
        t.Start();
      }
    }

    private static
      void OnExit
      (object sender, EventArgs e)
    {
      // Clear tray icon on close
      if (TrayIcon != null)
      {
        TrayIcon.Visible = false;
      }

      // On send clear priority
      if (_protoClient != null)
      {
        CaptureEnabled = false;
        _protoClient.ClearPriority(HyperionMessagePriority);
        Thread.Sleep(50);
        _protoClient.ClearPriority(HyperionMessagePriority);
        _protoClient.Disconnect();
      }

      Application.Exit();
    }

    protected override
      void OnLoad
      (EventArgs
        e)
    {
      Visible = false; // Hide form window.
      ShowInTaskbar = false; // Remove from taskbar.

      base.OnLoad(e);
    }

    #region DXCapture

    private void StartCapture()
    {
      try
      {
        while (CaptureEnabled)
        {
          if (!_protoClient.IsConnected())
          {
            // Reconnect every 2.5s
            _protoClient.Init(HyperionServerIp, HyperionServerPort, HyperionMessagePriority);
            Thread.Sleep(2500);
            continue;
          }

          Surface s = _d.CaptureScreen(HyperionWidth, HyperionHeight);
          DataStream ds = Surface.ToStream(s, ImageFileFormat.Bmp);

          byte[] buffer = new byte[ds.Length];
          using (MemoryStream ms = new MemoryStream())
          {
            int read;
            while ((read = ds.Read(buffer, 0, buffer.Length)) > 0)
            {
              ms.Write(buffer, 0, read);
            }

            byte[] pixelData = ms.ToArray();
            _protoClient.SendImage(pixelData);

            Thread.Sleep(CaptureInterval);
          }

          ds.Dispose();
          s.Dispose();
        }
      }
      catch (Exception ex)
      {
        if (NotificationLevel == NotifcationLevels.Info || NotificationLevel == NotifcationLevels.Error)
        {
          Notifications.Error("Failed to take screenshot." + ex.Message);
        }
      }
    }

    #endregion
  }
}