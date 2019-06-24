using ConsoleTester.Common;
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
    public partial class PrintServerControl : ControlConfig
    {
        private string filename;

        public PrintServerControl()
        {
            InitializeComponent();
        }

        public override void CreateNewWS()
        {
            string defaultFile = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, $"Plugins", "PrintServer", "PrintServerConfig.default.json");
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
            PrinterServerInfo = 1,
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
            Helper.SetSafeComboBox(this.cbActions, (ActionAsked)Enum.Parse(typeof(ActionAsked), config.Action));
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
                string adxSrvImp = Path.Combine(dirInstallPath, "AdxSrvImp.exe");
                if (Directory.Exists(dirInstallPath) && File.Exists(adxSrvImp))
                {
                    GetVersion(adxSrvImp, "/v");
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
            // process.WaitForExit();
            // logger.Log($"ExitCode={process.ex ExitCode}");
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
            paramList.AddRange(parameters);
            paramList.AddRange(newParams);
            parameters = new ConsolePrintNetParameter[paramList.Count];
            paramList.CopyTo(parameters);

            reportParametersGridView.DataSource = null;
            reportParametersGridView.DataSource = parameters;


        }
        private void AddItemInGrid(ConsolePrintNetParameter[] parameters, ConsolePrintNetParameter newParam, DataGridView dataGridView)
        {
            ArrayList paramList = new ArrayList();
            paramList.AddRange(parameters);
            paramList.Add(newParam);
            parameters = new ConsolePrintNetParameter[paramList.Count];
            paramList.CopyTo(parameters);

            dataGridView.DataSource = null;
            dataGridView.DataSource = parameters;
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
            dataGridView.DataSource = null;
            dataGridView.DataSource = parameters;
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
            bool result = IsServerConnected(dsn, userid, password);
            if (result)
            {
                MessageBox.Show($"Connection to {dsn} OK", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Error while connecting to {dsn}", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsServerConnected(string dsn, string userId, string password)
        {
            using (OdbcConnection connection = new OdbcConnection($"dsn={dsn};UID={userId};PWD={password};"))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (Exception ex)
                {
                    Logger.Log(ex.Message);
                    return false;
                }
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
            //ArrayList paramList = new ArrayList();
            //PrintServerConfigParameter[] parameters = new PrintServerConfigParameter[dgSettings.RowCount];
            //for (int i=0; i<dgSettings.RowCount; i++)
            //{

            //}
            //dgSettings.DataSource = null;r
            //dgSettings.DataSource = parameters;
        }

        private void llFindReportParameters_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var reportDetectedParameters = GetParameters();

            var conf = GetConfigFromUI() as ConsolePrintNet;
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
            cbActions.Text = ActionAsked.ParametersFields.ToString();
            string resultJson = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ConsoleExeName, $"{ConsoleExeName}Result.json");
            cbOutputFormat.Text = OutputFormatEnum.JsonFile.ToString() + "=" + resultJson;

            RunCommand();

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
            cbActions.Text = ActionAsked.PrinterServerInfo.ToString();
            string resultJson = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ConsoleExeName, $"{ConsoleExeName}Result.json");
            cbOutputFormat.Text = OutputFormatEnum.JsonFile.ToString() + "=" + resultJson;

            try
            {
                RunCommand();
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
            }

            if (File.Exists(resultJson))
            {
                object rawObject = JsonConvert.DeserializeObject(File.ReadAllText(resultJson));
                JObject resultJObject = rawObject as JObject;
                result = true;
                configurationInfoInitialized = true;
                JObject printServerInfoObject = resultJObject["printServerInfo"]?.Value<JObject>();
                if (printServerInfoObject != null)
                {
                    tbInstallPath.Text = printServerInfoObject["installPath"].Value<string>();

                    JArray array = printServerInfoObject["version"].Value<JArray>();
                    if (array != null)
                    {
                        string serverVersion = string.Empty;
                        foreach (JToken item in array)
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
            else
            {
                Logger.Log($"File result {resultJson} doesn't exist");
            }
            return result;
        }

    }
}
