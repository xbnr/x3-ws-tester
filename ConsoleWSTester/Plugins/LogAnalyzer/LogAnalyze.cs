﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.IO.Compression;
using System.Text.RegularExpressions;
using ConsoleTester.Common;
using ConsoleTester.Plugins;

namespace ConsoleTester.LogsAnalyzer
{

    internal class LogAnalyze
    {
        private string folder;
        private string filter;
        private bool recurseSubFolder;
        private ILogger logger;
        private Rules rules;

        internal static readonly string ResultRulesShortName = "Result";

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
            if (string.IsNullOrEmpty(resultDirectoryTarget))
            {
                resultDirectoryTarget = Path.Combine(ProgramUI.GetWorkspaceDirectory(), DateTime.Now.ToString("yyyyMMddHHmm"));
            }
            return resultDirectoryTarget;
        }

        internal static string GetConfigShortFilename()
        {
            return $"{Rules.RulesShortName}.json";
        }

        internal static string GetConfigFilename()
        {
            return Path.Combine(ProgramUI.GetWorkspaceDirectory(), GetConfigShortFilename());
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
            string fileName = GetConfigFilename();
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
            string fileName = GetConfigFilename();
            this.logger.Log($"Create ConfigFile: {fileName}");
            this.rules = CreateDefaultConfig();

            string wsDirectory = ProgramUI.GetWorkspaceDirectory();
            if (!Directory.Exists(wsDirectory))
            {
                Directory.CreateDirectory(wsDirectory);
            }
            string json = JsonConvert.SerializeObject(rules, Formatting.Indented, this.JsonSerializerSettings);
            File.WriteAllText(fileName, json, Encoding.UTF8);
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

            ProcessMonitoring(this.rules, file);

            int nbResult = this.rules.CountResults();
            if (nbResult > 0)
            {
                this.NbTotalResult += nbResult;
                SaveResults(this.rules, file);
            }
            ClearResults(rules);
        }

        private void ProcessMonitoring(Rules rules, FileInfo file)
        {
            List<double> results = new List<double>();
            foreach (var item in rules.RulesList.Where(p => p.Options != null))
            {
                foreach (var r in item.Results.Where(p => p.Monitoring.HasValue))
                {
                    results.Add(r.Monitoring.Value);
                }
                item.Results.RemoveAll(p => p.Monitoring.HasValue);
            }

            double sum = 0;
            double min = double.MaxValue;
            double max = 0;
            foreach (var result in results)
            {
                sum += result;
                if (result < min)
                {
                    min = result;
                }
                if (result > max)
                {
                    max = result;
                }
            }


            double average = 0;
            if (results.Count > 0)
            {
                average = sum / results.Count;

                string frienlyMesg = $"{file.Name} average: {Math.Round(average, 0)}, min: {Math.Round(min)}, max: {Math.Round(max)}, count: {results.Count} ";
                this.logger.Log(frienlyMesg);

                var rule = rules.RulesList.FirstOrDefault(p => p.Options != null);
                if (rule != null)
                {
                    rule.Results.Add(
                        new Result()
                        {
                            File = file.FullName,
                            Content = frienlyMesg
                        });

                }
            }
        }


        internal string[] UnZipArchives()
        {
            List<string> result = new List<string>();

            return result.ToArray();
        }

        private void Unzip(string zipArchiveFile)
        {
            string destDir = Path.Combine(Path.GetDirectoryName(zipArchiveFile), Path.GetFileNameWithoutExtension(zipArchiveFile));
            Directory.CreateDirectory(destDir);

            using (var file = File.OpenRead(zipArchiveFile))
            {
                using (ZipArchive archive = new ZipArchive(file, ZipArchiveMode.Read))
                {
                    foreach (var entry in archive.Entries)
                    {
                        entry.ExtractToFile(destDir);
                        //using (var stream = entry.Open())
                        //{

                        //}
                    }
                }
            }
        }

        internal void SaveResults(Rules rules, FileInfo file)
        {
            string wsDirectory = ProgramUI.GetWorkspaceDirectory();
            if (!Directory.Exists(wsDirectory))
            {
                Directory.CreateDirectory(wsDirectory);
            }
            string filename = GetResultRulesFilename(file);
            rules.File = file.FullName;

            string json = JsonConvert.SerializeObject(rules, Formatting.Indented, this.JsonSerializerSettings);

            int nbResults = 0;
            string resultsTitle = "";
            foreach (var rule in rules?.RulesList)
            {
                if (rule.Results?.Count > 0)
                {
                    resultsTitle += $"{rule.GetName()}: {rule.Results?.Count} results  ";
                    nbResults += rule.Results == null ? 0 : rule.Results.Count;
                }
            }
            this.logger.Log($"Save result in {filename}. {resultsTitle} Total results: {nbResults}", nbResults > 0);
            File.WriteAllText(filename, json, Encoding.UTF8);
        }

