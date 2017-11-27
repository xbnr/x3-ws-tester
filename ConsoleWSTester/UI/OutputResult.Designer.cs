namespace ConsoleTester.UI
{
    partial class OutputResult
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
            this._listView = new System.Windows.Forms.ListView();
            this._columnHeaderType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._columnHeaderInstance = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._columnHeaderDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._columnHeaderParent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._columnHeaderProject = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // _listView
            // 
            this._listView.AllowColumnReorder = true;
            this._listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._listView.BackColor = System.Drawing.SystemColors.Window;
            this._listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._columnHeaderType,
            this._columnHeaderInstance,
            this._columnHeaderDescription,
            this._columnHeaderParent,
            this._columnHeaderProject});
            this._listView.FullRowSelect = true;
            this._listView.GridLines = true;
            this._listView.HideSelection = false;
            this._listView.Location = new System.Drawing.Point(-308, 24);
            this._listView.MultiSelect = false;
            this._listView.Name = "_listView";
            this._listView.ShowItemToolTips = true;
            this._listView.Size = new System.Drawing.Size(1373, 212);
            this._listView.TabIndex = 1;
            this._listView.UseCompatibleStateImageBehavior = false;
            this._listView.View = System.Windows.Forms.View.Details;
            // 
            // _columnHeaderType
            // 
            this._columnHeaderType.Text = "!";
            this._columnHeaderType.Width = 39;
            // 
            // _columnHeaderInstance
            // 
            this._columnHeaderInstance.Text = "Object";
            this._columnHeaderInstance.Width = 137;
            // 
            // _columnHeaderDescription
            // 
            this._columnHeaderDescription.Text = "Description";
            this._columnHeaderDescription.Width = 500;
            // 
            // _columnHeaderParent
            // 
            this._columnHeaderParent.Text = "Parent";
            this._columnHeaderParent.Width = 100;
            // 
            // _columnHeaderProject
            // 
            this._columnHeaderProject.Text = "Project";
            // 
            // OutputResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 259);
            this.Controls.Add(this._listView);
            this.Name = "OutputResult";
            this.Text = "OutputResult";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView _listView;
        private System.Windows.Forms.ColumnHeader _columnHeaderType;
        private System.Windows.Forms.ColumnHeader _columnHeaderInstance;
        private System.Windows.Forms.ColumnHeader _columnHeaderDescription;
        private System.Windows.Forms.ColumnHeader _columnHeaderParent;
        private System.Windows.Forms.ColumnHeader _columnHeaderProject;
    }
}