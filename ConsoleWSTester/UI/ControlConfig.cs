using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTester.UI
{
    public class ControlConfig : IControlConfig
    {
        public virtual void CreateWS(FileInfo item)
        {
            throw new NotImplementedException();
        }

        public virtual bool IsVisibleInReleaseMode()
        {
            throw new NotImplementedException();
        }


        public virtual void SaveWorkspace()
        {
            throw new NotImplementedException();
        }

        public virtual string GetDefaultWorkspaceFilename()
        {
            throw new NotImplementedException();
        }
    }
}
