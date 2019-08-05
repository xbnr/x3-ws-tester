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
            try
            {
                new Program().Prompt();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                Environment.Exit(1);
            }
        }

        private void Prompt()
        {
            PromptHelper.ShowPromptInfo("Welcome to SAGE X3 Tester.");
            PromptHelper.ShowPromptInfo("");


            while (true)
            {
                FileInfo[] files = ConfigurationFileList();

                DisplayPromptMenu();

                string lineRead = PromptHelper.EnterValue("Please, enter your choice, or the solution you want to open : ");
                int number = -1;
                bool ok = int.TryParse(lineRead, out number);

                string configurationName = null;
                if (!ok)
                {
                    if (lineRead.Equals("Quit", StringComparison.InvariantCultureIgnoreCase) || lineRead.Equals("Exit", StringComparison.InvariantCultureIgnoreCase))
                    {
                        number = (int)Menu.ExitProgram;
                    }
                    else
                    {
                        number = (int)Menu.OpenConfiguration;
                        configurationName = lineRead;
                    }
                }

                switch (number)
                {
                    case (int)Menu.DisplayPrompt:
                        DisplayPromptMenu();
                        break;
                    case (int)Menu.CreateNewConfiguration:
                        CreateNewConfiguration();
                        break;
                    case (int)Menu.OpenConfiguration:
                        ConnectConfiguration(files, configurationName);
                        break;
                    case (int)Menu.ExitProgram:
                        Environment.Exit(0);
                        break;
                }


            }
        }

        private void CreateNewConfiguration()
        {
            List<IConfigService> configServiceResult = new List<IConfigService>();

            foreach (var item in ProgramUI.GetConfigs())
            {
                Type serviceType = Type.GetType(item.AssemblyQualifiedName);
                IConfigService configService = Activator.CreateInstance(serviceType) as IConfigService;
                configServiceResult.Add(configService);
                PromptHelper.ShowPromptHighlight($"{configService.GetConfigPrefixFilename()} \t {configService.GetTitle()}");
            }

            string serviceFileName = PromptHelper.EnterValue($"Enter the config name you want to create: ");
            IConfigService selectedService = configServiceResult.FirstOrDefault(item => item.GetConfigPrefixFilename() == serviceFileName);

            Type promptType = Type.GetType($"{selectedService.GetPromptToolFullName()}, {typeof(IConfigService).Assembly.GetName()}");
            var control = Activator.CreateInstance(promptType) as ControlConfig;
            string defaultFilename = control.GetDefaultWorkspaceFilename();
            string newFilename = Path.Combine(Path.GetDirectoryName(defaultFilename),  
                $"{Path.GetFileNameWithoutExtension(defaultFilename)}{serviceFileName}{Path.GetExtension(defaultFilename)}");
            control.CreateWS(new FileInfo(newFilename));
        }

        private static void ConnectConfiguration(FileInfo[] files, string jsonFilename)
        {
            FileInfo fileFound = null;
            while (fileFound == null)
            {
                if (!jsonFilename.EndsWith(".json", StringComparison.InvariantCultureIgnoreCase))
                {
                    jsonFilename += ".json";
                }
                fileFound = files.ToList().SingleOrDefault(p => p.Name == jsonFilename);

                if (fileFound == null)
                {
                    PromptHelper.ShowPromptHighlight($"{jsonFilename} doesn't exist.");
                    jsonFilename = PromptHelper.EnterValue("Please, enter your choice, or the solution you want to open : ");
                }
            }

            var content = GetControlInstance(fileFound);
            content.CreateWS(fileFound);
        }

        private static FileInfo[] ConfigurationFileList()
        {
            FileInfo[] files = new FileInfo[0];
            var dir = new DirectoryInfo(ProgramUI.GetWorkspaceDirectory());
            if (dir.Exists)
            {
                files = dir.GetFiles();
                foreach (var item in files)
                {
                    PromptHelper.ShowPromptInfo($"{item.Name}");
                }
                PromptHelper.ShowPromptInfo($" ");

            }
            return files;
        }

        private enum Menu
        {
            ListSolutions = 1,
            CreateNewConfiguration = 2,
            OpenConfiguration = 3,
            DisplayPrompt = 30,
            ExitProgram = 50,
        }

        private void DisplayPromptMenu()
        {
            PromptHelper.ShowPromptInfo($"\r");
            PromptHelper.ShowPromptInfo($"{(int)Menu.ListSolutions}. List configurations");
            PromptHelper.ShowPromptInfo($"{(int)Menu.OpenConfiguration}. Open configuration");

            PromptHelper.ShowPromptInfo($"{(int)Menu.CreateNewConfiguration}. Create new configuration");
            PromptHelper.ShowPromptInfo($"{(int)Menu.ExitProgram}. Quit");
        }


        private static ControlConfig GetControlInstance(FileInfo fileFound)
        {
            foreach (var item in ProgramUI.GetConfigs())
            {
                Type serviceType = Type.GetType(item.AssemblyQualifiedName);
                if (serviceType != null)
                {
                    if (Activator.CreateInstance(serviceType) is IConfigService configService && Path.GetFileNameWithoutExtension(fileFound.Name).IndexOf(configService.GetConfigPrefixFilename()) >= 0)
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
