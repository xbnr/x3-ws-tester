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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btValidate = new System.Windows.Forms.Button();
            this.tabPagePrintServer = new System.Windows.Forms.TabPage();
            this.panelParameters = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbReportName = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbReportDirectory = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btBrowseRpt = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btDelete = new System.Windows.Forms.Button();
            this.btAddParam = new System.Windows.Forms.Button();
            this.dgKeyValue = new System.Windows.Forms.DataGridView();
            this.gridContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeSelectedXsdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbPath = new System.Windows.Forms.ComboBox();
            this.labelPath = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageOptions = new System.Windows.Forms.TabPage();
            this.cbShowWarnings = new System.Windows.Forms.CheckBox();
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
            // panelParameters
            // 
            this.panelParameters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelParameters.Controls.Add(this.label8);
            this.panelParameters.Controls.Add(this.comboBox2);
            this.panelParameters.Controls.Add(this.label7);
            this.panelParameters.Controls.Add(this.comboBox4);
            this.panelParameters.Controls.Add(this.label6);
            this.panelParameters.Controls.Add(this.cbReportName);
            this.panelParameters.Controls.Add(this.label5);
            this.panelParameters.Controls.Add(this.comboBox3);
            this.panelParameters.Controls.Add(this.label4);
            this.panelParameters.Controls.Add(this.cbReportDirectory);
            this.panelParameters.Controls.Add(this.label3);
            this.panelParameters.Controls.Add(this.comboBox1);
            this.panelParameters.Controls.Add(this.btBrowseRpt);
            this.panelParameters.Controls.Add(this.label2);
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
            this.label8.Location = new System.Drawing.Point(7, 154);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Report parameters :";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(489, 113);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(143, 21);
            this.comboBox2.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(388, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Settings :";
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(108, 113);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(143, 21);
            this.comboBox4.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Action :";
            // 
            // cbReportName
            // 
            this.cbReportName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbReportName.FormattingEnabled = true;
            this.cbReportName.Items.AddRange(new object[] {
            "/soap-generic/syracuse/collaboration/syracuse/CAdxWebServiceXmlCC",
            "/adxwsvc/services/CAdxWebServiceXmlCC"});
            this.cbReportName.Location = new System.Drawing.Point(108, 59);
            this.cbReportName.Name = "cbReportName";
            this.cbReportName.Size = new System.Drawing.Size(524, 21);
            this.cbReportName.TabIndex = 5;
            this.cbReportName.Text = "TABCOUNTRY_CrDll_X3.rpt";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Report file:";
            // 
            // comboBox3
            // 
            this.comboBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "/soap-generic/syracuse/collaboration/syracuse/CAdxWebServiceXmlCC",
            "/adxwsvc/services/CAdxWebServiceXmlCC"});
            this.comboBox3.Location = new System.Drawing.Point(108, 5);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(524, 21);
            this.comboBox3.TabIndex = 1;
            this.comboBox3.Text = "datasource=ADX_2018R6ORA2;userid=X3;password=Gege_3x;basetype=Oracle";
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
            this.cbReportDirectory.Items.AddRange(new object[] {
            "/soap-generic/syracuse/collaboration/syracuse/CAdxWebServiceXmlCC",
            "/adxwsvc/services/CAdxWebServiceXmlCC"});
            this.cbReportDirectory.Location = new System.Drawing.Point(108, 32);
            this.cbReportDirectory.Name = "cbReportDirectory";
            this.cbReportDirectory.Size = new System.Drawing.Size(524, 21);
            this.cbReportDirectory.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Report directory : ";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "/soap-generic/syracuse/collaboration/syracuse/CAdxWebServiceXmlCC",
            "/adxwsvc/services/CAdxWebServiceXmlCC"});
            this.comboBox1.Location = new System.Drawing.Point(108, 86);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(524, 21);
            this.comboBox1.TabIndex = 8;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Export directory :";
            // 
            // btDelete
            // 
            this.btDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btDelete.Location = new System.Drawing.Point(638, 255);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(25, 23);
            this.btDelete.TabIndex = 17;
            this.btDelete.Text = "-";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // btAddParam
            // 
            this.btAddParam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btAddParam.Location = new System.Drawing.Point(638, 226);
            this.btAddParam.Name = "btAddParam";
            this.btAddParam.Size = new System.Drawing.Size(25, 23);
            this.btAddParam.TabIndex = 16;
            this.btAddParam.Text = "+";
            this.btAddParam.UseVisualStyleBackColor = true;
            this.btAddParam.Visible = false;
            this.btAddParam.Click += new System.EventHandler(this.btAddParam_Click);
            // 
            // dgKeyValue
            // 
            this.dgKeyValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgKeyValue.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgKeyValue.ContextMenuStrip = this.gridContextMenuStrip;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgKeyValue.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgKeyValue.Location = new System.Drawing.Point(108, 154);
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
            this.dgKeyValue.Size = new System.Drawing.Size(524, 148);
            this.dgKeyValue.TabIndex = 14;
            this.dgKeyValue.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgKeyValue_RowPostPaint);
            // 
            // gridContextMenuStrip
            // 
            this.gridContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeSelectedXsdToolStripMenuItem,
            this.normalizeToolStripMenuItem,
            this.openFileToolStripMenuItem,
            this.copyPathToolStripMenuItem});
            this.gridContextMenuStrip.Name = "gridContextMenuStrip";
            this.gridContextMenuStrip.Size = new System.Drawing.Size(186, 92);
            // 
            // removeSelectedXsdToolStripMenuItem
            // 
            this.removeSelectedXsdToolStripMenuItem.Name = "removeSelectedXsdToolStripMenuItem";
            this.removeSelectedXsdToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.removeSelectedXsdToolStripMenuItem.Text = "Remove selected Xsd";
            this.removeSelectedXsdToolStripMenuItem.Click += new System.EventHandler(this.removeSelectedXsdToolStripMenuItem_Click);
            // 
            // normalizeToolStripMenuItem
            // 
            this.normalizeToolStripMenuItem.Name = "normalizeToolStripMenuItem";
            this.normalizeToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.normalizeToolStripMenuItem.Text = "Normalize";
            this.normalizeToolStripMenuItem.Click += new System.EventHandler(this.normalizeToolStripMenuItem_Click);
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.openFileToolStripMenuItem.Text = "Open file";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
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
            this.cbPath.Items.AddRange(new object[] {
            "/soap-generic/syracuse/collaboration/syracuse/CAdxWebServiceXmlCC",
            "/adxwsvc/services/CAdxWebServiceXmlCC"});
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
            this.tabPageOptions.Controls.Add(this.cbShowWarnings);
            this.tabPageOptions.Location = new System.Drawing.Point(4, 22);
            this.tabPageOptions.Name = "tabPageOptions";
            this.tabPageOptions.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOptions.Size = new System.Drawing.Size(775, 439);
            this.tabPageOptions.TabIndex = 1;
            this.tabPageOptions.Text = "Options";
            this.tabPageOptions.UseVisualStyleBackColor = true;
            // 
            // cbShowWarnings
            // 
            this.cbShowWarnings.AutoSize = true;
            this.cbShowWarnings.Location = new System.Drawing.Point(32, 31);
            this.cbShowWarnings.Name = "cbShowWarnings";
            this.cbShowWarnings.Size = new System.Drawing.Size(98, 17);
            this.cbShowWarnings.TabIndex = 0;
            this.cbShowWarnings.Text = "Show warnings";
            this.cbShowWarnings.UseVisualStyleBackColor = true;
            // 
            // PrintServerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 460);
            this.Controls.Add(this.tabControl1);
            this.Name = "PrintServerControl";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PrintServerControl_FormClosing);
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
        private System.Windows.Forms.CheckBox cbShowWarnings;
        private System.Windows.Forms.ContextMenuStrip gridContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem removeSelectedXsdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normalizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyPathToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbReportName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbReportDirectory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label7;
    }
}