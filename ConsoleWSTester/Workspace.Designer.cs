namespace ConsoleTester
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
            this.label8 = new System.Windows.Forms.Label();
            this.tbBlocKey = new System.Windows.Forms.TextBox();
            this.panelDeleteLines = new System.Windows.Forms.Panel();
            this.tbLineKeys = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPageCredentials = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbXmlObject = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.panelXmlFile.SuspendLayout();
            this.panelDeleteLines.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPageCredentials.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(0, 503);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(663, 38);
            this.button1.TabIndex = 0;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.launch_Click);
            // 
            // tbPoolAlias
            // 
            this.tbPoolAlias.Location = new System.Drawing.Point(124, 59);
            this.tbPoolAlias.Name = "tbPoolAlias";
            this.tbPoolAlias.Size = new System.Drawing.Size(211, 20);
            this.tbPoolAlias.TabIndex = 2;
            this.tbPoolAlias.Text = "MYPOOL1";
            // 
            // tbLogs
            // 
            this.tbLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLogs.Location = new System.Drawing.Point(0, 287);
            this.tbLogs.Multiline = true;
            this.tbLogs.Name = "tbLogs";
            this.tbLogs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbLogs.Size = new System.Drawing.Size(663, 196);
            this.tbLogs.TabIndex = 3;
            // 
            // labelPoolAlias
            // 
            this.labelPoolAlias.AutoSize = true;
            this.labelPoolAlias.Location = new System.Drawing.Point(57, 62);
            this.labelPoolAlias.Name = "labelPoolAlias";
            this.labelPoolAlias.Size = new System.Drawing.Size(56, 13);
            this.labelPoolAlias.TabIndex = 4;
            this.labelPoolAlias.Text = "Pool Alias:";
            // 
            // labelLanguage
            // 
            this.labelLanguage.AutoSize = true;
            this.labelLanguage.Location = new System.Drawing.Point(377, 14);
            this.labelLanguage.Name = "labelLanguage";
            this.labelLanguage.Size = new System.Drawing.Size(58, 13);
            this.labelLanguage.TabIndex = 6;
            this.labelLanguage.Text = "Language:";
            // 
            // labelPublicName
            // 
            this.labelPublicName.AutoSize = true;
            this.labelPublicName.Location = new System.Drawing.Point(368, 36);
            this.labelPublicName.Name = "labelPublicName";
            this.labelPublicName.Size = new System.Drawing.Size(67, 13);
            this.labelPublicName.TabIndex = 8;
            this.labelPublicName.Text = "PublicName:";
            // 
            // labelHost
            // 
            this.labelHost.AutoSize = true;
            this.labelHost.Location = new System.Drawing.Point(81, 15);
            this.labelHost.Name = "labelHost";
            this.labelHost.Size = new System.Drawing.Size(32, 13);
            this.labelHost.TabIndex = 10;
            this.labelHost.Text = "Host:";
            // 
            // tbHost
            // 
            this.tbHost.Location = new System.Drawing.Point(124, 12);
            this.tbHost.Name = "tbHost";
            this.tbHost.Size = new System.Drawing.Size(211, 20);
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
            this.cbMode.Location = new System.Drawing.Point(124, 85);
            this.cbMode.Name = "cbMode";
            this.cbMode.Size = new System.Drawing.Size(211, 21);
            this.cbMode.TabIndex = 11;
            this.cbMode.SelectedIndexChanged += new System.EventHandler(this.cbMode_SelectedIndexChanged);
            // 
            // tbXmlFilename
            // 
            this.tbXmlFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbXmlFilename.Location = new System.Drawing.Point(61, 7);
            this.tbXmlFilename.Name = "tbXmlFilename";
            this.tbXmlFilename.Size = new System.Drawing.Size(537, 20);
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
            this.cbPublicName.Location = new System.Drawing.Point(449, 33);
            this.cbPublicName.Name = "cbPublicName";
            this.cbPublicName.Size = new System.Drawing.Size(184, 21);
            this.cbPublicName.TabIndex = 14;
            this.cbPublicName.Text = "OAUS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Operation mode:";
            // 
            // btBrowseXmlFile
            // 
            this.btBrowseXmlFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btBrowseXmlFile.Location = new System.Drawing.Point(604, 7);
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
            this.cbLanguage.Location = new System.Drawing.Point(449, 11);
            this.cbLanguage.Name = "cbLanguage";
            this.cbLanguage.Size = new System.Drawing.Size(184, 21);
            this.cbLanguage.TabIndex = 17;
            this.cbLanguage.Text = "ENG";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Request configuration:";
            // 
            // tbRequestConfiguration
            // 
            this.tbRequestConfiguration.Location = new System.Drawing.Point(124, 126);
            this.tbRequestConfiguration.Name = "tbRequestConfiguration";
            this.tbRequestConfiguration.Size = new System.Drawing.Size(509, 20);
            this.tbRequestConfiguration.TabIndex = 18;
            this.tbRequestConfiguration.Text = "adxwss.optreturn=XML&adxwss.beautify=true";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Key";
            // 
            // tbKey
            // 
            this.tbKey.Location = new System.Drawing.Point(62, 7);
            this.tbKey.Name = "tbKey";
            this.tbKey.Size = new System.Drawing.Size(144, 20);
            this.tbKey.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(257, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Value";
            // 
            // tbValue
            // 
            this.tbValue.Location = new System.Drawing.Point(300, 7);
            this.tbValue.Name = "tbValue";
            this.tbValue.Size = new System.Drawing.Size(141, 20);
            this.tbValue.TabIndex = 22;
            // 
            // panelXmlFile
            // 
            this.panelXmlFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelXmlFile.Controls.Add(this.btBrowseXmlFile);
            this.panelXmlFile.Controls.Add(this.tbXmlFilename);
            this.panelXmlFile.Controls.Add(this.label2);
            this.panelXmlFile.Location = new System.Drawing.Point(0, 6);
            this.panelXmlFile.Name = "panelXmlFile";
            this.panelXmlFile.Size = new System.Drawing.Size(646, 33);
            this.panelXmlFile.TabIndex = 24;
            // 
            // cbListSize
            // 
            this.cbListSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbListSize.FormattingEnabled = true;
            this.cbListSize.Location = new System.Drawing.Point(449, 59);
            this.cbListSize.Name = "cbListSize";
            this.cbListSize.Size = new System.Drawing.Size(184, 21);
            this.cbListSize.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(388, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "List size:";
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Location = new System.Drawing.Point(59, 40);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(36, 13);
            this.labelLogin.TabIndex = 28;
            this.labelLogin.Text = "Login:";
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(122, 37);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(111, 20);
            this.tbLogin.TabIndex = 27;
            this.tbLogin.Text = "admin";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(39, 81);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(56, 13);
            this.labelPassword.TabIndex = 30;
            this.labelPassword.Text = "Password:";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(125, 78);
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
            this.llClearConsole.Location = new System.Drawing.Point(15, 484);
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
            this.cbPath.Location = new System.Drawing.Point(124, 37);
            this.cbPath.Name = "cbPath";
            this.cbPath.Size = new System.Drawing.Size(211, 21);
            this.cbPath.TabIndex = 33;
            this.cbPath.Text = "/soap-generic/syracuse/collaboration/syracuse/CAdxWebServiceXmlCC";
            // 
            // labelPath
            // 
            this.labelPath.AutoSize = true;
            this.labelPath.Location = new System.Drawing.Point(81, 40);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(32, 13);
            this.labelPath.TabIndex = 32;
            this.labelPath.Text = "Path:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 35;
            this.label8.Text = "BlocKey";
            // 
            // tbBlocKey
            // 
            this.tbBlocKey.Location = new System.Drawing.Point(61, 6);
            this.tbBlocKey.Name = "tbBlocKey";
            this.tbBlocKey.Size = new System.Drawing.Size(145, 20);
            this.tbBlocKey.TabIndex = 34;
            // 
            // panelDeleteLines
            // 
            this.panelDeleteLines.Controls.Add(this.tbLineKeys);
            this.panelDeleteLines.Controls.Add(this.label9);
            this.panelDeleteLines.Controls.Add(this.tbBlocKey);
            this.panelDeleteLines.Controls.Add(this.label8);
            this.panelDeleteLines.Location = new System.Drawing.Point(3, 28);
            this.panelDeleteLines.Name = "panelDeleteLines";
            this.panelDeleteLines.Size = new System.Drawing.Size(649, 29);
            this.panelDeleteLines.TabIndex = 36;
            // 
            // tbLineKeys
            // 
            this.tbLineKeys.Location = new System.Drawing.Point(300, 4);
            this.tbLineKeys.Name = "tbLineKeys";
            this.tbLineKeys.Size = new System.Drawing.Size(141, 20);
            this.tbLineKeys.TabIndex = 36;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(248, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 37;
            this.label9.Text = "LineKeys";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPageCredentials);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(660, 265);
            this.tabControl1.TabIndex = 37;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.labelHost);
            this.tabPage1.Controls.Add(this.tbPoolAlias);
            this.tabPage1.Controls.Add(this.cbPath);
            this.tabPage1.Controls.Add(this.labelPoolAlias);
            this.tabPage1.Controls.Add(this.labelPath);
            this.tabPage1.Controls.Add(this.labelLanguage);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.labelPublicName);
            this.tabPage1.Controls.Add(this.tbRequestConfiguration);
            this.tabPage1.Controls.Add(this.cbListSize);
            this.tabPage1.Controls.Add(this.tbHost);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.cbMode);
            this.tabPage1.Controls.Add(this.cbPublicName);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.cbLanguage);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(652, 239);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Settings";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPageCredentials
            // 
            this.tabPageCredentials.Controls.Add(this.labelLogin);
            this.tabPageCredentials.Controls.Add(this.tbLogin);
            this.tabPageCredentials.Controls.Add(this.tbPassword);
            this.tabPageCredentials.Controls.Add(this.labelPassword);
            this.tabPageCredentials.Location = new System.Drawing.Point(4, 22);
            this.tabPageCredentials.Name = "tabPageCredentials";
            this.tabPageCredentials.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCredentials.Size = new System.Drawing.Size(652, 239);
            this.tabPageCredentials.TabIndex = 1;
            this.tabPageCredentials.Text = "Credentials";
            this.tabPageCredentials.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tbXmlObject);
            this.tabPage3.Controls.Add(this.panelXmlFile);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(652, 239);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Data: XmlObject";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbKey);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.tbValue);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(3, 80);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(653, 34);
            this.panel1.TabIndex = 37;
            // 
            // tbXmlObject
            // 
            this.tbXmlObject.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbXmlObject.Location = new System.Drawing.Point(2, 59);
            this.tbXmlObject.Multiline = true;
            this.tbXmlObject.Name = "tbXmlObject";
            this.tbXmlObject.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbXmlObject.Size = new System.Drawing.Size(641, 174);
            this.tbXmlObject.TabIndex = 38;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.panel1);
            this.tabPage4.Controls.Add(this.panelDeleteLines);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(652, 239);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Params";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // Workspace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.llClearConsole);
            this.Controls.Add(this.tbLogs);
            this.Controls.Add(this.button1);
            this.Name = "Workspace";
            this.Size = new System.Drawing.Size(675, 549);
            this.Load += new System.EventHandler(this.Workspace_Load);
            this.panelXmlFile.ResumeLayout(false);
            this.panelXmlFile.PerformLayout();
            this.panelDeleteLines.ResumeLayout(false);
            this.panelDeleteLines.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPageCredentials.ResumeLayout(false);
            this.tabPageCredentials.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
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
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbBlocKey;
        private System.Windows.Forms.Panel panelDeleteLines;
        private System.Windows.Forms.TextBox tbLineKeys;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPageCredentials;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbXmlObject;
        private System.Windows.Forms.TabPage tabPage4;
    }
}