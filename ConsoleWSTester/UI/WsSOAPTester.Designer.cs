namespace ConsoleTester.UI
{
    partial class WsSOAPTester
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
            this.workspace1 = new ConsoleTester.Workspace();
            this.SuspendLayout();
            // 
            // workspace1
            // 
            this.workspace1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.workspace1.Location = new System.Drawing.Point(-1, -3);
            this.workspace1.Name = "workspace1";
            this.workspace1.Size = new System.Drawing.Size(675, 549);
            this.workspace1.TabIndex = 0;
            // 
            // WsSOAPTester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 576);
            this.Controls.Add(this.workspace1);
            this.Name = "WsSOAPTester";
            this.Text = "WsSOAPTester";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WsSOAPTester_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private Workspace workspace1;
    }
}