using ConsoleTester.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace ConsoleTester.Plugins.Soap
{
    public partial class WsSOAPTester : ControlConfig
    {
        public WsSOAPTester()
        {
            InitializeComponent();
        }

        public override void CreateWS(FileInfo item)
        {
            Workspace ws = this.workspace1;
            if (item != null)
            {
                ws.LoadConfigFromJSON(item.FullName);
            }
        }

        private void WsSOAPTester_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.workspace1.SaveWorkspace();
        }
    }
}
