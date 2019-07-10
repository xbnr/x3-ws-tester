using ConsoleTester.Common;
using ConsoleTester.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTester.Plugins.Soap
{

    public class WsSOAPTesterPrompt : ControlConfig, IControlConfig
    {
        private string filename;

        public override void CreateWS(FileInfo item)
        {
            LoadConfigFromJSON(item.FullName);
        }

        internal void LoadConfigFromJSON(string filename)
        {
            this.filename = filename;
            PromptHelper.ShowPromptInfo("");
            PromptHelper.ShowPromptHighlight($"Not implemented yet.");
            PromptHelper.ShowPromptInfo("");
        }
    }
}
