﻿using ConsoleTester.Common;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace ConsoleTester.UI
{
    public partial class MainForm : Form
    {

        public static MainForm Instance { get; private set; }

        public static DockPanel MainDockPanel { get; private set; }

        public static TextBox LogControl { get; private set; }

        public static FileSystemTree FileSysTree { get; private set; }


        public MainForm()
        {
            InitializeComponent();
        }

        private void Init()
        {
            this.Size = new Size(Settings.Default.MainFormWidth, Settings.Default.MainFormHeight);

            this.Text = Program.GetApplicationName() + " - " + Program.GetApplicationVersion();
            Instance = this;
            var treeView = new FileSystemTree();
            FileSysTree = treeView;
            treeView.Show(dockPanelMain, DockState.DockLeft);
            // var outputResult = new OutputResult();
            // outputResult.Show(dockPanelMain, DockState.DockBottom);
            var logs = new Logs();
            LogControl = logs.LogControl;
            logs.Show(dockPanelMain, DockState.DockBottom);
            MainDockPanel = dockPanelMain;

            foreach (var item in Program.GetConfigs())
            {
                Type serviceType = Type.GetType(item.ToString());
                IConfigService configService = Activator.CreateInstance(serviceType) as IConfigService;
                var UIControl = Helper.GetUIControl(configService);
                if (UIControl.IsVisibleInReleaseMode())
                {
                    var toolTrip = newToolStripMenuItem.DropDownItems.Add(configService.GetTitle());
                    toolTrip.Tag = configService;
                    toolTrip.Click += new EventHandler(tsmiNewForm_Click);
                }
            }
        }

        private void tsmiNewForm_Click(object sender, EventArgs e)
        {
            var se = sender as ToolStripItem;
            var configService = se.Tag as IConfigService;
            var UIControl = Helper.GetUIControl(configService);
            UIControl.CreateNewWS();
            UIControl.Show(dockPanelMain, DockState.Document);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Init();
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

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var about = new AboutForm();
            about.Show();
            about.CheckLastUpdate();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }

        private void SaveSettings()
        {
            Settings.Default.MainFormWidth = this.Size.Width;
            Settings.Default.MainFormHeight = this.Size.Height;
            Settings.Default.Save();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControlConfig control = MainForm.MainDockPanel.ActiveContent as ControlConfig;
            if (control.GetWorkspaceFilename() == control.GetDefaultWorkspaceFilename())
            {
                SaveAs(control);
            }
            else
            {
                control?.SaveWorkspace();
            }
        }

        private void saveAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in MainForm.MainDockPanel.Contents)
            {
                ControlConfig control = item as ControlConfig;
                control?.SaveWorkspace();
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControlConfig control = MainForm.MainDockPanel.ActiveContent as ControlConfig;
            SaveAs(control);
        }

        private void SaveAs(ControlConfig control)
        {
            EnterValueDialog dialog = new EnterValueDialog
            {
                Label = "Enter filename :"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string defaultFilename = control.GetDefaultWorkspaceFilename();
                string newFilename = Path.Combine(Path.GetDirectoryName(defaultFilename),
                    $"{Path.GetFileNameWithoutExtension(defaultFilename)}{dialog.GetEnteredValue()}{Path.GetExtension(defaultFilename)}");
                control.SetWorkspaceFilename(newFilename);
                control.SaveWorkspace();
                FileSysTree.BuildTreeView();
            }
        }
    }
}
