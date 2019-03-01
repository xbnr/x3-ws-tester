namespace ConsoleTester.Plugins.PrintServer
{
    partial class PrintServerControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btValidate = new System.Windows.Forms.Button();
            this.tabPagePrintServer = new System.Windows.Forms.TabPage();
            this.btGenerateCommand = new System.Windows.Forms.Button();
            this.btDetectInstall = new System.Windows.Forms.Button();
            this.panelParameters = new System.Windows.Forms.Panel();
            this.btRemoveSetting = new System.Windows.Forms.Button();
            this.btAddSetting = new System.Windows.Forms.Button();
            this.dgSettings = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeSelectedXsdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbExportFilename = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.linkOpenExportDirectory = new System.Windows.Forms.LinkLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.lbOdbcDatasource = new System.Windows.Forms.Label();
            this.lbLogin = new System.Windows.Forms.Label();
            this.lbPassword = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.cbDatabaseType = new System.Windows.Forms.ComboBox();
            this.cbOdbcDatasource = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.labelSettings = new System.Windows.Forms.Label();
            this.cbActions = new System.Windows.Forms.ComboBox();
            this.labelActions = new System.Windows.Forms.Label();
            this.cbReportName = new System.Windows.Forms.ComboBox();
            this.labelReportFile = new System.Windows.Forms.Label();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbExportDirectory = new System.Windows.Forms.ComboBox();
            this.btBrowseRpt = new System.Windows.Forms.Button();
            this.labelExportDirectory = new System.Windows.Forms.Label();
            this.btDelete = new System.Windows.Forms.Button();
            this.btAddParam = new System.Windows.Forms.Button();
            this.dgKeyValue = new System.Windows.Forms.DataGridView();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbPath = new System.Windows.Forms.ComboBox();
            this.labelPath = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageOptions = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbVersion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPagePrintServer.SuspendLayout();
            this.panelParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSettings)).BeginInit();
            this.gridContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgKeyValue)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPageOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // btValidate
            // 
            this.btValidate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btValidate.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btValidate.Location = new System.Drawing.Point(435, 489);
            this.btValidate.Name = "btValidate";
            this.btValidate.Size = new System.Drawing.Size(430, 38);
            this.btValidate.TabIndex = 0;
            this.btValidate.Text = "Launch print";
            this.btValidate.UseVisualStyleBackColor = false;
            this.btValidate.Click += new System.EventHandler(this.launch_Click);
            // 
            // tabPagePrintServer
            // 
            this.tabPagePrintServer.Controls.Add(this.btGenerateCommand);
            this.tabPagePrintServer.Controls.Add(this.btDetectInstall);
            this.tabPagePrintServer.Controls.Add(this.panelParameters);
            this.tabPagePrintServer.Controls.Add(this.btValidate);
            this.tabPagePrintServer.Controls.Add(this.cbPath);
            this.tabPagePrintServer.Controls.Add(this.labelPath);
            this.tabPagePrintServer.Location = new System.Drawing.Point(4, 22);
            this.tabPagePrintServer.Name = "tabPagePrintServer";
            this.tabPagePrintServer.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePrintServer.Size = new System.Drawing.Size(873, 541);
            this.tabPagePrintServer.TabIndex = 0;
            this.tabPagePrintServer.Text = "PrintServer";
            this.tabPagePrintServer.UseVisualStyleBackColor = true;
            // 
            // btGenerateCommand
            // 
            this.btGenerateCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btGenerateCommand.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btGenerateCommand.Location = new System.Drawing.Point(6, 489);
            this.btGenerateCommand.Name = "btGenerateCommand";
            this.btGenerateCommand.Size = new System.Drawing.Size(407, 38);
            this.btGenerateCommand.TabIndex = 18;
            this.btGenerateCommand.Text = "Generate command";
            this.btGenerateCommand.UseVisualStyleBackColor = false;
            this.btGenerateCommand.Click += new System.EventHandler(this.btGenerateCommand_Click);
            // 
            // btDetectInstall
            // 
            this.btDetectInstall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btDetectInstall.Location = new System.Drawing.Point(742, 19);
            this.btDetectInstall.Name = "btDetectInstall";
            this.btDetectInstall.Size = new System.Drawing.Size(123, 23);
            this.btDetectInstall.TabIndex = 17;
            this.btDetectInstall.Text = "Detect install dir";
            this.btDetectInstall.UseVisualStyleBackColor = true;
            this.btDetectInstall.Click += new System.EventHandler(this.btDetectInstall_Click);
            // 
            // panelParameters
            // 
            this.panelParameters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelParameters.Controls.Add(this.btRemoveSetting);
            this.panelParameters.Controls.Add(this.btAddSetting);
            this.panelParameters.Controls.Add(this.dgSettings);
            this.panelParameters.Controls.Add(this.tbExportFilename);
            this.panelParameters.Controls.Add(this.label7);
            this.panelParameters.Controls.Add(this.linkOpenExportDirectory);
            this.panelParameters.Controls.Add(this.label6);
            this.panelParameters.Controls.Add(this.lbOdbcDatasource);
            this.panelParameters.Controls.Add(this.lbLogin);
            this.panelParameters.Controls.Add(this.lbPassword);
            this.panelParameters.Controls.Add(this.tbPassword);
            this.panelParameters.Controls.Add(this.cbDatabaseType);
            this.panelParameters.Controls.Add(this.cbOdbcDatasource);
            this.panelParameters.Controls.Add(this.label8);
            this.panelParameters.Controls.Add(this.labelSettings);
            this.panelParameters.Controls.Add(this.cbActions);
            this.panelParameters.Controls.Add(this.labelActions);
            this.panelParameters.Controls.Add(this.cbReportName);
            this.panelParameters.Controls.Add(this.labelReportFile);
            this.panelParameters.Controls.Add(this.tbLogin);
            this.panelParameters.Controls.Add(this.label4);
            this.panelParameters.Controls.Add(this.cbExportDirectory);
            this.panelParameters.Controls.Add(this.btBrowseRpt);
            this.panelParameters.Controls.Add(this.labelExportDirectory);
            this.panelParameters.Controls.Add(this.btDelete);
            this.panelParameters.Controls.Add(this.btAddParam);
            this.panelParameters.Controls.Add(this.dgKeyValue);
            this.panelParameters.Location = new System.Drawing.Point(6, 57);
            this.panelParameters.Name = "panelParameters";
            this.panelParameters.Size = new System.Drawing.Size(867, 426);
            this.panelParameters.TabIndex = 2;
            // 
            // btRemoveSetting
            // 
            this.btRemoveSetting.Location = new System.Drawing.Point(413, 356);
            this.btRemoveSetting.Name = "btRemoveSetting";
            this.btRemoveSetting.Size = new System.Drawing.Size(25, 23);
            this.btRemoveSetting.TabIndex = 30;
            this.btRemoveSetting.Text = "-";
            this.btRemoveSetting.UseVisualStyleBackColor = true;
            this.btRemoveSetting.Click += new System.EventHandler(this.btRemoveSetting_Click);
            // 
            // btAddSetting
            // 
            this.btAddSetting.Location = new System.Drawing.Point(413, 327);
            this.btAddSetting.Name = "btAddSetting";
            this.btAddSetting.Size = new System.Drawing.Size(25, 23);
            this.btAddSetting.TabIndex = 29;
            this.btAddSetting.Text = "+";
            this.btAddSetting.UseVisualStyleBackColor = true;
            this.btAddSetting.Click += new System.EventHandler(this.btAddSetting_Click);
            // 
            // dgSettings
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgSettings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgSettings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dgSettings.ContextMenuStrip = this.gridContextMenuStrip;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgSettings.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgSettings.Location = new System.Drawing.Point(113, 168);
            this.dgSettings.Name = "dgSettings";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgSettings.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgSettings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgSettings.Size = new System.Drawing.Size(294, 245);
            this.dgSettings.TabIndex = 28;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn1.HeaderText = "Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 120;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Value";
            this.dataGridViewTextBoxColumn2.HeaderText = "Value";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // gridContextMenuStrip
            // 
            this.gridContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeSelectedXsdToolStripMenuItem,
            this.copyPathToolStripMenuItem});
            this.gridContextMenuStrip.Name = "gridContextMenuStrip";
            this.gridContextMenuStrip.Size = new System.Drawing.Size(186, 48);
            // 
            // removeSelectedXsdToolStripMenuItem
            // 
            this.removeSelectedXsdToolStripMenuItem.Name = "removeSelectedXsdToolStripMenuItem";
            this.removeSelectedXsdToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.removeSelectedXsdToolStripMenuItem.Text = "Remove selected Xsd";
            this.removeSelectedXsdToolStripMenuItem.Click += new System.EventHandler(this.removeSelectedXsdToolStripMenuItem_Click);
            // 
            // copyPathToolStripMenuItem
            // 
            this.copyPathToolStripMenuItem.Name = "copyPathToolStripMenuItem";
            this.copyPathToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.copyPathToolStripMenuItem.Text = "Copy path";
            this.copyPathToolStripMenuItem.Click += new System.EventHandler(this.copyPathToolStripMenuItem_Click);
            // 
            // tbExportFilename
            // 
            this.tbExportFilename.Location = new System.Drawing.Point(540, 113);
            this.tbExportFilename.Name = "tbExportFilename";
            this.tbExportFilename.PasswordChar = '*';
            this.tbExportFilename.Size = new System.Drawing.Size(190, 20);
            this.tbExportFilename.TabIndex = 27;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(454, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "Export filename :";
            // 
            // linkOpenExportDirectory
            // 
            this.linkOpenExportDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkOpenExportDirectory.AutoSize = true;
            this.linkOpenExportDirectory.Location = new System.Drawing.Point(736, 89);
            this.linkOpenExportDirectory.Name = "linkOpenExportDirectory";
            this.linkOpenExportDirectory.Size = new System.Drawing.Size(76, 13);
            this.linkOpenExportDirectory.TabIndex = 25;
            this.linkOpenExportDirectory.TabStop = true;
            this.linkOpenExportDirectory.Text = "Open directory";
            this.linkOpenExportDirectory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkOpenExportDirectory_LinkClicked);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(436, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "DB type :";
            // 
            // lbOdbcDatasource
            // 
            this.lbOdbcDatasource.AutoSize = true;
            this.lbOdbcDatasource.Location = new System.Drawing.Point(142, 6);
            this.lbOdbcDatasource.Name = "lbOdbcDatasource";
            this.lbOdbcDatasource.Size = new System.Drawing.Size(101, 13);
            this.lbOdbcDatasource.TabIndex = 22;
            this.lbOdbcDatasource.Text = "ODBC Datasource :";
            // 
            // lbLogin
            // 
            this.lbLogin.AutoSize = true;
            this.lbLogin.Location = new System.Drawing.Point(204, 36);
            this.lbLogin.Name = "lbLogin";
            this.lbLogin.Size = new System.Drawing.Size(39, 13);
            this.lbLogin.TabIndex = 21;
            this.lbLogin.Text = "Login :";
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Location = new System.Drawing.Point(436, 36);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(59, 13);
            this.lbPassword.TabIndex = 20;
            this.lbPassword.Text = "Password :";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(501, 33);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(131, 20);
            this.tbPassword.TabIndex = 19;
            // 
            // cbDatabaseType
            // 
            this.cbDatabaseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDatabaseType.FormattingEnabled = true;
            this.cbDatabaseType.Items.AddRange(new object[] {
            "Oracle",
            "SqlServer"});
            this.cbDatabaseType.Location = new System.Drawing.Point(501, 3);
            this.cbDatabaseType.Name = "cbDatabaseType";
            this.cbDatabaseType.Size = new System.Drawing.Size(131, 21);
            this.cbDatabaseType.TabIndex = 18;
            // 
            // cbOdbcDatasource
            // 
            this.cbOdbcDatasource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOdbcDatasource.FormattingEnabled = true;
            this.cbOdbcDatasource.Location = new System.Drawing.Point(249, 3);
            this.cbOdbcDatasource.Name = "cbOdbcDatasource";
            this.cbOdbcDatasource.Size = new System.Drawing.Size(130, 21);
            this.cbOdbcDatasource.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(454, 143);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Report parameters :";
            // 
            // labelSettings
            // 
            this.labelSettings.AutoSize = true;
            this.labelSettings.Location = new System.Drawing.Point(110, 143);
            this.labelSettings.Name = "labelSettings";
            this.labelSettings.Size = new System.Drawing.Size(51, 13);
            this.labelSettings.TabIndex = 11;
            this.labelSettings.Text = "Settings :";
            // 
            // cbActions
            // 
            this.cbActions.FormattingEnabled = true;
            this.cbActions.Location = new System.Drawing.Point(113, 113);
            this.cbActions.Name = "cbActions";
            this.cbActions.Size = new System.Drawing.Size(130, 21);
            this.cbActions.TabIndex = 10;
            // 
            // labelActions
            // 
            this.labelActions.AutoSize = true;
            this.labelActions.Location = new System.Drawing.Point(7, 116);
            this.labelActions.Name = "labelActions";
            this.labelActions.Size = new System.Drawing.Size(43, 13);
            this.labelActions.TabIndex = 9;
            this.labelActions.Text = "Action :";
            // 
            // cbReportName
            // 
            this.cbReportName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbReportName.FormattingEnabled = true;
            this.cbReportName.Location = new System.Drawing.Point(113, 59);
            this.cbReportName.Name = "cbReportName";
            this.cbReportName.Size = new System.Drawing.Size(617, 21);
            this.cbReportName.TabIndex = 5;
            this.cbReportName.Text = "TABCOUNTRY_CrDll_X3.rpt";
            // 
            // labelReportFile
            // 
            this.labelReportFile.AutoSize = true;
            this.labelReportFile.Location = new System.Drawing.Point(7, 62);
            this.labelReportFile.Name = "labelReportFile";
            this.labelReportFile.Size = new System.Drawing.Size(58, 13);
            this.labelReportFile.TabIndex = 4;
            this.labelReportFile.Text = "Report file:";
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(249, 33);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(131, 20);
            this.tbLogin.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Connection info :";
            // 
            // cbExportDirectory
            // 
            this.cbExportDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbExportDirectory.FormattingEnabled = true;
            this.cbExportDirectory.Location = new System.Drawing.Point(113, 86);
            this.cbExportDirectory.Name = "cbExportDirectory";
            this.cbExportDirectory.Size = new System.Drawing.Size(617, 21);
            this.cbExportDirectory.TabIndex = 8;
            // 
            // btBrowseRpt
            // 
            this.btBrowseRpt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btBrowseRpt.Location = new System.Drawing.Point(736, 57);
            this.btBrowseRpt.Name = "btBrowseRpt";
            this.btBrowseRpt.Size = new System.Drawing.Size(125, 23);
            this.btBrowseRpt.TabIndex = 6;
            this.btBrowseRpt.Text = "Choose Rpt file";
            this.btBrowseRpt.UseVisualStyleBackColor = true;
            this.btBrowseRpt.Click += new System.EventHandler(this.btBrowseRpt_Click);
            // 
            // labelExportDirectory
            // 
            this.labelExportDirectory.AutoSize = true;
            this.labelExportDirectory.Location = new System.Drawing.Point(7, 89);
            this.labelExportDirectory.Name = "labelExportDirectory";
            this.labelExportDirectory.Size = new System.Drawing.Size(86, 13);
            this.labelExportDirectory.TabIndex = 7;
            this.labelExportDirectory.Text = "Export directory :";
            // 
            // btDelete
            // 
            this.btDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btDelete.Location = new System.Drawing.Point(736, 356);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(25, 23);
            this.btDelete.TabIndex = 16;
            this.btDelete.Text = "-";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // btAddParam
            // 
            this.btAddParam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btAddParam.Location = new System.Drawing.Point(736, 327);
            this.btAddParam.Name = "btAddParam";
            this.btAddParam.Size = new System.Drawing.Size(25, 23);
            this.btAddParam.TabIndex = 15;
            this.btAddParam.Text = "+";
            this.btAddParam.UseVisualStyleBackColor = true;
            this.btAddParam.Click += new System.EventHandler(this.btAddParam_Click);
            // 
            // dgKeyValue
            // 
            this.dgKeyValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgKeyValue.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgKeyValue.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnName,
            this.ColumnValue});
            this.dgKeyValue.ContextMenuStrip = this.gridContextMenuStrip;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgKeyValue.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgKeyValue.Location = new System.Drawing.Point(457, 168);
            this.dgKeyValue.Name = "dgKeyValue";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgKeyValue.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgKeyValue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgKeyValue.Size = new System.Drawing.Size(273, 245);
            this.dgKeyValue.TabIndex = 14;
            this.dgKeyValue.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgKeyValue_CellEndEdit);
            this.dgKeyValue.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgKeyValue_CellValueChanged);
            // 
            // ColumnName
            // 
            this.ColumnName.DataPropertyName = "Name";
            this.ColumnName.HeaderText = "Name";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.Width = 120;
            // 
            // ColumnValue
            // 
            this.ColumnValue.DataPropertyName = "Value";
            this.ColumnValue.HeaderText = "Value";
            this.ColumnValue.Name = "ColumnValue";
            this.ColumnValue.Width = 200;
            // 
            // cbPath
            // 
            this.cbPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPath.FormattingEnabled = true;
            this.cbPath.Location = new System.Drawing.Point(114, 21);
            this.cbPath.Name = "cbPath";
            this.cbPath.Size = new System.Drawing.Size(622, 21);
            this.cbPath.TabIndex = 1;
            // 
            // labelPath
            // 
            this.labelPath.AutoSize = true;
            this.labelPath.Location = new System.Drawing.Point(13, 24);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(89, 13);
            this.labelPath.TabIndex = 0;
            this.labelPath.Text = "Print Server path:";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPagePrintServer);
            this.tabControl1.Controls.Add(this.tabPageOptions);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(881, 567);
            this.tabControl1.TabIndex = 37;
            // 
            // tabPageOptions
            // 
            this.tabPageOptions.Controls.Add(this.label5);
            this.tabPageOptions.Controls.Add(this.label3);
            this.tabPageOptions.Controls.Add(this.label2);
            this.tabPageOptions.Controls.Add(this.tbVersion);
            this.tabPageOptions.Controls.Add(this.label1);
            this.tabPageOptions.Location = new System.Drawing.Point(4, 22);
            this.tabPageOptions.Name = "tabPageOptions";
            this.tabPageOptions.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOptions.Size = new System.Drawing.Size(873, 541);
            this.tabPageOptions.TabIndex = 1;
            this.tabPageOptions.Text = "Options";
            this.tabPageOptions.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Print Threads :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Memory :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Monitoring :";
            // 
            // tbVersion
            // 
            this.tbVersion.Location = new System.Drawing.Point(136, 70);
            this.tbVersion.Name = "tbVersion";
            this.tbVersion.Size = new System.Drawing.Size(324, 20);
            this.tbVersion.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Version :";
            // 
            // PrintServerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 562);
            this.Controls.Add(this.tabControl1);
            this.Name = "PrintServerControl";
            this.Load += new System.EventHandler(this.PrintServerControl_Load);
            this.tabPagePrintServer.ResumeLayout(false);
            this.tabPagePrintServer.PerformLayout();
            this.panelParameters.ResumeLayout(false);
            this.panelParameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSettings)).EndInit();
            this.gridContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgKeyValue)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPageOptions.ResumeLayout(false);
            this.tabPageOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btValidate;
        private System.Windows.Forms.TabPage tabPagePrintServer;
        private System.Windows.Forms.Button btBrowseRpt;
        private System.Windows.Forms.Panel panelParameters;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Button btAddParam;
        private System.Windows.Forms.DataGridView dgKeyValue;
        private System.Windows.Forms.ComboBox cbPath;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageOptions;
        private System.Windows.Forms.ContextMenuStrip gridContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem removeSelectedXsdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyPathToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbExportDirectory;
        private System.Windows.Forms.Label labelExportDirectory;
        private System.Windows.Forms.ComboBox cbActions;
        private System.Windows.Forms.Label labelActions;
        private System.Windows.Forms.ComboBox cbReportName;
        private System.Windows.Forms.Label labelReportFile;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelSettings;
        private System.Windows.Forms.Button btDetectInstall;
        private System.Windows.Forms.ComboBox cbOdbcDatasource;
        private System.Windows.Forms.TextBox tbVersion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbDatabaseType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btGenerateCommand;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label lbLogin;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbOdbcDatasource;
        private System.Windows.Forms.LinkLabel linkOpenExportDirectory;
        private System.Windows.Forms.TextBox tbExportFilename;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgSettings;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnValue;
        private System.Windows.Forms.Button btRemoveSetting;
        private System.Windows.Forms.Button btAddSetting;
    }
}