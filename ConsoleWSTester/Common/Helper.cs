using ConsoleTester.UI;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleTester.Common
{
    public static class Helper
    {
        public static void SaveWorkspace(string filename, IConfigService data)
        {
            string wsDirectory = Program.GetWorkspaceDirectory();

            if (!Directory.Exists(wsDirectory))
            {
                Directory.CreateDirectory(wsDirectory);
            }

            string json = JsonConvert.SerializeObject(data, Formatting.Indented, new JsonSerializerSettings
            {
                Converters = new List<JsonConverter> { new StringEnumConverter() },
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented,
                DefaultValueHandling = DefaultValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });

            if (File.Exists(filename))
            {
                string oldJson = File.ReadAllText(filename);
                if (!oldJson.Equals(json))
                {
                    DialogResult r = MessageBox.Show($"Data have changed. Do you want to save it to {Path.GetFileName(filename)} ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                    if (r == DialogResult.Yes)
                    {
                        File.WriteAllText(filename, json, Encoding.UTF8);
                    }
                }
            }
            else
            {
                File.WriteAllText(filename, json, Encoding.UTF8);
            }

        }

        public static void SetTextFromSettings(string settingValue, TextBox textBox)
        {
            if (!string.IsNullOrEmpty(settingValue))
            {
                textBox.Text = settingValue;
            }
        }

        public static void SetTextFromSettings(string settingValue, ComboBox controlBox)
        {
            if (!string.IsNullOrEmpty(settingValue))
            {
                if (controlBox.DataSource == null)
                {
                    controlBox.Items.Add(settingValue);
                }
                controlBox.SelectedItem = settingValue;
                //controlBox.SelectionStart = 0;
                //controlBox.SelectionLength = 0;
                controlBox.SelectedText = String.Empty;
                //if (settingValue.Length >= 0)
                //{
                //    controlBox.SelectionStart = settingValue.Length;
                //}
            }
        }

        public static ControlConfig GetUIControl(IConfigService configService)
        {
            Type formType = Type.GetType(configService.GetFormFullName());
            ControlConfig dockContent = Activator.CreateInstance(formType) as ControlConfig;
            return dockContent;
        }

        delegate void UpdateDatasourceDelegate(DataGridView dataGrid, object datasource);
        public static void SetSafeDatasource(DataGridView dataGrid, object datasource)
        {
            if (dataGrid.InvokeRequired)
            {
                dataGrid.Invoke(new UpdateDatasourceDelegate(SetSafeDatasource), new object[] { dataGrid, datasource });
            }
            else
            {
                dataGrid.DataSource = null;
                dataGrid.DataSource = datasource;
            }
        }

        delegate void UpdateDelegateCh(CheckBox control, bool check);

        public static void SetSafeCheck(CheckBox control, bool check)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new UpdateDelegateCh(SetSafeCheck), new object[] { control, check });
            }
            else
            {
                control.Checked = check;
            }
        }

        delegate void UpdateDelegate(Control control, string message);

        public static void SetSafeText(Control control, string text)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new UpdateDelegate(SetSafeText), new object[] { control, text });
            }
            else
            {
                control.Text = text;
            }
        }

        delegate void UpdateComboboxDelegate(ComboBox control, object itemValue);

        public static void SetSafeComboBox(ComboBox control, object itemValue)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new UpdateComboboxDelegate(SetSafeComboBox), new object[] { control, itemValue });
            }
            else
            {
                control.SelectedItem = itemValue;
                control.Text = itemValue?.ToString();
            }
        }
    }
}
