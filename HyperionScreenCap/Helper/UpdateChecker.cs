using HyperionScreenCap.Model.GitHub;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace HyperionScreenCap.Helper
{
    class UpdateChecker
    {
        private const string GITHUB_API_BASE_URL = "https://api.github.com";
        private const string GITHUB_LATEST_RELEASE_GET_URL = "repos/sabaatworld/HyperionScreenCap/releases/latest";
        private const string RELEASE_TAG_NAME_PREFIX = "v";

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
            var currentVersionTagName = RELEASE_TAG_NAME_PREFIX + Assembly.GetExecutingAssembly().GetName().Version.ToString();
            if ( LatestRelease == null || currentVersionTagName.StartsWith(LatestRelease.tag_name)
                || LatestRelease.assets.Count == 0 )
                return false;
            else
                return true;
        }

    }
}
