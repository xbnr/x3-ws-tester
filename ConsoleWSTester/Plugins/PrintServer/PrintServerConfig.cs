using System;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Converters;
using ConsoleTester.Plugins;
using ConsoleTester.Common;
using ConsoleTester.UI;
using System.Collections.Generic;

namespace ConsoleTester.Plugins.XsdValidator
{
    [JsonObject(IsReference = false)]
    public class PrintServerConfig : IConfigService
    {
        internal const string ConfigName = "PrintServerConfigConfig";

        public string GetTitle()
        {
            return "PrintServer tester";
        }

        public string GetFormFullName()
        {
            return typeof(PrintServerControl).FullName;
        }

        [JsonProperty]
        public string InstallDirectory { get; set; }

        [JsonProperty]
        public string Action { get; set; }

        [JsonProperty]
        public string ConnectionInfo { get; set; }

        [JsonProperty]
        public string ReportDirectory { get; set; }

        [JsonProperty]
        public string ReportName { get; set; }

        [JsonProperty]
        public string ExportDirectory { get; set; }

        [JsonProperty]
        public string Settings { get; set; }

        [JsonProperty]
        public List<string> Parameters { get; set; }



        internal static string GetWorkspaceShortFilename()
        {
            return $"{ConfigName}.json";
        }

        internal static string GetWorkspaceFilename()
        {
            return System.IO.Path.Combine(Program.GetWorkspaceDirectory(), GetWorkspaceShortFilename());
        }

        public string GetConfigPrefixFilename()
        {
            return ConfigName;
        }
    }
}
