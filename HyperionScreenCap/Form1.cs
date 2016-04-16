using SlimDX;
using SlimDX.Direct3D9;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net.Sockets;
using System.Windows.Forms;

namespace HyperionScreenCap
{
    public partial class Form1 : Form
    {
        static string hyperionServerIP = ConfigurationManager.AppSettings["hyperionServerIP"];
        static int hyperionServerJsonPort = int.Parse(ConfigurationManager.AppSettings["hyperionServerJsonPort"]);
        static public int hyperionMessagePriority = int.Parse(ConfigurationManager.AppSettings["hyperionMessagePriority"]);
        static public int hyperionMessageDuration = int.Parse(ConfigurationManager.AppSettings["hyperionMessageDuration"]);
        static public int hyperionWidth = int.Parse(ConfigurationManager.AppSettings["width"]);
        static public int hyperionHeight = int.Parse(ConfigurationManager.AppSettings["height"]);
        static public int captureInterval = int.Parse(ConfigurationManager.AppSettings["captureInterval"]);
        static public int monitorIndex = int.Parse(ConfigurationManager.AppSettings["monitorIndex"]);
        static int hyperionServerProtoPort = int.Parse(ConfigurationManager.AppSettings["hyperionServerProtoPort"]);
        static string protocol = ConfigurationManager.AppSettings["protocol"];

        static DxScreenCapture d;

        static public NotifyIcon trayIcon;
        static public ContextMenu trayMenu;
        static Notifications n = new Notifications();

        public Form1()
        {
            InitializeComponent();

            // Create a simple tray menu with only one item.
            trayMenu = new ContextMenu();
            trayMenu.MenuItems.Add("Exit", OnExit);

            trayIcon = new NotifyIcon();
            trayIcon.Text = "Hyperion Screen Capture (Not Connected)";
            trayIcon.DoubleClick += TrayIcon_DoubleClick;
            trayIcon.Icon = Resources.Hyperion_disabled;

            // Add menu to tray icon and show it.
            trayIcon.ContextMenu = trayMenu;
            trayIcon.Visible = true;

            d = new DxScreenCapture();

            if (protocol == "json")
            {
                connectToServer(hyperionServerIP, hyperionServerJsonPort);
            }
            else if(protocol == "proto")
            {
                protoClient = new ProtoClient();
                protoClient.Init(hyperionServerIP, hyperionServerProtoPort, hyperionMessagePriority);
            }
            
            if (Connected() || protoClient.isConnected())
            {
                Notifications.Info("Connected to Hyperion!");

                trayIcon.Icon = Resources.Hyperion_enabled;
                trayIcon.Text = "Hyperion Screen Capture (Enabled)";
                screenCaptureInterval.Interval = captureInterval;
                screenCaptureInterval.Enabled = true;

            }
        }

        private void stopTimer()
        {
            screenCaptureInterval.Enabled = false;
        }

        private void TrayIcon_DoubleClick(object sender, EventArgs e)
        {
            if (screenCaptureInterval.Enabled)
            {
                trayIcon.Icon = Resources.Hyperion_disabled;
                trayIcon.Text = "Hyperion Screen Capture (Disabled)";
                screenCaptureInterval.Stop();
            }
            else
            {
                trayIcon.Icon = Resources.Hyperion_enabled;
                trayIcon.Text = "Hyperion Screen Capture (Enabled)";
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

        static void capture()
        {
            try
            {
                Surface s = d.CaptureScreen();
              
                DataRectangle dr = s.LockRectangle(LockFlags.None);
                DataStream gs = dr.Data;

                var x = removeAlpha(gs);

                s.UnlockRectangle();
                s.Dispose();
                gs.Dispose();

                
                if (protocol == "json")
                {
                    var y = Convert.ToBase64String(x);
                    setImage(y, hyperionMessagePriority, hyperionMessageDuration);
                    y = null;
                }
                else if (protocol == "proto")
                {
                    protoClient.SendImage(x, null);
                }
                

            }
            catch (Exception ex)
            {
                Notifications.Error("Failed to take screenshot." + ex.Message);
            }
        }

        #endregion

        #region Tools

        static string serialize(Hashtable n)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(n);
        }
        static byte[] removeAlpha(DataStream ia)
        {
            List<byte> newImage = new List<byte>();
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

        static byte[] resizeImageArray(DataStream ia, int factor)
        {
            List<byte> newImage = new List<byte>();

            for (var i = 0; i < Screen.PrimaryScreen.Bounds.Height; i += 4)
            {
                for (var z = 0; z < Screen.PrimaryScreen.Bounds.Width; z += 4)
                {
                    var a = new byte[4];
                    //ia.Position = i + (z * 4);
                    ia.Read(a, 0, 4);

                    newImage.Add(a[0]);
                    newImage.Add(a[1]);
                    newImage.Add(a[2]);
                }
            }
            return newImage.ToArray();
        }

        #endregion

        #region TcpClient

        static TcpClient hyperionServer;
        static ProtoClient protoClient;
        static NetworkStream serverStream;
        static StreamWriter sendToServer;
        static StreamReader readFromServer;

        static void connectToServer(string ip, int port)
        {
            try
            {
                Notifications.Info(String.Format("Connecting to Hyperion server: {0}:{1}", hyperionServerIP, hyperionServerJsonPort));

                hyperionServer = new TcpClient(ip, port);
                hyperionServer.NoDelay = true;
                serverStream = hyperionServer.GetStream();
                sendToServer = new StreamWriter(serverStream);
                sendToServer.AutoFlush = true;

                readFromServer = new StreamReader(serverStream);

                
            }
            catch (Exception ex)
            {
                Notifications.Error("Failed to connect to server. " + ex.Message);
            }
        }
        static void closeConnection()
        {
            try
            {
                serverStream.Dispose();
                sendToServer.Dispose();
                hyperionServer.Close();
            }
            catch { }
        }

        public static bool Connected()
        {
            if (hyperionServer != null)
            {
                return hyperionServer.Connected;
            }
            return false;
        }

        static void sendMessage(Hashtable command)
        {
            try
            {
                var message = serialize(command);
                sendToServer.WriteLine(message);
                message = null;
                string response = readFromServer.ReadLine();

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

        static void setImage(string base64Image, int priority, int duration)
        {
            try
            {
                Hashtable command = new Hashtable();

                command["command"] = "image";
                command["priority"] = priority;
                command["imagewidth"] = hyperionWidth;
                command["imageheight"] = hyperionHeight;
                command["imagedata"] = base64Image;
                if (duration > 0)
                {
                    command["duration"] = duration;
                }

                // send command message
                sendMessage(command);
                command = null;
            }
            catch (Exception ex)
            {
                Notifications.Error("Failed to create JSON Message. " + ex.Message);
            }
            
        }

        #endregion

        private void screenCaptureInterval_Tick(object sender, EventArgs e)
        {
            capture();
        }
    }
}