        private JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings
        {
            Converters = new List<JsonConverter> { new StringEnumConverter() },
            NullValueHandling = NullValueHandling.Ignore,
            Formatting = Formatting.Indented,
            DefaultValueHandling = DefaultValueHandling.Include,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            PreserveReferencesHandling = PreserveReferencesHandling.Objects,
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };


        private void AggregateResults()
        {

            string directoryTarget = GetResultDirTarget();
            var filesResult = GetAllFiles(directoryTarget, "*.json", false);
            var resultDictionary = new Dictionary<string, List<Result>>();

            foreach (var fileName in filesResult)
            {
                var rules = JsonConvert.DeserializeObject<Rules>(File.ReadAllText(fileName.FullName));
                if (rules == null || rules.RulesList == null)
                    continue;

                foreach (var rule in rules?.RulesList)
                {
                    if (rule.Results != null)
                        foreach (var result in rule.Results)
                        {
                            result.File = rules.File;
                            if (!resultDictionary.ContainsKey(result.Content))
                            {
                                resultDictionary[result.Content] = new List<Result>();
                            }

                            resultDictionary[result.Content].Add(result);
                        }
                }
            }


            SaveExcerpt(directoryTarget, resultDictionary);
        }

        private void SaveExcerpt(string directoryTarget, Dictionary<string, List<Result>> resultDic)
        {
            string excerptFileName = Path.Combine(directoryTarget, "excerptResults.json");

            int max = 20000;
            if (resultDic.Count > max)
            {
                this.logger.Log($"{resultDic.Count} is too much results to save excerpt in {excerptFileName}.");

                var keys = resultDic.Keys.ToList();
                foreach (var key in keys)
                {
                    resultDic.Remove(key);
                    if (resultDic.Count < max)
                    {
                        break;
                    }
                }
            }

            // OutOfMemory on big objects:
            // string json = JsonConvert.SerializeObject(resultDic, Formatting.Indented, this.JsonSerializerSettings);
            // File.WriteAllText(excerptFileName, json, Encoding.UTF8);
            using (TextWriter textWriter = File.CreateText(excerptFileName))
            {
                var serializer = new JsonSerializer();
                serializer.Formatting = Formatting.Indented;
                serializer.NullValueHandling = NullValueHandling.Ignore;
                serializer.Serialize(textWriter, resultDic);
            }
            this.logger.Log($"Save excerpt in {excerptFileName}.");
        }

        internal void ShowExcerpt(System.Windows.Forms.TreeView treeview)
        {
            string excerptFileName = Path.Combine(GetResultDirTarget(), "excerptResults.json");
            Controls.JsonTreeView.JsonTreeViewLoader.LoadJsonToTreeView(treeview, File.ReadAllText(excerptFileName), excerptFileName);
            treeview.TopNode?.Expand();
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
            double? monitoring = null;
            foreach (var keyword in keywords)
            {
                string keyw = GetKeyword(keyword);

                string expression = @"(" + keyw + ")";
                if (rule.MatchWholeWord)
                {
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
                else if (rule.Options?.Count > 0)
                {
                    monitoring = GetOptionValue(keyword, line);
                }
            }

            if (found)
            {
                var result = new Result();
                result.Line = index + 1;
                result.Content = line;
                result.TemplateValue = templateValue;
                if (monitoring != null)
                    result.Monitoring = monitoring.Value;
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
            int indexValue = keyword.IndexOf("{value}");
            if (indexValue >= 0)
            {
                keyw = keyword.Substring(0, indexValue);
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

        /// <summary>
        /// "rss":408518656
        /// "rss":{value}
        /// </summary>
        /// <param name="template"></param>
        /// <param name="line"></param>
        /// <returns></returns>
        private static double? GetOptionValue(string template, string line)
        {
            double? result = null;
            string keyw = GetKeyword(template);
            int i = line.IndexOf(keyw);
            if (i >= 0)
            {
                string templateValue = line.Substring(i + keyw.Length);
                string[] templateValueArray = templateValue.Split(new char[] { ',', '}', ' ', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                if (templateValueArray.Count() > 0)
                {
                    double r = 0;
                    if (double.TryParse(templateValueArray[0], out r))
                    {
                        result = r;
                    }
                }
            }
            return result;
        }

    }
}
