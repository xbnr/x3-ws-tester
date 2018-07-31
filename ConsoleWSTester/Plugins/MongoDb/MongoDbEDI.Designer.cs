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
            this.btSearch = new System.Windows.Forms.Button();
            this.tbDocumentGuid = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btSearch
            // 
            this.btSearch.Location = new System.Drawing.Point(395, 29);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(75, 23);
            this.btSearch.TabIndex = 0;
            this.btSearch.Text = "Search";
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // tbDocumentGuid
            // 
            this.tbDocumentGuid.Location = new System.Drawing.Point(87, 31);
            this.tbDocumentGuid.Name = "tbDocumentGuid";
            this.tbDocumentGuid.Size = new System.Drawing.Size(302, 20);
            this.tbDocumentGuid.TabIndex = 1;
            // 
            // MongoDbEDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tbDocumentGuid);
            this.Controls.Add(this.btSearch);
            this.Name = "MongoDbEDI";
            this.Text = "MongoDbEDI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.TextBox tbDocumentGuid;
    }
}