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
    public class XsdValidatorConfig : IConfigService
    {
        public const string XsdValidatorConfigName = "XsdValidatorConfig";

        public string GetTitle()
        {
            return "XsdValidator tester";
        }

        public string GetFormFullName()
        {
            return typeof(XsdValidatorControl).FullName;
        }

        [JsonProperty]
        public string XMLFilename { get; set; }

        [JsonProperty]
        public List<string> XSDFiles { get; set; }

        [JsonProperty]
        public bool ShowWarnings { get; set; }

        internal static string GetWorkspaceShortFilename()
        {
            return $"{XsdValidatorConfigName}.json";
        }

        internal static string GetWorkspaceFilename()
        {
            return System.IO.Path.Combine(Program.GetWorkspaceDirectory(), GetWorkspaceShortFilename());
        }

        public string GetConfigPrefixFilename()
        {
            return XsdValidatorConfigName;
        }
    }
}
