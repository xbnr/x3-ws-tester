using ConsoleTester.CAWebService;
using ConsoleTester.Common;
using ConsoleTester.Plugins;
using ConsoleTester.Plugins.Soap;
using ConsoleTester.UI;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleTester.Plugins.Soap
{
    public partial class WsSOAPTester : ControlConfigUI
    {
        private string filename;
        private List<CAWebService.CAdxParamKeyValue> parametersDS = new List<CAWebService.CAdxParamKeyValue>();

        public WsSOAPTester()
        {
            InitializeComponent();
            FillComboBox();
        }
        public override void CreateWS(FileInfo item)
        {
            LoadConfigFromJSON(item.FullName);
        }

        private void FillComboBox()
        {
            cbMode.DataSource = Enum.GetNames(typeof(SOAPWebServiceCall.OperationMode));
            cbListSize.DataSource = Enumerable.Range(0, 100).ToArray();
            domainUpTimes.Items.AddRange(Enumerable.Range(1, 100).ToList());
            domainUpDelay.Items.AddRange(Enumerable.Range(0, 100).ToList());
        }

        public override void SetWorkspaceFilename(string filename)
        {
            this.filename = filename;
        }

        public override string GetDefaultWorkspaceFilename()
        {
            return SOAPConfig.GetWorkspaceFilename();
        }

        public override string GetWorkspaceFilename()
        {
            if (string.IsNullOrEmpty(this.filename))
            {
                this.filename = GetDefaultWorkspaceFilename();
            }
            return this.filename;
        } 

        internal void LoadConfigFromJSON(string filename)
        {
            this.filename = filename;
            SOAPConfig config = JsonConvert.DeserializeObject<SOAPConfig>(File.ReadAllText(filename));
            Helper.SetTextFromSettings(config.HostUrl, this.tbHost);
            Helper.SetTextFromSettings(config.Path, this.cbPath);
            Helper.SetTextFromSettings(config.PoolAlias, this.tbPoolAlias);
            Helper.SetTextFromSettings(config.Language, this.cbLanguage);
            Helper.SetTextFromSettings(config.PublicName, this.cbPublicName);
            this.cbListSize.SelectedIndex = (int)config.ListSize - 1;
            this.cbMode.SelectedIndex = (int)config.OperatMode;
            Helper.SetTextFromSettings(config.Login, this.tbLogin);
            Helper.SetTextFromSettings(config.Password, this.tbPassword);
            Helper.SetTextFromSettings(config.RequestConfiguration, this.tbRequestConfiguration);

            if (config.ObjectKeys != null)
            {
                parametersDS.AddRange(config.ObjectKeys);
                dgKeyValue.DataSource = parametersDS;
            }

            Helper.SetTextFromSettings(config.BlocKey, this.tbBlocKey);
            if (config.LineKeys != null)
            {
                this.tbLineKeys.Text = string.Join(",", config.LineKeys);
            }
            Helper.SetTextFromSettings(config.XmlFilename, this.tbXmlFilename);
            if (!string.IsNullOrEmpty(config.XmlFilename) && File.Exists(config.XmlFilename))
            {
                ShowFileText(config.XmlFilename);
            }
            ShowPanels();
        }

        private void ShowFileText(string xmlFile)
        {
            this.tbXmlObject.Text = File.ReadAllText(xmlFile);
            this.tbXmlObject.ReadOnly = true;
        }


        public override IConfigService GetConfigFromUI()
        {
            CAWebService.CAdxParamKeyValue[] objectKeys = null;

            objectKeys = new CAWebService.CAdxParamKeyValue[this.parametersDS.Count];
            this.parametersDS.CopyTo(objectKeys);

            SOAPConfig conf = new SOAPConfig();
            string opStringVal = string.IsNullOrEmpty(cbMode.Text) ? SOAPWebServiceCall.OperationMode.Query.ToString() : cbMode.Text;
            SOAPWebServiceCall.OperationMode opEnum = SOAPWebServiceCall.OperationMode.Query;
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
            if (string.IsNullOrEmpty(tbXmlFilename.Text))
            {
                conf.XmlObject = tbXmlObject.Text;
            }
            // DeleteLines
            conf.BlocKey = tbBlocKey.Text;
            conf.LineKeys = this.tbLineKeys.Text.Split(new char[] { ',', ';', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            conf.Login = tbLogin.Text;
            conf.Password = tbPassword.Text;
            return conf;
        }


        private void launch_Click(object sender, EventArgs e)
        {
            Launch();
        }

        private void Launch()
        {
            SOAPConfig conf = GetConfigFromUI() as SOAPConfig;

            var ws = new SOAPWebServiceCall(conf, Logger);
            SOAPWebServiceCall.OperationMode action = GetAction();

            string xml = tbXmlObject.Text;
            if (!string.IsNullOrEmpty(tbXmlFilename.Text) && File.Exists(tbXmlFilename.Text))
            {
                xml = File.ReadAllText(tbXmlFilename.Text);
            }

            int times = 1;
            if (!string.IsNullOrEmpty(domainUpTimes.Text))
            {
                times = Int32.Parse(domainUpTimes.Text);
            }
            float delayInSeconds = 0;
            if (!string.IsNullOrEmpty(domainUpDelay.Text))
            {
                float.TryParse(domainUpDelay.Text, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.GetCultureInfo("en-GB"), out delayInSeconds);
            }

            Task<CAWebService.CAdxResultXml> result = null;

            for (int i = 0; i < times; i++)
            {
                if (delayInSeconds > 0)
                {
                    Thread.Sleep((int)(delayInSeconds * 1000));
                }

                switch (action)
                {
                    default:
                    case SOAPWebServiceCall.OperationMode.Query:
                        result = ws.Query();
                        break;
                    case SOAPWebServiceCall.OperationMode.Read:
                        result = ws.Read();
                        break;
                    case SOAPWebServiceCall.OperationMode.GetDescription:
                        result = ws.GetDescription();
                        break;
                    case SOAPWebServiceCall.OperationMode.Modify:
                        result = ws.Modify(xml);
                        break;
                    case SOAPWebServiceCall.OperationMode.DeleteLines:
                        result = ws.Modify(xml);
                        break;
                    case SOAPWebServiceCall.OperationMode.Save:
                        result = ws.Save(xml);
                        break;
                    case SOAPWebServiceCall.OperationMode.Run:
                        result = ws.Run(xml);
                        break;
                }

                result.ContinueWith((input) => { Helper.SetSafeText(labelStatus, $"{input.Result?.status} ({(input.Result?.status== 1 ? "Success": "Error(s)")})" ); });
                result.ContinueWith((input) => { Logger.Log($"Result Status { input.Result?.status}"); });
            }
        }

        private Task InitAnswerStatus()
        {
            
             return null;
        }


        private SOAPWebServiceCall.OperationMode GetAction()
        {
            return (SOAPWebServiceCall.OperationMode)Enum.Parse(typeof(SOAPWebServiceCall.OperationMode), cbMode.Text);
        }

        private void btBrowse_Click(object sender, EventArgs e)
        {
            var folder = new OpenFileDialog();
            folder.Multiselect = false;
            folder.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); // @"C:\Users\frdepo\OneDrive - Sage Software, Inc\X3\X3-57422-SOAP Web Services - deleting lines on orders and quotes";
            var result = folder.ShowDialog();

            tbXmlFilename.Text = folder.FileName;
            ShowFileText(folder.FileName);
        }

        private void cbMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowPanels();
        }

        private void ShowPanels()
        {
            panelDeleteLines.Visible = GetAction() == SOAPWebServiceCall.OperationMode.DeleteLines;
            panelParameters.Visible = GetAction() == SOAPWebServiceCall.OperationMode.Read;
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

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (dgKeyValue.SelectedRows.Count > 0)
            {
                var selectedObj = dgKeyValue.SelectedRows[0];
                CAdxParamKeyValue selectedValue = selectedObj.DataBoundItem as CAdxParamKeyValue;
                if (selectedValue != null)
                {
                    this.parametersDS.Remove(selectedValue);
                    dgKeyValue.DataSource = null;
                    dgKeyValue.DataSource = this.parametersDS;
                }
            }
        }
    }
}
