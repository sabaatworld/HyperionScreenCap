using System;
using System.Collections.Generic;
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
        #region Variables
        private static readonly string HyperionServerIp = ConfigurationManager.AppSettings["hyperionServerIP"];

        private static readonly int HyperionMessagePriority = int.Parse(ConfigurationManager.AppSettings["hyperionMessagePriority"]);

        public static readonly int HyperionMessageDuration = int.Parse(ConfigurationManager.AppSettings["hyperionMessageDuration"]);

        public static readonly int HyperionWidth = int.Parse(ConfigurationManager.AppSettings["width"]);
        public static readonly int HyperionHeight = int.Parse(ConfigurationManager.AppSettings["height"]);
        private static readonly int CaptureInterval = int.Parse(ConfigurationManager.AppSettings["captureInterval"]);
        private static readonly int MonitorIndex = int.Parse(ConfigurationManager.AppSettings["monitorIndex"]);

        private static readonly int HyperionServerPort = int.Parse(ConfigurationManager.AppSettings["hyperionServerPort"]);

        public static readonly NotifcationLevels NotificationLevel = (NotifcationLevels)Enum.Parse(typeof(NotifcationLevels), ConfigurationManager.AppSettings["notificationLevel"]);

        private static DxScreenCapture _d;
        private static ProtoClient _protoClient;

        public static NotifyIcon TrayIcon;
        private static bool _captureEnabled;

        public enum NotifcationLevels { None, Info, Error }

        #endregion Variables

        public Form1()
        {
            InitializeComponent();

            #region TrayIcon

            // Create a simple tray menu with only one item.
            var trayMenu = new ContextMenu();
            trayMenu.MenuItems.Add("Exit", OnExit);

            TrayIcon = new NotifyIcon { Text = @"Hyperion Screen Capture (Not Connected)" };
            TrayIcon.DoubleClick += TrayIcon_DoubleClick;
            TrayIcon.Icon = Resources.Hyperion_disabled;

            // Add menu to tray icon and show it.
            TrayIcon.ContextMenu = trayMenu;
            TrayIcon.Visible = true;

            #endregion TrayIcon

            _d = new DxScreenCapture(MonitorIndex);

            _protoClient = new ProtoClient();
            ProtoClient.Init(HyperionServerIp, HyperionServerPort, HyperionMessagePriority);

            if (ProtoClient.IsConnected())
            {

                Notifications.Info($"Connected to Hyperion server on {HyperionServerIp}!");


                _captureEnabled = true;
                var t = new Thread(StartCapture) { IsBackground = true };
                t.Start();
            }

            TrayIcon.Icon = Resources.Hyperion_enabled;
            TrayIcon.Text = @"Hyperion Screen Capture (Enabled)";
        }

        private static void TrayIcon_DoubleClick(object sender, EventArgs e)
        {
            if (_captureEnabled)
            {
                TrayIcon.Icon = Resources.Hyperion_disabled;
                TrayIcon.Text = @"Hyperion Screen Capture (Disabled)";
                ProtoClient.ClearPriority(HyperionMessagePriority);
                _captureEnabled = false;
            }
            else
            {
                TrayIcon.Icon = Resources.Hyperion_enabled;
                TrayIcon.Text = @"Hyperion Screen Capture (Enabled)";
                _captureEnabled = true;
                Thread.Sleep(50);
                var t = new Thread(StartCapture) { IsBackground = true};
                t.Start();
            }
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
                ProtoClient.ClearPriority(HyperionMessagePriority);
                Thread.Sleep(50);
                ProtoClient.ClearPriority(HyperionMessagePriority);
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
                        // Reconnect every 0.5s
                        ProtoClient.Init(HyperionServerIp, HyperionServerPort, HyperionMessagePriority);
                        Thread.Sleep(500);
                        continue;
                    }

                    var s = _d.CaptureScreen(HyperionWidth, HyperionHeight);
                    var dr = s.LockRectangle(LockFlags.None);
                    var ds = dr.Data;
                    var x = removeAlpha(ds);

                    s.UnlockRectangle();
                    s.Dispose();
                    ds.Dispose();

                    ProtoClient.SendImageToServer(x);
                }
            }
            catch (Exception ex)
            {
                Notifications.Error("Failed to take screenshot." + ex.Message);
            }
        }

        #endregion DXCapture

        static byte[] removeAlpha(DataStream ia)
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