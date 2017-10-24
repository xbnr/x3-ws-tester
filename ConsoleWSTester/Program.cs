using System;
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
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(e.StackTrace);
            }
        }

        internal static string GetWorkspaceDirectory()
        {
            return System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Sage", "X3WsTester");
        }

        internal static string GetAppliVersion(bool applicationNameOrVersion)
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
    }
}