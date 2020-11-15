using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HyperionScreenCap.Config
{
    class AppConstants
    {
        /// <summary>
        /// Maximum number of consecutive screen capture attempts before giving up and disabling screen capture.
        /// </summary>
        public const int MAX_CAPTURE_ATTEMPTS = 30;

        /// <summary>
        /// Number of screen capture failure attemps after which screen capture should be re-initialized.
        /// </summary>
        public const int REINIT_CAPTURE_AFTER_ATTEMPTS = 24;

        /// <summary>
        /// Amount of time to wait before attempting screen capture after a failure.
        /// </summary>
        public const int CAPTURE_FAILED_COOLDOWN_MILLIS = 1000;

        /// <summary>
        /// Amount of time to wait before resuming screen capture.
        /// </summary>
        public const int CAPTURE_RESUME_GRACE_MILLIS = 5000;

        /// <summary>
        /// The send and receive timeout for the socket used by the Proto client.
        /// </summary>
        public const int PROTO_CLIENT_SOCKET_TIMEOUT = 2500;

        /// <summary>
        /// Interval after which each capture thread is polled for failure.
        /// </summary>
        public const int CAPTURE_FAILURE_DETECTION_INTERVAL = 2000;

        /// <summary>
        /// File name for debugging screen captured by this application.
        /// </summary>
        public static string DEBUG_IMAGE_FILE_NAME = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            + Path.DirectorySeparatorChar + "hyperion-capture-debug.png";

        /// <summary>
        /// Name of the application's log file.
        /// </summary>
        public static string LOG_FILE_NAME = "hyperion-screen-capture.log";

        /// <summary>
        /// Defines the constants related to the taskbar icon.
        /// </summary>
        public static class TrayIcon
        {
            /// <summary>
            /// Tooltip message displayed when screen capture is disabled.
            /// </summary>
            public const string TOOLTIP_CAPTURE_DISABLED = "Hyperion Screen Capture (Disabled)";

            /// <summary>
            /// Tooltip message displayed when screen capture is enabled.
            /// </summary>
            public const string TOOLTIP_CAPTURE_ENABLED = "Hyperion Screen Capture (Enabled)";

            /// <summary>
            /// Start capture menu option text.
            /// </summary>
            public const string MENU_TXT_START_CAPTURE = "Start Capture";

            /// <summary>
            /// Stop capture menu option text.
            /// </summary>
            public const string MENU_TXT_STOP_CAPTURE = "Stop Capture";

            /// <summary>
            /// Setup menu option text.
            /// </summary>
            public const string MENU_TXT_SETUP = "Setup";

            /// <summary>
            /// Setup menu option text.
            /// </summary>
            public const string MENU_TXT_DONATE = "Buy Me a Coffee";

            /// <summary>
            /// Exit menu option text.
            /// </summary>
            public const string MENU_TXT_EXIT = "Exit";
        }
    }
}
