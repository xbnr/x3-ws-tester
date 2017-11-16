using ConsoleTester.LogsAnalyzer;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace ConsoleTester.UI
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
            var logger = new LoggerToFile(Path.Combine(LogAnalyze.GetResultDirTarget(), "Report.txt"), MainForm.LogControl);
            var analyzer = new LogAnalyze(tbFolder.Text, tbFilter.Text, cbRecurseDir.Checked, logger);
            analyzer.LaunchAnalyze();
        }

        private void llOpenFolder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("explorer.exe", Program.GetWorkspaceDirectory());
        }

        private void llClearLogs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MainForm.LogControl.Clear();
        }

        private void llOpenConfigurationFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string configFilename = LogAnalyze.GetRulesFilename();
            Program.OpenJson(configFilename);
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
            Settings.Default.Save();
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

        private void llExcerptResult_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var browser = new Browser();
            browser.Show(MainForm.MainDockPanel, DockState.Document);
        }
    }
}
