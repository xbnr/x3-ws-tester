﻿using System;
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
        public const string ConfigName = "XsdValidatorConfig";

        public string GetTitle()
        {
            return "Xsd validator";
        }

        public string GetFormFullName()
        {
            return typeof(XsdValidatorControl).FullName;
        }

        public string GetPromptToolFullName()
        {
            return typeof(XsdValidatorControl).FullName;
        }


        [JsonProperty]
        public string XMLFilename { get; set; }

        [JsonProperty]
        public List<string> XSDFiles { get; set; }

        [JsonProperty]
        public bool ShowWarnings { get; set; }




        [JsonProperty]
        public string XMLFilenameForXSD { get; set; }



        internal static string GetWorkspaceShortFilename()
        {
            return $"{ConfigName}.json";
        }

        internal static string GetWorkspaceFilename()
        {
            return System.IO.Path.Combine(ProgramUI.GetWorkspaceDirectory(), GetWorkspaceShortFilename());
        }

        public string GetConfigPrefixFilename()
        {
            return ConfigName;
        }
    }
}
