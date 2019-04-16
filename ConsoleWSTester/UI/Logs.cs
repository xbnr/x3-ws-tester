using System;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

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

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(LogControl.SelectedText))
                Clipboard.SetText(LogControl.SelectedText);
        }
    }
}
