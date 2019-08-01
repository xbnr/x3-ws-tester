using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleTester.Common
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

        private List<string> logs = new List<string>();

        protected List<string> Logs => logs;

        delegate void UpdateDelegate(string message, bool error);

        public virtual void Log(string message, bool error)
        {
            logs.Add(message);

            int argbColorTextBox = 0;
            if (error && control != null)
            {
                argbColorTextBox = control.ForeColor.ToArgb();
                control.ForeColor = Color.Red;
                Console.ForegroundColor = ConsoleColor.Red;
            }
            if (control != null && control.InvokeRequired)
            {
                control.Invoke(new UpdateDelegate(Log), new object[] { message, error });
            }
            else
            {
                Console.WriteLine(message);
                control?.AppendText(message + (error ? " ****" : "") + "\r\n");
                if (error && control != null)
                {
                    control.ForeColor = Color.FromArgb(argbColorTextBox);
                    // Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }


        void ILogger.Log(string message, object tag)
        {
            throw new NotImplementedException();
        }
    }
}
