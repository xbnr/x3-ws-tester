using Newtonsoft.Json;
using System.Collections.Generic;

namespace ConsoleTester.LogsAnalyzer
{

    [JsonObject(IsReference = false)]
    public class Rule
    {
        public Rule()
        {
            this.Keywords = new List<string>();
            this.ChildKeywords = new List<string>();
            this.Results = new List<Result>();
        }

        [JsonProperty]
        public List<string> Keywords { get; set; }

        [JsonProperty]
        public List<string> ChildKeywords { get; set; }

        [JsonProperty]
        public List<Result> Results { get; set; }

        [JsonProperty]
        public string Name { get; set; }

        public string ProcessName()
        {
            return string.Join("-", Keywords.ToArray());
        }

        public string GetName()
        {
            if (string.IsNullOrEmpty(Name))
            {
                return ProcessName();
            }
            return Name;
        }

        [JsonProperty]
        public bool MatchCase { get; set; }

        [JsonProperty]
        public bool MatchWholeWord { get; set; }

        [JsonProperty]
        public bool Disabled { get; set; }


    }
}
