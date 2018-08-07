using ConsoleTester.Common;
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

    public partial class MongoDbEDI : ControlConfig
    {
        private string filename;
        private Logger logger = new Logger(MainForm.LogControl);

        public MongoDbEDI()
        {
            InitializeComponent();
        }
        public override void CreateWS(FileInfo item)
        {
            LoadConfigFromJSON(item.FullName);
            //  InitGridView();
        }

        internal void LoadConfigFromJSON(string filename)
        {
            this.filename = filename;
            MongoConfig config = JsonConvert.DeserializeObject<MongoConfig>(File.ReadAllText(filename));
            Helper.SetTextFromSettings(config.FieldName, this.cbFieldName);
            Helper.SetTextFromSettings(config.Occurence, this.tbTextToSearch);
        }


        private void MongoDbEDI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (string.IsNullOrEmpty(this.filename))
            {
                this.filename = MongoConfig.GetWorkspaceFilename();
            }
            Helper.SaveWorkspace(this.filename, GetConfigFromUI());
        }

        private MongoConfig GetConfigFromUI()
        {
            MongoConfig conf = new MongoConfig
            {
                ServerUrl = tbServer.Text,
                Database = tbDatabase.Text,
                FieldName = cbFieldName.Text,
                Occurence = tbTextToSearch.Text
            };
            return conf;
        }


        private void btSearch_Click(object sender, EventArgs e)
        {
            // var task = Task.Run(Search).GetAwaiter().GetResult();
            // Task.Run(() => Search("files_id", "ObjectId(\"534a811bf8b4aa4d33fdf94d\")"));
            // Task.Run(() => Search("_id", "ObjectId(\"534a811bf8b4aa4d33fdf94d\")"));
            // Task.Run(() => Search("filename", "CHORUS~1.2~EF1"));
            // Task.Run(() => Search("md5", "d41d8cd98f00b204e9800998ecf8427e"));

            Task.Run(() => Search(cbFieldName.Text, tbTextToSearch.Text));
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

        /*
         * 
         db.fs.chunks.find({files_id:ObjectId('534a811bf8b4aa4d33fdf94d')})        
            NOOK: db.getCollection('fs.files').find({metadata.filename:"CHORUS~1.2~EF1"})

            var filter = Builders<GridFSFileInfo>.Filter.And(
        Builders<GridFSFileInfo>.Filter.Eq(x => x.Metadata["FileName"], "node-v0.12.7-x64.msi"));

           */


        private string Database => tbDatabase.Text;



        private async Task Search(string fieldName, string fieldvalue)
        {
            IMongoDatabase database = GetDatabase();

            IMongoCollection<GridFSFileInfo> filesCollection = database.GetCollection<GridFSFileInfo>("fs.files");
            List<GridFSFileInfo> fileInfos;
            if (string.IsNullOrEmpty(fieldvalue))
                fileInfos = await GetLastFilesAsync(filesCollection, 100);
            else
                fileInfos = await FindFilesAsync(filesCollection, fieldName, fieldvalue);

            logger.Log($"Search fieldName: {fieldName}, value: {fieldvalue}  result(s): {fileInfos.Count}");

            Helper.SetSafeDatasource(dgKeyValue, fileInfos);
        }

        private IMongoDatabase GetDatabase()
        {
            string connectionString = tbServer.Text; // "mongodb://localhost/?safe=true";
            var client = new MongoClient(connectionString);
            IMongoDatabase database = client?.GetDatabase(Database); // "syracuse");
            return database;
        }

        public async Task<List<GridFSFileInfo>> FindFilesAsync(IMongoCollection<GridFSFileInfo> filesCollection, string fieldName, string fieldvalue)
        {
            FilterDefinitionBuilder<GridFSFileInfo> builder = Builders<GridFSFileInfo>.Filter;
            FilterDefinition<GridFSFileInfo> filter = builder.Eq(fieldName, fieldvalue);
            if (fieldName.IndexOf("fileName", StringComparison.CurrentCultureIgnoreCase) >= 0)
                filter = builder.Eq(x => x.Metadata["fileName"], fieldvalue);
            return await filesCollection.Find(filter).SortByDescending(item => item.UploadDateTime).ToListAsync();
        }

        public async Task<List<GridFSFileInfo>> GetLastFilesAsync(IMongoCollection<GridFSFileInfo> filesCollection, int lastXItems)
        {
            FilterDefinitionBuilder<GridFSFileInfo> builder = Builders<GridFSFileInfo>.Filter;
            return await filesCollection.Find(builder.Empty).Limit(lastXItems).SortByDescending(item => item.UploadDateTime).ToListAsync();
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
            if (dgKeyValue.SelectedRows.Count != 1) return;

            GridFSFileInfo item = dgKeyValue.SelectedRows[0].DataBoundItem as GridFSFileInfo;
            try
            {
                // string fileResult = Task.Run(() => DownloadFileAsync(item)).GetAwaiter().GetResult();
                string fileResult = "";
                Task.Run(() => DownloadFileAsync(item));
                if (!string.IsNullOrEmpty(fileResult) && File.Exists(fileResult))
                {
                    Program.OpenJson(fileResult);
                }
            }
            catch (Exception ex)
            {
                logger.Log("***GridFS Error " + ex.Message);
            }

        }

        public async Task<string> DownloadFileAsync(GridFSFileInfo file)
        {
            var gridFsBucket = new GridFSBucket(GetDatabase());
            string filename = file.Metadata["fileName"].AsString;
            string targetDir = Path.Combine(Program.GetWorkspaceDirectory(), DateTime.Now.ToString("yyyyMMddHHmm"));
            if (!Directory.Exists(targetDir))
            {
                Directory.CreateDirectory(targetDir);
            }

            string extension = ".bin";
            if (file.ContentType.Equals("plain/text", StringComparison.CurrentCultureIgnoreCase))
            {
                extension = ".json";
            }
            string targetFilename = Path.Combine(targetDir, filename + extension);

            logger.Log($"Saving file to {targetFilename}");
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

    }
}
