namespace ConsoleTester.Plugins.XsdValidator
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btValidate = new System.Windows.Forms.Button();
            this.tabPageXmlValidator = new System.Windows.Forms.TabPage();
            this.btBrowseXML = new System.Windows.Forms.Button();
            this.panelParameters = new System.Windows.Forms.Panel();
            this.btBrowse = new System.Windows.Forms.Button();
            this.btDelete = new System.Windows.Forms.Button();
            this.btAddParam = new System.Windows.Forms.Button();
            this.dgKeyValue = new System.Windows.Forms.DataGridView();
            this.gridContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeSelectedXsdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelParameters = new System.Windows.Forms.Label();
            this.cbPath = new System.Windows.Forms.ComboBox();
            this.labelPath = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageGenerateXsd = new System.Windows.Forms.TabPage();
            this.btGenerateXSD = new System.Windows.Forms.Button();
            this.btChooseXML = new System.Windows.Forms.Button();
            this.cbXmlFileForXSD = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageOptions = new System.Windows.Forms.TabPage();
            this.cbShowWarnings = new System.Windows.Forms.CheckBox();
            this.tabPageXmlValidator.SuspendLayout();
            this.panelParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgKeyValue)).BeginInit();
            this.gridContextMenuStrip.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageGenerateXsd.SuspendLayout();
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
            this.btValidate.Text = "Validate XML";
            this.btValidate.UseVisualStyleBackColor = false;
            this.btValidate.Click += new System.EventHandler(this.launch_Click);
            // 
            // tabPageXmlValidator
            // 
            this.tabPageXmlValidator.Controls.Add(this.btBrowseXML);
            this.tabPageXmlValidator.Controls.Add(this.panelParameters);
            this.tabPageXmlValidator.Controls.Add(this.btValidate);
            this.tabPageXmlValidator.Controls.Add(this.labelParameters);
            this.tabPageXmlValidator.Controls.Add(this.cbPath);
            this.tabPageXmlValidator.Controls.Add(this.labelPath);
            this.tabPageXmlValidator.Location = new System.Drawing.Point(4, 22);
            this.tabPageXmlValidator.Name = "tabPageXmlValidator";
            this.tabPageXmlValidator.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageXmlValidator.Size = new System.Drawing.Size(775, 439);
            this.tabPageXmlValidator.TabIndex = 0;
            this.tabPageXmlValidator.Text = "Xml validator";
            this.tabPageXmlValidator.UseVisualStyleBackColor = true;
            // 
            // btBrowseXML
            // 
            this.btBrowseXML.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btBrowseXML.Location = new System.Drawing.Point(644, 19);
            this.btBrowseXML.Name = "btBrowseXML";
            this.btBrowseXML.Size = new System.Drawing.Size(125, 23);
            this.btBrowseXML.TabIndex = 43;
            this.btBrowseXML.Text = "Choose Xml file";
            this.btBrowseXML.UseVisualStyleBackColor = true;
            this.btBrowseXML.Click += new System.EventHandler(this.btBrowseXML_Click);
            // 
            // panelParameters
            // 
            this.panelParameters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelParameters.Controls.Add(this.btBrowse);
            this.panelParameters.Controls.Add(this.btDelete);
            this.panelParameters.Controls.Add(this.btAddParam);
            this.panelParameters.Controls.Add(this.dgKeyValue);
            this.panelParameters.Location = new System.Drawing.Point(84, 57);
            this.panelParameters.Name = "panelParameters";
            this.panelParameters.Size = new System.Drawing.Size(691, 324);
            this.panelParameters.TabIndex = 34;
            // 
            // btBrowse
            // 
            this.btBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btBrowse.Location = new System.Drawing.Point(560, 3);
            this.btBrowse.Name = "btBrowse";
            this.btBrowse.Size = new System.Drawing.Size(125, 35);
            this.btBrowse.TabIndex = 42;
            this.btBrowse.Text = "Choose Xsd file(s)";
            this.btBrowse.UseVisualStyleBackColor = true;
            this.btBrowse.Click += new System.EventHandler(this.btBrowse_Click);
            // 
            // btDelete
            // 
            this.btDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btDelete.Location = new System.Drawing.Point(560, 127);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(25, 23);
            this.btDelete.TabIndex = 41;
            this.btDelete.Text = "-";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // btAddParam
            // 
            this.btAddParam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btAddParam.Location = new System.Drawing.Point(560, 98);
            this.btAddParam.Name = "btAddParam";
            this.btAddParam.Size = new System.Drawing.Size(25, 23);
            this.btAddParam.TabIndex = 40;
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgKeyValue.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgKeyValue.ContextMenuStrip = this.gridContextMenuStrip;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgKeyValue.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgKeyValue.Location = new System.Drawing.Point(3, 3);
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
            this.dgKeyValue.Size = new System.Drawing.Size(551, 321);
            this.dgKeyValue.TabIndex = 39;
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
            // labelParameters
            // 
            this.labelParameters.AutoSize = true;
            this.labelParameters.Location = new System.Drawing.Point(19, 60);
            this.labelParameters.Name = "labelParameters";
            this.labelParameters.Size = new System.Drawing.Size(55, 13);
            this.labelParameters.TabIndex = 21;
            this.labelParameters.Text = "XSD input";
            // 
            // cbPath
            // 
            this.cbPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPath.FormattingEnabled = true;
            this.cbPath.Items.AddRange(new object[] {
            "/soap-generic/syracuse/collaboration/syracuse/CAdxWebServiceXmlCC",
            "/adxwsvc/services/CAdxWebServiceXmlCC"});
            this.cbPath.Location = new System.Drawing.Point(84, 21);
            this.cbPath.Name = "cbPath";
            this.cbPath.Size = new System.Drawing.Size(554, 21);
            this.cbPath.TabIndex = 33;
            this.cbPath.Text = "C:\\Users\\frdepo\\OneDrive - Sage Software, Inc\\X3\\X3-CHORUS\\00-FSO1100-P24.xml";
            // 
            // labelPath
            // 
            this.labelPath.AutoSize = true;
            this.labelPath.Location = new System.Drawing.Point(19, 24);
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
            this.tabControl1.Controls.Add(this.tabPageXmlValidator);
            this.tabControl1.Controls.Add(this.tabPageGenerateXsd);
            this.tabControl1.Controls.Add(this.tabPageOptions);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(783, 465);
            this.tabControl1.TabIndex = 37;
            // 
            // tabPageGenerateXsd
            // 
            this.tabPageGenerateXsd.Controls.Add(this.btGenerateXSD);
            this.tabPageGenerateXsd.Controls.Add(this.btChooseXML);
            this.tabPageGenerateXsd.Controls.Add(this.cbXmlFileForXSD);
            this.tabPageGenerateXsd.Controls.Add(this.label1);
            this.tabPageGenerateXsd.Location = new System.Drawing.Point(4, 22);
            this.tabPageGenerateXsd.Name = "tabPageGenerateXsd";
            this.tabPageGenerateXsd.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGenerateXsd.Size = new System.Drawing.Size(775, 439);
            this.tabPageGenerateXsd.TabIndex = 2;
            this.tabPageGenerateXsd.Text = "Generate XSD";
            this.tabPageGenerateXsd.UseVisualStyleBackColor = true;
            // 
            // btGenerateXSD
            // 
            this.btGenerateXSD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btGenerateXSD.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btGenerateXSD.Location = new System.Drawing.Point(14, 55);
            this.btGenerateXSD.Name = "btGenerateXSD";
            this.btGenerateXSD.Size = new System.Drawing.Size(745, 38);
            this.btGenerateXSD.TabIndex = 47;
            this.btGenerateXSD.Text = "Generate XSD";
            this.btGenerateXSD.UseVisualStyleBackColor = false;
            this.btGenerateXSD.Click += new System.EventHandler(this.btGenerateXSD_Click);
            // 
            // btChooseXML
            // 
            this.btChooseXML.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btChooseXML.Location = new System.Drawing.Point(636, 26);
            this.btChooseXML.Name = "btChooseXML";
            this.btChooseXML.Size = new System.Drawing.Size(125, 23);
            this.btChooseXML.TabIndex = 46;
            this.btChooseXML.Text = "Choose Xml file";
            this.btChooseXML.UseVisualStyleBackColor = true;
            this.btChooseXML.Click += new System.EventHandler(this.btChooseXml_Click);
            // 
            // cbXmlFileForXSD
            // 
            this.cbXmlFileForXSD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbXmlFileForXSD.FormattingEnabled = true;
            this.cbXmlFileForXSD.Items.AddRange(new object[] {
            "/soap-generic/syracuse/collaboration/syracuse/CAdxWebServiceXmlCC",
            "/adxwsvc/services/CAdxWebServiceXmlCC"});
            this.cbXmlFileForXSD.Location = new System.Drawing.Point(76, 28);
            this.cbXmlFileForXSD.Name = "cbXmlFileForXSD";
            this.cbXmlFileForXSD.Size = new System.Drawing.Size(554, 21);
            this.cbXmlFileForXSD.TabIndex = 45;
            this.cbXmlFileForXSD.Text = "C:\\Users\\frdepo\\OneDrive - Sage Software, Inc\\X3\\X3-CHORUS\\00-FSO1100-P24.xml";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 44;
            this.label1.Text = "XML Input:";
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
            // XsdValidatorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 460);
            this.Controls.Add(this.tabControl1);
            this.Name = "XsdValidatorControl";
            this.tabPageXmlValidator.ResumeLayout(false);
            this.tabPageXmlValidator.PerformLayout();
            this.panelParameters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgKeyValue)).EndInit();
            this.gridContextMenuStrip.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageGenerateXsd.ResumeLayout(false);
            this.tabPageGenerateXsd.PerformLayout();
            this.tabPageOptions.ResumeLayout(false);
            this.tabPageOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btValidate;
        private System.Windows.Forms.TabPage tabPageXmlValidator;
        private System.Windows.Forms.Button btBrowseXML;
        private System.Windows.Forms.Panel panelParameters;
        private System.Windows.Forms.Button btBrowse;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Button btAddParam;
        private System.Windows.Forms.DataGridView dgKeyValue;
        private System.Windows.Forms.Label labelParameters;
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
        private System.Windows.Forms.TabPage tabPageGenerateXsd;
        private System.Windows.Forms.Button btChooseXML;
        private System.Windows.Forms.ComboBox cbXmlFileForXSD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btGenerateXSD;
    }
}