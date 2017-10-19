using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTester.LogsAnalyzer
{
    [JsonObject(IsReference = false)]
    public class Result
    {
        [JsonProperty]
        public int Line { get; set; }

        [JsonProperty]
        public string TemplateValue { get; set; }

        [JsonProperty]
        public string Content { get; set; }
    }

}
