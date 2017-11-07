﻿using System;
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

        public static DockPanel LogsDockPanel { get; private set; }

        public MainForm()
        {
            InitializeComponent();
        }

        private void Init()
        {
            this.Text = Program.GetAppliVersion(true) + " - " + Program.GetAppliVersion(false);
            var treeView = new FileSystemTree();
            treeView.Show(dockPanelMain, WeifenLuo.WinFormsUI.Docking.DockState.DockLeft);
            var logs = new Logs();
            logs.Show(dockPanelLogs, WeifenLuo.WinFormsUI.Docking.DockState.DockBottom);
            MainDockPanel = dockPanelMain;
            LogsDockPanel = dockPanelLogs;
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
    }
}
