using ConsoleTester.LogsAnalyzer;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ConsoleTester
{
    public partial class LogAnalyzer : Form
    {
        public LogAnalyzer()
        {
            InitializeComponent();
        }

        private void btBrowseFile_Click(object sender, EventArgs e)
        {
            var folderDialog = new FolderBrowserDialog();
            folderDialog.SelectedPath = Program.GetWorkspaceDirectory();
            var result = folderDialog.ShowDialog();
            if (result == DialogResult.OK || result == DialogResult.Yes)
            {
                tbFolder.Text = folderDialog.SelectedPath;
            }
        }

        private void btAnalyze_Click(object sender, EventArgs e)
        {
            var logger = new Logger(this.tbLogs);
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
    }
}
