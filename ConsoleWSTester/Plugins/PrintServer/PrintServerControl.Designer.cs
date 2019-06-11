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
            this.btGenerateCommand = new System.Windows.Forms.LinkLabel();
            this.btDetectInstall = new System.Windows.Forms.Button();
            this.panelParameters = new System.Windows.Forms.Panel();
            this.lbDatasourceInfo = new System.Windows.Forms.LinkLabel();
            this.lbServer = new System.Windows.Forms.Label();
            this.tbDbServer = new System.Windows.Forms.TextBox();
            this.panelAddRemoveParameters = new System.Windows.Forms.Panel();
            this.btAddParam = new System.Windows.Forms.Button();
            this.btDelete = new System.Windows.Forms.Button();
            this.dgKeyValue = new System.Windows.Forms.DataGridView();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeSelectedXsdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelAddRemoveSettings = new System.Windows.Forms.Panel();
            this.btAddSetting = new System.Windows.Forms.Button();
            this.btRemoveSetting = new System.Windows.Forms.Button();
            this.dgSettings = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label9 = new System.Windows.Forms.Label();
            this.tbDbName = new System.Windows.Forms.TextBox();
            this.btTestConnection = new System.Windows.Forms.Button();
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
            this.cbReportName = new System.Windows.Forms.TextBox();
            this.labelReportFile = new System.Windows.Forms.Label();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbExportDirectory = new System.Windows.Forms.TextBox();
            this.btBrowseRpt = new System.Windows.Forms.Button();
            this.labelExportDirectory = new System.Windows.Forms.Label();
            this.cbPath = new System.Windows.Forms.TextBox();
            this.labelPath = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageOptions = new System.Windows.Forms.TabPage();
            this.tbCRRuntime32Version = new System.Windows.Forms.TextBox();
            this.lbCrystalReportRuntime = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tbSapCrystalReport = new System.Windows.Forms.TextBox();
            this.tbService = new System.Windows.Forms.TextBox();
            this.lbService = new System.Windows.Forms.Label();
            this.tbInstallPath = new System.Windows.Forms.TextBox();
            this.labelInstalledPath = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelCrystalReport = new System.Windows.Forms.Label();
            this.tbPrintServerVersion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.llFindReportParameters = new System.Windows.Forms.LinkLabel();
            this.cbOutputFormat = new System.Windows.Forms.ComboBox();
            this.tabPagePrintServer.SuspendLayout();
            this.panelParameters.SuspendLayout();
            this.panelAddRemoveParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgKeyValue)).BeginInit();
            this.gridContextMenuStrip.SuspendLayout();
            this.panelAddRemoveSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSettings)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPageOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // btValidate
            // 
            this.btValidate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btValidate.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btValidate.Location = new System.Drawing.Point(119, 489);
            this.btValidate.Name = "btValidate";
            this.btValidate.Size = new System.Drawing.Size(746, 38);
            this.btValidate.TabIndex = 5;
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
            this.btGenerateCommand.BackColor = System.Drawing.Color.Transparent;
            this.btGenerateCommand.Location = new System.Drawing.Point(9, 499);
            this.btGenerateCommand.Name = "btGenerateCommand";
            this.btGenerateCommand.Size = new System.Drawing.Size(112, 24);
            this.btGenerateCommand.TabIndex = 4;
            this.btGenerateCommand.TabStop = true;
            this.btGenerateCommand.Text = "Generate command";
            this.btGenerateCommand.Click += new System.EventHandler(this.btGenerateCommand_Click);
            // 
            // btDetectInstall
            // 
            this.btDetectInstall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btDetectInstall.Location = new System.Drawing.Point(742, 19);
            this.btDetectInstall.Name = "btDetectInstall";
            this.btDetectInstall.Size = new System.Drawing.Size(123, 23);
            this.btDetectInstall.TabIndex = 2;
            this.btDetectInstall.Text = "Detect install dir";
            this.btDetectInstall.UseVisualStyleBackColor = true;
            this.btDetectInstall.Click += new System.EventHandler(this.btDetectInstall_Click);
            // 
            // panelParameters
            // 
            this.panelParameters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelParameters.Controls.Add(this.cbOutputFormat);
            this.panelParameters.Controls.Add(this.llFindReportParameters);
            this.panelParameters.Controls.Add(this.lbDatasourceInfo);
            this.panelParameters.Controls.Add(this.lbServer);
            this.panelParameters.Controls.Add(this.tbDbServer);
            this.panelParameters.Controls.Add(this.panelAddRemoveParameters);
            this.panelParameters.Controls.Add(this.panelAddRemoveSettings);
            this.panelParameters.Controls.Add(this.label9);
            this.panelParameters.Controls.Add(this.tbDbName);
            this.panelParameters.Controls.Add(this.btTestConnection);
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
            this.panelParameters.Location = new System.Drawing.Point(6, 57);
            this.panelParameters.Name = "panelParameters";
            this.panelParameters.Size = new System.Drawing.Size(867, 426);
            this.panelParameters.TabIndex = 3;
            // 
            // lbDatasourceInfo
            // 
            this.lbDatasourceInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDatasourceInfo.AutoSize = true;
            this.lbDatasourceInfo.Location = new System.Drawing.Point(737, 8);
            this.lbDatasourceInfo.Name = "lbDatasourceInfo";
            this.lbDatasourceInfo.Size = new System.Drawing.Size(123, 13);
            this.lbDatasourceInfo.TabIndex = 34;
            this.lbDatasourceInfo.TabStop = true;
            this.lbDatasourceInfo.Text = "Show all datasource info";
            this.lbDatasourceInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbDatasourceInfo_LinkClicked);
            // 
            // lbServer
            // 
            this.lbServer.AutoSize = true;
            this.lbServer.Location = new System.Drawing.Point(547, 10);
            this.lbServer.Name = "lbServer";
            this.lbServer.Size = new System.Drawing.Size(44, 13);
            this.lbServer.TabIndex = 32;
            this.lbServer.Text = "Server :";
            // 
            // tbDbServer
            // 
            this.tbDbServer.Location = new System.Drawing.Point(594, 6);
            this.tbDbServer.Name = "tbDbServer";
            this.tbDbServer.ReadOnly = true;
            this.tbDbServer.Size = new System.Drawing.Size(136, 20);
            this.tbDbServer.TabIndex = 33;
            // 
            // panelAddRemoveParameters
            // 
            this.panelAddRemoveParameters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelAddRemoveParameters.Controls.Add(this.btAddParam);
            this.panelAddRemoveParameters.Controls.Add(this.btDelete);
            this.panelAddRemoveParameters.Controls.Add(this.dgKeyValue);
            this.panelAddRemoveParameters.Location = new System.Drawing.Point(457, 168);
            this.panelAddRemoveParameters.Name = "panelAddRemoveParameters";
            this.panelAddRemoveParameters.Size = new System.Drawing.Size(320, 241);
            this.panelAddRemoveParameters.TabIndex = 31;
            // 
            // btAddParam
            // 
            this.btAddParam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btAddParam.Location = new System.Drawing.Point(283, 33);
            this.btAddParam.Name = "btAddParam";
            this.btAddParam.Size = new System.Drawing.Size(25, 23);
            this.btAddParam.TabIndex = 0;
            this.btAddParam.Text = "+";
            this.btAddParam.UseVisualStyleBackColor = true;
            this.btAddParam.Click += new System.EventHandler(this.btAddParam_Click);
            // 
            // btDelete
            // 
            this.btDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btDelete.Location = new System.Drawing.Point(283, 62);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(25, 23);
            this.btDelete.TabIndex = 1;
            this.btDelete.Text = "-";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // dgKeyValue
            // 
            this.dgKeyValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgKeyValue.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgKeyValue.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnName,
            this.ColumnValue});
            this.dgKeyValue.ContextMenuStrip = this.gridContextMenuStrip;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgKeyValue.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgKeyValue.Location = new System.Drawing.Point(3, 3);
            this.dgKeyValue.Name = "dgKeyValue";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgKeyValue.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgKeyValue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgKeyValue.Size = new System.Drawing.Size(274, 238);
            this.dgKeyValue.TabIndex = 29;
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
            this.ColumnValue.Width = 120;
            // 
            // gridContextMenuStrip
            // 
            this.gridContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeSelectedXsdToolStripMenuItem,
            this.copyPathToolStripMenuItem});
            this.gridContextMenuStrip.Name = "gridContextMenuStrip";
            this.gridContextMenuStrip.Size = new System.Drawing.Size(118, 48);
            // 
            // removeSelectedXsdToolStripMenuItem
            // 
            this.removeSelectedXsdToolStripMenuItem.Name = "removeSelectedXsdToolStripMenuItem";
            this.removeSelectedXsdToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.removeSelectedXsdToolStripMenuItem.Text = "Remove";
            this.removeSelectedXsdToolStripMenuItem.Click += new System.EventHandler(this.removeSelectedXsdToolStripMenuItem_Click);
            // 
            // copyPathToolStripMenuItem
            // 
            this.copyPathToolStripMenuItem.Name = "copyPathToolStripMenuItem";
            this.copyPathToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.copyPathToolStripMenuItem.Text = "Copy";
            this.copyPathToolStripMenuItem.Click += new System.EventHandler(this.copyPathToolStripMenuItem_Click);
            // 
            // panelAddRemoveSettings
            // 
            this.panelAddRemoveSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelAddRemoveSettings.Controls.Add(this.btAddSetting);
            this.panelAddRemoveSettings.Controls.Add(this.btRemoveSetting);
            this.panelAddRemoveSettings.Controls.Add(this.dgSettings);
            this.panelAddRemoveSettings.Location = new System.Drawing.Point(115, 168);
            this.panelAddRemoveSettings.Name = "panelAddRemoveSettings";
            this.panelAddRemoveSettings.Size = new System.Drawing.Size(336, 241);
            this.panelAddRemoveSettings.TabIndex = 30;
            // 
            // btAddSetting
            // 
            this.btAddSetting.Location = new System.Drawing.Point(303, 33);
            this.btAddSetting.Name = "btAddSetting";
            this.btAddSetting.Size = new System.Drawing.Size(25, 23);
            this.btAddSetting.TabIndex = 25;
            this.btAddSetting.Text = "+";
            this.btAddSetting.UseVisualStyleBackColor = true;
            this.btAddSetting.Click += new System.EventHandler(this.btAddSetting_Click);
            // 
            // btRemoveSetting
            // 
            this.btRemoveSetting.Location = new System.Drawing.Point(303, 63);
            this.btRemoveSetting.Name = "btRemoveSetting";
            this.btRemoveSetting.Size = new System.Drawing.Size(25, 23);
            this.btRemoveSetting.TabIndex = 27;
            this.btRemoveSetting.Text = "-";
            this.btRemoveSetting.UseVisualStyleBackColor = true;
            this.btRemoveSetting.Click += new System.EventHandler(this.btRemoveSetting_Click);
            // 
            // dgSettings
            // 
            this.dgSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgSettings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgSettings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dgSettings.ContextMenuStrip = this.gridContextMenuStrip;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgSettings.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgSettings.Location = new System.Drawing.Point(3, 3);
            this.dgSettings.Name = "dgSettings";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgSettings.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgSettings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgSettings.Size = new System.Drawing.Size(294, 238);
            this.dgSettings.TabIndex = 24;
            this.dgSettings.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgSettings_CellValidated);
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
            this.dataGridViewTextBoxColumn2.Width = 130;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(537, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "DbName :";
            // 
            // tbDbName
            // 
            this.tbDbName.Location = new System.Drawing.Point(594, 31);
            this.tbDbName.Name = "tbDbName";
            this.tbDbName.ReadOnly = true;
            this.tbDbName.Size = new System.Drawing.Size(136, 20);
            this.tbDbName.TabIndex = 6;
            // 
            // btTestConnection
            // 
            this.btTestConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btTestConnection.Location = new System.Drawing.Point(736, 30);
            this.btTestConnection.Name = "btTestConnection";
            this.btTestConnection.Size = new System.Drawing.Size(123, 20);
            this.btTestConnection.TabIndex = 11;
            this.btTestConnection.Text = "Test SQL connection";
            this.btTestConnection.UseVisualStyleBackColor = true;
            this.btTestConnection.Click += new System.EventHandler(this.btTestConnection_Click);
            // 
            // tbExportFilename
            // 
            this.tbExportFilename.Location = new System.Drawing.Point(540, 113);
            this.tbExportFilename.Name = "tbExportFilename";
            this.tbExportFilename.PasswordChar = '*';
            this.tbExportFilename.Size = new System.Drawing.Size(190, 20);
            this.tbExportFilename.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(454, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Export filename :";
            // 
            // linkOpenExportDirectory
            // 
            this.linkOpenExportDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkOpenExportDirectory.AutoSize = true;
            this.linkOpenExportDirectory.Location = new System.Drawing.Point(736, 89);
            this.linkOpenExportDirectory.Name = "linkOpenExportDirectory";
            this.linkOpenExportDirectory.Size = new System.Drawing.Size(76, 13);
            this.linkOpenExportDirectory.TabIndex = 17;
            this.linkOpenExportDirectory.TabStop = true;
            this.linkOpenExportDirectory.Text = "Open directory";
            this.linkOpenExportDirectory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkOpenExportDirectory_LinkClicked);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(362, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "DB type :";
            // 
            // lbOdbcDatasource
            // 
            this.lbOdbcDatasource.AutoSize = true;
            this.lbOdbcDatasource.Location = new System.Drawing.Point(105, 9);
            this.lbOdbcDatasource.Name = "lbOdbcDatasource";
            this.lbOdbcDatasource.Size = new System.Drawing.Size(101, 13);
            this.lbOdbcDatasource.TabIndex = 1;
            this.lbOdbcDatasource.Text = "ODBC Datasource :";
            // 
            // lbLogin
            // 
            this.lbLogin.AutoSize = true;
            this.lbLogin.Location = new System.Drawing.Point(166, 36);
            this.lbLogin.Name = "lbLogin";
            this.lbLogin.Size = new System.Drawing.Size(39, 13);
            this.lbLogin.TabIndex = 7;
            this.lbLogin.Text = "Login :";
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Location = new System.Drawing.Point(354, 36);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(59, 13);
            this.lbPassword.TabIndex = 9;
            this.lbPassword.Text = "Password :";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(418, 32);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(110, 20);
            this.tbPassword.TabIndex = 10;
            // 
            // cbDatabaseType
            // 
            this.cbDatabaseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDatabaseType.FormattingEnabled = true;
            this.cbDatabaseType.Items.AddRange(new object[] {
            "Oracle",
            "SqlServer"});
            this.cbDatabaseType.Location = new System.Drawing.Point(418, 5);
            this.cbDatabaseType.Name = "cbDatabaseType";
            this.cbDatabaseType.Size = new System.Drawing.Size(110, 21);
            this.cbDatabaseType.TabIndex = 4;
            // 
            // cbOdbcDatasource
            // 
            this.cbOdbcDatasource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOdbcDatasource.FormattingEnabled = true;
            this.cbOdbcDatasource.Location = new System.Drawing.Point(212, 5);
            this.cbOdbcDatasource.Name = "cbOdbcDatasource";
            this.cbOdbcDatasource.Size = new System.Drawing.Size(130, 21);
            this.cbOdbcDatasource.TabIndex = 2;
            this.cbOdbcDatasource.SelectedIndexChanged += new System.EventHandler(this.cbOdbcDatasource_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(454, 143);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 13);
            this.label8.TabIndex = 28;
            this.label8.Text = "Report parameters :";
            // 
            // labelSettings
            // 
            this.labelSettings.AutoSize = true;
            this.labelSettings.Location = new System.Drawing.Point(110, 143);
            this.labelSettings.Name = "labelSettings";
            this.labelSettings.Size = new System.Drawing.Size(51, 13);
            this.labelSettings.TabIndex = 23;
            this.labelSettings.Text = "Settings :";
            // 
            // cbActions
            // 
            this.cbActions.FormattingEnabled = true;
            this.cbActions.Location = new System.Drawing.Point(113, 113);
            this.cbActions.Name = "cbActions";
            this.cbActions.Size = new System.Drawing.Size(130, 21);
            this.cbActions.TabIndex = 20;
            // 
            // labelActions
            // 
            this.labelActions.AutoSize = true;
            this.labelActions.Location = new System.Drawing.Point(64, 116);
            this.labelActions.Name = "labelActions";
            this.labelActions.Size = new System.Drawing.Size(43, 13);
            this.labelActions.TabIndex = 19;
            this.labelActions.Text = "Action :";
            this.labelActions.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbReportName
            // 
            this.cbReportName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbReportName.Location = new System.Drawing.Point(113, 59);
            this.cbReportName.Name = "cbReportName";
            this.cbReportName.Size = new System.Drawing.Size(617, 20);
            this.cbReportName.TabIndex = 13;
            this.cbReportName.Text = "TABCOUNTRY_CrDll_X3.rpt";
            // 
            // labelReportFile
            // 
            this.labelReportFile.AutoSize = true;
            this.labelReportFile.Location = new System.Drawing.Point(49, 63);
            this.labelReportFile.Name = "labelReportFile";
            this.labelReportFile.Size = new System.Drawing.Size(58, 13);
            this.labelReportFile.TabIndex = 12;
            this.labelReportFile.Text = "Report file:";
            this.labelReportFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(211, 32);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(131, 20);
            this.tbLogin.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Connection info :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbExportDirectory
            // 
            this.cbExportDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbExportDirectory.Location = new System.Drawing.Point(113, 86);
            this.cbExportDirectory.Name = "cbExportDirectory";
            this.cbExportDirectory.Size = new System.Drawing.Size(617, 20);
            this.cbExportDirectory.TabIndex = 16;
            // 
            // btBrowseRpt
            // 
            this.btBrowseRpt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btBrowseRpt.Location = new System.Drawing.Point(736, 57);
            this.btBrowseRpt.Name = "btBrowseRpt";
            this.btBrowseRpt.Size = new System.Drawing.Size(125, 23);
            this.btBrowseRpt.TabIndex = 14;
            this.btBrowseRpt.Text = "Choose Rpt file";
            this.btBrowseRpt.UseVisualStyleBackColor = true;
            this.btBrowseRpt.Click += new System.EventHandler(this.btBrowseRpt_Click);
            // 
            // labelExportDirectory
            // 
            this.labelExportDirectory.AutoSize = true;
            this.labelExportDirectory.Location = new System.Drawing.Point(21, 90);
            this.labelExportDirectory.Name = "labelExportDirectory";
            this.labelExportDirectory.Size = new System.Drawing.Size(86, 13);
            this.labelExportDirectory.TabIndex = 15;
            this.labelExportDirectory.Text = "Export directory :";
            this.labelExportDirectory.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbPath
            // 
            this.cbPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPath.Location = new System.Drawing.Point(114, 21);
            this.cbPath.Name = "cbPath";
            this.cbPath.Size = new System.Drawing.Size(622, 20);
            this.cbPath.TabIndex = 1;
            // 
            // labelPath
            // 
            this.labelPath.AutoSize = true;
            this.labelPath.Location = new System.Drawing.Point(19, 24);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(89, 13);
            this.labelPath.TabIndex = 0;
            this.labelPath.Text = "Print Server path:";
            this.labelPath.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.tabPageOptions.Controls.Add(this.tbCRRuntime32Version);
            this.tabPageOptions.Controls.Add(this.lbCrystalReportRuntime);
            this.tabPageOptions.Controls.Add(this.label11);
            this.tabPageOptions.Controls.Add(this.tbSapCrystalReport);
            this.tabPageOptions.Controls.Add(this.tbService);
            this.tabPageOptions.Controls.Add(this.lbService);
            this.tabPageOptions.Controls.Add(this.tbInstallPath);
            this.tabPageOptions.Controls.Add(this.labelInstalledPath);
            this.tabPageOptions.Controls.Add(this.label5);
            this.tabPageOptions.Controls.Add(this.label3);
            this.tabPageOptions.Controls.Add(this.labelCrystalReport);
            this.tabPageOptions.Controls.Add(this.tbPrintServerVersion);
            this.tabPageOptions.Controls.Add(this.label1);
            this.tabPageOptions.Location = new System.Drawing.Point(4, 22);
            this.tabPageOptions.Name = "tabPageOptions";
            this.tabPageOptions.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOptions.Size = new System.Drawing.Size(873, 541);
            this.tabPageOptions.TabIndex = 1;
            this.tabPageOptions.Text = "Properties";
            this.tabPageOptions.UseVisualStyleBackColor = true;
            // 
            // tbCRRuntime32Version
            // 
            this.tbCRRuntime32Version.Location = new System.Drawing.Point(142, 124);
            this.tbCRRuntime32Version.Name = "tbCRRuntime32Version";
            this.tbCRRuntime32Version.ReadOnly = true;
            this.tbCRRuntime32Version.Size = new System.Drawing.Size(693, 20);
            this.tbCRRuntime32Version.TabIndex = 7;
            // 
            // lbCrystalReportRuntime
            // 
            this.lbCrystalReportRuntime.Location = new System.Drawing.Point(-2, 121);
            this.lbCrystalReportRuntime.Name = "lbCrystalReportRuntime";
            this.lbCrystalReportRuntime.Size = new System.Drawing.Size(143, 27);
            this.lbCrystalReportRuntime.TabIndex = 6;
            this.lbCrystalReportRuntime.Text = "Crystal Report Runtime :";
            this.lbCrystalReportRuntime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 307);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "Monitoring :";
            // 
            // tbSapCrystalReport
            // 
            this.tbSapCrystalReport.AcceptsReturn = true;
            this.tbSapCrystalReport.AcceptsTab = true;
            this.tbSapCrystalReport.HideSelection = false;
            this.tbSapCrystalReport.Location = new System.Drawing.Point(142, 150);
            this.tbSapCrystalReport.Multiline = true;
            this.tbSapCrystalReport.Name = "tbSapCrystalReport";
            this.tbSapCrystalReport.ReadOnly = true;
            this.tbSapCrystalReport.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbSapCrystalReport.Size = new System.Drawing.Size(693, 101);
            this.tbSapCrystalReport.TabIndex = 9;
            this.tbSapCrystalReport.WordWrap = false;
            // 
            // tbService
            // 
            this.tbService.Location = new System.Drawing.Point(142, 96);
            this.tbService.Name = "tbService";
            this.tbService.ReadOnly = true;
            this.tbService.Size = new System.Drawing.Size(693, 20);
            this.tbService.TabIndex = 5;
            // 
            // lbService
            // 
            this.lbService.Location = new System.Drawing.Point(82, 99);
            this.lbService.Name = "lbService";
            this.lbService.Size = new System.Drawing.Size(59, 13);
            this.lbService.TabIndex = 4;
            this.lbService.Text = "Service :";
            this.lbService.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbInstallPath
            // 
            this.tbInstallPath.Location = new System.Drawing.Point(142, 44);
            this.tbInstallPath.Name = "tbInstallPath";
            this.tbInstallPath.ReadOnly = true;
            this.tbInstallPath.Size = new System.Drawing.Size(693, 20);
            this.tbInstallPath.TabIndex = 1;
            // 
            // labelInstalledPath
            // 
            this.labelInstalledPath.Location = new System.Drawing.Point(67, 47);
            this.labelInstalledPath.Name = "labelInstalledPath";
            this.labelInstalledPath.Size = new System.Drawing.Size(74, 13);
            this.labelInstalledPath.TabIndex = 0;
            this.labelInstalledPath.Text = "Install path :";
            this.labelInstalledPath.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 281);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Print Threads :";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(17, 260);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Memory :";
            // 
            // labelCrystalReport
            // 
            this.labelCrystalReport.Location = new System.Drawing.Point(-2, 154);
            this.labelCrystalReport.Name = "labelCrystalReport";
            this.labelCrystalReport.Size = new System.Drawing.Size(143, 24);
            this.labelCrystalReport.TabIndex = 8;
            this.labelCrystalReport.Text = "Crystal Report :";
            this.labelCrystalReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbPrintServerVersion
            // 
            this.tbPrintServerVersion.Location = new System.Drawing.Point(142, 70);
            this.tbPrintServerVersion.Name = "tbPrintServerVersion";
            this.tbPrintServerVersion.ReadOnly = true;
            this.tbPrintServerVersion.Size = new System.Drawing.Size(693, 20);
            this.tbPrintServerVersion.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(93, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Version :";
            // 
            // llFindReportParameters
            // 
            this.llFindReportParameters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.llFindReportParameters.AutoSize = true;
            this.llFindReportParameters.Location = new System.Drawing.Point(733, 143);
            this.llFindReportParameters.Name = "llFindReportParameters";
            this.llFindReportParameters.Size = new System.Drawing.Size(112, 13);
            this.llFindReportParameters.TabIndex = 35;
            this.llFindReportParameters.TabStop = true;
            this.llFindReportParameters.Text = "Find report parameters";
            this.llFindReportParameters.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llFindReportParameters_LinkClicked);
            this.llFindReportParameters.Click += new System.EventHandler(this.llFindReportParameters_Click);
            // 
            // cbOutputFormat
            // 
            this.cbOutputFormat.FormattingEnabled = true;
            this.cbOutputFormat.Location = new System.Drawing.Point(321, 113);
            this.cbOutputFormat.Name = "cbOutputFormat";
            this.cbOutputFormat.Size = new System.Drawing.Size(91, 21);
            this.cbOutputFormat.TabIndex = 36;
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
            this.panelAddRemoveParameters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgKeyValue)).EndInit();
            this.gridContextMenuStrip.ResumeLayout(false);
            this.panelAddRemoveSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgSettings)).EndInit();
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
        private System.Windows.Forms.TextBox cbPath;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageOptions;
        private System.Windows.Forms.ContextMenuStrip gridContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem removeSelectedXsdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyPathToolStripMenuItem;
        private System.Windows.Forms.TextBox cbExportDirectory;
        private System.Windows.Forms.Label labelExportDirectory;
        private System.Windows.Forms.ComboBox cbActions;
        private System.Windows.Forms.Label labelActions;
        private System.Windows.Forms.TextBox cbReportName;
        private System.Windows.Forms.Label labelReportFile;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelSettings;
        private System.Windows.Forms.Button btDetectInstall;
        private System.Windows.Forms.ComboBox cbOdbcDatasource;
        private System.Windows.Forms.TextBox tbPrintServerVersion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbDatabaseType;
        private System.Windows.Forms.Label labelCrystalReport;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel btGenerateCommand;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label lbLogin;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbOdbcDatasource;
        private System.Windows.Forms.LinkLabel linkOpenExportDirectory;
        private System.Windows.Forms.TextBox tbExportFilename;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgSettings;
        private System.Windows.Forms.Button btRemoveSetting;
        private System.Windows.Forms.Button btAddSetting;
        private System.Windows.Forms.Button btTestConnection;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbDbName;
        private System.Windows.Forms.TextBox tbInstallPath;
        private System.Windows.Forms.Label labelInstalledPath;
        private System.Windows.Forms.Panel panelAddRemoveParameters;
        private System.Windows.Forms.Panel panelAddRemoveSettings;
        private System.Windows.Forms.TextBox tbService;
        private System.Windows.Forms.Label lbService;
        private System.Windows.Forms.Label lbServer;
        private System.Windows.Forms.TextBox tbDbServer;
        private System.Windows.Forms.LinkLabel lbDatasourceInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbSapCrystalReport;
        private System.Windows.Forms.TextBox tbCRRuntime32Version;
        private System.Windows.Forms.Label lbCrystalReportRuntime;
        private System.Windows.Forms.LinkLabel llFindReportParameters;
        private System.Windows.Forms.ComboBox cbOutputFormat;
    }
}