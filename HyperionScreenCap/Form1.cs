using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using SlimDX;
using SlimDX.Direct3D9;

namespace HyperionScreenCap
{
  public partial class Form1 : Form
  {
    #region Variables

    private static bool _initLock;
    private static DxScreenCapture _d;
    private static ProtoClient _protoClient;

    public static NotifyIcon TrayIcon;
    public static bool _captureEnabled;

    public enum NotifcationLevels
    {
      None,
      Info,
      Error
    }

    #endregion Variables

    public Form1()
    {
      InitializeComponent();

      #region TrayIcon

      // Create a simple tray menu with only one item.
      var trayMenu = new ContextMenu();
      MenuItem menuItemChangeMonitor = new MenuItem("Change monitor index");

      for (int i = 0; i <= 8; i++)
      {
        menuItemChangeMonitor.MenuItems.Add(new MenuItem(string.Format("#{0}", i), OnChangeMonitor));
      }

      trayMenu.MenuItems.Add(menuItemChangeMonitor);
      trayMenu.MenuItems.Add("Setup", OnSetup);
      trayMenu.MenuItems.Add("Exit", OnExit);

      TrayIcon = new NotifyIcon {Text = @"Hyperion Screen Capture (Not Connected)"};
      TrayIcon.DoubleClick += TrayIcon_DoubleClick;
      TrayIcon.Icon = Resources.Hyperion_disabled;

      // Add menu to tray icon and show it.
      TrayIcon.ContextMenu = trayMenu;
      TrayIcon.Visible = true;

      Settings.LoadSetttings();

      if (Settings.HyperionServerIp == "0.0.0.0")
      {
        MessageBox.Show("No configuration found, please setup in the next window.");
        SetupForm setupForm = new SetupForm();
        setupForm.Show();
      }
      else
      {
        Init();
      }

      #endregion TrayIcon
    }

    public static void Init(bool reInit = false)
    {
      if (!_initLock)
      {
        _initLock = true;

        // Stop current capture first on reinit
        if (reInit)
        {
          _captureEnabled = false;
          Thread.Sleep(500 + Settings.CaptureInterval);

          if (_protoClient != null)
          {
            ProtoClient.Disconnect();
            Thread.Sleep(500);
          }
        }

        _d = new DxScreenCapture(Settings.MonitorIndex);

        _protoClient = new ProtoClient();
        ProtoClient.Init(Settings.HyperionServerIp, Settings.HyperionServerPort, Settings.HyperionMessagePriority);

        if (ProtoClient.IsConnected())
        {
          Notifications.Info($"Connected to Hyperion server on {Settings.HyperionServerIp}!");

          _captureEnabled = true;
          var t = new Thread(StartCapture) {IsBackground = true};
          t.Start();
        }

        TrayIcon.Icon = Resources.Hyperion_enabled;
        TrayIcon.Text = @"Hyperion Screen Capture (Enabled)";

        _initLock = false;
      }
    }

    private static void TrayIcon_DoubleClick(object sender, EventArgs e)
    {
      if (_captureEnabled)
      {
        TrayIcon.Icon = Resources.Hyperion_disabled;
        TrayIcon.Text = @"Hyperion Screen Capture (Disabled)";
        ProtoClient.ClearPriority(Settings.HyperionMessagePriority);
        _captureEnabled = false;
      }
      else
      {
        TrayIcon.Icon = Resources.Hyperion_enabled;
        TrayIcon.Text = @"Hyperion Screen Capture (Enabled)";
        _captureEnabled = true;
        Thread.Sleep(50);
        var t = new Thread(StartCapture) {IsBackground = true};
        t.Start();
      }
    }


    private static void OnChangeMonitor(object sender, EventArgs e)
    {
      MenuItem selectedMenuItem = sender as MenuItem;
      if (selectedMenuItem != null)
      {
        int newMonitorIndex;
        bool isValidInteger = int.TryParse(selectedMenuItem.Text.Replace("#", string.Empty), out newMonitorIndex);
        if (isValidInteger)
        {
          Settings.MonitorIndex = newMonitorIndex;
          Settings.SaveSettings();
          Init(true);
        }
      }
    }

    private static void OnSetup(object sender, EventArgs e)
    {
      SetupForm setupForm = new SetupForm();
      setupForm.Show();
    }
    private static void OnExit(object sender, EventArgs e)
    {
      // Clear tray icon on close
      if (TrayIcon != null)
      {
        TrayIcon.Visible = false;
      }

      // On send clear priority
      if (_protoClient != null)
      {
        _captureEnabled = false;
        ProtoClient.ClearPriority(Settings.HyperionMessagePriority);
        Thread.Sleep(50);
        ProtoClient.ClearPriority(Settings.HyperionMessagePriority);
        ProtoClient.Disconnect();
      }

      Application.Exit();
    }

    protected override void OnLoad(EventArgs e)
    {
      Visible = false; // Hide form window.
      ShowInTaskbar = false; // Remove from taskbar.

      base.OnLoad(e);
    }

    #region DXCapture

    private static void StartCapture()
    {
      try
      {
        while (_captureEnabled)
        {
          if (!ProtoClient.IsConnected())
          {
            // Reconnect every 5s (default)
            ProtoClient.Init(Settings.HyperionServerIp, Settings.HyperionServerPort, Settings.HyperionMessagePriority);
            Thread.Sleep(Settings.ReconnectInterval);
            continue;
          }

          var s = _d.CaptureScreen(Settings.HyperionWidth, Settings.HyperionHeight);
          var dr = s.LockRectangle(LockFlags.None);
          var ds = dr.Data;
          var x = RemoveAlpha(ds);

          s.UnlockRectangle();
          s.Dispose();
          ds.Dispose();

          ProtoClient.SendImageToServer(x);

          // Add small delay to reduce cpu usage (200FPS max)
          Thread.Sleep(5);
        }
      }
      catch (Exception ex)
      {
        Notifications.Error("Failed to take screenshot." + ex.Message);
      }
    }

    #endregion DXCapture

    static byte[] RemoveAlpha(DataStream ia)
    {
      var newImage = new List<byte>();
      while (ia.Position < ia.Length)
      {
        var a = new byte[4];
        ia.Read(a, 0, 4);
        newImage.Add(a[2]);
        newImage.Add(a[1]);
        newImage.Add(a[0]);
      }
      return newImage.ToArray();
    }
  }
}