using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTester.LogsAnalyzer
{
    [JsonObject(IsReference = false)]
    public class Rules
    {
        [JsonProperty]
        public List<Rule> RulesList { get; set; }

        [JsonProperty]
        public string Folder { get; set; }

        [JsonProperty]
        public string File { get; set; }
    }
}
