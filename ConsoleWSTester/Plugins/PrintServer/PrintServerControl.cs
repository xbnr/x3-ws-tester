using ConsoleTester.Common;
using ConsoleTester.UI;
using Microsoft.Win32;
using Newtonsoft.Json;
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
            string defaultFile = $"Plugins\\PrintServer\\PrintServerConfig.default.json";
            if (File.Exists(defaultFile))
                LoadConfigFromJSON(defaultFile);
            this.filename = null;
        }

        private void PrintServerControl_Load(object sender, EventArgs e)
        {
            
        }

        public override string GetWorkspaceFilename()
        {
            if (string.IsNullOrEmpty(this.filename))
            {
                this.filename = PrintServerConfig.GetWorkspaceFilename();
            }
            return this.filename;
        }


        private enum ActionAsked
        {
            OpenPRINTER = 3,
            OpenPREVIEW = 5,
            ExportPDF = 6,
            ExportRPT = 8,
            ExportMSWORD = 9,
            ExportRTF = 11,
            ExportCSV = 12,
            ExportCSVTAB = 14,
            ExportTEXT = 15,
            ExportEXCEL = 16,
            ExportEXCELDATAONLY = 17,
            ExportHTML = 18,
            TestPrinterSettings = 21,
            ExportXEXCEL = 24,
            None = -1
        }

        private void InitControls()
        {
            cbActions.DataSource = Enum.GetValues(typeof(ActionAsked));
            cbOdbcDatasource.DataSource = EnumDsn();

            string dirInstallPath = GetPrintServerIntallPath();
            tbInstallPath.Text = dirInstallPath;
            string adxSrvImp = Path.Combine(dirInstallPath, "AdxSrvImp.exe");
            if (Directory.Exists(dirInstallPath) && File.Exists(adxSrvImp))
            {
                GetVersion(adxSrvImp, "/v");
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
            PrintServerConfig config = JsonConvert.DeserializeObject<PrintServerConfig>(File.ReadAllText(filename));
            Helper.SetTextFromSettings(config.InstallDirectory, this.cbPath);
            Helper.SetTextFromSettings(config.OdbcDatasource, this.cbOdbcDatasource);
            Helper.SetTextFromSettings(config.DatabaseName, this.tbDbName);
            Helper.SetTextFromSettings(config.Basetype, this.cbDatabaseType);
            Helper.SetTextFromSettings(config.Login, this.tbLogin);
            Helper.SetTextFromSettings(config.Password, this.tbPassword);
            Helper.SetTextFromSettings(config.ReportFilename, this.cbReportName); // Path.GetFileName( this.cbReportName.Text));
            Helper.SetTextFromSettings(config.ExportDirectory, this.cbExportDirectory);
            Helper.SetSafeText(this.cbActions, config.Action);
            if (config.Settings != null)
            {
                dgSettings.DataSource = config.Settings;
            }

            if (config.Parameters != null)
            {
                dgKeyValue.DataSource = config.Parameters;
            }
        }


        public override IConfigService GetConfigFromUI()
        {   
            PrintServerConfig conf = new PrintServerConfig
            {
                InstallDirectory = cbPath.Text,
                OdbcDatasource = cbOdbcDatasource.Text,
                DatabaseName = tbDbName.Text,
                Basetype = cbDatabaseType.Text,
                Login = tbLogin.Text,
                Password = tbPassword.Text,
                ReportFilename = cbReportName.Text,
                ExportDirectory = cbExportDirectory.Text,
                Action = cbActions.Text
            };
            if (dgSettings.DataSource != null)
            {
                var fileList = dgSettings.DataSource as PrintServerConfigParameter[];
                conf.Settings = fileList;
            }

            if (dgKeyValue.DataSource != null)
            {
                var fileList = dgKeyValue.DataSource as PrintServerConfigParameter[];
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

        private void BuildCommand(out string exe, out string arguments)
        {
            var conf = GetConfigFromUI() as PrintServerConfig;
            exe = $"{conf.InstallDirectory}\\TestConsolePrintNet.exe";
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
            //if (!string.IsNullOrEmpty(conf.Settings))
            //    arguments += $" -settings:\"{conf.Settings}\" ";
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
            var conf = GetConfigFromUI() as PrintServerConfig;
            AddItem(conf.Parameters, dgKeyValue);
        }

        private void AddItem(PrintServerConfigParameter[] parameters, DataGridView dataGridView)
        {
            ArrayList paramList = new ArrayList();
            paramList.AddRange(parameters);
            paramList.Add(new PrintServerConfigParameter());
            parameters = new PrintServerConfigParameter[paramList.Count];
            paramList.CopyTo(parameters);

            dataGridView.DataSource = null;
            dataGridView.DataSource = parameters;
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            RemoveSelectedItem(dgKeyValue);
        }

        private string GetSelectedParameter()
        {
            if (dgKeyValue.SelectedRows.Count != 1)
            {
                MessageBox.Show($"Please, select just one item", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            var selectedObj = dgKeyValue.SelectedRows[0];
            string selectedValue = selectedObj.DataBoundItem as string;
            return selectedValue;
        }

        private void RemoveSelectedItem(DataGridView dataGridView)
        {
            var fileList = dataGridView.DataSource as PrintServerConfigParameter[];
            PrintServerConfigParameter[] parameters = new PrintServerConfigParameter[fileList.Length];
            foreach (DataGridViewRow row in dataGridView.SelectedRows)
            {
                var file = row.DataBoundItem as PrintServerConfigParameter;
                ArrayList paramList = new ArrayList();
                paramList.AddRange(fileList);
                paramList.Remove(file);
                parameters = new PrintServerConfigParameter[paramList.Count];
                paramList.CopyTo(parameters);
            }
            dataGridView.DataSource = null;
            dataGridView.DataSource = parameters;
        }


        private void btBrowseRpt_Click(object sender, EventArgs e)
        {
            var folder = new OpenFileDialog
            {
                InitialDirectory = Path.GetDirectoryName((GetConfigFromUI() as PrintServerConfig).ReportFilename),
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
            RemoveSelectedItem(dgKeyValue);
        }


        private void copyPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var file = GetSelectedParameter();
            if (file != null)
            {
                Clipboard.SetText(file);
            }
        }

        private List<string> EnumDsn()
        {
            List<string> list = new List<string>();
            list.AddRange(EnumDsn(Registry.CurrentUser));
            list.AddRange(EnumDsn(Registry.LocalMachine));
            return list;
        }

        private IEnumerable<string> EnumDsn(RegistryKey rootKey)
        {
            RegistryKey regKey = rootKey.OpenSubKey(@"Software\ODBC\ODBC.INI\ODBC Data Sources");
            if (regKey != null)
            {
                foreach (string name in regKey.GetValueNames())
                {
                    string value = regKey.GetValue(name, "").ToString();
                    yield return name;
                }
            }
        }

        private void btDetectInstall_Click(object sender, EventArgs e)
        {
            cbPath.Text = GetPrintServerIntallPath();
        }

        private string GetPrintServerIntallPath()
        {
            string result = null;
            RegistryKey regKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Adonix\SRVIMP\0,1,5,0\GENERAL");
            if (regKey != null)
            {
                result = (string)regKey.GetValue("Path");
            }
            return result;
        }
        private void btGenerateCommand_Click(object sender, EventArgs e)
        {
            string exe, arguments;
            BuildCommand(out exe, out arguments);
            Logger.Log(exe + arguments);
        }

        private void linkOpenExportDirectory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("explorer", cbExportDirectory.Text);
        }

        private void btAddSetting_Click(object sender, EventArgs e)
        {
            var conf = GetConfigFromUI() as PrintServerConfig;
            AddItem(conf.Settings, dgSettings);
        }

        private void btRemoveSetting_Click(object sender, EventArgs e)
        {
            RemoveSelectedItem(dgSettings);
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
            string dbName = GetDatabaseName(cbOdbcDatasource.Text);
            if (!string.IsNullOrEmpty(dbName))
            {
                tbDbName.Text = dbName;
            }

            string serverName = GetDbServerName(cbOdbcDatasource.Text);
            if (!string.IsNullOrEmpty(serverName))
            {
                tbDbServer.Text = serverName;
            }
        }

        private string GetDatabaseName(string odbcDatasource)
        {
            string result = null;
            RegistryKey regKey = Registry.LocalMachine.OpenSubKey($@"SOFTWARE\ODBC\ODBC.INI\{odbcDatasource}");
            if (regKey != null)
            {
                result = (string)regKey.GetValue("Database");
            }
            return result;
        }

        private string GetDbServerName(string odbcDatasource)
        {
            string result = null;
            RegistryKey regKey = Registry.LocalMachine.OpenSubKey($@"SOFTWARE\ODBC\ODBC.INI\{odbcDatasource}");
            if (regKey != null)
            {
                result = (string)regKey.GetValue("Server");
                if (string.IsNullOrEmpty(result))
                    result = (string)regKey.GetValue("HostName");
                if (string.IsNullOrEmpty(result))
                    result = (string)regKey.GetValue("ServerName");
            }
            return result;
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
            //dgSettings.DataSource = null;
            //dgSettings.DataSource = parameters;

        }
    }
}
