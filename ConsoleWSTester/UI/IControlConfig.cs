using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTester.UI
{
    public interface IControlConfig
    {
        bool IsVisibleInReleaseMode();

        void CreateWS(FileInfo item);

        void SaveWorkspace();

        string GetDefaultWorkspaceFilename();

    }
}
