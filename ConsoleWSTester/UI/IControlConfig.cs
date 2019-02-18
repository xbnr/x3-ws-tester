using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTester.UI
{
    interface IControlConfig
    {
        void CreateWS(FileInfo item);

        void SaveWorkspace();

    }
}
