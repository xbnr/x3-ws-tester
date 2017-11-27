namespace ConsoleTester.UI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewLogAnalyzer = new System.Windows.Forms.ToolStripMenuItem();
            this.soapTesterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rESTTesterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dockPanelMain = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.dockPanelLogs = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1038, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.checkForUpdatesToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNewLogAnalyzer,
            this.soapTesterToolStripMenuItem,
            this.rESTTesterToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // tsmiNewLogAnalyzer
            // 
            this.tsmiNewLogAnalyzer.Name = "tsmiNewLogAnalyzer";
            this.tsmiNewLogAnalyzer.Size = new System.Drawing.Size(140, 22);
            this.tsmiNewLogAnalyzer.Text = "Log analyzer";
            this.tsmiNewLogAnalyzer.Click += new System.EventHandler(this.tsmiNewLogAnalayzer_Click);
            // 
            // soapTesterToolStripMenuItem
            // 
            this.soapTesterToolStripMenuItem.Name = "soapTesterToolStripMenuItem";
            this.soapTesterToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.soapTesterToolStripMenuItem.Text = "Soap tester";
            this.soapTesterToolStripMenuItem.Click += new System.EventHandler(this.soapTesterToolStripMenuItem_Click);
            // 
            // rESTTesterToolStripMenuItem
            // 
            this.rESTTesterToolStripMenuItem.Name = "rESTTesterToolStripMenuItem";
            this.rESTTesterToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.rESTTesterToolStripMenuItem.Text = "REST tester";
            this.rESTTesterToolStripMenuItem.Click += new System.EventHandler(this.rESTTesterToolStripMenuItem_Click);
            // 
            // checkForUpdatesToolStripMenuItem
            // 
            this.checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
            this.checkForUpdatesToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.checkForUpdatesToolStripMenuItem.Text = "Check for updates";
            this.checkForUpdatesToolStripMenuItem.Click += new System.EventHandler(this.checkForUpdatesToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // dockPanelMain
            // 
            this.dockPanelMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dockPanelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.dockPanelMain.DockBackColor = System.Drawing.SystemColors.AppWorkspace;
            this.dockPanelMain.DockBottomPortion = 250D;
            this.dockPanelMain.DockLeftPortion = 250D;
            this.dockPanelMain.DockRightPortion = 250D;
            this.dockPanelMain.DockTopPortion = 250D;
            this.dockPanelMain.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.dockPanelMain.Location = new System.Drawing.Point(0, 27);
            this.dockPanelMain.Name = "dockPanelMain";
            this.dockPanelMain.RightToLeftLayout = true;
            this.dockPanelMain.Size = new System.Drawing.Size(1038, 638);
            this.dockPanelMain.SupportDeeplyNestedContent = true;
            this.dockPanelMain.TabIndex = 133;
            // 
            // dockPanelLogs
            // 
            this.dockPanelLogs.Location = new System.Drawing.Point(0, 0);
            this.dockPanelLogs.Name = "dockPanelLogs";
            this.dockPanelLogs.Size = new System.Drawing.Size(200, 100);
            this.dockPanelLogs.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 666);
            this.Controls.Add(this.dockPanelMain);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanelMain;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanelLogs;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewLogAnalyzer;
        private System.Windows.Forms.ToolStripMenuItem soapTesterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rESTTesterToolStripMenuItem;
    }
}