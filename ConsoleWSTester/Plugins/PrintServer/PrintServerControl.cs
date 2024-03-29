﻿using ConsoleTester.Common;
using ConsoleTester.UI;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace ConsoleTester.Plugins.PrintServer
{
    public partial class PrintServerControl : ControlConfigUI
    {
        private string filename;

        public PrintServerControl()
        {
            InitializeComponent();
        }

        public override void CreateNewWS()
        {
            string defaultFile = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, $"Plugins", "PrintServer", "ConsolePrintNet.default.json");
            if (File.Exists(defaultFile))
                LoadConfigFromJSON(defaultFile);
            this.filename = null;
        }

        public override void SetWorkspaceFilename(string filename)
        {
            this.filename = filename;
        }

        public override string GetDefaultWorkspaceFilename()
        {
            return ConsolePrintNet.GetWorkspaceFilename();
        }

        public override string GetWorkspaceFilename()
        {
            if (string.IsNullOrEmpty(this.filename))
            {
                this.filename = GetDefaultWorkspaceFilename();
            }
            return this.filename;
        }

        private enum OutputFormatEnum
        {
            Default = 0,
            JsonFile = 1
        }

        private enum ActionAsked
        {
            PrintServerInfo = 1,
            OpenPrinter = 3,
            OpenPreview = 5,
            ExportPdf = 6,
            ExportRpt = 8,
            ExportMsWord = 9,
            ExportRtf = 11,
            ExportCsv = 12,
            ExportCsvTab = 14,
            ExportText = 15,
            ExportExcel = 16,
            ExportExcelDataOnly = 17,
            ExportHtml = 18,
            ExportXExcel = 24,
            ParametersFields = 26,
            None = -1
        }

        private void InitControls()
        {
            cbActions.DataSource = Enum.GetValues(typeof(ActionAsked));
            cbOutputFormat.DataSource = Enum.GetValues(typeof(OutputFormatEnum));
            cbOdbcDatasource.DataSource = PrintServerHelper.EnumDsn();
            dgSettings.ContextMenuStrip.Tag = dgSettings;
            reportParametersGridView.ContextMenuStrip.Tag = reportParametersGridView;
            tbInstallPath.Text = PrintServerHelper.GetPrintServerIntallPath();
            if (string.IsNullOrEmpty(cbPath.Text))
            {
                cbPath.Text = tbInstallPath.Text;
            }
            if (string.IsNullOrEmpty(cbExportDirectory.Text))
            {
                string tempDir = System.IO.Path.GetTempPath();
                if (tempDir.EndsWith("\\")) // to avoid issues while launching command line
                    tempDir = tempDir.Substring(0, tempDir.Length - 1);
                cbExportDirectory.Text = tempDir;
            }

            if (!string.IsNullOrEmpty(tbInstallPath.Text))
            {
                string editionServerConfigXml = Path.Combine(tbInstallPath.Text, "Config", "adxeditionserverconfig.xml");
                if (File.Exists(editionServerConfigXml))
                    linkLabelEditionServerConfigXml.Tag = editionServerConfigXml;

                string editionServerSolutionsXml = Path.Combine(tbInstallPath.Text, "Config", "adxeditionserversolutions.xml");
                if (File.Exists(editionServerSolutionsXml))
                    linkLabelEditionServerSolutionsXml.Tag = editionServerSolutionsXml;

                string adxOdbcConfigXml = Path.Combine(tbInstallPath.Text, "Config", "AdxOdbcConfig.xml");
                if (File.Exists(adxOdbcConfigXml))
                    linkLabelOdbcConfigXml.Tag = adxOdbcConfigXml;
            }

        }

        private void GetVersion(string exe, string arguments)
        {
            //* Create your Process
            Process process = new Process();
            process.StartInfo.FileName = exe;
            process.StartInfo.Arguments = arguments;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            //* Set your output and error (asynchronous) handlers
            process.OutputDataReceived += new DataReceivedEventHandler(OutputHandler2);
            process.ErrorDataReceived += new DataReceivedEventHandler(OutputHandler2);
            process.Exited += new EventHandler(Exited);
            //* Start process and handlers
            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
        }

        private string logResult = string.Empty;
        private void OutputHandler2(object sendingProcess, DataReceivedEventArgs outLine)
        {
            logResult += outLine.Data;
            Logger.Log(outLine.Data);
            tbPrintServerVersion.Text = logResult;
        }


        internal void LoadConfigFromJSON(string filename)
        {
            InitControls();

            linkOpenJson.Tag = filename;
            this.filename = filename;
            ConsolePrintNet config = JsonConvert.DeserializeObject<ConsolePrintNet>(File.ReadAllText(filename));
            Helper.SetTextFromSettings(config.InstallDirectory, this.cbPath);
            Helper.SetTextFromSettings(config.OdbcDatasource, this.cbOdbcDatasource);
            Helper.SetTextFromSettings(config.DatabaseName, this.tbDbName);
            Helper.SetTextFromSettings(config.Basetype, this.cbDatabaseType);
            Helper.SetTextFromSettings(config.Login, this.tbLogin);
            Helper.SetTextFromSettings(config.Password, this.tbPassword);
            Helper.SetTextFromSettings(config.ReportFilename, this.cbReportName);
            Helper.SetTextFromSettings(config.ExportDirectory, this.cbExportDirectory);
            Helper.SetSafeComboBox(this.cbActions, SafeEnumParse(config.Action));
            Helper.SetSafeText(this.cbOutputFormat, config.OutputFormat);
            Helper.SetSafeCheck(this.cbOpenDocumentAfterGeneration, config.OpenGeneratedFile);

            if (config.Settings != null)
            {
                dgSettings.DataSource = config.Settings;
            }

            if (config.Parameters != null)
            {
                reportParametersGridView.DataSource = config.Parameters;
            }

            if (!configurationInfoInitialized && !GetConfigurationInfo())
            {
                string dirInstallPath = PrintServerHelper.GetPrintServerIntallPath();
                if (!string.IsNullOrEmpty(dirInstallPath))
                {
                    string adxSrvImp = Path.Combine(dirInstallPath, "AdxSrvImp.exe");
                    if (Directory.Exists(dirInstallPath) && File.Exists(adxSrvImp))
                    {
                        GetVersion(adxSrvImp, "/v");
                    }
                }
                else
                {
                    Logger.Log("Error: PrintServer IntallPath not found");
                }
                var subKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\SAP BusinessObjects\Crystal Reports for .NET Framework 4.0\Crystal Reports");

                tbCRRuntime32Version.Text = $"{subKey.GetValue("CRRuntime32Version")}";

                foreach (string item in subKey.GetValueNames())
                {
                    tbSapCrystalReport.Text += $"{item}: {subKey.GetValue(item)} \r\n";
                }
                foreach (string item in subKey.GetSubKeyNames())
                {
                    tbSapCrystalReport.Text += $"{item} \r\n";
                }
                configurationInfoInitialized = true;
            }
        }

        private static ActionAsked SafeEnumParse(string action)
        {
            ActionAsked result = ActionAsked.None;
            try
            {
                result = (ActionAsked)Enum.Parse(typeof(ActionAsked), action);
            }
            catch (Exception)
            {
                Logger.Log($"Cannot parse value {action}. Possible values: {Enum.GetValues(typeof(ActionAsked))} . ");
            }
            return result;
        }

        public override IConfigService GetConfigFromUI()
        {
            ConsolePrintNet conf = new ConsolePrintNet
            {
                InstallDirectory = cbPath.Text,
                OdbcDatasource = cbOdbcDatasource.Text,
                DatabaseName = tbDbName.Text,
                Basetype = cbDatabaseType.Text,
                Login = tbLogin.Text,
                Password = tbPassword.Text,
                ReportFilename = cbReportName.Text,
                ExportDirectory = cbExportDirectory.Text,
                Action = cbActions.Text,
                OutputFormat = cbOutputFormat.Text,
                OpenGeneratedFile = cbOpenDocumentAfterGeneration.Checked
            };

            if (dgSettings.DataSource != null)
            {
                var fileList = dgSettings.DataSource as ConsolePrintNetParameter[];
                conf.Settings = fileList;
            }

            if (reportParametersGridView.DataSource != null)
            {
                var fileList = reportParametersGridView.DataSource as ConsolePrintNetParameter[];
                conf.Parameters = fileList;
            }
            return conf;
        }

        private void launch_Click(object sender, EventArgs e)
        {
            RunCommand();
        }

        private void RunCommand()
        {
            string exe, arguments;

            BuildCommand(out exe, out arguments);
            Logger.Log(exe + arguments);

            if (!File.Exists(exe))
            {
                string friendlyMesg = $"Error: executable filename '{exe}' doesn't exist. Please check the Sage PrintServer directory and it's version. Version must be >= V2.18  ";
                Logger.Log(friendlyMesg, true);
                MessageBox.Show(friendlyMesg, $"{exe}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //* Create your Process
            Process process = new Process();
            process.StartInfo.FileName = exe;
            process.StartInfo.Arguments = arguments;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            //* Set your output and error (asynchronous) handlers
            process.OutputDataReceived += new DataReceivedEventHandler(OutputHandler);
            process.ErrorDataReceived += new DataReceivedEventHandler(OutputHandler);
            process.Exited += new EventHandler(Exited);
            //* Start process and handlers
            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
        }

        private void Exited(object sendingProcess, EventArgs output)
        {
            Logger.Log(output.ToString());
        }

        private void OutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            Logger.Log(outLine.Data);
        }

        private const string ConsoleExeName = "ConsolePrintNet";

        private void BuildCommand(out string exe, out string arguments)
        {
            var conf = GetConfigFromUI() as ConsolePrintNet;
            string dirInstallPath = string.IsNullOrEmpty(conf.InstallDirectory) ? PrintServerHelper.GetPrintServerIntallPath() : conf.InstallDirectory;

            exe = $"{dirInstallPath}\\{ConsoleExeName}.exe";
            arguments = $" -connectioninfos:\"datasource={conf.OdbcDatasource};";
            if (!string.IsNullOrEmpty(conf.DatabaseName))
                arguments += $"databasename={conf.DatabaseName};";
            arguments += $"basetype ={conf.Basetype};userid={conf.Login};password={conf.Password};\" ";
            if (!string.IsNullOrEmpty(conf.ReportFilename))
                arguments += $" -reportdirectory:\"{Path.GetDirectoryName(conf.ReportFilename)}\" ";
            if (!string.IsNullOrEmpty(conf.ReportFilename))
                arguments += $" -reportname:\"{Path.GetFileName(conf.ReportFilename)}\" ";
            if (!string.IsNullOrEmpty(conf.Action))
                arguments += $" -action:{conf.Action}";
            if (!string.IsNullOrEmpty(conf.ExportDirectory))
                arguments += $" -exportdirectory:\"{conf.ExportDirectory}\" ";
            if (!string.IsNullOrEmpty(conf.OutputFormat))
                arguments += $" -outputformat:\"{conf.OutputFormat}\" ";
            if (conf.OpenGeneratedFile)
                arguments += $" -opengeneratedfile ";

            if (conf.Settings?.Length > 0)
            {
                arguments += $" -settings:\"";
                foreach (var item in conf.Settings)
                {
                    arguments += $"{item.Name}={item.Value};";
                }
                arguments += $"\"";
            }
            if (conf.Parameters?.Length > 0)
            {
                arguments += $" -reportparameters:\"";
                foreach (var item in conf.Parameters)
                {
                    arguments += $"{item.Name}={item.Value};";
                }
                arguments += $"\"";
            }

        }


        private void btAddParam_Click(object sender, EventArgs e)
        {
            var conf = GetConfigFromUI() as ConsolePrintNet;
            AddItemInGrid(conf.Parameters, new ConsolePrintNetParameter(), reportParametersGridView);
        }


        private void AddItemsInGrid(ConsolePrintNetParameter[] parameters, List<ConsolePrintNetParameter> newParams, DataGridView dataGridView)
        {
            ArrayList paramList = new ArrayList();
            if (parameters != null)
                paramList.AddRange(parameters);
            if (newParams != null)
                paramList.AddRange(newParams);
            parameters = new ConsolePrintNetParameter[paramList.Count];
            paramList.CopyTo(parameters);

            if (newParams?.Count > 0)
            {
                Helper.SetSafeText(labelParametersMessage, "Please fill in parameter(s) value(s)");
            }
            Helper.SetSafeDatasource(reportParametersGridView, parameters);
        }

        private void AddItemInGrid(ConsolePrintNetParameter[] parameters, ConsolePrintNetParameter newParam, DataGridView dataGridView)
        {
            ArrayList paramList = new ArrayList();
            if (parameters != null)
                paramList.AddRange(parameters);
            if (newParam != null)
                paramList.Add(newParam);
            parameters = new ConsolePrintNetParameter[paramList.Count];
            paramList.CopyTo(parameters);

            Helper.SetSafeDatasource(dataGridView, parameters);
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            RemoveSelectedItems(reportParametersGridView);
        }

        private string GetSelectedParameter()
        {
            if (reportParametersGridView.SelectedRows.Count != 1)
            {
                MessageBox.Show($"Please, select just one item", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            var selectedObj = reportParametersGridView.SelectedRows[0];
            string selectedValue = selectedObj.DataBoundItem as string;
            return selectedValue;
        }

        private void RemoveSelectedItems(DataGridView dataGridView)
        {
            var fileList = dataGridView.DataSource as ConsolePrintNetParameter[];
            ArrayList paramList = new ArrayList();
            paramList.AddRange(fileList);

            ConsolePrintNetParameter[] parameters = new ConsolePrintNetParameter[fileList.Length];
            foreach (DataGridViewRow row in dataGridView.SelectedRows)
            {
                var file = row.DataBoundItem as ConsolePrintNetParameter;
                paramList.Remove(file);
            }
            parameters = new ConsolePrintNetParameter[paramList.Count];
            paramList.CopyTo(parameters);

            Helper.SetSafeDatasource(dataGridView, parameters);
        }

        private void RemoveAllItems(DataGridView dataGridView)
        {
            ConsolePrintNetParameter[] parameters = new ConsolePrintNetParameter[0];
            Helper.SetSafeDatasource(dataGridView, parameters);
        }

        private void btBrowseRpt_Click(object sender, EventArgs e)
        {
            var folder = new OpenFileDialog
            {
                InitialDirectory = Path.GetDirectoryName((GetConfigFromUI() as ConsolePrintNet).ReportFilename),
                Multiselect = false,
                Filter = "*.rpt|*.*"
            };
            var result = folder.ShowDialog();
            if (result == DialogResult.OK && folder != null)
            {
                cbReportName.Text = folder.FileName;
            }
        }

        public override void CreateWS(FileInfo item)
        {
            LoadConfigFromJSON(item.FullName);
        }

        private void removeSelectedXsdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem selectedTSMI = sender as ToolStripMenuItem;
            if (((ContextMenuStrip)((ToolStripMenuItem)sender).Owner)?.SourceControl is DataGridView selectedView)
            {
                RemoveSelectedItems(selectedView);
            }
        }

        private void copyPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var file = GetSelectedParameter();
            if (file != null)
            {
                Clipboard.SetText(file);
            }
        }


        private void btDetectInstall_Click(object sender, EventArgs e)
        {
            cbPath.Text = PrintServerHelper.GetPrintServerIntallPath();
        }


        private void btGenerateCommand_Click(object sender, EventArgs e)
        {
            string exe, arguments;
            BuildCommand(out exe, out arguments);
            Logger.Log(exe + arguments);
        }

        private void linkOpenExportDirectory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("explorer", cbExportDirectory.Text));
        }

        private void btAddSetting_Click(object sender, EventArgs e)
        {
            var conf = GetConfigFromUI() as ConsolePrintNet;
            AddItemInGrid(conf.Settings, new ConsolePrintNetParameter(), dgSettings);
        }

        private void btRemoveSetting_Click(object sender, EventArgs e)
        {
            RemoveSelectedItems(dgSettings);
        }

        private void btTestConnection_Click(object sender, EventArgs e)
        {
            string dsn = cbOdbcDatasource.Text;
            string userid = tbLogin.Text;
            string password = tbPassword.Text;
            bool result = PrintServerHelper.TestSqlConnection(dsn, userid, password);
            if (result)
            {
                MessageBox.Show($"Connection to {dsn} OK", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Error while connecting to {dsn}", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void cbOdbcDatasource_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dbName = PrintServerHelper.GetDatabaseName(cbOdbcDatasource.Text);
            if (!string.IsNullOrEmpty(dbName))
            {
                tbDbName.Text = dbName;
            }

            string serverName = PrintServerHelper.GetDbServerName(cbOdbcDatasource.Text);
            if (!string.IsNullOrEmpty(serverName))
            {
                tbDbServer.Text = serverName;
            }
        }



        private void lbDatasourceInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PrintAllDatasourceInfo(cbOdbcDatasource.Text);
        }

        private void PrintAllDatasourceInfo(string odbcDatasource)
        {
            RegistryKey regKey = Registry.LocalMachine.OpenSubKey($@"SOFTWARE\ODBC\ODBC.INI\{odbcDatasource}");
            Logger.Log($"Datasource {odbcDatasource}: ");
            if (regKey != null)
            {
                foreach (var name in regKey.GetValueNames())
                {
                    Logger.Log($"{name}: {regKey.GetValue(name)}");
                }
            }
        }

        private void dgSettings_CellValidated(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void llFindReportParameters_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var reportDetectedParameters = GetParameters();

            var conf = GetConfigFromUI() as ConsolePrintNet;
            if (conf.Parameters == null)
            {
                conf.Parameters = new ConsolePrintNetParameter[0];
            }
            var uiParameters = conf.Parameters;

            List<ConsolePrintNetParameter> listToAdd = new List<ConsolePrintNetParameter>();

            foreach (var newParam in reportDetectedParameters)
            {
                bool found = false;
                foreach (var parameter in uiParameters)
                {
                    if (parameter.Name == newParam.Name)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    listToAdd.Add(newParam);
                }
            }

            AddItemsInGrid(uiParameters, listToAdd, reportParametersGridView);

        }

        private List<ConsolePrintNetParameter> GetParameters()
        {
            ActionAsked formerAction = ActionAsked.None;
            if (cbActions.SelectedItem != null && cbActions.SelectedItem is ActionAsked)
                formerAction = (ActionAsked)cbActions.SelectedItem;
            Helper.SetSafeComboBox(cbActions, ActionAsked.ParametersFields);
            string resultJson = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ConsoleExeName, $"{ConsoleExeName}Result.json");
            Helper.SetSafeText(cbOutputFormat, OutputFormatEnum.JsonFile.ToString() + "=" + resultJson);
            try
            {
                RunCommand();
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
            }
            finally
            {
                if (formerAction != ActionAsked.None)
                    Helper.SetSafeComboBox(this.cbActions, formerAction);
            }

            List<ConsolePrintNetParameter> list = new List<ConsolePrintNetParameter>();
            if (File.Exists(resultJson))
            {
                object rawObject = JsonConvert.DeserializeObject(File.ReadAllText(resultJson));
                JObject resultJObject = rawObject as JObject;
                JArray array = resultJObject["parameters"]?.Value<JArray>();
                if (array != null)
                {
                    foreach (JToken item in array)
                    {
                        bool? hasDefaultValue = item["hasDefaultValue"]?.Value<bool>();
                        ConsolePrintNetParameter param = new ConsolePrintNetParameter(item["name"]?.Value<string>(), item["promptText"]?.Value<string>());
                        if (!hasDefaultValue.HasValue || (hasDefaultValue.HasValue && !hasDefaultValue.Value))
                        {
                            list.Add(param);
                        }
                    }
                }
            }
            else
            {
                Logger.Log($"File result {resultJson} doesn't exist");
            }

            return list;
        }

        private bool configurationInfoInitialized = false;

        private bool GetConfigurationInfo()
        {
            bool result = false;
            ActionAsked formerAction = ActionAsked.None;
            if (cbActions.SelectedItem != null && cbActions.SelectedItem is ActionAsked)
                formerAction = (ActionAsked)cbActions.SelectedItem;
            Helper.SetSafeComboBox(cbActions, ActionAsked.PrintServerInfo);
            string currentReportName = GetWorkspaceFilename() != null ? Path.GetFileNameWithoutExtension(GetWorkspaceFilename()) : ConsoleExeName;
            string resultJsonFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ConsoleExeName, $"{currentReportName}Result.json");
            Helper.SetSafeText(cbOutputFormat, OutputFormatEnum.JsonFile.ToString() + "=" + resultJsonFile);
            linkLabelJSon.Tag = resultJsonFile;

            try
            {
                RunCommand();
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
            }
            finally
            {
                if (formerAction != ActionAsked.None)
                    Helper.SetSafeComboBox(this.cbActions, formerAction);
            }

            if (File.Exists(resultJsonFile))
            {
                result = true;
                ReadConfigurationInfoFile(resultJsonFile);
                configurationInfoInitialized = true;
            }
            else
            {
                Logger.Log($"File result {resultJsonFile} doesn't exist");
            }
            return result;
        }

        private void ReadConfigurationInfoFile(string resultJsonFile)
        {
            object rawObject = JsonConvert.DeserializeObject(File.ReadAllText(resultJsonFile));
            JObject resultJObject = rawObject as JObject;
            JObject printServerInfoObject = resultJObject["printServerInfo"]?.Value<JObject>();
            if (printServerInfoObject != null)
            {
                tbInstallPath.Text = printServerInfoObject["installPath"].Value<string>();

                JArray arrayVersion = printServerInfoObject["version"].Value<JArray>();
                if (arrayVersion != null)
                {
                    string serverVersion = string.Empty;
                    foreach (JToken item in arrayVersion)
                    {
                        if (item["name"]?.Value<string>() == "AdxSrvImp.ProductName")
                        {
                            serverVersion += item["value"]?.Value<string>();
                        }
                        if (item["name"]?.Value<string>() == "AdxSrvImp.ProductVersion")
                        {
                            serverVersion += " " + item["value"]?.Value<string>();
                        }
                    }
                    tbPrintServerVersion.Text = serverVersion;
                }
                JArray arrayService = printServerInfoObject["service"]?.Value<JArray>();
                if (arrayService != null)
                {
                    string serverService = string.Empty;
                    foreach (JToken item in arrayService)
                    {
                        if (item["name"]?.Value<string>() == "ServiceName")
                        {
                            serverService += item["value"]?.Value<string>() + "\r\n";
                        }
                        if (item["name"]?.Value<string>() == "ServicePath")
                        {
                            serverService += item["value"]?.Value<string>() + "\r\n";
                        }
                    }
                    tbService.Text = serverService;
                }

                if (printServerInfoObject["config"]?.Value<JObject>() != null)
                {
                    ShowXmlConfigInfo(printServerInfoObject);
                }
            }



            JArray arrayPrinters = resultJObject["serverPrinters"]?.Value<JArray>();
            if (arrayPrinters != null)
            {
                foreach (JToken item in arrayPrinters)
                {
                    tbPrinters.Text += $"{item["name"]} \t isDefault: {item["isDefault"]}  {item["isNetworkPrinter"]}   \t status : {item["status"]} \r\n";
                }
            }

            JObject CRInfoObject = resultJObject["crystalReportInfo"]?.Value<JObject>();
            if (CRInfoObject != null)
            {
                JArray array = CRInfoObject["version"]?.Value<JArray>();
                if (array != null)
                {
                    foreach (JToken item in array)
                    {
                        tbSapCrystalReport.Text += $"{item["name"]} : \t {item["value"]}  \t \r\n";

                        if (item["name"]?.Value<string>() == "CRRuntime32Version")
                        {
                            tbCRRuntime32Version.Text = item["value"]?.Value<string>();
                        }
                    }
                }
            }
        }

        private void ShowXmlConfigInfo(JObject printServerInfoObject)
        {
            JObject configObject = printServerInfoObject["config"]?.Value<JObject>();
            if (configObject != null)
            {
                tbAdxEditionServerConfigXml.Text = JsonConfigHelper.GetAdxEditionServerConfigXml(configObject);
                tbAdxEditionServerSolutions.Text = JsonConfigHelper.GetAdxServerSolutionsXml(configObject);
                tbAdxOdbcConfigXml.Text = JsonConfigHelper.GetAdxOdbcConfigXml(configObject);
            }
        }




        private void linkLabelJSon_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenJSONFile(linkLabelJSon);
        }

        private void OpenJSONFile(LinkLabel linkLabelJSon)
        {
            if (linkLabelJSon.Tag != null && linkLabelJSon.Tag is string)
            {
                string jsonFilename = (string)linkLabelJSon.Tag;
                if (File.Exists(jsonFilename))
                {
                    ProgramUI.OpenJson(jsonFilename);
                }
            }
        }

        private void linkOpenJson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenJSONFile(linkOpenJson);
        }

        private void removeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem selectedTSMI = sender as ToolStripMenuItem;
            if (((ContextMenuStrip)((ToolStripMenuItem)sender).Owner)?.SourceControl is DataGridView selectedView)
            {
                RemoveAllItems(selectedView);
            }

        }

        private void linkLabelODBC_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // c:\Windows\SysWOW64\odbcad32.exe
            Process.Start(new ProcessStartInfo("odbcad32.exe"));
        }

        private void linkLabelOpenReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!string.IsNullOrEmpty(cbReportName.Text) && File.Exists(cbReportName.Text))
                Process.Start(new ProcessStartInfo(cbReportName.Text));
            else
            {
                Logger.Log($"Cannot open rpt file {cbReportName.Text}");
            }
        }

        private void linkLabelEditionServerConfigXml_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenJSONFile(linkLabelEditionServerConfigXml);
        }

        private void linkLabelEditionServerSolutionsXml_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenJSONFile(linkLabelEditionServerSolutionsXml);
        }

        private void linkLabelOdbcConfigXml_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenJSONFile(linkLabelOdbcConfigXml);
        }
    }
}
