using ConsoleTester.Common;
using ConsoleTester.Plugins;
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
        internal const string RulesShortName = "LogAnalysisConfig";

        public string GetFormFullName()
        {
            return typeof(ConsoleTester.UI.LogAnalyzer).FullName;
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

        public string GetConfigPrefixFilename()
        {
            return RulesShortName;
        }
    }
}
