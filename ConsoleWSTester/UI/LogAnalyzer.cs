using ConsoleTester.Common;
using ConsoleTester.LogsAnalyzer;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
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
            folderDialog.ShowNewFolderButton = true;
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
            var logger = new Logger(MainForm.LogControl);
            var analyzer = new LogAnalyze(tbFolder.Text, tbFilter.Text, cbRecurseDir.Checked, logger);
            if (unzipFiles.Checked)
            {
                analyzer.UnZipArchives();
            }
            analyzer.LaunchAnalyze();
            analyzer.ShowExcerpt(treeViewResult);
        }

        private void llOpenFolder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("explorer.exe", Program.GetWorkspaceDirectory());
        }

        private void llOpenConfigurationFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string configFilename = LogAnalyze.GetConfigFilename();
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
            Settings.Default.UnZipFiles = unzipFiles.Checked;
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
            unzipFiles.Checked = Settings.Default.UnZipFiles;
            cbRecurseDir.Checked = Settings.Default.SubFolders;
        }


        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeViewResult.SelectedNode != null)
            {
                Program.OpenJson(treeViewResult.SelectedNode.Text);
            }
        }

        private void treeViewResult_DoubleClick(object sender, EventArgs e)
        {
            string path = treeViewResult.SelectedNode.Text;
            if (path.IndexOf("file: ") >= 0)
            {
                path = path.Substring("file: ".Length);
                string line = treeViewResult.SelectedNode.Parent.Nodes[0].Text.Substring("line: ".Length);
                int lineNumber = int.Parse(line, System.Globalization.NumberStyles.Number);
                Program.OpenJson(path, lineNumber);
            }

        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(treeViewResult.SelectedNode.Text);
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeViewResult.TopNode?.Remove();
        }

        private void copyHeadersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var r = new StringBuilder();
            foreach (TreeNode node in treeViewResult.TopNode.Nodes)
            {
                r.Append(node.Text + "\r\n");
            }
            Clipboard.SetText(r.ToString());

        }
    }
}
