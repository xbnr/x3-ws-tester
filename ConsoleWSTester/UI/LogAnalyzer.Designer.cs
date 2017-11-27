namespace ConsoleTester.UI
{
    partial class LogAnalyzer
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
            this.components = new System.ComponentModel.Container();
            this.panelXmlFile = new System.Windows.Forms.Panel();
            this.unzipFiles = new System.Windows.Forms.CheckBox();
            this.llOpenConfigurationFile = new System.Windows.Forms.LinkLabel();
            this.tbFilter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbRecurseDir = new System.Windows.Forms.CheckBox();
            this.btBrowseFile = new System.Windows.Forms.Button();
            this.tbFolder = new System.Windows.Forms.TextBox();
            this.lbFolder = new System.Windows.Forms.Label();
            this.btAnalyze = new System.Windows.Forms.Button();
            this.llOpenFolder = new System.Windows.Forms.LinkLabel();
            this.treeViewResult = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelXmlFile.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelXmlFile
            // 
            this.panelXmlFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelXmlFile.Controls.Add(this.unzipFiles);
            this.panelXmlFile.Controls.Add(this.llOpenConfigurationFile);
            this.panelXmlFile.Controls.Add(this.tbFilter);
            this.panelXmlFile.Controls.Add(this.label1);
            this.panelXmlFile.Controls.Add(this.cbRecurseDir);
            this.panelXmlFile.Controls.Add(this.btBrowseFile);
            this.panelXmlFile.Controls.Add(this.tbFolder);
            this.panelXmlFile.Controls.Add(this.lbFolder);
            this.panelXmlFile.Location = new System.Drawing.Point(12, 12);
            this.panelXmlFile.Name = "panelXmlFile";
            this.panelXmlFile.Size = new System.Drawing.Size(794, 77);
            this.panelXmlFile.TabIndex = 25;
            // 
            // unzipFiles
            // 
            this.unzipFiles.AutoSize = true;
            this.unzipFiles.Checked = true;
            this.unzipFiles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.unzipFiles.Location = new System.Drawing.Point(61, 57);
            this.unzipFiles.Name = "unzipFiles";
            this.unzipFiles.Size = new System.Drawing.Size(118, 17);
            this.unzipFiles.TabIndex = 29;
            this.unzipFiles.Text = "Unzip ZIPpped files";
            this.unzipFiles.UseVisualStyleBackColor = true;
            // 
            // llOpenConfigurationFile
            // 
            this.llOpenConfigurationFile.AutoSize = true;
            this.llOpenConfigurationFile.Location = new System.Drawing.Point(397, 34);
            this.llOpenConfigurationFile.Name = "llOpenConfigurationFile";
            this.llOpenConfigurationFile.Size = new System.Drawing.Size(113, 13);
            this.llOpenConfigurationFile.TabIndex = 28;
            this.llOpenConfigurationFile.TabStop = true;
            this.llOpenConfigurationFile.Text = "Open configuration file";
            this.llOpenConfigurationFile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llOpenConfigurationFile_LinkClicked);
            // 
            // tbFilter
            // 
            this.tbFilter.Location = new System.Drawing.Point(61, 31);
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(310, 20);
            this.tbFilter.TabIndex = 18;
            this.tbFilter.Text = "*.log";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Filter:";
            // 
            // cbRecurseDir
            // 
            this.cbRecurseDir.AutoSize = true;
            this.cbRecurseDir.Checked = true;
            this.cbRecurseDir.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbRecurseDir.Location = new System.Drawing.Point(582, 33);
            this.cbRecurseDir.Name = "cbRecurseDir";
            this.cbRecurseDir.Size = new System.Drawing.Size(91, 17);
            this.cbRecurseDir.TabIndex = 17;
            this.cbRecurseDir.Text = "All sub-folders";
            this.cbRecurseDir.UseVisualStyleBackColor = true;
            // 
            // btBrowseFile
            // 
            this.btBrowseFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btBrowseFile.Location = new System.Drawing.Point(752, 7);
            this.btBrowseFile.Name = "btBrowseFile";
            this.btBrowseFile.Size = new System.Drawing.Size(39, 23);
            this.btBrowseFile.TabIndex = 16;
            this.btBrowseFile.Text = "...";
            this.btBrowseFile.UseVisualStyleBackColor = true;
            this.btBrowseFile.Click += new System.EventHandler(this.btBrowseFile_Click);
            // 
            // tbFolder
            // 
            this.tbFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFolder.Location = new System.Drawing.Point(61, 7);
            this.tbFolder.Name = "tbFolder";
            this.tbFolder.Size = new System.Drawing.Size(685, 20);
            this.tbFolder.TabIndex = 12;
            this.tbFolder.Text = "C:\\Users\\frdepo\\OneDrive - Sage Software, Inc\\X3\\X3-37916-Restart of Syracuse ran" +
    "domly";
            // 
            // lbFolder
            // 
            this.lbFolder.AutoSize = true;
            this.lbFolder.Location = new System.Drawing.Point(13, 10);
            this.lbFolder.Name = "lbFolder";
            this.lbFolder.Size = new System.Drawing.Size(39, 13);
            this.lbFolder.TabIndex = 13;
            this.lbFolder.Text = "Folder:";
            // 
            // btAnalyze
            // 
            this.btAnalyze.Location = new System.Drawing.Point(12, 91);
            this.btAnalyze.Name = "btAnalyze";
            this.btAnalyze.Size = new System.Drawing.Size(371, 33);
            this.btAnalyze.TabIndex = 17;
            this.btAnalyze.Text = "Analyze";
            this.btAnalyze.UseVisualStyleBackColor = true;
            this.btAnalyze.Click += new System.EventHandler(this.btAnalyze_Click);
            // 
            // llOpenFolder
            // 
            this.llOpenFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.llOpenFolder.AutoSize = true;
            this.llOpenFolder.Location = new System.Drawing.Point(12, 354);
            this.llOpenFolder.Name = "llOpenFolder";
            this.llOpenFolder.Size = new System.Drawing.Size(90, 13);
            this.llOpenFolder.TabIndex = 26;
            this.llOpenFolder.TabStop = true;
            this.llOpenFolder.Text = "Open result folder";
            this.llOpenFolder.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llOpenFolder_LinkClicked);
            // 
            // treeViewResult
            // 
            this.treeViewResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewResult.ContextMenuStrip = this.contextMenuStrip1;
            this.treeViewResult.Location = new System.Drawing.Point(12, 130);
            this.treeViewResult.Name = "treeViewResult";
            this.treeViewResult.Size = new System.Drawing.Size(794, 221);
            this.treeViewResult.TabIndex = 29;
            this.treeViewResult.DoubleClick += new System.EventHandler(this.treeViewResult_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.clearToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 92);
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.openFileToolStripMenuItem.Text = "Open file";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // LogAnalyzer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 374);
            this.Controls.Add(this.treeViewResult);
            this.Controls.Add(this.llOpenFolder);
            this.Controls.Add(this.btAnalyze);
            this.Controls.Add(this.panelXmlFile);
            this.Name = "LogAnalyzer";
            this.Text = "LogAnalyzer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LogAnalyzer_FormClosing);
            this.Load += new System.EventHandler(this.LogAnalyzer_Load);
            this.panelXmlFile.ResumeLayout(false);
            this.panelXmlFile.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panelXmlFile;
        private System.Windows.Forms.Button btBrowseFile;
        private System.Windows.Forms.TextBox tbFolder;
        private System.Windows.Forms.Label lbFolder;
        private System.Windows.Forms.Button btAnalyze;
        private System.Windows.Forms.LinkLabel llOpenFolder;
        private System.Windows.Forms.CheckBox cbRecurseDir;
        private System.Windows.Forms.TextBox tbFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel llOpenConfigurationFile;
        private System.Windows.Forms.CheckBox unzipFiles;
        private System.Windows.Forms.TreeView treeViewResult;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
    }
}