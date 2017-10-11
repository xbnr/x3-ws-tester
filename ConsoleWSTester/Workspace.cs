using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ConsoleWSTester
{
    public partial class Workspace : UserControl
    {
        public Workspace()
        {
            InitializeComponent();
            cbMode.DataSource = Enum.GetNames(typeof(WebServiceCall.OperationMode));
        }

        private string filename;

        internal void SaveWorkspace()
        {
            var config = GetConfigFromUI();
            string wsDirectory = WorkspaceConfig.GetWorkspaceDirectory();
            if (!Directory.Exists(wsDirectory))
                Directory.CreateDirectory(wsDirectory);

            if (string.IsNullOrEmpty(this.filename))
                this.filename = WorkspaceConfig.GetWorkspaceFilename();

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
            WorkspaceConfig config = JsonConvert.DeserializeObject<WorkspaceConfig>(File.ReadAllText(filename));
            SetTextFromSettings(config.HostUrl, this.tbHost);
            SetTextFromSettings(config.PoolAlias, this.tbPoolAlias);
            SetTextFromSettings(config.Language, this.cbLanguage);
            SetTextFromSettings(config.PublicName, this.cbPublicName);
            this.cbMode.SelectedIndex = (int)config.OperatMode;
            SetTextFromSettings(config.RequestConfiguration, this.tbRequestConfiguration);

            foreach (var item in config.ObjectKeys)
            {
                SetTextFromSettings(item.key, this.tbKey);
                SetTextFromSettings(item.value, this.tbValue);
            }
            SetTextFromSettings(config.XmlFilename, this.tbXmlFilename);
        }

        private WorkspaceConfig GetConfigFromUI()
        {
            CAWebService.CAdxParamKeyValue[] objectKeys = null;
            if (!string.IsNullOrEmpty(tbKey.Text))
            {
                objectKeys = new CAWebService.CAdxParamKeyValue[1];
                objectKeys[0] = new CAWebService.CAdxParamKeyValue();
                objectKeys[0].key = tbKey.Text;
                objectKeys[0].value = tbValue.Text;
            }

            WorkspaceConfig conf = new WorkspaceConfig();
            string opStringVal = string.IsNullOrEmpty(cbMode.Text) ? WebServiceCall.OperationMode.Query.ToString() : cbMode.Text;
            WebServiceCall.OperationMode opEnum = WebServiceCall.OperationMode.Query;
            if (!Enum.TryParse(opStringVal, out opEnum))
            {
                Console.WriteLine("Enum.Parse(" + opStringVal + ") failed");
            }
            conf.OperatMode = opEnum;
            conf.HostUrl = tbHost.Text;
            conf.PoolAlias = tbPoolAlias.Text;
            conf.Language = cbLanguage.Text;
            conf.PublicName = cbPublicName.Text;
            conf.ObjectKeys = objectKeys;
            conf.RequestConfiguration = tbRequestConfiguration.Text;
            conf.XmlFilename = tbXmlFilename.Text;
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
            WorkspaceConfig conf = GetConfigFromUI();

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
            return (WebServiceCall.OperationMode)Enum.Parse(typeof(WebServiceCall.OperationMode), cbMode.Text);
        }

        private void btBrowse_Click(object sender, EventArgs e)
        {
            var folder = new OpenFileDialog();
            folder.Multiselect = false;
            folder.InitialDirectory = @"C:\Users\frdepo\OneDrive - Sage Software, Inc\X3\X3-57422-SOAP Web Services - deleting lines on orders and quotes";
            var result = folder.ShowDialog();

            tbXmlFilename.Text = folder.FileName;
        }

        private void Workspace_Load(object sender, EventArgs e)
        {
           // cbMode.DataSource = Enum.GetValues(typeof( WebServiceCall.OperationMode));

        }


    }
}
