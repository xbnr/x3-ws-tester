using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace ConsoleTester
{
    class Program
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

        internal static string GetWorkspaceDirectory()
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
                ass = Assembly.GetExecutingAssembly();
            AssemblyName assn = ass.GetName();
            if (applicationNameOrVersion)
            {
                object[] customAttributes = ass.GetCustomAttributes(false);
                AssemblyProductAttribute product = customAttributes.Where(p => p.GetType() == typeof(AssemblyProductAttribute)).SingleOrDefault() as AssemblyProductAttribute;
                return product == null ? assn.Name : product.Product;
            }

            return assn.Version.ToString();
        }

        internal static void OpenJson(string configFilename)
        {
            List<string> preferences = new List<string>();
            preferences.Add(@"C:\Program Files (x86)\Microsoft VS Code\Code.exe");
            preferences.Add(@"notepad++.exe");
            preferences.Add(@"notepad2.exe");
            preferences.Add(@"notepad.exe");

            foreach (var item in preferences)
            {
                if (OpenConfigWith(item, configFilename))
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