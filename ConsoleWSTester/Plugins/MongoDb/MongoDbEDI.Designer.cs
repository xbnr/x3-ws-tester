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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btSearch = new System.Windows.Forms.Button();
            this.tbTextToSearch = new System.Windows.Forms.TextBox();
            this.dgKeyValue = new System.Windows.Forms.DataGridView();
            this.cbFieldName = new System.Windows.Forms.ComboBox();
            this.tbServer = new System.Windows.Forms.TextBox();
            this.lbServer = new System.Windows.Forms.Label();
            this.lbDatabase = new System.Windows.Forms.Label();
            this.tbDatabase = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.downloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgKeyValue)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btSearch
            // 
            this.btSearch.Location = new System.Drawing.Point(340, 8);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(133, 22);
            this.btSearch.TabIndex = 0;
            this.btSearch.Text = "Search";
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // tbTextToSearch
            // 
            this.tbTextToSearch.Location = new System.Drawing.Point(140, 10);
            this.tbTextToSearch.Name = "tbTextToSearch";
            this.tbTextToSearch.Size = new System.Drawing.Size(183, 20);
            this.tbTextToSearch.TabIndex = 1;
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
            this.dgKeyValue.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgKeyValue.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgKeyValue.Location = new System.Drawing.Point(25, 92);
            this.dgKeyValue.MultiSelect = false;
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
            this.dgKeyValue.Size = new System.Drawing.Size(763, 326);
            this.dgKeyValue.TabIndex = 40;
            this.dgKeyValue.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgKeyValue_RowPostPaint);
            // 
            // cbFieldName
            // 
            this.cbFieldName.FormattingEnabled = true;
            this.cbFieldName.Items.AddRange(new object[] {
            "filename",
            "_id",
            "md5"});
            this.cbFieldName.Location = new System.Drawing.Point(3, 10);
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
            this.panel1.Controls.Add(this.cbFieldName);
            this.panel1.Controls.Add(this.tbTextToSearch);
            this.panel1.Controls.Add(this.btSearch);
            this.panel1.Location = new System.Drawing.Point(25, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(481, 40);
            this.panel1.TabIndex = 46;
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
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.downloadToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(129, 26);
            // 
            // downloadToolStripMenuItem
            // 
            this.downloadToolStripMenuItem.Name = "downloadToolStripMenuItem";
            this.downloadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.downloadToolStripMenuItem.Text = "Download";
            this.downloadToolStripMenuItem.Click += new System.EventHandler(this.downloadToolStripMenuItem_Click);
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
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
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
    }
}