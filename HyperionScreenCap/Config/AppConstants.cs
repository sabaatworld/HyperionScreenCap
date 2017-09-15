using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HyperionScreenCap.Config
{
    class AppConstants
    {
        /// <summary>
        /// Maximum number of consecutive screen capture attempts before giving up and disabling screen capture.
        /// </summary>
        public const int MAX_CAPTURE_ATTEMPTS = 10;

        /// <summary>
        /// Amount of time to wait before attempting screen capture after a failure.
        /// </summary>
        public const int CAPTURE_FAILED_COOLDOWN_MILLIS = 3000;

        /// <summary>
        /// Amount of time to wait before resuming screen capture.
        /// </summary>
        public const int CAPTURE_RESUME_GRACE_MILLIS = 5000;

        /// <summary>
        /// Tray icon tooltip message displayed when Hyperion server is not connected.
        /// </summary>
        public const string TRAY_ICON_MSG_NOT_CONNECTED = "Hyperion Screen Capture (Not Connected)";

        /// <summary>
        /// Tray icon tooltip message displayed when screen capture is disabled.
        /// </summary>
        public const string TRAY_ICON_MSG_CAPTURE_DISABLED = "Hyperion Screen Capture (Disabled)";

        /// <summary>
        /// Tray icon tooltip message displayed when screen capture is enabled.
        /// </summary>
        public const string TRAY_ICON_MSG_CAPTURE_ENABLED = "Hyperion Screen Capture (Enabled)";

    }
}
