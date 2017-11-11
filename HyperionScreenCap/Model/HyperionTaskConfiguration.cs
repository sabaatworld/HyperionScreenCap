using HyperionScreenCap.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HyperionScreenCap.Model
{
    [Serializable]
    public class HyperionTaskConfiguration
    {
        public String Id { get; set; }
        public String HyperionHost { get; set; }
        public int HyperionPort { get; set; }
        public int HyperionPriority { get; set; }
        public int HyperionMessageDuration { get; set; }
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

        public static HyperionTaskConfiguration BuildUsingLegacySettings()
        {
            return new HyperionTaskConfiguration()
            {
                Id = GetNewId(),
                HyperionHost = Settings.Default.hyperionServerIP,
                HyperionPort = Settings.Default.hyperionServerPort,
                HyperionPriority = Settings.Default.hyperionMessagePriority,
                HyperionMessageDuration = Settings.Default.hyperionMessageDuration,
                CaptureMethod = Settings.Default.captureMethod,
                Dx9CaptureHeight = Settings.Default.height,
                Dx9CaptureWidth = Settings.Default.width,
                Dx9MonitorIndex = Settings.Default.monitorIndex,
                Dx9CaptureInterval = Settings.Default.captureInterval,
                Dx11MaxFps = Settings.Default.dx11MaxFps,
                Dx11FrameCaptureTimeout = Settings.Default.dx11FrameCaptureTimeout,
                Dx11ImageScalingFactor = Settings.Default.dx11ImageScalingFactor,
                Dx11AdapterIndex = Settings.Default.dx11AdapterIndex,
                Dx11MonitorIndex = Settings.Default.dx11MonitorIndex
            };
        }

        public static String GetNewId()
        {
            return Guid.NewGuid().ToString().Substring(0, 6);
        }
    }
}
