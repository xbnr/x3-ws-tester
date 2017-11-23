using ConsoleTester.CAWebService;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace ConsoleTester.UI
{
    public partial class WsRESTControl : DockContent
    {
        private string filename;

        public WsRESTControl()
        {
            InitializeComponent();
            FillComboBox();
        }

        private void FillComboBox()
        {
            cbMode.DataSource = Enum.GetNames(typeof(WebServiceCall.OperationMode));
        }

        internal void SaveWorkspace()
        {
            var config = GetConfigFromUI();
            string wsDirectory = Program.GetWorkspaceDirectory();
            if (!Directory.Exists(wsDirectory))
                Directory.CreateDirectory(wsDirectory);

            if (string.IsNullOrEmpty(this.filename))
            {
                this.filename = RESTConfig.GetWorkspaceFilename();
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
            RESTConfig config = JsonConvert.DeserializeObject<RESTConfig>(File.ReadAllText(filename));
            SetTextFromSettings(config.HostUrl, this.tbHost);
            SetTextFromSettings(config.Path, this.cbPath);
           
            this.cbMode.SelectedIndex = (int)config.OperatMode;
            SetTextFromSettings(config.Login, this.tbLogin);
            SetTextFromSettings(config.Password, this.tbPassword);

            ShowPanels();
        }

        private void ShowFileText(string xmlFile)
        {
            //this.tbXmlObject.Text = File.ReadAllText(xmlFile);
            //this.tbXmlObject.ReadOnly = true;
        }


        private SOAPConfig GetConfigFromUI()
        {
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
            int listSize = 10;
            conf.ListSize = listSize;

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
            Logger logger = new Logger(MainForm.LogControl);
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
            }
        }


        private WebServiceCall.OperationMode GetAction()
        {
            return (WebServiceCall.OperationMode)Enum.Parse(typeof(WebServiceCall.OperationMode), cbMode.Text);
        }

        private void Workspace_Load(object sender, EventArgs e)
        {

        }

        private void cbMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowPanels();

        }

        private void ShowPanels()
        {
            panelParameters.Visible = GetAction() == WebServiceCall.OperationMode.Read;
        }

        private void btAddParam_Click(object sender, EventArgs e)
        {
            var keyValue = new CAWebService.CAdxParamKeyValue();
            keyValue.value = "value";
            dgKeyValue.DataSource = null;
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (dgKeyValue.SelectedRows.Count>0)
            {
                var selectedObj = dgKeyValue.SelectedRows[0];
                CAdxParamKeyValue selectedValue = selectedObj.DataBoundItem as CAdxParamKeyValue;
                if (selectedValue != null)
                {
                    dgKeyValue.DataSource = null;
                }
            }
        }
    }
}
