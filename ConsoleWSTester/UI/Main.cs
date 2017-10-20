using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace ConsoleTester
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.Text +=  $" version { Program.GetAppliVersion(false) } ";
          
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.Save();
        }

        private void btSOAPTester_Click(object sender, EventArgs e)
        {
            var tester = new WsTester();
            tester.Show(this);
        }

        private void btLogAnalyzer_Click(object sender, EventArgs e)
        {
            var logAnalyzer = new LogAnalyzer();
            logAnalyzer.Show(this);
        }

        private void llConfigFolder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("explorer.exe", Program.GetWorkspaceDirectory());
        }
    }
}
