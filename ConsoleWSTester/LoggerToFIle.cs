using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleTester
{
    public class LoggerToFile : Logger, IDisposable
    {
        private string fileName;
        public LoggerToFile(string fileName, TextBox control): base(control)
        {
            this.fileName = fileName;
        }

        public void Dispose()
        {
            WriteLogs();
        }

        public override void Log(string message, bool error)
        {
            base.Log(message, error);
        }

        private void WriteLogs()
        {
            string dir = Path.GetDirectoryName(this.fileName);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            if (!File.Exists(this.fileName))
            {
                File.CreateText(fileName);
            }
            File.AppendAllLines(this.fileName, this.Logs);
            this.Logs.Clear();
        }
    }
}
