using ConsoleTester.Common;
using ConsoleTester.UI;
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

            PromptHelper.ShowPromptInfo($"Last X files: ");

        }

    }
}
