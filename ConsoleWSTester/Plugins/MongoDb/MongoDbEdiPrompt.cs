using ConsoleTester.Common;
using ConsoleTester.UI;
using MongoDB.Driver.GridFS;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTester.Plugins.MongoDb
{
    public class MongoDbEdiPrompt : ControlConfig, IControlConfig
    {
        private string filename;

        public override void CreateWS(FileInfo item)
        {
            LoadConfigFromJSON(item.FullName);
        }

        internal void LoadConfigFromJSON(string filename)
        {
            this.filename = filename;
            MongoConfig config = JsonConvert.DeserializeObject<MongoConfig>(File.ReadAllText(filename));
            PromptHelper.ShowPromptInfo($"Server: {config.ServerUrl}");
            PromptHelper.ShowPromptInfo(config.FieldName);
            PromptHelper.ShowPromptInfo(config.SearchType);

            MongoServer = config.ServerUrl;
            MongoDatabase = config.Database;

            PromptHelper.ShowPromptInfo($"Last X files: ");
            InitGridAsync(config.FieldName, config.SearchType, "");
        }

        public string MongoServer { get; private set; }
        public string MongoDatabase { get; private set; }

        public string FieldName { get; private set; }
        public string SearchType { get; private set; }


        private async void InitGridAsync(string fieldName, string cbSearchType, string tbTextToSearch)
        {
            EdiHelper h = new EdiHelper(MongoServer, MongoDatabase);
            List<GridFSFileInfo> result = await h.SearchAsync(fieldName, cbSearchType, tbTextToSearch);
            foreach(var item in result)
            {
                PromptHelper.ShowPromptInfo($"{item.Filename}");
            }
        }

    }
}
