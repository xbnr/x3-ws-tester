using ConsoleTester.LogsAnalyzer;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace ConsoleTester
{
    public partial class LogAnalyzer : DockContent
    {
        public LogAnalyzer()
        {
            InitializeComponent();
        }

        private void btBrowseFile_Click(object sender, EventArgs e)
        {
            var folderDialog = new FolderBrowserDialog();
            folderDialog.RootFolder = Environment.SpecialFolder.UserProfile;
            folderDialog.SelectedPath = !string.IsNullOrEmpty(tbFolder.Text) ? tbFolder.Text : Program.GetWorkspaceDirectory();
            var result = folderDialog.ShowDialog();
            if (result == DialogResult.OK || result == DialogResult.Yes)
            {
                tbFolder.Text = folderDialog.SelectedPath;
            }
        }

        private void btAnalyze_Click(object sender, EventArgs e)
        {
            var logger = new LoggerToFile(Path.Combine( LogAnalyze.GetResultDirTarget(), "Report.txt"), this.tbLogs);
            var analyzer = new LogAnalyze(tbFolder.Text, tbFilter.Text, cbRecurseDir.Checked, logger);
            analyzer.LaunchAnalyze();
        }

        private void llOpenFolder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("explorer.exe", Program.GetWorkspaceDirectory());
        }

        private void llClearLogs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tbLogs.Clear();
        }

        private void llOpenConfigurationFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string configFilename = LogAnalyze.GetRulesFilename();

            if (!OpenConfigWith(@"C:\Program Files (x86)\Microsoft VS Code\Code.exe", configFilename))
            {
                if (!OpenConfigWith("notepad++.exe", configFilename))
                {
                    if (!OpenConfigWith("notepad2.exe", configFilename))
                    {
                        OpenConfigWith("notepad.exe", configFilename);
                    }
                }
            }
        }

        private static bool OpenConfigWith(string exeProgramName, string arguments)
        {
            try
            {
                Process.Start(exeProgramName, arguments);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void LogAnalyzer_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }

        private void SaveSettings()
        {
            Settings.Default.XmlFilename = tbFolder.Text;
            Settings.Default.Filter = tbFilter.Text;
            Settings.Default.SubFolders = cbRecurseDir.Checked;
        }

        private void LogAnalyzer_Load(object sender, EventArgs e)
        {
            InitSettings();
        }

        private void InitSettings()
        {
            tbFolder.Text = Settings.Default.XmlFilename;
            tbFilter.Text = Settings.Default.Filter;
            cbRecurseDir.Checked = Settings.Default.SubFolders;
        }
    }
}
