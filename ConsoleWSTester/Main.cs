using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ConsoleWSTester
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            string wsDirectory = WorkspaceConfig.GetWorkspaceDirectory();
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

            // List<Workspace> wsList = new List<Workspace>();
            var dir = new DirectoryInfo(WorkspaceConfig.GetWorkspaceDirectory());
            foreach (var item in dir.GetFiles().OrderBy(p => p.Name)
                .Where(p => p.Name.StartsWith(WorkspaceConfig.GetWorkspaceShortName())))
            {
                TabPage tabPage = new TabPage(item.Name);
                tabControl1.Controls.Add(tabPage);

                Workspace ws = new Workspace();
                ws.LoadConfigFromJSON( item.FullName );
                ws.Location = new System.Drawing.Point(5, 5);
                ws.Size = new System.Drawing.Size(670, 530);
                ws.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
                tabPage.Controls.Add(ws);
            }

            tabControl1.Refresh();
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
