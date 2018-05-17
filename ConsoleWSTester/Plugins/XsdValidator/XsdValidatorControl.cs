using ConsoleTester.CAWebService;
using ConsoleTester.Common;
using ConsoleTester.Plugins;
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
    /// <summary>
    /// https://msdn.microsoft.com/en-us/library/wc8csdkz(v=vs.71).aspx
    /// </summary>
    public partial class XsdValidatorControl : ControlConfig
    {
        private string filename;

        public XsdValidatorControl()
        {
            InitializeComponent();
            FillComboBox();
        }

        private void FillComboBox()
        {
            // cbMode.DataSource = Enum.GetNames(typeof(WebServiceCall.OperationMode));
        }

        internal void SaveWorkspace()
        {
            if (string.IsNullOrEmpty(this.filename))
            {
                this.filename = XsdValidatorConfig.GetWorkspaceFilename();
            }
            Helper.SaveWorkspace(this.filename, GetConfigFromUI());
        }

        internal void LoadConfigFromJSON(string filename)
        {
            this.filename = filename;
            XsdValidatorConfig config = JsonConvert.DeserializeObject<XsdValidatorConfig>(File.ReadAllText(filename));
            Helper.SetTextFromSettings(config.XMLFilename, this.cbPath);
            if (config.XSDFiles != null)
            {
                List<FileInfo> list = new List<FileInfo>();
                foreach (var fullfilename in config.XSDFiles)
                {
                    list.Add(new FileInfo(fullfilename));
                }
                dgKeyValue.DataSource = list;
            }
        }


        private XsdValidatorConfig GetConfigFromUI()
        {
            XsdValidatorConfig conf = new XsdValidatorConfig();

            conf.XMLFilename = cbPath.Text;
            if (dgKeyValue.DataSource != null)
            {
                var fileList = dgKeyValue.DataSource as List<FileInfo>;
                conf.XSDFiles = fileList.ConvertAll(p => p.FullName);
            }
            return conf;
        }

        private void launch_Click(object sender, EventArgs e)
        {
            Logger logger = new Logger(MainForm.LogControl);
            var conf = GetConfigFromUI();



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

        private void btBrowseXML_Click(object sender, EventArgs e)
        {
            var folder = new OpenFileDialog();
            folder.Multiselect = false;
            folder.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); // @"C:\Users\frdepo\OneDrive - Sage Software, Inc\X3\X3-57422-SOAP Web Services - deleting lines on orders and quotes";
            var result = folder.ShowDialog();

            cbPath.Text = folder.FileName;
        }

        private void btBrowse_Click(object sender, EventArgs e)
        {
            var folder = new OpenFileDialog();
            folder.Multiselect = true;
            folder.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); // @"C:\Users\frdepo\OneDrive - Sage Software, Inc\X3\X3-57422-SOAP Web Services - deleting lines on orders and quotes";
            var result = folder.ShowDialog();

            List<FileInfo> fileList = new List<FileInfo>();
            foreach (var filename in folder.FileNames)
            {
                fileList.Add(new FileInfo(filename));
            }
            dgKeyValue.DataSource = fileList;
        }

        private void XsdValidatorControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveWorkspace();
        }

        public override void CreateWS(FileInfo item)
        {
            LoadConfigFromJSON(item.FullName);
        }
    }
}
