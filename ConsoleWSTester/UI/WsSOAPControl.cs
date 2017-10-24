using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Environment;

namespace ConsoleTester
{
    public partial class Workspace : UserControl
    {
        private string filename;
        private List<CAWebService.CAdxParamKeyValue> parametersDS = new List<CAWebService.CAdxParamKeyValue>();


        public Workspace()
        {
            InitializeComponent();
            FillComboBox();
        }

        private void FillComboBox()
        {
            cbMode.DataSource = Enum.GetNames(typeof(WebServiceCall.OperationMode));
            cbListSize.DataSource = Enumerable.Range(0, 100).ToArray();
        }

        internal void SaveWorkspace()
        {
            var config = GetConfigFromUI();
            string wsDirectory = Program.GetWorkspaceDirectory();
            if (!Directory.Exists(wsDirectory))
                Directory.CreateDirectory(wsDirectory);

            if (string.IsNullOrEmpty(this.filename))
            {
                this.filename = SOAPConfig.GetWorkspaceFilename();
            }
            string json = JsonConvert.SerializeObject(config, Formatting.Indented, new JsonSerializerSettings
            {
                Converters = new List<JsonConverter> { new StringEnumConverter() },
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented,
                DefaultValueHandling = DefaultValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });

            File.WriteAllText(this.filename, json, Encoding.UTF8);
        }

        internal void LoadConfigFromJSON(string filename)
        {
            this.filename = filename;
            SOAPConfig config = JsonConvert.DeserializeObject<SOAPConfig>(File.ReadAllText(filename));
            SetTextFromSettings(config.HostUrl, this.tbHost);
            SetTextFromSettings(config.Path, this.cbPath);
            SetTextFromSettings(config.PoolAlias, this.tbPoolAlias);
            SetTextFromSettings(config.Language, this.cbLanguage);
            SetTextFromSettings(config.PublicName, this.cbPublicName);
            this.cbListSize.SelectedIndex = (int)config.ListSize - 1;
            this.cbMode.SelectedIndex = (int)config.OperatMode;
            SetTextFromSettings(config.Login, this.tbLogin);
            SetTextFromSettings(config.Password, this.tbPassword);
            SetTextFromSettings(config.RequestConfiguration, this.tbRequestConfiguration);

            if (config.ObjectKeys != null)
            {
                parametersDS.AddRange(config.ObjectKeys);
                dgKeyValue.DataSource = parametersDS;                
            }

            SetTextFromSettings(config.BlocKey, this.tbBlocKey);
            if (config.LineKeys != null)
            {
                this.tbLineKeys.Text = string.Join(",", config.LineKeys);
            }
            SetTextFromSettings(config.XmlFilename, this.tbXmlFilename);
            if (!string.IsNullOrEmpty(config.XmlFilename) && File.Exists(config.XmlFilename))
            {
                ShowFileText(config.XmlFilename);
            }
        }

        private void ShowFileText(string xmlFile)
        {
            this.tbXmlObject.Text = File.ReadAllText(xmlFile);
            this.tbXmlObject.ReadOnly = true;
        }


        private SOAPConfig GetConfigFromUI()
        {
            CAWebService.CAdxParamKeyValue[] objectKeys = null;

            objectKeys = new CAWebService.CAdxParamKeyValue[this.parametersDS.Count];
            this.parametersDS.CopyTo(objectKeys);

            SOAPConfig conf = new SOAPConfig();
            string opStringVal = string.IsNullOrEmpty(cbMode.Text) ? WebServiceCall.OperationMode.Query.ToString() : cbMode.Text;
            WebServiceCall.OperationMode opEnum = WebServiceCall.OperationMode.Query;
            if (!Enum.TryParse(opStringVal, out opEnum))
            {
                Console.WriteLine("Enum.Parse(" + opStringVal + ") failed");
            }
            conf.OperatMode = opEnum;
            conf.HostUrl = tbHost.Text;
            conf.Path = cbPath.Text;
            conf.PoolAlias = tbPoolAlias.Text;
            conf.Language = cbLanguage.Text;
            conf.PublicName = cbPublicName.Text;
            int listSize = 10;
            int.TryParse(cbListSize.Text, out listSize);
            conf.ListSize = listSize;
            conf.ObjectKeys = objectKeys;
            conf.RequestConfiguration = tbRequestConfiguration.Text;
            conf.XmlFilename = tbXmlFilename.Text;
            // DeleteLines
            conf.BlocKey = tbBlocKey.Text;
            conf.LineKeys = this.tbLineKeys.Text.Split(new char[] { ',', ';', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            conf.Login = tbLogin.Text;
            conf.Password = tbPassword.Text;
            return conf;
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
                controlBox.Items.Add(settingValue);
                controlBox.SelectedItem = settingValue;
            }
        }


        private void launch_Click(object sender, EventArgs e)
        {
            Logger logger = new Logger(tbLogs);
            SOAPConfig conf = GetConfigFromUI();

            var ws = new WebServiceCall(conf, logger);
            WebServiceCall.OperationMode action = GetAction();
            switch (action)
            {
                default:
                case WebServiceCall.OperationMode.Query:
                    ws.Query();
                    break;
                case WebServiceCall.OperationMode.Read:
                    ws.Read();
                    break;
                case WebServiceCall.OperationMode.GetDescription:
                    ws.GetDescription();
                    break;
                case WebServiceCall.OperationMode.Modify:
                    ws.Modify(tbXmlFilename.Text);
                    break;
                case WebServiceCall.OperationMode.DeleteLines:
                    ws.Modify(tbXmlFilename.Text);
                    break;
                case WebServiceCall.OperationMode.Save:
                    ws.Save(tbXmlFilename.Text);
                    break;
            }
        }


        private WebServiceCall.OperationMode GetAction()
        {
            return (WebServiceCall.OperationMode)Enum.Parse(typeof(WebServiceCall.OperationMode), cbMode.Text);
        }

        private void btBrowse_Click(object sender, EventArgs e)
        {
            var folder = new OpenFileDialog();
            folder.Multiselect = false;
            folder.InitialDirectory = Environment.GetFolderPath(SpecialFolder.MyDocuments); // @"C:\Users\frdepo\OneDrive - Sage Software, Inc\X3\X3-57422-SOAP Web Services - deleting lines on orders and quotes";
            var result = folder.ShowDialog();

            tbXmlFilename.Text = folder.FileName;
            ShowFileText(folder.FileName);
        }

        private void Workspace_Load(object sender, EventArgs e)
        {

        }

        private void llClearConsole_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tbLogs.Clear();
        }

        private void cbMode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btAddParam_Click(object sender, EventArgs e)
        {
            var keyValue = new CAWebService.CAdxParamKeyValue();
            keyValue.key = "Key" + this.parametersDS.Count;
            keyValue.value = "value";
            this.parametersDS.Add(keyValue);
            dgKeyValue.DataSource = null;
            dgKeyValue.DataSource = this.parametersDS;
        }
    }
}
