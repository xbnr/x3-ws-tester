namespace ConsoleWSTester
{
    partial class Workspace
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
            this.labelPublicName = new System.Windows.Forms.Label();
            this.labelHost = new System.Windows.Forms.Label();
            this.tbHost = new System.Windows.Forms.TextBox();
            this.cbMode = new System.Windows.Forms.ComboBox();
            this.tbXmlFilename = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbPublicName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btBrowseXmlFile = new System.Windows.Forms.Button();
            this.cbLanguage = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbRequestConfiguration = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbKey = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbValue = new System.Windows.Forms.TextBox();
            this.panelXmlFile = new System.Windows.Forms.Panel();
            this.cbListSize = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.labelLogin = new System.Windows.Forms.Label();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.llClearConsole = new System.Windows.Forms.LinkLabel();
            this.cbPath = new System.Windows.Forms.ComboBox();
            this.labelPath = new System.Windows.Forms.Label();
            this.panelXmlFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(12, 485);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(651, 38);
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
            this.tbPoolAlias.Location = new System.Drawing.Point(120, 73);
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
            this.tbLogs.Location = new System.Drawing.Point(12, 258);
            this.tbLogs.Multiline = true;
            this.tbLogs.Name = "tbLogs";
            this.tbLogs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbLogs.Size = new System.Drawing.Size(651, 207);
            this.tbLogs.TabIndex = 3;
            // 
            // labelPoolAlias
            // 
            this.labelPoolAlias.AutoSize = true;
            this.labelPoolAlias.Location = new System.Drawing.Point(50, 76);
            this.labelPoolAlias.Name = "labelPoolAlias";
            this.labelPoolAlias.Size = new System.Drawing.Size(56, 13);
            this.labelPoolAlias.TabIndex = 4;
            this.labelPoolAlias.Text = "Pool Alias:";
            // 
            // labelLanguage
            // 
            this.labelLanguage.AutoSize = true;
            this.labelLanguage.Location = new System.Drawing.Point(312, 32);
            this.labelLanguage.Name = "labelLanguage";
            this.labelLanguage.Size = new System.Drawing.Size(58, 13);
            this.labelLanguage.TabIndex = 6;
            this.labelLanguage.Text = "Language:";
            // 
            // labelPublicName
            // 
            this.labelPublicName.AutoSize = true;
            this.labelPublicName.Location = new System.Drawing.Point(303, 54);
            this.labelPublicName.Name = "labelPublicName";
            this.labelPublicName.Size = new System.Drawing.Size(67, 13);
            this.labelPublicName.TabIndex = 8;
            this.labelPublicName.Text = "PublicName:";
            // 
            // labelHost
            // 
            this.labelHost.AutoSize = true;
            this.labelHost.Location = new System.Drawing.Point(74, 29);
            this.labelHost.Name = "labelHost";
            this.labelHost.Size = new System.Drawing.Size(32, 13);
            this.labelHost.TabIndex = 10;
            this.labelHost.Text = "Host:";
            // 
            // tbHost
            // 
            this.tbHost.Location = new System.Drawing.Point(120, 26);
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
            "read",
            "modify",
            "save"});
            this.cbMode.Location = new System.Drawing.Point(120, 99);
            this.cbMode.Name = "cbMode";
            this.cbMode.Size = new System.Drawing.Size(144, 21);
            this.cbMode.TabIndex = 11;
            // 
            // tbXmlFilename
            // 
            this.tbXmlFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbXmlFilename.Location = new System.Drawing.Point(61, 7);
            this.tbXmlFilename.Name = "tbXmlFilename";
            this.tbXmlFilename.Size = new System.Drawing.Size(556, 20);
            this.tbXmlFilename.TabIndex = 12;
            this.tbXmlFilename.Text = "C:\\Users\\frdepo\\OneDrive - Sage Software, Inc\\X3\\X3-57422-SOAP Web Services - del" +
    "eting lines on orders and quotes\\TEST1FROMD3.txt";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 10);
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
            this.cbPublicName.Location = new System.Drawing.Point(384, 51);
            this.cbPublicName.Name = "cbPublicName";
            this.cbPublicName.Size = new System.Drawing.Size(144, 21);
            this.cbPublicName.TabIndex = 14;
            this.cbPublicName.Text = "OAUS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Operation mode:";
            // 
            // btBrowseXmlFile
            // 
            this.btBrowseXmlFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btBrowseXmlFile.Location = new System.Drawing.Point(625, 7);
            this.btBrowseXmlFile.Name = "btBrowseXmlFile";
            this.btBrowseXmlFile.Size = new System.Drawing.Size(39, 23);
            this.btBrowseXmlFile.TabIndex = 16;
            this.btBrowseXmlFile.Text = "...";
            this.btBrowseXmlFile.UseVisualStyleBackColor = true;
            this.btBrowseXmlFile.Click += new System.EventHandler(this.btBrowse_Click);
            // 
            // cbLanguage
            // 
            this.cbLanguage.FormattingEnabled = true;
            this.cbLanguage.Items.AddRange(new object[] {
            "ENG",
            "FRA"});
            this.cbLanguage.Location = new System.Drawing.Point(384, 29);
            this.cbLanguage.Name = "cbLanguage";
            this.cbLanguage.Size = new System.Drawing.Size(144, 21);
            this.cbLanguage.TabIndex = 17;
            this.cbLanguage.Text = "ENG";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Request configuration:";
            // 
            // tbRequestConfiguration
            // 
            this.tbRequestConfiguration.Location = new System.Drawing.Point(120, 145);
            this.tbRequestConfiguration.Name = "tbRequestConfiguration";
            this.tbRequestConfiguration.Size = new System.Drawing.Size(408, 20);
            this.tbRequestConfiguration.TabIndex = 18;
            this.tbRequestConfiguration.Text = "adxwss.optreturn=XML&adxwss.beautify=true";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(89, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Key";
            // 
            // tbKey
            // 
            this.tbKey.Location = new System.Drawing.Point(120, 174);
            this.tbKey.Name = "tbKey";
            this.tbKey.Size = new System.Drawing.Size(144, 20);
            this.tbKey.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(345, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Value";
            // 
            // tbValue
            // 
            this.tbValue.Location = new System.Drawing.Point(384, 174);
            this.tbValue.Name = "tbValue";
            this.tbValue.Size = new System.Drawing.Size(144, 20);
            this.tbValue.TabIndex = 22;
            // 
            // panelXmlFile
            // 
            this.panelXmlFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelXmlFile.Controls.Add(this.btBrowseXmlFile);
            this.panelXmlFile.Controls.Add(this.tbXmlFilename);
            this.panelXmlFile.Controls.Add(this.label2);
            this.panelXmlFile.Location = new System.Drawing.Point(-1, 212);
            this.panelXmlFile.Name = "panelXmlFile";
            this.panelXmlFile.Size = new System.Drawing.Size(676, 33);
            this.panelXmlFile.TabIndex = 24;
            // 
            // cbListSize
            // 
            this.cbListSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbListSize.FormattingEnabled = true;
            this.cbListSize.Location = new System.Drawing.Point(384, 74);
            this.cbListSize.Name = "cbListSize";
            this.cbListSize.Size = new System.Drawing.Size(144, 21);
            this.cbListSize.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(323, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "List size:";
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Location = new System.Drawing.Point(549, 14);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(36, 13);
            this.labelLogin.TabIndex = 28;
            this.labelLogin.Text = "Login:";
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(552, 32);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(111, 20);
            this.tbLogin.TabIndex = 27;
            this.tbLogin.Text = "admin";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(549, 62);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(56, 13);
            this.labelPassword.TabIndex = 30;
            this.labelPassword.Text = "Password:";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(552, 78);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(108, 20);
            this.tbPassword.TabIndex = 29;
            this.tbPassword.Text = "admin";
            // 
            // llClearConsole
            // 
            this.llClearConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.llClearConsole.AutoSize = true;
            this.llClearConsole.Location = new System.Drawing.Point(15, 466);
            this.llClearConsole.Name = "llClearConsole";
            this.llClearConsole.Size = new System.Drawing.Size(71, 13);
            this.llClearConsole.TabIndex = 31;
            this.llClearConsole.TabStop = true;
            this.llClearConsole.Text = "Clear console";
            this.llClearConsole.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llClearConsole_LinkClicked);
            // 
            // cbPath
            // 
            this.cbPath.FormattingEnabled = true;
            this.cbPath.Items.AddRange(new object[] {
            "/soap-generic/syracuse/collaboration/syracuse/CAdxWebServiceXmlCC",
            "/adxwsvc/services/CAdxWebServiceXmlCC"});
            this.cbPath.Location = new System.Drawing.Point(120, 51);
            this.cbPath.Name = "cbPath";
            this.cbPath.Size = new System.Drawing.Size(144, 21);
            this.cbPath.TabIndex = 33;
            this.cbPath.Text = "/soap-generic/syracuse/collaboration/syracuse/CAdxWebServiceXmlCC";
            // 
            // labelPath
            // 
            this.labelPath.AutoSize = true;
            this.labelPath.Location = new System.Drawing.Point(39, 54);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(32, 13);
            this.labelPath.TabIndex = 32;
            this.labelPath.Text = "Path:";
            // 
            // Workspace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbPath);
            this.Controls.Add(this.labelPath);
            this.Controls.Add(this.llClearConsole);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.labelLogin);
            this.Controls.Add(this.tbLogin);
            this.Controls.Add(this.cbListSize);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panelXmlFile);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbValue);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbKey);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbRequestConfiguration);
            this.Controls.Add(this.cbLanguage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbPublicName);
            this.Controls.Add(this.cbMode);
            this.Controls.Add(this.labelHost);
            this.Controls.Add(this.tbHost);
            this.Controls.Add(this.labelPublicName);
            this.Controls.Add(this.labelLanguage);
            this.Controls.Add(this.labelPoolAlias);
            this.Controls.Add(this.tbLogs);
            this.Controls.Add(this.tbPoolAlias);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Workspace";
            this.Size = new System.Drawing.Size(675, 531);
            this.Load += new System.EventHandler(this.Workspace_Load);
            this.panelXmlFile.ResumeLayout(false);
            this.panelXmlFile.PerformLayout();
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
        private System.Windows.Forms.Label labelPublicName;
        private System.Windows.Forms.Label labelHost;
        private System.Windows.Forms.TextBox tbHost;
        private System.Windows.Forms.ComboBox cbMode;
        private System.Windows.Forms.TextBox tbXmlFilename;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbPublicName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btBrowseXmlFile;
        private System.Windows.Forms.ComboBox cbLanguage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbRequestConfiguration;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbKey;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbValue;
        private System.Windows.Forms.Panel panelXmlFile;
        private System.Windows.Forms.ComboBox cbListSize;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.LinkLabel llClearConsole;
        private System.Windows.Forms.ComboBox cbPath;
        private System.Windows.Forms.Label labelPath;
    }
}