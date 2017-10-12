﻿using System;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Converters;

namespace ConsoleWSTester
{
    [JsonObject(IsReference = false)]
    public class WorkspaceConfig
    {
        private const int MaxListSize = 4;

        [JsonProperty]
        public string HostUrl { get; set; }

        [JsonProperty]
        public string Path { get; set; }


        [JsonProperty]
        public string PoolAlias { get; set; }

        [JsonProperty]
        public string Language { get; set; }

        [JsonProperty]
        public string PublicName { get; set; }

        [JsonProperty]
        public string RequestConfiguration { get; set; }

        [JsonProperty]
        public string XmlObject { get; set; }

        [JsonProperty]
        public string XmlFilename { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public WebServiceCall.OperationMode OperatMode { get; set; }


        [JsonProperty]
        public CAWebService.CAdxParamKeyValue[] ObjectKeys { get; set; }

        [JsonProperty]
        public int ListSize { get; set; }

        [JsonProperty]
        public string Login { get; set; }

        [JsonProperty]
        public string Password { get; set; }


        internal static string GetWorkspaceShortName()
        {
            return "WorkspaceConfig";
        }

        internal static string GetWorkspaceShortFilename()
        {
            return $"{GetWorkspaceShortName()}.json";
        }

        internal static string GetWorkspaceFilename()
        {
            return System.IO.Path.Combine(WorkspaceConfig.GetWorkspaceDirectory(), GetWorkspaceShortFilename());
        }

        internal static string GetWorkspaceDirectory()
        {
            return System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Sage", "X3WsTester");
        }

    }
}