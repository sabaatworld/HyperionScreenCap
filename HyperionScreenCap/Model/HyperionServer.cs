using HyperionScreenCap.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HyperionScreenCap.Model
{
    [Serializable]
    public class HyperionServer
    {
        public String Host { get; set; }
        public int Port { get; set; }
        public int Priority { get; set; }
        public int MessageDuration { get; set; }

        public static HyperionServer BuildUsingLegacySettings()
        {
            return new HyperionServer()
            {
                Host = Settings.Default.hyperionServerIP,
                Port = Settings.Default.hyperionServerPort,
                Priority = Settings.Default.hyperionMessagePriority,
                MessageDuration = Settings.Default.hyperionMessageDuration
            };
        }

        public static HyperionServer BuildUsingDefaultSettings()
        {
            return new HyperionServer()
            {
                Host = "0.0.0.0",
                Port = 19445,
                Priority = 10,
                MessageDuration = 1500
            };
        }
    }
}
