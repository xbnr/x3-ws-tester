using ConsoleTester.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace ConsoleTester.UI
{
    public partial class MainForm : Form
    {

        public static MainForm Instance { get; private set; }
        public static DockPanel MainDockPanel { get; private set; }

        public static TextBox LogControl { get; private set; }


        public MainForm()
        {
            InitializeComponent();
        }

        private void Init()
        {
            this.Text = Program.GetApplicationName() + " - " + Program.GetApplicationVersion();
            Instance = this;
            var treeView = new FileSystemTree();
            treeView.Show(dockPanelMain, DockState.DockLeft);
            var outputResult = new OutputResult();
            outputResult.Show(dockPanelMain, DockState.DockBottom);
            var logs = new Logs();
            LogControl = logs.LogControl;
            logs.Show(dockPanelMain, DockState.DockBottom);
            MainDockPanel = dockPanelMain;

            foreach(var item in Program.GetConfigs())
            {
                Type serviceType = Type.GetType(item.ToString());
                IConfigService configService = Activator.CreateInstance(serviceType) as IConfigService;
                var toolTrip = newToolStripMenuItem.DropDownItems.Add(configService.GetTitle());
                toolTrip.Tag = configService;
                toolTrip.Click += new EventHandler(tsmiNewForm_Click);
            }
        }

        private void tsmiNewForm_Click(object sender, EventArgs e)
        {
            // https://msdn.microsoft.com/en-us/library/wc8csdkz(v=vs.71).aspx
            var se = sender as ToolStripItem;
            var configService = se.Tag as IConfigService;

            Type formType = Type.GetType(configService.GetFormFullName());
            DockContent dockContent = Activator.CreateInstance(formType) as DockContent;
            dockContent.Show(dockPanelMain, DockState.Document);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void tsmiNewLogAnalayzer_Click(object sender, EventArgs e)
        {
            var logAnalyzer = new LogAnalyzer();
            logAnalyzer.Show(dockPanelMain, DockState.Document);
        }

        private void soapTesterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var soapTester = new WsSOAPTester();
            soapTester.Show(dockPanelMain, DockState.Document);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var about = new AboutForm();
            about.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rESTTesterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var restTester = new WsRESTControl();
            restTester.Show(dockPanelMain, DockState.Document);
        }

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var about = new AboutForm();
            about.Show();
            about.CheckLastUpdate();
        }
    }
}
