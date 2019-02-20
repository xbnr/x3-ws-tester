using ConsoleTester.Common;
using ConsoleTester.UI;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        }

        internal void LoadConfigFromJSON(string filename)
        {
            InitControls();

            this.filename = filename;
            PrintServerConfig config = JsonConvert.DeserializeObject<PrintServerConfig>(File.ReadAllText(filename));
            Helper.SetTextFromSettings(config.InstallDirectory, this.cbPath);
            Helper.SetTextFromSettings(config.OdbcDatasource, this.cbOdbcDatasource);
            Helper.SetTextFromSettings(config.Basetype, this.cbDatabaseType);
            Helper.SetTextFromSettings(config.Login, this.tbLogin);
            Helper.SetTextFromSettings(config.Password, this.tbPassword);
            Helper.SetTextFromSettings(config.ReportFilename, this.cbReportName); // Path.GetFileName( this.cbReportName.Text));
            Helper.SetTextFromSettings(config.ExportDirectory, this.cbExportDirectory);
            Helper.SetSafeText(this.cbActions, config.Action);
            Helper.SetSafeText(this.cbSettings, config.Settings);

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
                Basetype = cbDatabaseType.Text,
                Login = tbLogin.Text,
                Password = tbPassword.Text,
                ReportFilename = cbReportName.Text,
                ExportDirectory = cbExportDirectory.Text,
                Action = cbActions.Text,
                Settings = cbSettings.Text
            };

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
            arguments = $" -connectioninfos:\"datasource={conf.OdbcDatasource};basetype={conf.Basetype};userid={conf.Login};password={conf.Password};\" ";
            if (!string.IsNullOrEmpty(conf.ReportFilename))
                arguments += $" -reportdirectory:\"{Path.GetDirectoryName(conf.ReportFilename)}\" ";
            if (!string.IsNullOrEmpty(conf.ReportFilename))
                arguments += $" -reportname:\"{Path.GetFileName(conf.ReportFilename)}\" ";
            if (!string.IsNullOrEmpty(conf.Action))
                arguments += $" -action:{conf.Action}";
            if (!string.IsNullOrEmpty(conf.ExportDirectory))
                arguments += $" -exportdirectory:\"{conf.ExportDirectory}\" ";
            if (!string.IsNullOrEmpty(conf.Settings))
                arguments += $" -settings:\"{conf.Settings}\" ";
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
            if (conf.Parameters == null)
            {
                conf.Parameters = new PrintServerConfigParameter[1];// new List<PrintServerConfigParameter>();
            }
            conf.Parameters[0] = new PrintServerConfigParameter();
            dgKeyValue.DataSource = null;
            dgKeyValue.DataSource = conf.Parameters;
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            RemoveSelectedFiles();
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

        private void RemoveSelectedFiles()
        {
            var fileList = dgKeyValue.DataSource as List<string>;

            foreach (DataGridViewRow row in dgKeyValue.SelectedRows)
            {
                var file = row.DataBoundItem as string;
                fileList.Remove(file);
            }
            dgKeyValue.DataSource = null;
            dgKeyValue.DataSource = fileList;
        }
        private void dgKeyValue_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgKeyValue_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //dgKeyValue.DataSource = null;
            //dgKeyValue.DataSource = conf.Parameters;
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
            cbReportName.Text = folder.FileName;
        }

        public override void CreateWS(FileInfo item)
        {
            LoadConfigFromJSON(item.FullName);
        }

        private void removeSelectedXsdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveSelectedFiles();
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
            MessageBox.Show("TODO");
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
    }
}
