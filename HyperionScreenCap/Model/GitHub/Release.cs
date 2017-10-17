using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HyperionScreenCap.Model.GitHub
{
    class Release
    {

        public string tag_name { get; set; }
        public string body { get; set; }
        public DateTime published_at { get; set; }
        public List<ReleaseAsset> assets { get; set; }

    }
}
