using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleTester.LogsAnalyzer
{

    internal class LogAnalyze
    {
        private string folder;
        private string filter;
        private bool recurseSubFolder;
        private ILogger logger;
        private Rules rules;

        internal static readonly string ResultRulesShortName = "RulesResult";
        internal static readonly string RulesShortName = "RulesConfig";

        internal static string GetResultRulesShortFilename(FileInfo file)
        {
            return $"{ResultRulesShortName}.{file.Name}.json";
        }

        internal static string GetResultRulesFilename(FileInfo file)
        {
            string subdirectory = Path.Combine(Program.GetWorkspaceDirectory(), DateTime.Now.ToString("yyyyMMddHHmm"));
            Directory.CreateDirectory(subdirectory);
            return Path.Combine(subdirectory, GetResultRulesShortFilename(file));
        }

        internal static string GetRulesShortFilename()
        {
            return $"{RulesShortName}.json";
        }

        internal static string GetRulesFilename()
        {
            return Path.Combine(Program.GetWorkspaceDirectory(), GetRulesShortFilename());
        }

        internal LogAnalyze(string folderToAnalyze, string filter, bool recurseSubFolder, ILogger logger)
        {
            this.folder = folderToAnalyze;
            this.filter = filter;
            this.recurseSubFolder = recurseSubFolder;
            this.logger = logger;
        }

        internal Rules LoadRules()
        {
            Rules config = JsonConvert.DeserializeObject<Rules>(File.ReadAllText(GetRulesFilename()));

            return config;
            //var rules = new Rules();
            //rules.RulesList = new List<Rule>();
            //rules.IgnoreCase = true;

            //var rule0 = new Rule();
            //rule0.Keywords = new List<string>();
            //rule0.Keywords.Add("Error");
            //rule0.Name = rule0.GetKey();
            //rule0.MatchCase = true;
            //rule0.MatchWholeWord = true;
            //rule0.Results = new List<Result>();
            //rules.RulesList.Add(rule0);

            //var rule1 = new Rule();
            //rule1.Keywords = new List<string>();
            //rule1.Keywords.Add("SYRACUSE REQUEST");
            //rule1.Keywords.Add("trackingId={guid}");
            //rule1.ChildKeywords = new List<string>();
            //rule1.ChildKeywords.Add("SYRACUSE RESPONSE");
            //rule1.ChildKeywords.Add("trackingId={guid}");
            //rule1.Options = "trackingId={guid}";
            //rule1.Name = rule1.GetKey();
            //rule1.MatchCase = true;
            //rule1.MatchWholeWord = true;
            //rule1.Results = new List<Result>();
            //rules.RulesList.Add(rule1);

            //return rules;
        }

        internal void LaunchAnalyze()
        {
            this.rules = LoadRules();
            var list = GetAllFiles(this.folder, this.filter, this.recurseSubFolder);
            this.logger.Log($"Start analyze: {list.Count()} files in {this.folder}. Filter: {this.filter}");
            foreach (var fileName in list)
            {
                AnalyzeFile(fileName);
            }
            this.logger.Log($"Analyze finished");


        }

        private FileInfo[] GetAllFiles(string folder, string searchPattern, bool recurseDir)
        {
            DirectoryInfo dir = new DirectoryInfo(folder);
            return dir.GetFiles(searchPattern, recurseDir ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
        }

        private void AnalyzeFile(FileInfo file)
        {
            var streamReader = File.OpenText(file.FullName);
            string line = null;
            int index = 0;
            while ((line = streamReader.ReadLine()) != null)
            {
                CheckAllRules(line, index, this.rules);
                index++;
            }

            SaveResults(this.rules, file);
            ClearResults(rules);
        }

        internal void SaveResults(Rules rules, FileInfo file)
        {
            string wsDirectory = Program.GetWorkspaceDirectory();
            if (!Directory.Exists(wsDirectory))
                Directory.CreateDirectory(wsDirectory);

            string filename = GetResultRulesFilename(file);
            rules.File = file.FullName;

            string json = JsonConvert.SerializeObject(rules, Formatting.Indented, new JsonSerializerSettings
            {
                Converters = new List<JsonConverter> { new StringEnumConverter() },
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented,
                DefaultValueHandling = DefaultValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });

            int nbResults = 0;
            string suffix = "";
            foreach (var rule in rules.RulesList)
            {
                suffix += $"{rule.Name}: {rule.Results.Count} results  ";
                nbResults += rule.Results.Count;
            }
            this.logger.Log($"Save result in {filename}. {suffix} Total results: {nbResults}", nbResults > 0);
            File.WriteAllText(filename, json, Encoding.UTF8);
        }

        private static void ClearResults(Rules rules)
        {
            foreach (var rule in rules.RulesList)
            {
                rule.Results.Clear();
            }
        }

        private void CheckAllRules(string line, int index, Rules rules)
        {
            foreach (var rule in rules.RulesList)
            {
                Result result = GetResult(line, index, rule, rule.Keywords);
                if (result != null)
                {
                    rule.Results.Add(result);
                }
                // Options to manage
                if (rule.ChildKeywords?.Count > 0)
                {
                    result = GetResult(line, index, rule, rule.ChildKeywords);
                    if (result != null)
                    {
                        var resultWithTemplate = SearchRuleWithTemplate(result.TemplateValue, rule);

                        if (string.IsNullOrEmpty(result.TemplateValue))
                        {
                            rule.Results.Add(result);
                        }
                        else if (resultWithTemplate != null)
                        {
                            rule.Results.Remove(resultWithTemplate);
                        }
                    }
                }

            }
        }

        private Result SearchRuleWithTemplate(string templateValue, Rule rule)
        {
            return rule.Results.SingleOrDefault(p => p.TemplateValue == templateValue);
        }

        private static Result GetResult(string line, int index, Rule rule, List<string> keywords)
        {
            bool found = true;
            string templateValue = null;
            foreach (var keyword in keywords)
            {
                string keyw = GetKeyword(keyword);

                string expression = @"(" + keyw + ")";
                if (rule.MatchWholeWord)
                {
                    // expression = @"/\b(" + keyw + ")\b/i"; // @"(?<=\W |^)("+ keyw + @")(?=\W |$)"; // @"\b" + keyw + "\b";
                    // expression = @"^"+ keyw + "$"; // @"(?<=\W |^)("+ keyw + @")(?=\W |$)"; // @"\b" + keyw + "\b";
                    expression = @"(^|\\W)" + keyw + "($|\\W)";
                }

                if (!rule.MatchCase)
                {
                    expression += "/i";
                }
                var reg = new Regex(expression);
                // bool match = Regex.IsMatch(line, expression, rule.MatchCase ? RegexOptions.CultureInvariant : RegexOptions.IgnoreCase);
                if (!reg.Match(line).Success)
                {
                    found = false;
                    break;
                }
                else if (HasTemplate(keyword))
                {
                    templateValue = GetTemplateValue(keyword, line);
                }
            }

            if (found)
            {
                var result = new Result();
                result.Line = index;
                result.Content = line;
                result.TemplateValue = templateValue;
                return result;
            }
            return null;
        }

        private static string GetKeyword(string keyword)
        {
            string keyw = keyword;
            int indexGuid = keyword.IndexOf("{guid}");
            if (indexGuid >= 0)
            {
                keyw = keyword.Substring(0, indexGuid);
            }

            return keyw;
        }

        private static bool HasTemplate(string keyword)
        {
            int indexGuid = keyword.IndexOf("{guid}");
            return (indexGuid >= 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="template">"trackingId={guid}"</param>
        /// <param name="line"></param>
        /// <returns>
        /// Ex: trackingId=AAABBBB
        /// Return AAABBBB
        /// </returns>
        private static string GetTemplateValue(string template, string line)
        {
            string keyw = GetKeyword(template);
            int i = line.IndexOf(keyw);
            if (i >= 0)
            {
                string templateValue = line.Substring(i + keyw.Length);
                string[] templateValueArray = templateValue.Split(new char[] { '&', ' ', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                if (templateValueArray.Count() > 0)
                {
                    return templateValueArray[0];
                }
            }
            return null;
        }

    }
}
