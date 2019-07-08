using ConsoleTester;
using ConsoleTester.Common;
using ConsoleTester.UI;
using ConsoleTester.Plugins.MongoDb;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePrompt
{
    class Program
    {
        static void Main(string[] args)
        {
            PromptHelper.ShowPromptInfo("Welcome to SAGE X3 Tester.");
            PromptHelper.ShowPromptInfo("");
            var dir = new DirectoryInfo(ProgramUI.GetWorkspaceDirectory());
            if (dir.Exists)
            {
                var files = dir.GetFiles();
                foreach (var item in files)
                {
                    PromptHelper.ShowPromptInfo($"{item.Name}");
                }

                FileInfo fileFound = null;
                string jsonFilename = null;
                while (fileFound == null)
                {
                    jsonFilename = PromptHelper.EnterValue("Please enter the solution you want to open.");
                    if (!jsonFilename.EndsWith(".json", StringComparison.InvariantCultureIgnoreCase))
                    {
                        jsonFilename += ".json";
                    }
                    fileFound = files.ToList().SingleOrDefault(p => p.Name == jsonFilename);

                    if (fileFound == null)
                    {
                        PromptHelper.ShowPromptHighlight($"{jsonFilename} doesn't exist.");
                    }
                }

                var content = GetControlInstance(fileFound);
                PromptHelper.ShowPromptInfo(content?.ToString());
                content.CreateWS(fileFound);

            }
        }

        private static ControlConfig GetControlInstance(FileInfo fileFound)
        {
            foreach (var item in ProgramUI.GetConfigs())
            {
                Type serviceType = Type.GetType(item.AssemblyQualifiedName);
                if (serviceType != null)
                {
                    IConfigService configService = Activator.CreateInstance(serviceType) as IConfigService;
                    if (configService != null && Path.GetFileNameWithoutExtension(fileFound.Name).IndexOf(configService.GetConfigPrefixFilename()) >= 0)
                    {
                        Type promptType = Type.GetType($"{configService.GetPromptToolFullName()}, {serviceType.Assembly.GetName()}"); 
                         var content = Activator.CreateInstance(promptType) as ControlConfig;
                        return content;
                    }
                }
                else
                {
                    PromptHelper.ShowPromptWarning($"{item } not found");
                }
            }
            return null;
        }
    }
}
