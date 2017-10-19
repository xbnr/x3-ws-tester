namespace ConsoleTester
{
    partial class Main
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
            this.btSOAPTester = new System.Windows.Forms.Button();
            this.btLogAnalyzer = new System.Windows.Forms.Button();
            this.llConfigFolder = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // btSOAPTester
            // 
            this.btSOAPTester.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btSOAPTester.Location = new System.Drawing.Point(32, 96);
            this.btSOAPTester.Name = "btSOAPTester";
            this.btSOAPTester.Size = new System.Drawing.Size(526, 45);
            this.btSOAPTester.TabIndex = 0;
            this.btSOAPTester.Text = "SOAP WebService";
            this.btSOAPTester.UseVisualStyleBackColor = true;
            this.btSOAPTester.Click += new System.EventHandler(this.btSOAPTester_Click);
            // 
            // btLogAnalyzer
            // 
            this.btLogAnalyzer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btLogAnalyzer.Location = new System.Drawing.Point(32, 178);
            this.btLogAnalyzer.Name = "btLogAnalyzer";
            this.btLogAnalyzer.Size = new System.Drawing.Size(526, 45);
            this.btLogAnalyzer.TabIndex = 1;
            this.btLogAnalyzer.Text = "Log analyzer";
            this.btLogAnalyzer.UseVisualStyleBackColor = true;
            this.btLogAnalyzer.Click += new System.EventHandler(this.btLogAnalyzer_Click);
            // 
            // llConfigFolder
            // 
            this.llConfigFolder.AutoSize = true;
            this.llConfigFolder.Location = new System.Drawing.Point(32, 297);
            this.llConfigFolder.Name = "llConfigFolder";
            this.llConfigFolder.Size = new System.Drawing.Size(94, 13);
            this.llConfigFolder.TabIndex = 2;
            this.llConfigFolder.TabStop = true;
            this.llConfigFolder.Text = "Open config folder";
            this.llConfigFolder.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llConfigFolder_LinkClicked);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 322);
            this.Controls.Add(this.llConfigFolder);
            this.Controls.Add(this.btLogAnalyzer);
            this.Controls.Add(this.btSOAPTester);
            this.Name = "Main";
            this.Text = "X3  Maintenance";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btSOAPTester;
        private System.Windows.Forms.Button btLogAnalyzer;
        private System.Windows.Forms.LinkLabel llConfigFolder;
    }
}