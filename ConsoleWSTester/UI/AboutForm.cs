//------------------------------------------------------------------------
// © The Sage Group plc 2000   All Rights Reserved.
//------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace ConsoleTester.UI
{
    internal sealed partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            InitializeProductInformation();
        }

        private void OkButtonClick(object sender, EventArgs e) => Close();

        private void InitializeProductInformation()
        {
            _labelProductName.Text = Program.GetApplicationName();
            _labelVersion.Text = Program.GetApplicationVersion();
        }

        private void SystemButtonClick(object sender, EventArgs e) => Process.Start("msinfo32.exe");

        private string _urlDownload;

        private void _linkLabelUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Updater updater = new Updater();

            if (updater.UpTodate())
            {
                _labelMessageUpToDate.Text = "Parfait: Votre version est à jour !";
            }
            else
            {
                _labelMessageUpToDate.Text = $"Une version plus récente est disponible: {updater.OnLineVersion?.Version}";
                if (updater.OnLineVersion != null)
                {
                    _urlDownload = updater.OnLineVersion.DownloadUrl;
                    _linkLabelDownload.Visible = true;
                    _linkLabelDownload.Refresh();
                    _labelInformation.Text = "";
                    foreach (var item in updater.AllVersions)
                    {
                        _labelInformation.Text += $"{item.Date.ToShortDateString()} {Environment.NewLine}";
                        _labelInformation.Text += $"{item.Description.Replace("\n", Environment.NewLine)} { Environment.NewLine } { Environment.NewLine }";
                    }
                }
                _labelInformation.BackColor = System.Drawing.Color.Black;
                _labelInformation.Visible = true;
                _labelInformation.Refresh();
            }
            _labelMessageUpToDate.Visible = true;
            _labelMessageUpToDate.Refresh();
        }

        private void _linkLabelDowload_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("explorer", Path.GetDirectoryName(_urlDownload));
            Process.Start("explorer", _urlDownload);
            MainForm.Instance.Close();
        }

        private void linkLabelInformation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }
    }
}