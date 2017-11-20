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
            this.panelXmlFile = new System.Windows.Forms.Panel();
            this.llOpenConfigurationFile = new System.Windows.Forms.LinkLabel();
            this.tbFilter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbRecurseDir = new System.Windows.Forms.CheckBox();
            this.btBrowseFile = new System.Windows.Forms.Button();
            this.tbFolder = new System.Windows.Forms.TextBox();
            this.lbFolder = new System.Windows.Forms.Label();
            this.btAnalyze = new System.Windows.Forms.Button();
            this.llOpenFolder = new System.Windows.Forms.LinkLabel();
            this.llExcerptResult = new System.Windows.Forms.LinkLabel();
            this.panelXmlFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelXmlFile
            // 
            this.panelXmlFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelXmlFile.Controls.Add(this.llOpenConfigurationFile);
            this.panelXmlFile.Controls.Add(this.tbFilter);
            this.panelXmlFile.Controls.Add(this.label1);
            this.panelXmlFile.Controls.Add(this.cbRecurseDir);
            this.panelXmlFile.Controls.Add(this.btBrowseFile);
            this.panelXmlFile.Controls.Add(this.tbFolder);
            this.panelXmlFile.Controls.Add(this.lbFolder);
            this.panelXmlFile.Location = new System.Drawing.Point(12, 12);
            this.panelXmlFile.Name = "panelXmlFile";
            this.panelXmlFile.Size = new System.Drawing.Size(794, 53);
            this.panelXmlFile.TabIndex = 25;
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
            this.btAnalyze.Location = new System.Drawing.Point(12, 71);
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
            // llExcerptResult
            // 
            this.llExcerptResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.llExcerptResult.AutoSize = true;
            this.llExcerptResult.Location = new System.Drawing.Point(215, 354);
            this.llExcerptResult.Name = "llExcerptResult";
            this.llExcerptResult.Size = new System.Drawing.Size(100, 13);
            this.llExcerptResult.TabIndex = 28;
            this.llExcerptResult.TabStop = true;
            this.llExcerptResult.Text = "Open Excerp result ";
            this.llExcerptResult.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llExcerptResult_LinkClicked);
            // 
            // LogAnalyzer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 374);
            this.Controls.Add(this.llExcerptResult);
            this.Controls.Add(this.llOpenFolder);
            this.Controls.Add(this.btAnalyze);
            this.Controls.Add(this.panelXmlFile);
            this.Name = "LogAnalyzer";
            this.Text = "LogAnalyzer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LogAnalyzer_FormClosing);
            this.Load += new System.EventHandler(this.LogAnalyzer_Load);
            this.panelXmlFile.ResumeLayout(false);
            this.panelXmlFile.PerformLayout();
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
        private System.Windows.Forms.LinkLabel llExcerptResult;
    }
}