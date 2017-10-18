using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var folder = new FolderBrowserDialog();
            // folder.RootFolder = @"C:\Users\frdepo\OneDrive - Sage Software, Inc\X3\X3-57422-SOAP Web Services - deleting lines on orders and quotes";
            var result = folder.ShowDialog();

        }

        private void btAnalyze_Click(object sender, EventArgs e)
        {
            var logger = new Logger(this.tbLogs);
            var analyzer = new LogAnalyze(tbFolder.Text, logger);
            analyzer.LaunchAnalyze();
        }
    }
}
