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
    public partial class Logs : DockContent
    {
        public Logs()
        {
            InitializeComponent();
        }

        public TextBox LogControl => tbLogs;

        private void Logs_Load(object sender, EventArgs e)
        {
        }

        private void clearLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogControl.Clear();
        }

        private void copyAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(LogControl.Text);
        }
    }
}
