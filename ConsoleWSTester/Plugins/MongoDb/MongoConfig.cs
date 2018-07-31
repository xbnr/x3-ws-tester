using System;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Converters;
using ConsoleTester.Common;
using ConsoleTester.UI;

namespace ConsoleTester.Plugins.MongoDb
{
    [JsonObject(IsReference = false)]
    public class MongoConfig : IConfigService
    {
        private const int MaxListSize = 4;
        public const string MongoConfigName = "MongoConfig";

        public string GetTitle()
        {
            return "MongoConfig tester";
        }

        public string GetFormFullName()
        {
            return typeof(MongoDbEDI).FullName;
        }

        [JsonProperty]
        public string HostUrl { get; set; }

        [JsonProperty]
        public string Login { get; set; }

        [JsonProperty]
        public string Password { get; set; }

        [JsonProperty]
        public string Name { get; set; }


        internal static string GetWorkspaceShortFilename()
        {
            return $"{MongoConfigName}.json";
        }

        internal static string GetWorkspaceFilename()
        {
            return System.IO.Path.Combine(Program.GetWorkspaceDirectory(), GetWorkspaceShortFilename());
        }

        public string GetConfigPrefixFilename()
        {
            return MongoConfigName;
        }
    }
}
