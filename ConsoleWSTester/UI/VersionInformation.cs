using Newtonsoft.Json;
using System;

namespace ConsoleTester.UI
{
    internal sealed class VersionInformation
    {
        [JsonProperty]
        public DateTime Date
        {
            get;
            set;
        }

        [JsonProperty]
        public string Version
        {
            get;
            set;
        }

        [JsonProperty]
        public string Description
        {
            get;
            set;
        }

        [JsonProperty]
        public string DownloadUrl
        {
            get;
            set;
        }
    }
}
