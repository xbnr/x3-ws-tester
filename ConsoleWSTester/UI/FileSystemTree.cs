using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.IO;
using ConsoleTester.LogsAnalyzer;

namespace ConsoleTester.UI
{
    public partial class FileSystemTree : DockContent
    {
        public FileSystemTree()
        {
            InitializeComponent();
        }

        private void FileSystemTree_Load(object sender, EventArgs e)
        {
            BuildTreeView();
        }

        private void AddNode(FileInfo file)
        {
            var treeNode = new TreeNode(file.Name);
            treeNode.Tag = file;
            treeNode.ToolTipText = file.FullName;
            tvFileSystem.TopNode.Nodes.Add(treeNode);
        }

        private void tvFileSystem_Click(object sender, EventArgs e)
        {

        }

        private void tvFileSystem_DoubleClick(object sender, EventArgs e)
        {
            FileInfo file = SelectedFile;
            if (file != null)
            {
                DockContent content = null;
                if (file.Name.StartsWith(LogAnalyze.RulesShortName))
                {
                    content = new LogAnalyzer();
                }
                else
                {
                    content = new WsSOAPTester();
                    ((WsSOAPTester)content).CreateWS(file);
                }
                if (content != null)
                {
                    content.Text = file.Name;
                    content.Show(MainForm.MainDockPanel, WeifenLuo.WinFormsUI.Docking.DockState.Document);
                }
            }

        }

        private FileInfo SelectedFile
        {
            get
            {
                return tvFileSystem.SelectedNode?.Tag as FileInfo;
            }
        }

        private void openWithToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.OpenJson(SelectedFile.FullName);
        }

        private void duplicateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string newName = GetNewName(SelectedFile);
            SelectedFile.CopyTo(newName);
            BuildTreeView();
        }

        private string GetNewName(FileInfo fileToDuplicate)
        {
            int i = 2;
            string result =  Path.Combine( fileToDuplicate.DirectoryName,  Path.GetFileNameWithoutExtension(fileToDuplicate.Name) + i.ToString("00") + fileToDuplicate.Extension);
            while (File.Exists(result))
            {
                result = Path.Combine(fileToDuplicate.DirectoryName, Path.GetFileNameWithoutExtension(fileToDuplicate.Name) + (i++).ToString("00") + fileToDuplicate.Extension);
            }
            return result;
        }


        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Delete {SelectedFile.FullName} ?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                SelectedFile.Delete();
                BuildTreeView();
            }
        }

        private void BuildTreeView()
        {
            tvFileSystem.TopNode.Nodes.Clear();

            var dir = new DirectoryInfo(Program.GetWorkspaceDirectory());
            var files = dir.GetFiles();

            foreach (var item in files)
            {
                AddNode(item);
            }

            tvFileSystem.TopNode.Expand();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuildTreeView();
        }
    }
}
