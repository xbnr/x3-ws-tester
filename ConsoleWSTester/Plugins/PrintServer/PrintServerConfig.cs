using System;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Converters;
using ConsoleTester.Plugins;
using ConsoleTester.Common;
using ConsoleTester.UI;
using System.Collections.Generic;

namespace ConsoleTester.Plugins.PrintServer
{
    [JsonObject(IsReference = false)]
    public class PrintServerConfigParameter
    {
        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public string Value { get; set; }

    }

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
        public string OdbcDatasource { get; set; }

        [JsonProperty]
        public string Basetype { get; set; }

        [JsonProperty]
        public string Login { get; set; }

        [JsonProperty]
        public string Password { get; set; }

        [JsonProperty]
        public string ReportFilename { get; set; }

        [JsonProperty]
        public string ExportDirectory { get; set; }

        [JsonProperty]
        public string Settings { get; set; }

        [JsonProperty]
        public PrintServerConfigParameter[] Parameters { get; set; }


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
