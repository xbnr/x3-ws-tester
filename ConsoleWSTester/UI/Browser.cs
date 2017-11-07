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
using CefSharp.WinForms;
using CefSharp;

namespace ConsoleTester.UI
{
    public partial class Browser : DockContent
    {
        public Browser()
        {
            InitializeComponent();
        }

        private void Logs_Load(object sender, EventArgs e)
        {
            InitBrowser();
        }

        public void InitBrowser()
        {
            Cef.Initialize(new CefSettings());
            var browser = new ChromiumWebBrowser("http://www.google.com");
            this.Controls.Add(browser);
            browser.Dock = DockStyle.Fill;
        }


    }
}
