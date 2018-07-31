using ConsoleTester.Common;
using ConsoleTester.UI;
using MongoDB.Driver;
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
            //Workspace ws = this.workspace1;
            //if (item != null)
            //{
            //    ws.LoadConfigFromJSON(item.FullName);
            //}
        }

        private void WsSOAPTester_FormClosing(object sender, FormClosingEventArgs e)
        {
            // this.workspace1.SaveWorkspace();
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            Search(tbDocumentGuid.Text);
        }

        private void Search(string guid)
        {
            IMongoDatabase database = null;
            const string connectionString = "mongodb://localhost/?safe=true";
            var client = new MongoClient(connectionString);
            if (client != null)
                database = client.GetDatabase("syracuse");

            var col = database.GetCollection<FsFiles>("fs.files");
            string s = JsonConvert.SerializeObject(col);

            Logger logger = new Logger(MainForm.LogControl);

            logger.Log(s);
        }
    }
}
