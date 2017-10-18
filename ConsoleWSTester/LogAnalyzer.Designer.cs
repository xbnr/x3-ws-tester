namespace ConsoleTester
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
            this.tbLogs = new System.Windows.Forms.TextBox();
            this.panelXmlFile = new System.Windows.Forms.Panel();
            this.btBrowseFile = new System.Windows.Forms.Button();
            this.tbFolder = new System.Windows.Forms.TextBox();
            this.lbFolder = new System.Windows.Forms.Label();
            this.btAnalyze = new System.Windows.Forms.Button();
            this.panelXmlFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbLogs
            // 
            this.tbLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLogs.Location = new System.Drawing.Point(12, 90);
            this.tbLogs.Multiline = true;
            this.tbLogs.Name = "tbLogs";
            this.tbLogs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbLogs.Size = new System.Drawing.Size(674, 214);
            this.tbLogs.TabIndex = 4;
            // 
            // panelXmlFile
            // 
            this.panelXmlFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelXmlFile.Controls.Add(this.btBrowseFile);
            this.panelXmlFile.Controls.Add(this.tbFolder);
            this.panelXmlFile.Controls.Add(this.lbFolder);
            this.panelXmlFile.Location = new System.Drawing.Point(12, 12);
            this.panelXmlFile.Name = "panelXmlFile";
            this.panelXmlFile.Size = new System.Drawing.Size(674, 33);
            this.panelXmlFile.TabIndex = 25;
            // 
            // btBrowseFile
            // 
            this.btBrowseFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btBrowseFile.Location = new System.Drawing.Point(632, 7);
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
            this.tbFolder.Size = new System.Drawing.Size(565, 20);
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
            this.btAnalyze.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btAnalyze.Location = new System.Drawing.Point(12, 51);
            this.btAnalyze.Name = "btAnalyze";
            this.btAnalyze.Size = new System.Drawing.Size(251, 33);
            this.btAnalyze.TabIndex = 17;
            this.btAnalyze.Text = "Analyze";
            this.btAnalyze.UseVisualStyleBackColor = true;
            this.btAnalyze.Click += new System.EventHandler(this.btAnalyze_Click);
            // 
            // LogAnalyzer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 315);
            this.Controls.Add(this.btAnalyze);
            this.Controls.Add(this.panelXmlFile);
            this.Controls.Add(this.tbLogs);
            this.Name = "LogAnalyzer";
            this.Text = "LogAnalyzer";
            this.panelXmlFile.ResumeLayout(false);
            this.panelXmlFile.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbLogs;
        private System.Windows.Forms.Panel panelXmlFile;
        private System.Windows.Forms.Button btBrowseFile;
        private System.Windows.Forms.TextBox tbFolder;
        private System.Windows.Forms.Label lbFolder;
        private System.Windows.Forms.Button btAnalyze;
    }
}