namespace ConsoleWSTester
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPoolAlias = new System.Windows.Forms.TextBox();
            this.tbLogs = new System.Windows.Forms.TextBox();
            this.labelPoolAlias = new System.Windows.Forms.Label();
            this.labelLanguage = new System.Windows.Forms.Label();
            this.tbLanguage = new System.Windows.Forms.TextBox();
            this.labelPublicName = new System.Windows.Forms.Label();
            this.labelHost = new System.Windows.Forms.Label();
            this.tbHost = new System.Windows.Forms.TextBox();
            this.cbMode = new System.Windows.Forms.ComboBox();
            this.tbXmlFilename = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbPublicName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btBrowse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(12, 360);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(624, 38);
            this.button1.TabIndex = 0;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.launch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "WebService SOAP";
            // 
            // tbPoolAlias
            // 
            this.tbPoolAlias.Location = new System.Drawing.Point(242, 34);
            this.tbPoolAlias.Name = "tbPoolAlias";
            this.tbPoolAlias.Size = new System.Drawing.Size(144, 20);
            this.tbPoolAlias.TabIndex = 2;
            this.tbPoolAlias.Text = "MYPOOL1";
            // 
            // tbLogs
            // 
            this.tbLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLogs.Location = new System.Drawing.Point(12, 134);
            this.tbLogs.Multiline = true;
            this.tbLogs.Name = "tbLogs";
            this.tbLogs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbLogs.Size = new System.Drawing.Size(624, 206);
            this.tbLogs.TabIndex = 3;
            // 
            // labelPoolAlias
            // 
            this.labelPoolAlias.AutoSize = true;
            this.labelPoolAlias.Location = new System.Drawing.Point(172, 37);
            this.labelPoolAlias.Name = "labelPoolAlias";
            this.labelPoolAlias.Size = new System.Drawing.Size(56, 13);
            this.labelPoolAlias.TabIndex = 4;
            this.labelPoolAlias.Text = "Pool Alias:";
            // 
            // labelLanguage
            // 
            this.labelLanguage.AutoSize = true;
            this.labelLanguage.Location = new System.Drawing.Point(420, 15);
            this.labelLanguage.Name = "labelLanguage";
            this.labelLanguage.Size = new System.Drawing.Size(58, 13);
            this.labelLanguage.TabIndex = 6;
            this.labelLanguage.Text = "Language:";
            // 
            // tbLanguage
            // 
            this.tbLanguage.Location = new System.Drawing.Point(492, 12);
            this.tbLanguage.Name = "tbLanguage";
            this.tbLanguage.Size = new System.Drawing.Size(144, 20);
            this.tbLanguage.TabIndex = 5;
            this.tbLanguage.Text = "ENG";
            // 
            // labelPublicName
            // 
            this.labelPublicName.AutoSize = true;
            this.labelPublicName.Location = new System.Drawing.Point(411, 41);
            this.labelPublicName.Name = "labelPublicName";
            this.labelPublicName.Size = new System.Drawing.Size(67, 13);
            this.labelPublicName.TabIndex = 8;
            this.labelPublicName.Text = "PublicName:";
            // 
            // labelHost
            // 
            this.labelHost.AutoSize = true;
            this.labelHost.Location = new System.Drawing.Point(196, 12);
            this.labelHost.Name = "labelHost";
            this.labelHost.Size = new System.Drawing.Size(32, 13);
            this.labelHost.TabIndex = 10;
            this.labelHost.Text = "Host:";
            // 
            // tbHost
            // 
            this.tbHost.Location = new System.Drawing.Point(242, 9);
            this.tbHost.Name = "tbHost";
            this.tbHost.Size = new System.Drawing.Size(144, 20);
            this.tbHost.TabIndex = 9;
            this.tbHost.Text = "http://localhost:8126";
            // 
            // cbMode
            // 
            this.cbMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMode.FormattingEnabled = true;
            this.cbMode.Items.AddRange(new object[] {
            "query",
            "modify",
            "save"});
            this.cbMode.Location = new System.Drawing.Point(242, 60);
            this.cbMode.Name = "cbMode";
            this.cbMode.Size = new System.Drawing.Size(144, 21);
            this.cbMode.TabIndex = 11;
            // 
            // tbXmlFilename
            // 
            this.tbXmlFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbXmlFilename.Location = new System.Drawing.Point(76, 108);
            this.tbXmlFilename.Name = "tbXmlFilename";
            this.tbXmlFilename.Size = new System.Drawing.Size(515, 20);
            this.tbXmlFilename.TabIndex = 12;
            this.tbXmlFilename.Text = "C:\\Users\\frdepo\\OneDrive - Sage Software, Inc\\X3\\X3-57422-SOAP Web Services - del" +
    "eting lines on orders and quotes\\TEST1FROMD3.txt";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "XmlFile:";
            // 
            // cbPublicName
            // 
            this.cbPublicName.FormattingEnabled = true;
            this.cbPublicName.Items.AddRange(new object[] {
            "OAUS"});
            this.cbPublicName.Location = new System.Drawing.Point(492, 34);
            this.cbPublicName.Name = "cbPublicName";
            this.cbPublicName.Size = new System.Drawing.Size(144, 21);
            this.cbPublicName.TabIndex = 14;
            this.cbPublicName.Text = "OAUS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(143, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Operation mode:";
            // 
            // btBrowse
            // 
            this.btBrowse.Location = new System.Drawing.Point(597, 106);
            this.btBrowse.Name = "btBrowse";
            this.btBrowse.Size = new System.Drawing.Size(39, 23);
            this.btBrowse.TabIndex = 16;
            this.btBrowse.Text = "...";
            this.btBrowse.UseVisualStyleBackColor = true;
            this.btBrowse.Click += new System.EventHandler(this.btBrowse_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 422);
            this.Controls.Add(this.btBrowse);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbPublicName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbXmlFilename);
            this.Controls.Add(this.cbMode);
            this.Controls.Add(this.labelHost);
            this.Controls.Add(this.tbHost);
            this.Controls.Add(this.labelPublicName);
            this.Controls.Add(this.labelLanguage);
            this.Controls.Add(this.tbLanguage);
            this.Controls.Add(this.labelPoolAlias);
            this.Controls.Add(this.tbLogs);
            this.Controls.Add(this.tbPoolAlias);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Main";
            this.Text = "X3 WebService";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPoolAlias;
        private System.Windows.Forms.TextBox tbLogs;
        private System.Windows.Forms.Label labelPoolAlias;
        private System.Windows.Forms.Label labelLanguage;
        private System.Windows.Forms.TextBox tbLanguage;
        private System.Windows.Forms.Label labelPublicName;
        private System.Windows.Forms.Label labelHost;
        private System.Windows.Forms.TextBox tbHost;
        private System.Windows.Forms.ComboBox cbMode;
        private System.Windows.Forms.TextBox tbXmlFilename;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbPublicName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btBrowse;
    }
}