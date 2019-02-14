using ConsoleTester.CAWebService;
using ConsoleTester.Common;
using ConsoleTester.Plugins;
using ConsoleTester.UI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using WeifenLuo.WinFormsUI.Docking;

namespace ConsoleTester.Plugins.XsdValidator
{
    public partial class PrintServerControl : ControlConfig
    {
        private string filename;
        Logger logger = new Logger(MainForm.LogControl);

        public PrintServerControl()
        {
            InitializeComponent();
        }

        private void PrintServerControl_Load(object sender, EventArgs e)
        {
            // InitControls();
        }

        internal void SaveWorkspace()
        {
            if (string.IsNullOrEmpty(this.filename))
            {
                this.filename = PrintServerConfig.GetWorkspaceFilename();
            }
            Helper.SaveWorkspace(this.filename, GetConfigFromUI());
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
        }

        internal void LoadConfigFromJSON(string filename)
        {
            InitControls();

            this.filename = filename;
            PrintServerConfig config = JsonConvert.DeserializeObject<PrintServerConfig>(File.ReadAllText(filename));
            Helper.SetTextFromSettings(config.InstallDirectory, this.cbPath);
            Helper.SetTextFromSettings(config.OdbcDatasource, this.cbOdbcDatasource);
            Helper.SetTextFromSettings(config.ConnectionInfo, this.cbConnectionInfo);
            Helper.SetTextFromSettings(config.ReportDirectory, this.cbReportDirectory);
            Helper.SetTextFromSettings(config.ReportName, this.cbReportName);
            Helper.SetTextFromSettings(config.ExportDirectory, this.cbExportDirectory);
            Helper.SetSafeText(this.cbActions, config.Action);
            Helper.SetSafeText(this.cbSettings, config.Settings);

            if (config.Parameters != null)
            {
               // InitGridView();
                List<string> list = new List<string>();
                foreach (var fullfilename in config.Parameters)
                {
                    list.Add(fullfilename);
                }
                dgKeyValue.DataSource = list;
            }
        }

        private void InitGridView()
        {
            dgKeyValue.Columns.Clear();
            dgKeyValue.AutoGenerateColumns = false;
            dgKeyValue.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            DataGridViewCell cell = new DataGridViewTextBoxCell();
            DataGridViewTextBoxColumn colFileName = new DataGridViewTextBoxColumn()
            {
                CellTemplate = cell,
                HeaderText = "Name",
                Name = "Name",
                DataPropertyName = "Name" // Tell the column which property of FileName it should use
            };
            //DataGridViewTextBoxColumn colFileDir = new DataGridViewTextBoxColumn()
            //{
            //    CellTemplate = cell,
            //    HeaderText = "Directory",
            //    Name = "Directory",
            //    DataPropertyName = "Directory"
            //};

            dgKeyValue.Columns.Add(colFileName);
            //dgKeyValue.Columns.Add(colFileDir);
        }

        private PrintServerConfig GetConfigFromUI()
        {
            PrintServerConfig conf = new PrintServerConfig
            {
                InstallDirectory = cbPath.Text,
                OdbcDatasource = cbOdbcDatasource.Text,
                ConnectionInfo = cbConnectionInfo.Text,
                ReportDirectory = cbReportDirectory.Text,
                ReportName = cbReportName.Text,
                ExportDirectory = cbExportDirectory.Text,
                Action = cbActions.Text,
                Settings = cbSettings.Text
            };

            if (dgKeyValue.DataSource != null)
            {
                var fileList = dgKeyValue.DataSource as List<string>;
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
            logger.Log(exe + arguments);

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
            //* Start process and handlers
            //process.Start();
            //process.BeginOutputReadLine();
            //process.BeginErrorReadLine();
            //process.WaitForExit();
            //logger.Log($"ExitCode={process.ExitCode}");
        }

        private void BuildCommand(out string exe, out string arguments)
        {
            var conf = GetConfigFromUI();
            exe = $"{conf.InstallDirectory}\\TestConsolePrintNet.exe";
            arguments = $" -connectioninfos:\"{ conf.ConnectionInfo}\" ";
            if (!string.IsNullOrEmpty(conf.ReportDirectory))
                arguments += $" -reportdirectory:\"{conf.ReportDirectory}\" ";
            if (!string.IsNullOrEmpty(conf.ReportName))
                arguments += $" -reportname:\"{conf.ReportName}\" ";
            if (!string.IsNullOrEmpty(conf.Action))
                arguments += $" -action:{conf.Action}";
            if (!string.IsNullOrEmpty(conf.ExportDirectory))
                arguments += $" -exportdirectory:\"{conf.ExportDirectory}\" ";
            if (!string.IsNullOrEmpty(conf.Settings))
                arguments += $" -settings:\"{conf.Settings}\" ";
            if (conf.Parameters?.Count > 0)
            {
                arguments += $" -parameters:\"";
                foreach (var item in conf.Parameters)
                {
                    arguments += item + ";";
                }
                arguments += $"\"";
            }

        }

        private void OutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            logger.Log(outLine.Data);
        }

        private void btAddParam_Click(object sender, EventArgs e)
        {
            var conf = GetConfigFromUI();
            if (conf.Parameters == null)
                conf.Parameters = new List<string>();

            conf.Parameters.Add("NEW");
            // dgKeyValue.row
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

        private void btBrowseRpt_Click(object sender, EventArgs e)
        {
            var folder = new OpenFileDialog
            {
                InitialDirectory = GetConfigFromUI().ReportDirectory,
                Multiselect = false,
                Filter = "*.rpt|*.*"
            };
            var result = folder.ShowDialog();
            cbReportName.Text = folder.FileName;
        }



        private void PrintServerControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveWorkspace();
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

        private void btDetectInstall_Click(object sender, EventArgs e)
        {
            MessageBox.Show("TODO");
        }
    }
}
