using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleTester
{
    public class Logger : ILogger
    {
        private TextBox control;

        public Logger(TextBox control)
        {
            this.control = control;
        }

        public void Log(string message)
        {
            Log(message, false);
        }

        public void Log(string message, bool error)
        {
            int argbColorTextBox = 0;
            if (error)
            {
                argbColorTextBox = control.ForeColor.ToArgb();
                control.ForeColor = Color.Red;
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.WriteLine(message);
            control.AppendText(message + (error ? " ****" : "") + "\r\n");
            if (error)
            {
                control.ForeColor = Color.FromArgb(argbColorTextBox);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
