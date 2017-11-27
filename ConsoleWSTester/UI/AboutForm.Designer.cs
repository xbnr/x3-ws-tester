//------------------------------------------------------------------------
// © The Sage Group plc 2000   All Rights Reserved.
//------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ConsoleTester.UI
{
	internal sealed partial class AboutForm
	{
	    private TextBox _labelProductName;
		private TextBox _labelVersion;
		private Label _labelInternalUse;
		private Button _systemButton;
		private Button _OKButton;
		private Container components = null;

	    /// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this._labelProductName = new System.Windows.Forms.TextBox();
            this._labelVersion = new System.Windows.Forms.TextBox();
            this._labelInternalUse = new System.Windows.Forms.Label();
            this._systemButton = new System.Windows.Forms.Button();
            this._OKButton = new System.Windows.Forms.Button();
            this._linkLabelUpdate = new System.Windows.Forms.LinkLabel();
            this._labelMessageUpToDate = new System.Windows.Forms.Label();
            this._linkLabelDownload = new System.Windows.Forms.LinkLabel();
            this.linkLabelInformation = new System.Windows.Forms.LinkLabel();
            this._labelInformation = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // _labelProductName
            // 
            this._labelProductName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this._labelProductName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this._labelProductName, "_labelProductName");
            this._labelProductName.ForeColor = System.Drawing.Color.White;
            this._labelProductName.Name = "_labelProductName";
            this._labelProductName.ReadOnly = true;
            // 
            // _labelVersion
            // 
            this._labelVersion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this._labelVersion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this._labelVersion, "_labelVersion");
            this._labelVersion.ForeColor = System.Drawing.Color.White;
            this._labelVersion.Name = "_labelVersion";
            this._labelVersion.ReadOnly = true;
            // 
            // _labelInternalUse
            // 
            this._labelInternalUse.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this._labelInternalUse, "_labelInternalUse");
            this._labelInternalUse.ForeColor = System.Drawing.Color.White;
            this._labelInternalUse.Name = "_labelInternalUse";
            // 
            // _systemButton
            // 
            resources.ApplyResources(this._systemButton, "_systemButton");
            this._systemButton.Name = "_systemButton";
            this._systemButton.Click += new System.EventHandler(this.SystemButtonClick);
            // 
            // _OKButton
            // 
            this._OKButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this._OKButton, "_OKButton");
            this._OKButton.Name = "_OKButton";
            this._OKButton.Click += new System.EventHandler(this.OkButtonClick);
            // 
            // _linkLabelUpdate
            // 
            resources.ApplyResources(this._linkLabelUpdate, "_linkLabelUpdate");
            this._linkLabelUpdate.BackColor = System.Drawing.Color.Transparent;
            this._linkLabelUpdate.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this._linkLabelUpdate.LinkColor = System.Drawing.Color.White;
            this._linkLabelUpdate.Name = "_linkLabelUpdate";
            this._linkLabelUpdate.TabStop = true;
            this._linkLabelUpdate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this._linkLabelUpdate_LinkClicked);
            // 
            // _labelMessageUpToDate
            // 
            this._labelMessageUpToDate.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this._labelMessageUpToDate, "_labelMessageUpToDate");
            this._labelMessageUpToDate.ForeColor = System.Drawing.Color.White;
            this._labelMessageUpToDate.Name = "_labelMessageUpToDate";
            // 
            // _linkLabelDownload
            // 
            resources.ApplyResources(this._linkLabelDownload, "_linkLabelDownload");
            this._linkLabelDownload.BackColor = System.Drawing.Color.Transparent;
            this._linkLabelDownload.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this._linkLabelDownload.LinkColor = System.Drawing.Color.White;
            this._linkLabelDownload.Name = "_linkLabelDownload";
            this._linkLabelDownload.TabStop = true;
            this._linkLabelDownload.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this._linkLabelDowload_LinkClicked);
            // 
            // linkLabelInformation
            // 
            resources.ApplyResources(this.linkLabelInformation, "linkLabelInformation");
            this.linkLabelInformation.BackColor = System.Drawing.Color.Transparent;
            this.linkLabelInformation.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.linkLabelInformation.LinkColor = System.Drawing.Color.White;
            this.linkLabelInformation.Name = "linkLabelInformation";
            this.linkLabelInformation.TabStop = true;
            this.linkLabelInformation.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelInformation_LinkClicked);
            // 
            // _labelInformation
            // 
            this._labelInformation.BackColor = System.Drawing.SystemColors.InfoText;
            this._labelInformation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this._labelInformation, "_labelInformation");
            this._labelInformation.ForeColor = System.Drawing.Color.White;
            this._labelInformation.Name = "_labelInformation";
            this._labelInformation.ReadOnly = true;
            // 
            // AboutForm
            // 
            resources.ApplyResources(this, "$this");
            this.CancelButton = this._OKButton;
            this.Controls.Add(this._labelInformation);
            this.Controls.Add(this.linkLabelInformation);
            this.Controls.Add(this._linkLabelDownload);
            this.Controls.Add(this._labelMessageUpToDate);
            this.Controls.Add(this._linkLabelUpdate);
            this.Controls.Add(this._OKButton);
            this.Controls.Add(this._systemButton);
            this.Controls.Add(this._labelInternalUse);
            this.Controls.Add(this._labelProductName);
            this.Controls.Add(this._labelVersion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        private LinkLabel _linkLabelUpdate;
        private Label _labelMessageUpToDate;
        private LinkLabel _linkLabelDownload;
        private LinkLabel linkLabelInformation;
        private TextBox _labelInformation;
    }
}
