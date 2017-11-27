using System;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Converters;

namespace ConsoleTester
{
    [JsonObject(IsReference = false)]
    public class RESTConfig
    {
        private const int MaxListSize = 4;
        public const string SOAPConfigName = "RESTConfig";


        [JsonProperty]
        public string HostUrl { get; set; }

        [JsonProperty]
        public string Path { get; set; }

        [JsonProperty]
        public string Language { get; set; }

        [JsonProperty]
        public string XmlObject { get; set; }

        [JsonProperty]
        public string XmlFilename { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public WebServiceCall.OperationMode OperatMode { get; set; }


        [JsonProperty]
        public CAWebService.CAdxParamKeyValue[] ObjectKeys { get; set; }

        [JsonProperty]
        public string Login { get; set; }

        [JsonProperty]
        public string Password { get; set; }

        [JsonProperty]
        public string Name { get; set; }


        internal static string GetWorkspaceShortFilename()
        {
            return $"{SOAPConfigName}.json";
        }

        internal static string GetWorkspaceFilename()
        {
            return System.IO.Path.Combine(Program.GetWorkspaceDirectory(), GetWorkspaceShortFilename());
        }

    }
}
