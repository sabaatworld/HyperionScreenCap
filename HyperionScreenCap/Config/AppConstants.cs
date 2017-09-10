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
        /// Amount of time to wait before attempting capture after a failure.
        /// </summary>
        public const int CAPTURE_FAILED_COOLDOWN_MILLIS = 3000;

    }
}
