namespace ConsoleTester.Plugins.XsdValidator
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btValidate = new System.Windows.Forms.Button();
            this.tabPagePrintServer = new System.Windows.Forms.TabPage();
            this.btDetectInstall = new System.Windows.Forms.Button();
            this.panelParameters = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.cbSettings = new System.Windows.Forms.ComboBox();
            this.labelSettings = new System.Windows.Forms.Label();
            this.cbActions = new System.Windows.Forms.ComboBox();
            this.labelActions = new System.Windows.Forms.Label();
            this.cbReportName = new System.Windows.Forms.ComboBox();
            this.labelReportFile = new System.Windows.Forms.Label();
            this.cbConnectionInfo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbReportDirectory = new System.Windows.Forms.ComboBox();
            this.labelReportsDirectory = new System.Windows.Forms.Label();
            this.cbExportDirectory = new System.Windows.Forms.ComboBox();
            this.btBrowseRpt = new System.Windows.Forms.Button();
            this.labelExportDirectory = new System.Windows.Forms.Label();
            this.btDelete = new System.Windows.Forms.Button();
            this.btAddParam = new System.Windows.Forms.Button();
            this.dgKeyValue = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeSelectedXsdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbPath = new System.Windows.Forms.ComboBox();
            this.labelPath = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageOptions = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.tbVersion = new System.Windows.Forms.TextBox();
            this.cbOdbcDatasource = new System.Windows.Forms.ComboBox();
            this.tabPagePrintServer.SuspendLayout();
            this.panelParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgKeyValue)).BeginInit();
            this.gridContextMenuStrip.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // btValidate
            // 
            this.btValidate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btValidate.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btValidate.Location = new System.Drawing.Point(22, 387);
            this.btValidate.Name = "btValidate";
            this.btValidate.Size = new System.Drawing.Size(745, 38);
            this.btValidate.TabIndex = 0;
            this.btValidate.Text = "Test print";
            this.btValidate.UseVisualStyleBackColor = false;
            this.btValidate.Click += new System.EventHandler(this.launch_Click);
            // 
            // tabPagePrintServer
            // 
            this.tabPagePrintServer.Controls.Add(this.btDetectInstall);
            this.tabPagePrintServer.Controls.Add(this.panelParameters);
            this.tabPagePrintServer.Controls.Add(this.btValidate);
            this.tabPagePrintServer.Controls.Add(this.cbPath);
            this.tabPagePrintServer.Controls.Add(this.labelPath);
            this.tabPagePrintServer.Location = new System.Drawing.Point(4, 22);
            this.tabPagePrintServer.Name = "tabPagePrintServer";
            this.tabPagePrintServer.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePrintServer.Size = new System.Drawing.Size(775, 439);
            this.tabPagePrintServer.TabIndex = 0;
            this.tabPagePrintServer.Text = "PrintServer";
            this.tabPagePrintServer.UseVisualStyleBackColor = true;
            // 
            // btDetectInstall
            // 
            this.btDetectInstall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btDetectInstall.Location = new System.Drawing.Point(644, 19);
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
            this.panelParameters.Controls.Add(this.cbOdbcDatasource);
            this.panelParameters.Controls.Add(this.label8);
            this.panelParameters.Controls.Add(this.cbSettings);
            this.panelParameters.Controls.Add(this.labelSettings);
            this.panelParameters.Controls.Add(this.cbActions);
            this.panelParameters.Controls.Add(this.labelActions);
            this.panelParameters.Controls.Add(this.cbReportName);
            this.panelParameters.Controls.Add(this.labelReportFile);
            this.panelParameters.Controls.Add(this.cbConnectionInfo);
            this.panelParameters.Controls.Add(this.label4);
            this.panelParameters.Controls.Add(this.cbReportDirectory);
            this.panelParameters.Controls.Add(this.labelReportsDirectory);
            this.panelParameters.Controls.Add(this.cbExportDirectory);
            this.panelParameters.Controls.Add(this.btBrowseRpt);
            this.panelParameters.Controls.Add(this.labelExportDirectory);
            this.panelParameters.Controls.Add(this.btDelete);
            this.panelParameters.Controls.Add(this.btAddParam);
            this.panelParameters.Controls.Add(this.dgKeyValue);
            this.panelParameters.Location = new System.Drawing.Point(6, 57);
            this.panelParameters.Name = "panelParameters";
            this.panelParameters.Size = new System.Drawing.Size(769, 324);
            this.panelParameters.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 179);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Report parameters :";
            // 
            // cbSettings
            // 
            this.cbSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSettings.FormattingEnabled = true;
            this.cbSettings.Items.AddRange(new object[] {
            "orientation=Portrait; papersize=PaperLetter"});
            this.cbSettings.Location = new System.Drawing.Point(113, 146);
            this.cbSettings.Name = "cbSettings";
            this.cbSettings.Size = new System.Drawing.Size(519, 21);
            this.cbSettings.TabIndex = 12;
            // 
            // labelSettings
            // 
            this.labelSettings.AutoSize = true;
            this.labelSettings.Location = new System.Drawing.Point(7, 149);
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
            this.cbActions.Size = new System.Drawing.Size(143, 21);
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
            this.cbReportName.Size = new System.Drawing.Size(519, 21);
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
            // cbConnectionInfo
            // 
            this.cbConnectionInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbConnectionInfo.FormattingEnabled = true;
            this.cbConnectionInfo.Items.AddRange(new object[] {
            "datasource=ADX_2018R6ORA2;userid=X3;password=Gege_3x;basetype=Oracle"});
            this.cbConnectionInfo.Location = new System.Drawing.Point(291, 5);
            this.cbConnectionInfo.Name = "cbConnectionInfo";
            this.cbConnectionInfo.Size = new System.Drawing.Size(341, 21);
            this.cbConnectionInfo.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Connection info :";
            // 
            // cbReportDirectory
            // 
            this.cbReportDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbReportDirectory.FormattingEnabled = true;
            this.cbReportDirectory.Location = new System.Drawing.Point(113, 32);
            this.cbReportDirectory.Name = "cbReportDirectory";
            this.cbReportDirectory.Size = new System.Drawing.Size(519, 21);
            this.cbReportDirectory.TabIndex = 3;
            // 
            // labelReportsDirectory
            // 
            this.labelReportsDirectory.AutoSize = true;
            this.labelReportsDirectory.Location = new System.Drawing.Point(7, 35);
            this.labelReportsDirectory.Name = "labelReportsDirectory";
            this.labelReportsDirectory.Size = new System.Drawing.Size(96, 13);
            this.labelReportsDirectory.TabIndex = 2;
            this.labelReportsDirectory.Text = "Reports directory : ";
            // 
            // cbExportDirectory
            // 
            this.cbExportDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbExportDirectory.FormattingEnabled = true;
            this.cbExportDirectory.Location = new System.Drawing.Point(113, 86);
            this.cbExportDirectory.Name = "cbExportDirectory";
            this.cbExportDirectory.Size = new System.Drawing.Size(519, 21);
            this.cbExportDirectory.TabIndex = 8;
            // 
            // btBrowseRpt
            // 
            this.btBrowseRpt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btBrowseRpt.Location = new System.Drawing.Point(638, 57);
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
            this.btDelete.Location = new System.Drawing.Point(665, 250);
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
            this.btAddParam.Location = new System.Drawing.Point(665, 221);
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
            this.Column1});
            this.dgKeyValue.ContextMenuStrip = this.gridContextMenuStrip;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgKeyValue.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgKeyValue.Location = new System.Drawing.Point(113, 179);
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
            this.dgKeyValue.Size = new System.Drawing.Size(519, 119);
            this.dgKeyValue.TabIndex = 14;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.Width = 500;
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
            // cbPath
            // 
            this.cbPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPath.FormattingEnabled = true;
            this.cbPath.Location = new System.Drawing.Point(114, 21);
            this.cbPath.Name = "cbPath";
            this.cbPath.Size = new System.Drawing.Size(524, 21);
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
            this.tabControl1.Size = new System.Drawing.Size(783, 465);
            this.tabControl1.TabIndex = 37;
            // 
            // tabPageOptions
            // 
            this.tabPageOptions.Controls.Add(this.tbVersion);
            this.tabPageOptions.Controls.Add(this.label1);
            this.tabPageOptions.Location = new System.Drawing.Point(4, 22);
            this.tabPageOptions.Name = "tabPageOptions";
            this.tabPageOptions.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOptions.Size = new System.Drawing.Size(775, 439);
            this.tabPageOptions.TabIndex = 1;
            this.tabPageOptions.Text = "Options";
            this.tabPageOptions.UseVisualStyleBackColor = true;
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
            // tbVersion
            // 
            this.tbVersion.Location = new System.Drawing.Point(136, 70);
            this.tbVersion.Name = "tbVersion";
            this.tbVersion.Size = new System.Drawing.Size(324, 20);
            this.tbVersion.TabIndex = 2;
            // 
            // cbOdbcDatasource
            // 
            this.cbOdbcDatasource.FormattingEnabled = true;
            this.cbOdbcDatasource.Items.AddRange(new object[] {
            "datasource=ADX_2018R6ORA2;userid=X3;password=Gege_3x;basetype=Oracle"});
            this.cbOdbcDatasource.Location = new System.Drawing.Point(113, 5);
            this.cbOdbcDatasource.Name = "cbOdbcDatasource";
            this.cbOdbcDatasource.Size = new System.Drawing.Size(156, 21);
            this.cbOdbcDatasource.TabIndex = 17;
            // 
            // PrintServerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 460);
            this.Controls.Add(this.tabControl1);
            this.Name = "PrintServerControl";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PrintServerControl_FormClosing);
            this.Load += new System.EventHandler(this.PrintServerControl_Load);
            this.tabPagePrintServer.ResumeLayout(false);
            this.tabPagePrintServer.PerformLayout();
            this.panelParameters.ResumeLayout(false);
            this.panelParameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgKeyValue)).EndInit();
            this.gridContextMenuStrip.ResumeLayout(false);
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
        private System.Windows.Forms.ComboBox cbConnectionInfo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbReportDirectory;
        private System.Windows.Forms.Label labelReportsDirectory;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbSettings;
        private System.Windows.Forms.Label labelSettings;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Button btDetectInstall;
        private System.Windows.Forms.ComboBox cbOdbcDatasource;
        private System.Windows.Forms.TextBox tbVersion;
        private System.Windows.Forms.Label label1;
    }
}