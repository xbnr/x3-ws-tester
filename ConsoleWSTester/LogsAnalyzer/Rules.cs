using ConsoleTester.Common;
using ConsoleTester.WebService;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTester.LogsAnalyzer
{
    [JsonObject(IsReference = false)]
    public class Rules : IConfigService
    {
        public string GetConfigName()
        {
            return "LogAnalysis";
        }

        public string GetTitle()
        {
            return "Log analysis";
        }

        [JsonProperty]
        public List<Rule> RulesList { get; set; }

        [JsonProperty]
        public string Folder { get; set; }

        [JsonProperty]
        public string File { get; set; }

        public int CountResults()
        {
            int nbResults = 0;
            foreach (var rule in this.RulesList)
            {
                nbResults += rule.Results == null ? 0 : rule.Results.Count;
            }
            return nbResults;
        }

       
    }
}
