using HyperionScreenCap.Properties;
using System;
using System.Collections.Generic;

namespace HyperionScreenCap.Model
{
    [Serializable]
    public class HyperionTaskConfiguration
    {
        public String Id { get; set; }
        public bool Enabled { get; set; }
        public CaptureMethod CaptureMethod { get; set; }
        public int Dx9CaptureWidth { get; set; }
        public int Dx9CaptureHeight { get; set; }
        public int Dx9MonitorIndex { get; set; }
        public int Dx9CaptureInterval { get; set; }
        public int Dx11MaxFps { get; set; }
        public int Dx11FrameCaptureTimeout { get; set; }
        public int Dx11ImageScalingFactor { get; set; }
        public int Dx11AdapterIndex { get; set; }
        public int Dx11MonitorIndex { get; set; }
        public List<HyperionServer> HyperionServers { get; set; }

        public static HyperionTaskConfiguration BuildUsingLegacySettings()
        {
            List<HyperionServer> hyperionServers = new List<HyperionServer>();
            hyperionServers.Add(HyperionServer.BuildUsingDefaultFbsSettings());

            return new HyperionTaskConfiguration()
            {
                Id = GetNewId(),
                Enabled = true,
                CaptureMethod = Settings.Default.captureMethod,
                Dx9CaptureHeight = Settings.Default.height,
                Dx9CaptureWidth = Settings.Default.width,
                Dx9MonitorIndex = Settings.Default.monitorIndex,
                Dx9CaptureInterval = Settings.Default.captureInterval,
                Dx11MaxFps = Settings.Default.dx11MaxFps,
                Dx11FrameCaptureTimeout = Settings.Default.dx11FrameCaptureTimeout,
                Dx11ImageScalingFactor = Settings.Default.dx11ImageScalingFactor,
                Dx11AdapterIndex = Settings.Default.dx11AdapterIndex,
                Dx11MonitorIndex = Settings.Default.dx11MonitorIndex,
                HyperionServers = hyperionServers
            };
        }

        public static HyperionTaskConfiguration BuildUsingDefaultSettings()
        {
            List<HyperionServer> hyperionServers = new List<HyperionServer>();
            hyperionServers.Add(HyperionServer.BuildUsingDefaultFbsSettings());

            return new HyperionTaskConfiguration()
            {
                Id = GetNewId(),
                Enabled = true,
                CaptureMethod = CaptureMethod.DX11,
                Dx9CaptureHeight = 64,
                Dx9CaptureWidth = 64,
                Dx9MonitorIndex = 0,
                Dx9CaptureInterval = 5,
                Dx11MaxFps = 60,
                Dx11FrameCaptureTimeout = 1250,
                Dx11ImageScalingFactor = 32,
                Dx11AdapterIndex = 0,
                Dx11MonitorIndex = 0,
                HyperionServers = hyperionServers
            };
        }

        public static String GetNewId()
        {
            return Guid.NewGuid().ToString().Substring(0, 6);
        }

        public HyperionTaskConfiguration DeepCopy()
        {
            var copy = (HyperionTaskConfiguration) MemberwiseClone();
            copy.Id = String.Copy(Id);
            copy.HyperionServers = new List<HyperionServer>();
            HyperionServers.ForEach(server => copy.HyperionServers.Add(server.DeepCopy()));
            return copy;
        }
    }
}
