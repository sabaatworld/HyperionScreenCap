using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net.Sockets;
using System.Windows.Forms;
using Newtonsoft.Json;
using SlimDX;
using SlimDX.Direct3D9;

namespace HyperionScreenCap
{
    public partial class Form1 : Form
    {
        private static readonly string HyperionServerIp = ConfigurationManager.AppSettings["hyperionServerIP"];

        private static readonly int HyperionServerJsonPort =
            int.Parse(ConfigurationManager.AppSettings["hyperionServerJsonPort"]);

        private static readonly int HyperionMessagePriority =
            int.Parse(ConfigurationManager.AppSettings["hyperionMessagePriority"]);

        public static readonly int HyperionMessageDuration =
            int.Parse(ConfigurationManager.AppSettings["hyperionMessageDuration"]);

        public static readonly int HyperionWidth = int.Parse(ConfigurationManager.AppSettings["width"]);
        public static readonly int HyperionHeight = int.Parse(ConfigurationManager.AppSettings["height"]);
        private static readonly int CaptureInterval = int.Parse(ConfigurationManager.AppSettings["captureInterval"]);
        public static readonly int MonitorIndex = int.Parse(ConfigurationManager.AppSettings["monitorIndex"]);

        private static readonly int HyperionServerProtoPort =
            int.Parse(ConfigurationManager.AppSettings["hyperionServerProtoPort"]);

        private static readonly string Protocol = ConfigurationManager.AppSettings["protocol"];

        private static DxScreenCapture _d;

        public static NotifyIcon TrayIcon;

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

            _d = new DxScreenCapture();

            if (Protocol == "json")
            {
                ConnectToServer(HyperionServerIp, HyperionServerJsonPort);
            }
            else if (Protocol == "proto")
            {
                _protoClient = new ProtoClient();
                _protoClient.Init(HyperionServerIp, HyperionServerProtoPort, HyperionMessagePriority);
            }

            if (Connected() || _protoClient.IsConnected())
            {
                Notifications.Info("Connected to Hyperion!");

                TrayIcon.Icon = Resources.Hyperion_enabled;
                TrayIcon.Text = @"Hyperion Screen Capture (Enabled)";
                screenCaptureInterval.Interval = CaptureInterval;
                screenCaptureInterval.Enabled = true;
            }
        }


        private void TrayIcon_DoubleClick(object sender, EventArgs e)
        {
            if (screenCaptureInterval.Enabled)
            {
                TrayIcon.Icon = Resources.Hyperion_disabled;
                TrayIcon.Text = @"Hyperion Screen Capture (Disabled)";
                screenCaptureInterval.Stop();
            }
            else
            {
                TrayIcon.Icon = Resources.Hyperion_enabled;
                TrayIcon.Text = @"Hyperion Screen Capture (Enabled)";
                screenCaptureInterval.Start();
            }
        }

        private void OnExit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        protected override void OnLoad(EventArgs e)
        {
            Visible = false; // Hide form window.
            ShowInTaskbar = false; // Remove from taskbar.

            base.OnLoad(e);
        }

        #region DXCapture

        private static void capture()
        {
            try
            {
                var s = _d.CaptureScreen();

                var dr = s.LockRectangle(LockFlags.None);
                var gs = dr.Data;

                var x = RemoveAlpha(gs);

                s.UnlockRectangle();
                s.Dispose();
                gs.Dispose();


                if (Protocol == "json")
                {
                    var y = Convert.ToBase64String(x);
                    SetImage(y, HyperionMessagePriority, HyperionMessageDuration);
                }
                else if (Protocol == "proto")
                {
                    _protoClient.SendImage(x);
                }
            }
            catch (Exception ex)
            {
                Notifications.Error("Failed to take screenshot." + ex.Message);
            }
        }

        #endregion

        private void screenCaptureInterval_Tick(object sender, EventArgs e)
        {
            capture();
        }

        #region Tools

        private static string Serialize(Hashtable n)
        {
            return JsonConvert.SerializeObject(n);
        }

        private static byte[] RemoveAlpha(DataStream ia)
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

        #endregion

        #region TcpClient

        private static TcpClient _hyperionServer;
        private static ProtoClient _protoClient;
        private static NetworkStream _serverStream;
        private static StreamWriter _sendToServer;
        private static StreamReader _readFromServer;

        private static void ConnectToServer(string ip, int port)
        {
            try
            {
                Notifications.Info($"Connecting to Hyperion server: {HyperionServerIp}:{HyperionServerJsonPort}");

                _hyperionServer = new TcpClient(ip, port) {NoDelay = true};
                _serverStream = _hyperionServer.GetStream();
                _sendToServer = new StreamWriter(_serverStream) {AutoFlush = true};

                _readFromServer = new StreamReader(_serverStream);
            }
            catch (Exception ex)
            {
                Notifications.Error("Failed to connect to server. " + ex.Message);
            }
        }

        private static void CloseConnection()
        {
            try
            {
                _serverStream.Dispose();
                _sendToServer.Dispose();
                _hyperionServer.Close();
            }
            catch
            {
                // ignored
            }
        }

        private static bool Connected()
        {
            return _hyperionServer != null && _hyperionServer.Connected;
        }

        private static void SendMessage(Hashtable command)
        {
            try
            {
                var message = Serialize(command);
                _sendToServer.WriteLine(message);
                var response = _readFromServer.ReadLine();

                if (response != "{\"success\":true}")
                {
                    Notifications.Error("Hyperion error. " + response);
                }
            }
            catch (Exception ex)
            {
                Notifications.Error("Failed to send message to Hyperion Server. " + ex.Message);
            }
        }

        private static void SetImage(string base64Image, int priority, int duration)
        {
            try
            {
                var command = new Hashtable
                {
                    ["command"] = "image",
                    ["priority"] = priority,
                    ["imagewidth"] = HyperionWidth,
                    ["imageheight"] = HyperionHeight,
                    ["imagedata"] = base64Image
                };

                if (duration > 0)
                {
                    command["duration"] = duration;
                }

                // send command message
                SendMessage(command);
            }
            catch (Exception ex)
            {
                Notifications.Error("Failed to create JSON Message. " + ex.Message);
            }
        }

        #endregion
    }
}