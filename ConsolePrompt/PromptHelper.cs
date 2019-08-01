using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePrompt
{
    public static class PromptHelper
    {
        public enum EnterValueOption { None, UpperCase };
        public static ConsoleColor ForegroundColorDefault { get; set; } = ConsoleColor.White;
        public static ConsoleColor ForegroundColorError { get; set; } = ConsoleColor.Red;
        /// <summary>
        /// Important info: Blue
        /// </summary>
        public static ConsoleColor ForegroundColorInfo { get; set; } = ConsoleColor.Cyan;
        /// <summary>
        /// Warnings: Yellow
        /// </summary>
        public static ConsoleColor ForegroundColorWarning { get; set; } = ConsoleColor.Yellow;

        public static string EnterValue(string promptLabel)
        {
            string result = null;
            while (string.IsNullOrEmpty(result))
            {
                result = EnterValue(promptLabel, null, EnterValueOption.None);
            }
            return result;
        }

        public static string EnterValue(string promptLabel, string defaultValue, EnterValueOption valueOption)
        {
            string result = defaultValue;
            PromptHelper.ShowPromptHighlight(promptLabel);
            string valueEntered = EnterString();
            if (!string.IsNullOrEmpty(valueEntered))
            {
                result = valueEntered.Trim();
            }

            switch (valueOption)
            {
                case EnterValueOption.UpperCase:
                    if (!string.IsNullOrEmpty(result))
                    {
                        result = result.ToUpper();
                    }
                    break;
                case EnterValueOption.None:
                default:
                    break;
            }
            return result;
        }

        public static bool EnterBooleanValue(string promptLabel, bool defaultValue)
        {
            bool result = defaultValue;
            PromptHelper.ShowPromptInfo(promptLabel);
            string valueEntered = EnterString();
            if (!string.IsNullOrEmpty(valueEntered))
            {
                if (valueEntered.Trim().Equals("Yes", StringComparison.InvariantCultureIgnoreCase))
                {
                    result = true;
                }
                if (valueEntered.Trim().Equals("True", StringComparison.InvariantCultureIgnoreCase))
                {
                    result = true;
                }
            }
            return result;
        }

        private static string EnterString()
        {
            var pwd = new StringBuilder();
            while (true)
            {
                ConsoleKeyInfo i = System.Console.ReadKey(true);
                if (i.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (i.Key == ConsoleKey.Backspace)
                {
                    if (pwd.Length > 0)
                    {
                        pwd.Remove(pwd.Length - 1, 1);
                        System.Console.Write("\b \b");
                    }
                }
                else if (i.KeyChar != '\u0000') // KeyChar == '\u0000' if the key pressed does not correspond to a printable character, e.g. F1, Pause-Break, etc
                {
                    pwd.Append(i.KeyChar);
                    System.Console.Write(i.KeyChar);
                }
            }
            System.Console.Out.Write("\n");
            return pwd.ToString();
        }



        public static string DecodePassword(SecureString securedPassword)
        {
            return new NetworkCredential(string.Empty, securedPassword).Password;
        }

        public static SecureString EnterPassword()
        {
            var pwd = new SecureString();
            while (true)
            {
                ConsoleKeyInfo i = System.Console.ReadKey(true);
                if (i.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (i.Key == ConsoleKey.Backspace)
                {
                    if (pwd.Length > 0)
                    {
                        pwd.RemoveAt(pwd.Length - 1);
                        System.Console.Write("\b \b");
                    }
                }
                else if (i.KeyChar != '\u0000') // KeyChar == '\u0000' if the key pressed does not correspond to a printable character, e.g. F1, Pause-Break, etc
                {
                    pwd.AppendChar(i.KeyChar);
                    System.Console.Write("*");
                }
            }
            System.Console.Out.Write("\n");
            return pwd;
        }

        public static void ShowPromptWarning(string frienlyMesg)
        {
            System.Console.ForegroundColor = PromptHelper.ForegroundColorWarning;
            System.Console.Out.WriteLine(frienlyMesg);
            System.Console.ForegroundColor = PromptHelper.ForegroundColorDefault;
        }

        public static void ShowPromptInfo(string frienlyMesg)
        {
            System.Console.ForegroundColor = PromptHelper.ForegroundColorDefault;
            System.Console.Out.WriteLine(frienlyMesg);
            System.Console.ForegroundColor = PromptHelper.ForegroundColorDefault;
        }

        public static void ShowPromptHighlight(string frienlyMesg)
        {
            System.Console.ForegroundColor = PromptHelper.ForegroundColorInfo;
            System.Console.Out.WriteLine(frienlyMesg);
            System.Console.ForegroundColor = PromptHelper.ForegroundColorDefault;
        }


        public static void ShowPromptError(string frienlyMesg)
        {
            System.Console.ForegroundColor = PromptHelper.ForegroundColorError;
            System.Console.Error.WriteLine(frienlyMesg);
            System.Console.ForegroundColor = PromptHelper.ForegroundColorDefault;
        }

        
    }
}
