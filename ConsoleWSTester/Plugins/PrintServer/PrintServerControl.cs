﻿using ConsoleTester.CAWebService;
using ConsoleTester.Common;
using ConsoleTester.Plugins;
using ConsoleTester.UI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using WeifenLuo.WinFormsUI.Docking;

namespace ConsoleTester.Plugins.XsdValidator
{
    public partial class PrintServerControl : ControlConfig
    {
        private string filename;
        Logger logger = new Logger(MainForm.LogControl);

        public PrintServerControl()
        {
            InitializeComponent();
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
            PrintServerConfig config = JsonConvert.DeserializeObject<PrintServerConfig>(File.ReadAllText(filename));
            Helper.SetTextFromSettings(config.RootDirectory, this.cbPath);
            if (config.XSDFiles != null)
            {
                InitGridView();

                List<FileInfo> list = new List<FileInfo>();
                foreach (var fullfilename in config.XSDFiles)
                {
                    if (File.Exists(fullfilename))
                    {
                        list.Add(new FileInfo(fullfilename));
                    }
                    else
                    {
                        logger.Log($"{fullfilename} doesn't exist");
                    }
                }
                dgKeyValue.DataSource = list;
            }
       }

        private void InitGridView()
        {
            dgKeyValue.Columns.Clear();
            dgKeyValue.AutoGenerateColumns = false;
            dgKeyValue.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            DataGridViewCell cell = new DataGridViewTextBoxCell();
            DataGridViewTextBoxColumn colFileName = new DataGridViewTextBoxColumn()
            {
                CellTemplate = cell,
                HeaderText = "Name",
                Name = "Name",
                DataPropertyName = "Name" // Tell the column which property of FileName it should use
            };
            DataGridViewTextBoxColumn colFileDir = new DataGridViewTextBoxColumn()
            {
                CellTemplate = cell,
                HeaderText = "Directory",
                Name = "Directory",
                DataPropertyName = "Directory"
            };
            DataGridViewTextBoxColumn colFileLength = new DataGridViewTextBoxColumn()
            {
                CellTemplate = cell,
                HeaderText = "Length",
                Name = "Length",
                DataPropertyName = "Length",
                Resizable = DataGridViewTriState.True
            };

            dgKeyValue.Columns.Add(colFileName);
            dgKeyValue.Columns.Add(colFileDir);
            dgKeyValue.Columns.Add(colFileLength);
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
            conf.ShowWarnings = cbShowWarnings.Checked;
            return conf;
        }

        private void launch_Click(object sender, EventArgs e)
        {
            var conf = GetConfigFromUI();

            MessageBox.Show("TODO");
        }

        private void btAddParam_Click(object sender, EventArgs e)
        {
            var keyValue = new CAWebService.CAdxParamKeyValue();
            keyValue.value = "value";
            dgKeyValue.DataSource = null;
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            RemoveSelectedFiles();
        }

        private FileInfo GetSelectedFile()
        {
            if (dgKeyValue.SelectedRows.Count != 1)
            {
                MessageBox.Show($"Please, select just one xsd file", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            var selectedObj = dgKeyValue.SelectedRows[0];
            FileInfo selectedValue = selectedObj.DataBoundItem as FileInfo;
            return selectedValue;
        }


        private void normalizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectedValue = GetSelectedFile();
            if (selectedValue != null)
            {
                XsdSchemaNormalizer normalizer = new XsdSchemaNormalizer();
                string dest = selectedValue.FullName + ".normalized" + selectedValue.Extension;
                normalizer.Merge(selectedValue.FullName, dest);
                logger.Log($"{selectedValue.FullName} Normalized in { dest }");
            }
        }

        private void btBrowseRpt_Click(object sender, EventArgs e)
        {
            var folder = new OpenFileDialog();
            folder.Multiselect = false;
            folder.Filter = "*.rpt|*.*";
            var result = folder.ShowDialog();

            cbPath.Text = folder.FileName;
        }

  

        private void PrintServerControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveWorkspace();
        }

        public override void CreateWS(FileInfo item)
        {
            LoadConfigFromJSON(item.FullName);
        }

        private void removeSelectedXsdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveSelectedFiles();
        }

        private void RemoveSelectedFiles()
        {
            var fileList = dgKeyValue.DataSource as List<FileInfo>;

            foreach (DataGridViewRow row in dgKeyValue.SelectedRows)
            {
                var file = row.DataBoundItem as FileInfo;
                fileList.Remove(file);
            }
            dgKeyValue.DataSource = null;
            dgKeyValue.DataSource = fileList;
        }

        private void dgKeyValue_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center,

                LineAlignment = StringAlignment.Center
            };
            //get the size of the string
            Size textSize = TextRenderer.MeasureText(rowIdx, this.Font);
            //if header width lower then string width then resize
            if (grid.RowHeadersWidth < textSize.Width + 40)
            {
                grid.RowHeadersWidth = textSize.Width + 40;
            }
            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var file = GetSelectedFile();
            if (file != null)
            {
                Program.OpenJson(file.FullName);
            }
        }

        private void copyPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var file = GetSelectedFile();
            if (file != null)
            {
                Clipboard.SetText(file.FullName);
            }
        }
     
    }
}
