using System;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Converters;
using ConsoleTester.Common;
using ConsoleTester.UI;

namespace ConsoleTester.Plugins
{
    [JsonObject(IsReference = false)]
    public class SOAPConfig : IConfigService
    {
        private const int MaxListSize = 4;
        internal const string SOAPConfigName = "SOAPConfig";
        

        public string GetTitle()
        {
            return "SOAP tester";
        }

        public string GetFormFullName()
        {
            return typeof(WsSOAPTester).FullName;
        }

        public string GetConfigPrefixFilename()
        {
            return SOAPConfigName;
        }

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
        public SOAPWebServiceCall.OperationMode OperatMode { get; set; }


        [JsonProperty]
        public CAWebService.CAdxParamKeyValue[] ObjectKeys { get; set; }

        [JsonProperty]
        public string BlocKey { get; set; }

        [JsonProperty]
        public string[] LineKeys { get; set; }

        [JsonProperty]
        public int ListSize { get; set; }

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
