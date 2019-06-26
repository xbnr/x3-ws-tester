using ConsoleTester.Common;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTester.Plugins.PrintServer
{
    static class PrintServerHelper
    {

        public static bool TestSqlConnection(string dsn, string userId, string password)
        {
            using (OdbcConnection connection = new OdbcConnection($"dsn={dsn};UID={userId};PWD={password};"))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }


        public static string GetPrintServerIntallPath()
        {
            string result = null;
            RegistryKey regKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Adonix\SRVIMP\0,1,5,0\GENERAL");
            if (regKey != null)
            {
                result = (string)regKey.GetValue("Path");
            }
            return result;
        }

        public static string GetDatabaseName(string odbcDatasource)
        {
            string result = null;
            RegistryKey regKey = Registry.LocalMachine.OpenSubKey($@"SOFTWARE\ODBC\ODBC.INI\{odbcDatasource}");
            if (regKey != null)
            {
                result = (string)regKey.GetValue("Database");
            }
            return result;
        }

        public static List<string> EnumDsn()
        {
            List<string> list = new List<string>();
            list.AddRange(EnumDsn(Registry.CurrentUser));
            list.AddRange(EnumDsn(Registry.LocalMachine));
            return list;
        }

        private static IEnumerable<string> EnumDsn(RegistryKey rootKey)
        {
            RegistryKey regKey = rootKey.OpenSubKey(@"Software\ODBC\ODBC.INI\ODBC Data Sources");
            if (regKey != null)
            {
                foreach (string name in regKey.GetValueNames())
                {
                    string value = regKey.GetValue(name, "").ToString();
                    yield return name;
                }
            }
        }

        public static string GetDbServerName(string odbcDatasource)
        {
            string result = null;
            RegistryKey regKey = Registry.LocalMachine.OpenSubKey($@"SOFTWARE\ODBC\ODBC.INI\{odbcDatasource}");
            if (regKey != null)
            {
                result = (string)regKey.GetValue("Server");
                if (string.IsNullOrEmpty(result))
                    result = (string)regKey.GetValue("HostName");
                if (string.IsNullOrEmpty(result))
                    result = (string)regKey.GetValue("ServerName");
            }
            return result;
        }
    }
}
