using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTester.LogsAnalyzer
{
   

    [JsonObject(IsReference = false)]
    public class Rule
    {
        [JsonProperty]
        public List<string> Keywords { get; set; }

        [JsonProperty]
        public List<string> ChildKeywords { get; set; }

        [JsonProperty]
        public string Options { get; set; }

        [JsonProperty]
        public List<Result> Results { get; set; }

        [JsonProperty]
        public string Name { get; set; }

        public string GetKey()
        {
            return string.Join("-", Keywords.ToArray());
        }

        [JsonProperty]
        public bool MatchCase { get; set; }

        [JsonProperty]
        public bool MatchWholeWord { get; set; }

    }
}
