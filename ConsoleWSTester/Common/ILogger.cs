using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTester.Common
{
    public interface ILogger
    {
        void Log(string message);

        void Log(string message, bool error);

        void Log(string message, object tag);

    }
}
