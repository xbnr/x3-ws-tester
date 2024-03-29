﻿using ConsoleTester.Common;
using ConsoleTester.UI;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleTester.Plugins.MongoDb
{

    public partial class MongoDbEDI : ControlConfigUI
    {
        private string filename;

        public MongoDbEDI()
        {
            InitializeComponent();
        }

        public override bool IsVisibleInReleaseMode()
        {
#if DEBUG
            return true;
#else
            return false;
#endif
        }

        public override void CreateWS(FileInfo item)
        {
            LoadConfigFromJSON(item.FullName);
        }

        internal void LoadConfigFromJSON(string filename)
        {
            this.filename = filename;
            MongoConfig config = JsonConvert.DeserializeObject<MongoConfig>(File.ReadAllText(filename));
            Helper.SetTextFromSettings(config.FieldName, this.cbFieldName);
            Helper.SetTextFromSettings(config.SearchType, this.cbSearchType);
            Helper.SetTextFromSettings(config.Occurence, this.tbTextToSearch);
        }

        public override void SetWorkspaceFilename(string filename)
        {
            this.filename = filename;
        }

        public override string GetDefaultWorkspaceFilename()
        {
            return MongoConfig.GetWorkspaceFilename();
        }

        public override string GetWorkspaceFilename()
        {
            if (string.IsNullOrEmpty(this.filename))
            {
                this.filename = GetDefaultWorkspaceFilename();
            }
            return this.filename;
        }


        public override IConfigService GetConfigFromUI()
        {
            MongoConfig conf = new MongoConfig
            {
                ServerUrl = tbServer.Text,
                Database = tbDatabase.Text,
                FieldName = cbFieldName.Text,
                SearchType = cbSearchType.Text,
                Occurence = tbTextToSearch.Text
            };
            return conf;
        }

        private void tbTextToSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SearchAsync();
        }

        private async void btSearch_ClickAsync(object sender, EventArgs e)
        {
            await SearchAsync();
        }

        private async Task SearchAsync()
        {
            // var task = Task.Run(Search).GetAwaiter().GetResult();
            // Task.Run(() => Search("files_id", "ObjectId(\"534a811bf8b4aa4d33fdf94d\")"));
            // Task.Run(() => Search("_id", "ObjectId(\"534a811bf8b4aa4d33fdf94d\")"));
            // Task.Run(() => Search("filename", "CHORUS~1.2~EF1"));
            // Task.Run(() => Search("md5", "d41d8cd98f00b204e9800998ecf8427e"));

            // Task.Run(() => SearchAsync(cbFieldName.Text, tbTextToSearch.Text));
            EdiHelper h = new EdiHelper(MongoServer, MongoDatabase);
            List<GridFSFileInfo> result = await h.SearchAsync(cbFieldName.Text, cbSearchType.Text, tbTextToSearch.Text, 100);
            Helper.SetSafeDatasource(dgKeyValue, result);
        }

        //    { "_id" : ObjectId("5b68310b5aa06d3894786726"), "filename" : "718af082-581b-4edd-831e-8e809a84f8ac", "contentType" : "plain/text", "length" : 426380, "chunkSize" : 261120, "uploadDate" : ISODate("2018-08-06T11:29:1

        private void InitGridView()
        {
            dgKeyValue.Columns.Clear();
            dgKeyValue.AutoGenerateColumns = false;
            dgKeyValue.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            DataGridViewCell cell = new DataGridViewTextBoxCell();
            DataGridViewTextBoxColumn colid = new DataGridViewTextBoxColumn()
            {
                CellTemplate = cell,
                HeaderText = "_id",
                Name = "_id",
                DataPropertyName = "_id" // Tell the column which property of FileName it should use
            };
            DataGridViewTextBoxColumn colFilename = new DataGridViewTextBoxColumn()
            {
                CellTemplate = cell,
                HeaderText = "filename",
                Name = "filename",
                DataPropertyName = "filename"
            };
            DataGridViewTextBoxColumn colFilelength = new DataGridViewTextBoxColumn()
            {
                CellTemplate = cell,
                HeaderText = "length",
                Name = "length",
                DataPropertyName = "length"
            };
            DataGridViewTextBoxColumn colContentType = new DataGridViewTextBoxColumn()
            {
                CellTemplate = cell,
                HeaderText = "contentType",
                Name = "contentType",
                DataPropertyName = "contentType"
            };
            DataGridViewTextBoxColumn colUploadDate = new DataGridViewTextBoxColumn()
            {
                CellTemplate = cell,
                HeaderText = "uploadDate",
                Name = "uploadDate",
                DataPropertyName = "uploadDate"
            }; dgKeyValue.Columns.Add(colid);
            dgKeyValue.Columns.Add(colFilename);
            dgKeyValue.Columns.Add(colFilelength);
            dgKeyValue.Columns.Add(colContentType);
            dgKeyValue.Columns.Add(colUploadDate);
        }


        private string MongoDatabase => tbDatabase.Text;

        private string MongoServer => tbServer.Text;

       

        private IMongoDatabase GetDatabase()
        {
            var client = new MongoClient(MongoServer);// "mongodb://localhost/?safe=true";
            return client?.GetDatabase(MongoDatabase); // "syracuse");
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

        private void downloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GridFSFileInfo item = GetSelectedItem();
            if (item == null) return;
            try
            {
                var result = Task.Run(() => DownloadFileAsync(item));
            }
            catch (Exception ex)
            {
                Logger.Log("***GridFS Error " + ex.Message);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var items = GetSelectedItems();
            if (items.Count == 0) return;
            try
            {
                var gridFsBucket = new GridFSBucket(GetDatabase());
                foreach (var item in items)
                {
                    gridFsBucket.Delete(item.Id);
                }
                SearchAsync();
            }
            catch (Exception ex)
            {
                Logger.Log("***GridFS Error " + ex.Message);
            }

        }

        private async void downloadAndViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GridFSFileInfo item = GetSelectedItem();
            if (item == null) return;
            try
            {
                // string fileResult = Task.Run(() => DownloadFileAsync(item)).GetAwaiter().GetResult();
                // var result = Task.Run(() => DownloadFileAsync(item));
                var result = await DownloadFileAsync(item);
                if (!string.IsNullOrEmpty(result))
                {
                    ProgramUI.OpenJson(result);
                }
            }
            catch (Exception ex)
            {
                Logger.Log("***GridFS Error " + ex.Message);
            }
        }

        private List<GridFSFileInfo> GetSelectedItems()
        {
            List<GridFSFileInfo> result = new List<GridFSFileInfo>();
            foreach (DataGridViewRow item in dgKeyValue.SelectedRows)
            {
                var add = item.DataBoundItem as GridFSFileInfo;
                if (add != null)
                    result.Add(add);
            }
            return result;
        }

        private GridFSFileInfo GetSelectedItem()
        {
            if (dgKeyValue.SelectedRows.Count == 0)
            {
                return null;
            }
            return dgKeyValue.SelectedRows[0].DataBoundItem as GridFSFileInfo;
        }

        public async Task<string> DownloadFileAsync(GridFSFileInfo file)
        {
            var gridFsBucket = new GridFSBucket(GetDatabase());
            string filename = file.Metadata["fileName"].AsString;
            string targetDir = Path.Combine(ProgramUI.GetWorkspaceDirectory(), MongoConfig.MongoConfigName);
            if (!Directory.Exists(targetDir))
            {
                Directory.CreateDirectory(targetDir);
            }

            string extension = ".bin";
            if (file.ContentType.Equals("plain/text", StringComparison.CurrentCultureIgnoreCase))
            {
                extension = ".txt";
            }
            string targetFilename = Path.Combine(targetDir, filename + "_" + file.Id.ToString() + extension);

            Logger.Log($"Saving file to {targetFilename}");
            // using (GridFSDownloadStream<ObjectId> sourceStream = await gridFsBucket.OpenDownloadStreamByNameAsync(filename))
            using (GridFSDownloadStream sourceStream = await gridFsBucket.OpenDownloadStreamAsync(file.Id))
            {
                using (FileStream destinationStream = File.Open(targetFilename, FileMode.Create))
                {
                    await sourceStream.CopyToAsync(destinationStream);
                }
            }
            return targetFilename;
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(GetSelectedItem()?.BackingDocument.ToString());
        }

        private void dgKeyValue_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            Logger.Log(e.Exception.Message);
        }

        private void btEdiProcessSearch_Click(object sender, EventArgs e)
        {
            SearchEDIProcessAsync(cbEDIProcessFieldName.Text, "", tbEdiProcessSearch.Text);
        }

        private async Task SearchEDIProcessAsync(string fieldName, string searchType, string fieldvalue)
        {
            try
            {
                IMongoDatabase database = GetDatabase();

                IMongoCollection<EdiProcess> ediProcessCollection = database.GetCollection<EdiProcess>("EdiProcess");
                List<EdiProcess> fileInfos;
                //if (string.IsNullOrEmpty(fieldvalue))
                //    fileInfos = await GetLastFilesAsync(ediProcessCollection, 100);
                //else
                fileInfos = await FindCollectionAsync<EdiProcess>(ediProcessCollection, fieldName, searchType, fieldvalue);

                Logger.Log($"Search fieldName: {fieldName}, value: {fieldvalue}  result(s): {fileInfos.Count}");
                Helper.SetSafeDatasource(dgKeyValue, fileInfos);
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
            }
        }

        public async Task<List<T>> FindCollectionAsync<T>(IMongoCollection<T> collection, string fieldName, string searchType, string fieldvalue)
        {
            FilterDefinitionBuilder<T> builder = Builders<T>.Filter;
            FilterDefinition<T> filter = builder.Eq(fieldName, fieldvalue);

            return await collection.Find(filter).ToListAsync();
        }


    }
}
