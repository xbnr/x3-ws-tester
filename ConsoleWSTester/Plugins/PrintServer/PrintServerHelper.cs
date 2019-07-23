using ConsoleTester.Common;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Security.Cryptography;
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







        public static string DecodePasswordFromCryptedString(string cryptSSSecuredPassword)
        {
            string result = cryptSSSecuredPassword;
            if (cryptSSSecuredPassword.StartsWith(CRYTPSS))
            {
                result = Decrypt(cryptSSSecuredPassword);
            }
            return result;
        }


        public static string EncodePasswordToCryptedtring(string password)
        {
            return $"{CRYTPSS}{Encrypt(password)}";
        }


        public static string CRYTPSS = "CRYPTSS:";
        private static readonly string Pas = "FDHJK1209876!FRDEPO@SAGE";
        private static readonly string K = "NHYBGTVFRCDEXSZAQWIKUJYHTGRFEDZSAQAGERTTYAEabPOE@az6767889sFTGYHqsfFDHJK!TGRFEDZSAQO@SAGE";

        public static string Decrypt(string textToDecrypt)
        {
            return Decrypt(textToDecrypt, Pas, K);
        }

        public static string Decrypt(string textToDecrypt, string pwd, string key)
        {
            if (textToDecrypt.StartsWith(CRYTPSS))
            {
                textToDecrypt = textToDecrypt.Substring(CRYTPSS.Length);
            }

            RijndaelManaged rijndaelCipher = new RijndaelManaged
            {
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7,

                KeySize = 0x80,
                BlockSize = 0x80
            };
            byte[] encryptedData = Convert.FromBase64String(textToDecrypt);
            byte[] pwdBytes = ArrayFill(new byte[0x10], Encoding.UTF8.GetBytes(pwd));
            byte[] keyBytes = ArrayFill(new byte[0x10], Encoding.UTF8.GetBytes(key));

            rijndaelCipher.Key = keyBytes;
            rijndaelCipher.IV = pwdBytes;
            byte[] plainText = rijndaelCipher.CreateDecryptor().TransformFinalBlock(encryptedData, 0, encryptedData.Length);
            return Encoding.UTF8.GetString(plainText);
        }

        public static string Encrypt(string textToEncrypt)
        {
            return Encrypt(textToEncrypt, Pas, K);
        }

        public static string Encrypt(string textToEncrypt, string pwd, string key)
        {
            RijndaelManaged rijndaelCipher = new RijndaelManaged
            {
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7,

                KeySize = 0x80,
                BlockSize = 0x80
            };
            byte[] pwdBytes = ArrayFill(new byte[0x10], Encoding.UTF8.GetBytes(pwd));
            byte[] keyBytes = ArrayFill(new byte[0x10], Encoding.UTF8.GetBytes(key));

            rijndaelCipher.Key = keyBytes;
            rijndaelCipher.IV = pwdBytes;
            ICryptoTransform transform = rijndaelCipher.CreateEncryptor();
            byte[] plainText = Encoding.UTF8.GetBytes(textToEncrypt);
            return Convert.ToBase64String(transform.TransformFinalBlock(plainText, 0, plainText.Length));
        }

        private static byte[] ArrayFill(byte[] destination, byte[] source)
        {
            int remain = 0;
            int quotient = Math.DivRem(destination.Length, source.Length, out remain);

            // fill when keyBytesTemp.Length < keyBytes.Length
            for (int i = 0; i < quotient; i++)
            {
                Array.Copy(source, 0, destination, i * source.Length, source.Length);
            }

            // fill when keyBytesTemp.Length < keyBytes.Length
            for (int i = 0; i < remain; i++)
            {
                destination[quotient * source.Length + i] = source[i];
            }

            return destination;
        }
    }
}
