using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace ConsoleTester.UI
{
    public partial class MainForm : Form
    {
        public static DockPanel MainDockPanel { get; private set; }
        public MainForm()
        {
            InitializeComponent();
        }

        private void Init()
        {
            var treeView = new FileSystemTree();
            treeView.Show(dockPanelMain, WeifenLuo.WinFormsUI.Docking.DockState.DockLeft);
            //var wsSoapTester = new WsSOAPTester();
            //wsSoapTester.Show(dockPanelMain, WeifenLuo.WinFormsUI.Docking.DockState.Document);

            MainDockPanel = dockPanelMain;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void tsmiNewLogAnalayzer_Click(object sender, EventArgs e)
        {
            var logAnalyzer = new LogAnalyzer();
            logAnalyzer.Show(dockPanelMain, WeifenLuo.WinFormsUI.Docking.DockState.Document);
        }
    }
}
