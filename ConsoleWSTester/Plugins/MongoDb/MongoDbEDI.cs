using ConsoleTester.Common;
using ConsoleTester.UI;
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
        // private Workspace workspace1;

        public MongoDbEDI()
        {
            InitializeComponent();
        }
        public override void CreateWS(FileInfo item)
        {

            InitGridView();
        }

        private void MongoDbEDI_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            // var task = Task.Run(Search).GetAwaiter().GetResult();
            // Task.Run(() => Search("metadata.filename", "CHORUS~1.2~EF1"));
            // Task.Run(() => Search("files_id", "ObjectId(\"534a811bf8b4aa4d33fdf94d\")"));
            // Task.Run(() => Search("_id", "534a811bf8b4aa4d33fdf94d"));
            // Task.Run(() => Search("_id", "ObjectId(\"534a811bf8b4aa4d33fdf94d\")"));

            // Task.Run(() => Search("filename", "CHORUS~1.2~EF1"));
            Task.Run(() => Search(cbFieldName.Text, tbTextToSearch.Text));
            // Task.Run(() => Search("md5", "d41d8cd98f00b204e9800998ecf8427e"));
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
        
            NOOK:
            db.getCollection('fs.files').find({metadata.filename:"CHORUS~1.2~EF1"})

            var filter = Builders<GridFSFileInfo>.Filter.And(
        Builders<GridFSFileInfo>.Filter.Eq(x => x.Metadata["FileName"], "node-v0.12.7-x64.msi"));

           */

        private async Task Search(string fieldName, string fieldvalue)
        {
            string connectionString = tbServer.Text; // "mongodb://localhost/?safe=true";
            var client = new MongoClient(connectionString);
            IMongoDatabase database = client?.GetDatabase(tbDatabase.Text); // "syracuse");

            Logger logger = new Logger(MainForm.LogControl);
            IMongoCollection<GridFSFileInfo> filesCollection = database.GetCollection<GridFSFileInfo>("fs.files");
            List<GridFSFileInfo> fileInfos = await FindFilesAsync(filesCollection, fieldName, fieldvalue);

            logger.Log($"Search fieldName: {fieldName}, value: {fieldvalue}  result(s): {fileInfos.Count}");

            dgKeyValue.DataSource = fileInfos;


            foreach (GridFSFileInfo gridFsFileInfo in fileInfos)
            {
                logger.Log($"Found file {gridFsFileInfo.BackingDocument} Length {gridFsFileInfo.Length}");
                try
                {
                    //  await DemoDownloadFileAsync(database, filePath, fileName);
                }
                catch (Exception e)
                {
                    logger.Log("***GridFS Error " + e.Message);
                }
            }
        }

        public async Task<List<GridFSFileInfo>> FindFilesAsync(IMongoCollection<GridFSFileInfo> filesCollection, string fieldName, string fieldvalue)
        {
            FilterDefinitionBuilder<GridFSFileInfo> builder = Builders<GridFSFileInfo>.Filter;
            FilterDefinition<GridFSFileInfo> filter = builder.Eq(fieldName, fieldvalue);
            if (fieldName.IndexOf("fileName", StringComparison.CurrentCultureIgnoreCase) >= 0)
                filter = builder.Eq(x => x.Metadata["fileName"], fieldvalue);
            return await filesCollection.Find(filter).SortBy(x => x.UploadDateTime).ToListAsync();
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

    }
}
