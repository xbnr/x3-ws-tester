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
            string subdirectory = GetResultDirTarget();
            Directory.CreateDirectory(subdirectory);
            return Path.Combine(subdirectory, GetResultRulesShortFilename(file));
        }

        private static string resultDirectoryTarget = null;
        internal static string GetResultDirTarget()
        {
            if (string.IsNullOrEmpty( resultDirectoryTarget))
            {
                resultDirectoryTarget = Path.Combine(Program.GetWorkspaceDirectory(), DateTime.Now.ToString("yyyyMMddHHmm"));
            }
            return resultDirectoryTarget;
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

        private Rules LoadRules()
        {
            string fileName = GetRulesFilename();
            if (!File.Exists(fileName))
            {
                return null;
            }
            return JsonConvert.DeserializeObject<Rules>(File.ReadAllText(fileName));
        }

        private Rules CreateDefaultConfig()
        {
            var rules = new Rules();
            rules.RulesList = new List<Rule>();

            var rule = new Rule();
            rule.Keywords = new List<string>();
            rule.Keywords.Add("Error");
            rule.Name = rule.ProcessName();
            rule.MatchCase = true;
            rule.MatchWholeWord = false;
            rules.RulesList.Add(rule);

            var rule1 = new Rule();
            rule1.Keywords = new List<string>();
            rule1.Keywords.Add("Memory limit reached");
            rule1.Name = rule1.ProcessName();
            rule1.MatchCase = true;
            rule1.MatchWholeWord = true;
            rules.RulesList.Add(rule1);

            var rule2 = new Rule();
            rule2.Keywords.Add("SYRACUSE REQUEST");
            rule2.Keywords.Add("trackingId={guid}");
            rule2.ChildKeywords.Add("SYRACUSE RESPONSE");
            rule2.ChildKeywords.Add("trackingId={guid}");
            rule2.Name = rule2.ProcessName();
            rule2.MatchCase = true;
            rule2.MatchWholeWord = true;
            rules.RulesList.Add(rule2);

            return rules;
        }

        private int NbTotalResult = 0;

        internal void LaunchAnalyze()
        {
            resultDirectoryTarget = null;
            this.NbTotalResult = 0;
            this.rules = LoadRules();
            if (this.rules == null)
            {
                CreateDefaultConfigFile();
            }
            var logFilesToAnalyze = GetAllFiles(this.folder, this.filter, this.recurseSubFolder);
            this.logger.Log($"Start analyze: {logFilesToAnalyze.Count()} files in {this.folder}. Filter: {this.filter}");
            foreach (var fileName in logFilesToAnalyze)
            {
                AnalyzeFile(fileName);
            }

            AggregateResults();

            this.logger.Log($"Analyze finished: {this.NbTotalResult} results.");
        }

        private void CreateDefaultConfigFile()
        {
            string destination = GetRulesFilename();
            this.logger.Log($"Create ConfigFile: {destination}");
            this.rules = CreateDefaultConfig();
            SaveResults(this.rules, new FileInfo(destination));
        }

        private FileInfo[] GetAllFiles(string folder, string searchPattern, bool recurseDir)
        {
            DirectoryInfo dir = new DirectoryInfo(folder);
            if (!dir.Exists)
            {
                throw new IOException($"Directory {dir.FullName} doesn't exist");
            }
            return dir.GetFiles(searchPattern, recurseDir ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
        }

        private void AnalyzeFile(FileInfo file)
        {
            using (var streamReader = File.OpenText(file.FullName))
            {
                string line = null;
                int index = 0;
                while ((line = streamReader.ReadLine()) != null)
                {
                    CheckAllRules(line, index, this.rules);
                    index++;
                }
            }
            int nbResult = this.rules.CountResults();
            if (nbResult > 0)
            {
                this.NbTotalResult += nbResult;
                SaveResults(this.rules, file);
            }
            ClearResults(rules);
        }

        internal void SaveResults(Rules rules, FileInfo file)
        {
            string wsDirectory = Program.GetWorkspaceDirectory();
            if (!Directory.Exists(wsDirectory))
            {
                Directory.CreateDirectory(wsDirectory);
            }
            string filename = GetResultRulesFilename(file);
            rules.File = file.FullName;

            string json = JsonConvert.SerializeObject(rules, Formatting.Indented, new JsonSerializerSettings
            {
                Converters = new List<JsonConverter> { new StringEnumConverter() },
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented,
                DefaultValueHandling = DefaultValueHandling.Include,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });

            int nbResults = 0;
            string suffix = "";
            foreach (var rule in rules?.RulesList)
            {
                suffix += $"{rule.Name}: {rule.Results?.Count} results  ";
                nbResults += rule.Results == null ? 0 : rule.Results.Count;
            }
            this.logger.Log($"Save result in {filename}. {suffix} Total results: {nbResults}", nbResults > 0);
            File.WriteAllText(filename, json, Encoding.UTF8);
        }


        private void AggregateResults()
        {
            string directoryTarget = GetResultDirTarget();
            var filesResult = GetAllFiles(directoryTarget, "*.json", false);
            var resultDic = new Dictionary<string, List<Result>>();

            foreach (var fileName in filesResult)
            {
                var rules = JsonConvert.DeserializeObject<Rules>(File.ReadAllText(fileName.FullName));
                foreach (var rule in rules.RulesList)
                {
                    if (rule.Results != null)
                        foreach (var result in rule.Results)
                        {
                            result.File = rules.File;
                            if (!resultDic.ContainsKey(result.Content))
                            {
                                resultDic[result.Content] = new List<Result>();
                            }

                            resultDic[result.Content].Add(result);
                        }
                }
            }

            SaveExcerpt(directoryTarget, resultDic);
        }

        private void SaveExcerpt(string directoryTarget, Dictionary<string, List<Result>> resultDic)
        {
            string json = JsonConvert.SerializeObject(resultDic, Formatting.Indented, new JsonSerializerSettings
            {
                Converters = new List<JsonConverter> { new StringEnumConverter() },
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented,
                DefaultValueHandling = DefaultValueHandling.Include,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });

            string excerptFileName = Path.Combine(directoryTarget, "excerpt.json");
            this.logger.Log($"Save excerpt in {excerptFileName}.");
            File.WriteAllText(excerptFileName, json, Encoding.UTF8);
        }

        private static void ClearResults(Rules rules)
        {
            foreach (var rule in rules.RulesList)
            {
                rule.Results?.Clear();
            }
        }

        private void CheckAllRules(string line, int index, Rules rules)
        {
            if (string.IsNullOrEmpty(line))
            {
                return;
            }
            foreach (var rule in rules.RulesList)
            {
                if (rule.Disabled)
                {
                    continue;
                }
                Result result = GetResult(line, index, rule, rule.Keywords);
                if (result != null)
                {
                    if (rule.Results == null)
                    {
                        rule.Results = new List<Result>();
                    }
                    rule.Results?.Add(result);
                }
                // Options to manage
                if (rule.ChildKeywords?.Count > 0)
                {
                    result = GetResult(line, index, rule, rule.ChildKeywords);
                    if (result != null)
                    {
                        if (rule.Results == null)
                        {
                            rule.Results = new List<Result>();
                        }
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
                    expression = "(?i)" + expression;
                }
                var reg = new Regex(expression);
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
