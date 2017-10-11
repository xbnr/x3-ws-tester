using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public int ListSize => MaxListSize;


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
            return Path.Combine(WorkspaceConfig.GetWorkspaceDirectory(), GetWorkspaceShortFilename());
        }

        internal static string GetWorkspaceDirectory()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Sage", "X3WsTester");
        }

    }
}
