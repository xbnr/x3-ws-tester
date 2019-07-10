using ConsoleTester.Common;
using ConsoleTester.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace ConsoleTester
{
    public class ProgramUI
    {
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new ConsoleTester.UI.MainForm());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(e.StackTrace);
            }
        }

        public static string GetWorkspaceDirectory()
        {
            return System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Sage", "X3WsTester");
        }

        internal static string GetApplicationName()
        {
            return GetAppliVersion(true);
        }

        internal static string GetApplicationVersion()
        {
            return GetAppliVersion(false);
        }

        private static string GetAppliVersion(bool applicationNameOrVersion)
        {
            Assembly ass = System.Reflection.Assembly.GetEntryAssembly();
            if (ass == null)
            {
                ass = Assembly.GetExecutingAssembly();
            }
            AssemblyName assn = ass.GetName();
            if (applicationNameOrVersion)
            {
                object[] customAttributes = ass.GetCustomAttributes(false);
                AssemblyProductAttribute product = customAttributes.Where(p => p.GetType() == typeof(AssemblyProductAttribute)).SingleOrDefault() as AssemblyProductAttribute;
                return product == null ? assn.Name : product.Product;
            }

            return assn.Version.ToString();
        }

        public static List<System.Type> GetConfigs()
        {
            var ass = Assembly.GetExecutingAssembly();
            return ass.GetTypes().Where(p => typeof(IConfigService).IsAssignableFrom(p) && p.IsClass && !p.IsAbstract).ToList();
            // .Cast<IConfigService>().ToList(); // .ConvertAll(item => item as IConfigService);
        }


        internal static void OpenJson(string configFilename)
        {
            OpenJson(configFilename, null);
        }

        internal static void OpenJson(string configFilename, int? lineNumber)
        {
            List<string> preferences = new List<string>
            {
                // https://stackoverflow.com/questions/30169715/how-do-i-open-a-file-from-a-prompt-with-vs-code-and-go-to-a-specific-line-number
                // code -g file1:<line>:<column?> file2:<line>:<column?> file3:<line>:<column?>
                @"Code - Insiders.exe",
                @"Code.exe",
                @"notepad++.exe",
                @"notepad2.exe",
                @"notepad.exe"
            };

            foreach (var item in preferences)
            {
                if (OpenConfigWith(item, "\"" + configFilename + "\"" + (lineNumber != null ? " -n" + lineNumber : "")))
                    break;

            }
        }
        private static bool OpenConfigWith(string exeProgramName, string arguments)
        {
            try
            {
                Process.Start(exeProgramName, arguments);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }



    }
}