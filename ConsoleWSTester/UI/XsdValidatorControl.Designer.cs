namespace ConsoleTester.UI
{
    partial class XsdValidatorControl
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
            this.labelParameters = new System.Windows.Forms.Label();
            this.labelLogin = new System.Windows.Forms.Label();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.cbPath = new System.Windows.Forms.ComboBox();
            this.labelPath = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panelParameters = new System.Windows.Forms.Panel();
            this.btDelete = new System.Windows.Forms.Button();
            this.btAddParam = new System.Windows.Forms.Button();
            this.dgKeyValue = new System.Windows.Forms.DataGridView();
            this.ColumnKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageCredentials = new System.Windows.Forms.TabPage();
            this.btBrowse = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panelParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgKeyValue)).BeginInit();
            this.tabPageCredentials.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(0, 291);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(664, 38);
            this.button1.TabIndex = 0;
            this.button1.Text = "Validate XML";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.launch_Click);
            // 
            // labelParameters
            // 
            this.labelParameters.AutoSize = true;
            this.labelParameters.Location = new System.Drawing.Point(53, 108);
            this.labelParameters.Name = "labelParameters";
            this.labelParameters.Size = new System.Drawing.Size(55, 13);
            this.labelParameters.TabIndex = 21;
            this.labelParameters.Text = "XSD input";
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
            // cbPath
            // 
            this.cbPath.FormattingEnabled = true;
            this.cbPath.Items.AddRange(new object[] {
            "/soap-generic/syracuse/collaboration/syracuse/CAdxWebServiceXmlCC",
            "/adxwsvc/services/CAdxWebServiceXmlCC"});
            this.cbPath.Location = new System.Drawing.Point(124, 37);
            this.cbPath.Name = "cbPath";
            this.cbPath.Size = new System.Drawing.Size(509, 21);
            this.cbPath.TabIndex = 33;
            this.cbPath.Text = "C:\\Users\\frdepo\\OneDrive - Sage Software, Inc\\X3\\X3-CHORUS\\00-FSO1100-P24.xml";
            // 
            // labelPath
            // 
            this.labelPath.AutoSize = true;
            this.labelPath.Location = new System.Drawing.Point(59, 40);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(59, 13);
            this.labelPath.TabIndex = 32;
            this.labelPath.Text = "XML Input:";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPageCredentials);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(661, 274);
            this.tabControl1.TabIndex = 37;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.panelParameters);
            this.tabPage1.Controls.Add(this.labelParameters);
            this.tabPage1.Controls.Add(this.cbPath);
            this.tabPage1.Controls.Add(this.labelPath);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(653, 248);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Settings";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panelParameters
            // 
            this.panelParameters.Controls.Add(this.btBrowse);
            this.panelParameters.Controls.Add(this.btDelete);
            this.panelParameters.Controls.Add(this.btAddParam);
            this.panelParameters.Controls.Add(this.dgKeyValue);
            this.panelParameters.Location = new System.Drawing.Point(124, 108);
            this.panelParameters.Name = "panelParameters";
            this.panelParameters.Size = new System.Drawing.Size(509, 121);
            this.panelParameters.TabIndex = 34;
            // 
            // btDelete
            // 
            this.btDelete.Location = new System.Drawing.Point(404, 32);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(25, 23);
            this.btDelete.TabIndex = 41;
            this.btDelete.Text = "-";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // btAddParam
            // 
            this.btAddParam.Location = new System.Drawing.Point(404, 3);
            this.btAddParam.Name = "btAddParam";
            this.btAddParam.Size = new System.Drawing.Size(25, 23);
            this.btAddParam.TabIndex = 40;
            this.btAddParam.Text = "+";
            this.btAddParam.UseVisualStyleBackColor = true;
            this.btAddParam.Click += new System.EventHandler(this.btAddParam_Click);
            // 
            // dgKeyValue
            // 
            this.dgKeyValue.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnKey,
            this.ColumnValue});
            this.dgKeyValue.Location = new System.Drawing.Point(3, 3);
            this.dgKeyValue.Name = "dgKeyValue";
            this.dgKeyValue.Size = new System.Drawing.Size(380, 115);
            this.dgKeyValue.TabIndex = 39;
            // 
            // ColumnKey
            // 
            this.ColumnKey.DataPropertyName = "key";
            this.ColumnKey.HeaderText = "Key";
            this.ColumnKey.Name = "ColumnKey";
            this.ColumnKey.Width = 160;
            // 
            // ColumnValue
            // 
            this.ColumnValue.DataPropertyName = "value";
            this.ColumnValue.HeaderText = "Value";
            this.ColumnValue.Name = "ColumnValue";
            this.ColumnValue.Width = 160;
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
            this.tabPageCredentials.Size = new System.Drawing.Size(653, 212);
            this.tabPageCredentials.TabIndex = 1;
            this.tabPageCredentials.Text = "Credentials";
            this.tabPageCredentials.UseVisualStyleBackColor = true;
            // 
            // btBrowse
            // 
            this.btBrowse.Location = new System.Drawing.Point(404, 75);
            this.btBrowse.Name = "btBrowse";
            this.btBrowse.Size = new System.Drawing.Size(92, 23);
            this.btBrowse.TabIndex = 42;
            this.btBrowse.Text = "Choose file(s)";
            this.btBrowse.UseVisualStyleBackColor = true;
            this.btBrowse.Click += new System.EventHandler(this.btBrowse_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(528, 64);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 23);
            this.button2.TabIndex = 43;
            this.button2.Text = "Choose file";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // XsdValidatorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 342);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button1);
            this.Name = "XsdValidatorControl";
            this.Load += new System.EventHandler(this.Workspace_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panelParameters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgKeyValue)).EndInit();
            this.tabPageCredentials.ResumeLayout(false);
            this.tabPageCredentials.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelParameters;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.ComboBox cbPath;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPageCredentials;
        private System.Windows.Forms.DataGridView dgKeyValue;
        private System.Windows.Forms.Button btAddParam;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnValue;
        private System.Windows.Forms.Panel panelParameters;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Button btBrowse;
        private System.Windows.Forms.Button button2;
    }
}