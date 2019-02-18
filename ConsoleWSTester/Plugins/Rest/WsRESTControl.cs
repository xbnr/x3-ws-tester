using ConsoleTester.CAWebService;
using ConsoleTester.Common;
using ConsoleTester.Plugins;
using ConsoleTester.UI;
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

namespace ConsoleTester.Plugins.Rest
{
    public partial class WsRESTControl : ControlConfig
    {
        private string filename;

        public WsRESTControl()
        {
            InitializeComponent();
            FillComboBox();
        }

        private void FillComboBox()
        {
            // cbMode.DataSource = Enum.GetNames(typeof(WebServiceCall.OperationMode));
        }

        public override void SaveWorkspace()
        {
            var config = GetConfigFromUI();
            string wsDirectory = Program.GetWorkspaceDirectory();
            if (!Directory.Exists(wsDirectory))
            {
                Directory.CreateDirectory(wsDirectory);
            }
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

            // this.cbMode.SelectedIndex = (int)config.OperatMode;
            SetTextFromSettings(config.Login, this.tbLogin);
            SetTextFromSettings(config.Password, this.tbPassword);

            ShowPanels();
        }

       
        public override IConfigService GetConfigFromUI()
        {
            RESTConfig conf = new RESTConfig
            {
                // conf.OperatMode = opEnum;
                HostUrl = tbHost.Text,
                Path = cbPath.Text,
                // int listSize = 10;
                // conf.ListSize = listSize;

                Login = tbLogin.Text,
                Password = tbPassword.Text
            };
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
            //Logger logger = new Logger(MainForm.LogControl);
            //SOAPConfig conf = GetConfigFromUI();

            //var ws = new SOAPWebServiceCall(conf, logger);
            //SOAPWebServiceCall.OperationMode action = GetAction();
            //switch (action)
            //{
            //    default:
            //    case SOAPWebServiceCall.OperationMode.Query:
            //        ws.Query();
            //        break;
            //    case SOAPWebServiceCall.OperationMode.Read:
            //        ws.Read();
            //        break;
            //    case SOAPWebServiceCall.OperationMode.GetDescription:
            //        ws.GetDescription();
            //        break;
            //}
        }
       

        private void Workspace_Load(object sender, EventArgs e)
        {

        }


        private void ShowPanels()
        {
            //panelParameters.Visible = GetAction() == SOAPWebServiceCall.OperationMode.Read;
        }

        private void btAddParam_Click(object sender, EventArgs e)
        {
            var keyValue = new CAWebService.CAdxParamKeyValue();
            keyValue.value = "value";
            dgKeyValue.DataSource = null;
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (dgKeyValue.SelectedRows.Count > 0)
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
