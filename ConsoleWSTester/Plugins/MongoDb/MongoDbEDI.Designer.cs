namespace ConsoleTester.Plugins.MongoDb
{
    partial class MongoDbEDI
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
            this.btSearch = new System.Windows.Forms.Button();
            this.tbTextToSearch = new System.Windows.Forms.TextBox();
            this.dgKeyValue = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.downloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadAndViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbFieldName = new System.Windows.Forms.ComboBox();
            this.tbServer = new System.Windows.Forms.TextBox();
            this.lbServer = new System.Windows.Forms.Label();
            this.lbDatabase = new System.Windows.Forms.Label();
            this.tbDatabase = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbSearchType = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgKeyValue)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btSearch
            // 
            this.btSearch.Location = new System.Drawing.Point(481, 9);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(133, 22);
            this.btSearch.TabIndex = 0;
            this.btSearch.Text = "Search";
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // tbTextToSearch
            // 
            this.tbTextToSearch.Location = new System.Drawing.Point(278, 11);
            this.tbTextToSearch.Name = "tbTextToSearch";
            this.tbTextToSearch.Size = new System.Drawing.Size(195, 20);
            this.tbTextToSearch.TabIndex = 1;
            this.tbTextToSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbTextToSearch_KeyDown);
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
            this.dgKeyValue.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgKeyValue.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgKeyValue.Location = new System.Drawing.Point(25, 92);
            this.dgKeyValue.MultiSelect = false;
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
            this.dgKeyValue.Size = new System.Drawing.Size(763, 326);
            this.dgKeyValue.TabIndex = 40;
            this.dgKeyValue.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgKeyValue_DataError);
            this.dgKeyValue.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgKeyValue_RowPostPaint);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.downloadToolStripMenuItem,
            this.downloadAndViewToolStripMenuItem,
            this.copyToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(180, 70);
            // 
            // downloadToolStripMenuItem
            // 
            this.downloadToolStripMenuItem.Name = "downloadToolStripMenuItem";
            this.downloadToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.downloadToolStripMenuItem.Text = "Download";
            this.downloadToolStripMenuItem.Click += new System.EventHandler(this.downloadToolStripMenuItem_Click);
            // 
            // downloadAndViewToolStripMenuItem
            // 
            this.downloadAndViewToolStripMenuItem.Name = "downloadAndViewToolStripMenuItem";
            this.downloadAndViewToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.downloadAndViewToolStripMenuItem.Text = "Download and View";
            this.downloadAndViewToolStripMenuItem.Click += new System.EventHandler(this.downloadAndViewToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // cbFieldName
            // 
            this.cbFieldName.FormattingEnabled = true;
            this.cbFieldName.Items.AddRange(new object[] {
            "filename",
            "_id",
            "md5"});
            this.cbFieldName.Location = new System.Drawing.Point(3, 11);
            this.cbFieldName.Name = "cbFieldName";
            this.cbFieldName.Size = new System.Drawing.Size(121, 21);
            this.cbFieldName.TabIndex = 41;
            // 
            // tbServer
            // 
            this.tbServer.Location = new System.Drawing.Point(61, 5);
            this.tbServer.Name = "tbServer";
            this.tbServer.Size = new System.Drawing.Size(197, 20);
            this.tbServer.TabIndex = 42;
            this.tbServer.Text = "mongodb://localhost/?safe=true";
            // 
            // lbServer
            // 
            this.lbServer.AutoSize = true;
            this.lbServer.Location = new System.Drawing.Point(9, 8);
            this.lbServer.Name = "lbServer";
            this.lbServer.Size = new System.Drawing.Size(38, 13);
            this.lbServer.TabIndex = 43;
            this.lbServer.Text = "Server";
            // 
            // lbDatabase
            // 
            this.lbDatabase.AutoSize = true;
            this.lbDatabase.Location = new System.Drawing.Point(275, 8);
            this.lbDatabase.Name = "lbDatabase";
            this.lbDatabase.Size = new System.Drawing.Size(53, 13);
            this.lbDatabase.TabIndex = 45;
            this.lbDatabase.Text = "Database";
            // 
            // tbDatabase
            // 
            this.tbDatabase.Location = new System.Drawing.Point(331, 5);
            this.tbDatabase.Name = "tbDatabase";
            this.tbDatabase.Size = new System.Drawing.Size(142, 20);
            this.tbDatabase.TabIndex = 44;
            this.tbDatabase.Text = "syracuse";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbSearchType);
            this.panel1.Controls.Add(this.cbFieldName);
            this.panel1.Controls.Add(this.tbTextToSearch);
            this.panel1.Controls.Add(this.btSearch);
            this.panel1.Location = new System.Drawing.Point(25, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(763, 40);
            this.panel1.TabIndex = 46;
            // 
            // cbSearchType
            // 
            this.cbSearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSearchType.FormattingEnabled = true;
            this.cbSearchType.Items.AddRange(new object[] {
            "Contains",
            "Equals"});
            this.cbSearchType.Location = new System.Drawing.Point(137, 11);
            this.cbSearchType.Name = "cbSearchType";
            this.cbSearchType.Size = new System.Drawing.Size(121, 21);
            this.cbSearchType.TabIndex = 42;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbServer);
            this.panel2.Controls.Add(this.tbServer);
            this.panel2.Controls.Add(this.lbDatabase);
            this.panel2.Controls.Add(this.tbDatabase);
            this.panel2.Location = new System.Drawing.Point(25, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(505, 28);
            this.panel2.TabIndex = 47;
            // 
            // MongoDbEDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgKeyValue);
            this.Name = "MongoDbEDI";
            this.Text = "MongoDbEDI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MongoDbEDI_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgKeyValue)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.TextBox tbTextToSearch;
        private System.Windows.Forms.DataGridView dgKeyValue;
        private System.Windows.Forms.ComboBox cbFieldName;
        private System.Windows.Forms.TextBox tbServer;
        private System.Windows.Forms.Label lbServer;
        private System.Windows.Forms.Label lbDatabase;
        private System.Windows.Forms.TextBox tbDatabase;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem downloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadAndViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbSearchType;
    }
}