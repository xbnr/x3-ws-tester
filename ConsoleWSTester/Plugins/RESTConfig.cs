using System;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Converters;
using ConsoleTester.Common;
using ConsoleTester.UI;

namespace ConsoleTester.Plugins
{
    [JsonObject(IsReference = false)]
    public class RESTConfig : IConfigService
    {
        private const int MaxListSize = 4;
        public const string RESTConfigName = "RESTConfig";

        public string GetTitle()
        {
            return "REST tester";
        }

        public string GetFormFullName()
        {
            return typeof(WsRESTControl).FullName;
        }

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
        public SOAPWebServiceCall.OperationMode OperatMode { get; set; }


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
            return $"{RESTConfigName}.json";
        }

        internal static string GetWorkspaceFilename()
        {
            return System.IO.Path.Combine(Program.GetWorkspaceDirectory(), GetWorkspaceShortFilename());
        }

        
    }
}
