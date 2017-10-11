using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleWSTester
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
            Console.WriteLine(message);
            control.AppendText(message + "\r\n");
        }
    }
}
