using HyperionScreenCap.Model.GitHub;
using log4net;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace HyperionScreenCap.Helper
{
    class UpdateChecker
    {
        private const string GITHUB_API_BASE_URL = "https://api.github.com";
        private const string GITHUB_LATEST_RELEASE_GET_URL = "repos/sabaatworld/HyperionScreenCap/releases/latest";
        private const string TAG_NAME_PREFIX = "v";

        private static readonly ILog LOG = LogManager.GetLogger(typeof(UpdateChecker));
        private static readonly Version ZERO_VERSION = new Version(0, 0);

        private RestClient _restClient;
        public Release LatestRelease { get; private set; }

        public UpdateChecker()
        {
            _restClient = new RestClient(GITHUB_API_BASE_URL);
            RestRequest request = new RestRequest(GITHUB_LATEST_RELEASE_GET_URL, Method.GET);
            IRestResponse<Release> response = _restClient.Execute<Release>(request);
            LatestRelease = response.Data;
        }

        public bool IsUpdateAvailable()
        {
            if ( LatestRelease != null )
            {
                Version currVer = Assembly.GetExecutingAssembly().GetName().Version;
                Version newVer;
                try
                {
                    newVer = new Version(LatestRelease.tag_name.Replace(TAG_NAME_PREFIX, ""));
                }
                catch ( Exception ex )
                {
                    LOG.Error($"Tag name ({LatestRelease.tag_name}) for the latest release has an unexpected format", ex);
                    newVer = ZERO_VERSION; // Fall back on 0.0
                }
                if ( newVer > currVer )
                    return true;
            }
            return false;
        }

        public static void StartUpdateCheck(bool isStartupCheck)
        {
            LOG.Info("Starting update check");
            UpdateChecker updateChecker = new UpdateChecker();
            if ( updateChecker.IsUpdateAvailable() )
            {
                Release latestRelease = updateChecker.LatestRelease;
                StringBuilder bodyBuilder = new StringBuilder();
                bodyBuilder.Append("New Version: " + latestRelease.tag_name + "\n");
                bodyBuilder.Append("Release Date: " + latestRelease.published_at + "\n");
                bodyBuilder.Append("Release Notes:\n" + latestRelease.body + "\n");
                bodyBuilder.Append("\n");
                LOG.Info("Update available:\n" + bodyBuilder);
                bodyBuilder.Append("Would you like to download the update?");
                DialogResult dialogResult = MessageBox.Show(bodyBuilder.ToString(), "Hyperion Screen Capture Update Available",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if ( dialogResult == DialogResult.Yes )
                {
                    LOG.Info("Starting latest release download");
                    Process.Start(latestRelease.assets[0].browser_download_url);
                }
            }
            else
            {
                if ( !isStartupCheck )
                {
                    MessageBox.Show("No updates available. If you think this is an error, please check your internet connection.",
                        "Hyperion Screen Capture Update Check", MessageBoxButtons.OK);
                }
            }
        }
    }
}
