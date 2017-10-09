using System;
using System.Windows.Forms;

namespace ConsoleWSTester
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void InitSettings()
        {
            SetTextFromSettings(Settings.Default.Host, this.tbHost);
            SetTextFromSettings(Settings.Default.PoolAlias, this.tbPoolAlias);
            SetTextFromSettings(Settings.Default.Language, this.cbLanguage);
            SetTextFromSettings(Settings.Default.PublicName, this.cbPublicName);
            SetTextFromSettings(Settings.Default.OperationMode, this.cbMode);
            SetTextFromSettings(Settings.Default.RequestConfiguration, this.tbRequestConfiguration);
            SetTextFromSettings(Settings.Default.Key0, this.tbKey);
            SetTextFromSettings(Settings.Default.Value0, this.tbValue);
            SetTextFromSettings(Settings.Default.XmlFilename, this.tbXmlFilename);
        }

        private void SaveSettings()
        {
            Settings.Default.Host = this.tbHost.Text;
            Settings.Default.PoolAlias = this.tbPoolAlias.Text;
            Settings.Default.Language = this.cbLanguage.Text;
            Settings.Default.PublicName = this.cbPublicName.Text;
            Settings.Default.OperationMode = this.cbMode.Text;
            Settings.Default.RequestConfiguration = this.tbRequestConfiguration.Text;
            Settings.Default.Key0 = this.tbKey.Text;
            Settings.Default.Value0 = this.tbValue.Text;
            Settings.Default.XmlFilename = this.tbXmlFilename.Text;
            Settings.Default.Save();
        }

        private void SetTextFromSettings(string settingValue, TextBox textBox)
        {
            if (!string.IsNullOrEmpty(settingValue))
            {
                textBox.Text = settingValue;
            }
        }

        private void SetTextFromSettings(string settingValue, ComboBox controlBox)
        {
            if (!string.IsNullOrEmpty(settingValue))
            {
                controlBox.Text = settingValue;
            }
        }


        private void launch_Click(object sender, EventArgs e)
        {
            Logger logger = new Logger(tbLogs);

            CAWebService.CAdxParamKeyValue[] objectKeys = null;
            if (!string.IsNullOrEmpty(tbKey.Text))
            {
                objectKeys = new CAWebService.CAdxParamKeyValue[1];
                objectKeys[0] = new CAWebService.CAdxParamKeyValue();
                objectKeys[0].key = tbKey.Text;
                objectKeys[0].value = tbValue.Text;
            }

            var ws = new WebServiceCall(tbHost.Text, tbPoolAlias.Text, cbLanguage.Text, cbPublicName.Text, objectKeys, logger);
            WebServiceCall.OperationMode action = GetAction();
            switch (action)
            {
                default:
                case WebServiceCall.OperationMode.Query:
                    ws.Query();
                    break;
                case WebServiceCall.OperationMode.Modify:
                    ws.Modify(tbXmlFilename.Text);
                    break;
                case WebServiceCall.OperationMode.Save:
                    ws.Save(tbXmlFilename.Text);
                    break;
            }
        }

        private WebServiceCall.OperationMode GetAction()
        {
            var action = WebServiceCall.OperationMode.Query;
            if (!string.IsNullOrEmpty(cbMode.Text))
            {
                if (cbMode.Text.Equals("modify", StringComparison.CurrentCultureIgnoreCase))
                {
                    action = WebServiceCall.OperationMode.Modify;
                }
                else if (cbMode.Text.Equals("save", StringComparison.CurrentCultureIgnoreCase))
                {
                    action = WebServiceCall.OperationMode.Save;
                }
            }

            return action;
        }

        private void btBrowse_Click(object sender, EventArgs e)
        {
            var folder = new OpenFileDialog();
            folder.Multiselect = false;
            folder.InitialDirectory = @"C:\Users\frdepo\OneDrive - Sage Software, Inc\X3\X3-57422-SOAP Web Services - deleting lines on orders and quotes";
            var result = folder.ShowDialog();

            tbXmlFilename.Text = folder.FileName;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            InitSettings();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }
    }
}
