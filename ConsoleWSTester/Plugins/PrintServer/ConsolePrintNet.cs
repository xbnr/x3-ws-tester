﻿using System;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Converters;
using ConsoleTester.Plugins;
using ConsoleTester.Common;
using ConsoleTester.UI;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ConsoleTester.Plugins.PrintServer
{
    [JsonObject(IsReference = false)]
    public class ConsolePrintNetParameter
    {
        public ConsolePrintNetParameter() { }

        public ConsolePrintNetParameter(string name, string value)
        {
            Name = name;
            Value = value;
        }

        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public string Value { get; set; }

    }

    [Serializable()]
    [JsonObject(IsReference = false)]
    public class ConsolePrintNet : IConfigService
    {
        internal const string ConfigName = "ConsolePrintNet";

        public string GetTitle()
        {
            return "PrintServer tester";
        }

        public string GetFormFullName()
        {
            return typeof(PrintServerControl).FullName;
        }
        public string GetPromptToolFullName()
        {
            return typeof(PrintPrompt).FullName;
        }

        [JsonProperty]
        public string InstallDirectory { get; set; }

        [JsonProperty]
        public string Action { get; set; }

        [JsonProperty]
        public bool OpenGeneratedFile { get; set; }


        [JsonProperty]
        public string OutputFormat { get; set; }

        [JsonProperty]
        public string OutputFilename { get; set; }

        [JsonProperty]
        public string OdbcDatasource { get; set; }

        [JsonProperty]
        public string DatabaseName { get; set; }

        [JsonProperty]
        public string Basetype { get; set; }

        [JsonProperty]
        public string Login { get; set; }

        [JsonProperty]
        public string Password { get; set; }

        [OnSerializing()]
        internal void OnSerializingMethod(StreamingContext context)
        {
            Password = PrintServerHelper.EncodePasswordToCryptedtring(Password);
        }

        [OnSerialized()]
        internal void OnSerializedMethod(StreamingContext context)
        {
            // member2 = "This value was reset after serialization.";
        }

        [OnDeserializing()]
        internal void OnDeserializingMethod(StreamingContext context)
        {
          //  member3 = "This value was set during deserialization";
        }

        [OnDeserialized()]
        internal void OnDeserializedMethod(StreamingContext context)
        {
            Password = PrintServerHelper.DecodePasswordFromCryptedString(Password);
        }

        [JsonProperty]
        public string ReportFilename { get; set; }

        [JsonProperty]
        public string ExportDirectory { get; set; }

        [JsonProperty]
        public ConsolePrintNetParameter[] Settings { get; set; }

        [JsonProperty]
        public ConsolePrintNetParameter[] Parameters { get; set; }


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
