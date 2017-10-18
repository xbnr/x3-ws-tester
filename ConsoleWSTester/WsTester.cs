using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace ConsoleTester
{
    public partial class WsTester : Form
    {
        public WsTester()
        {
            InitializeComponent();
        }


        private void Main_Load(object sender, EventArgs e)
        {
            this.Text +=  $" version { Program.GetAppliVersion(false) } ";

            string wsDirectory = Program.GetWorkspaceDirectory();
            if (!Directory.Exists(wsDirectory))
            {
                Directory.CreateDirectory(wsDirectory);
            }

            if (tabPage1.Controls.Count > 0)
            {
                tabPage1.Controls.Clear();
            }
            if (tabControl1.Controls.Count > 0)
            {
                tabControl1.Controls.Clear();
            }

            var dir = new DirectoryInfo(Program.GetWorkspaceDirectory());
            var wSConfigFiles = dir.GetFiles().OrderBy(p => p.Name);
            foreach (var item in wSConfigFiles.Where(p => p.Name.StartsWith(WorkspaceConfig.GetWorkspaceShortName())))
            {
                TabPage tabPage = new TabPage(item.Name);
                tabControl1.Controls.Add(tabPage);
                Workspace ws = CreateWS(item);
                tabPage.Controls.Add(ws);
            }

            if (wSConfigFiles.Count() == 0)
            {
                TabPage tabPage = new TabPage("New");
                tabControl1.Controls.Add(tabPage);
                Workspace ws = CreateWS(null);
                tabPage.Controls.Add(ws);
            }

            tabControl1.Refresh();
        }

        private static Workspace CreateWS(FileInfo item)
        {
            Workspace ws = new Workspace();
            if (item != null)
                ws.LoadConfigFromJSON(item.FullName);
            ws.Location = new System.Drawing.Point(5, 5);
            ws.Size = new System.Drawing.Size(670, 530);
            ws.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
            return ws;
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (TabPage tabPage in tabControl1.TabPages)
            {
                if (tabPage.Controls.Count == 0)
                    continue;

                Workspace ws = tabPage.Controls[0] as Workspace;
                if (ws != null)
                {
                    ws.SaveWorkspace();
                }
            }
        }
    }
}
