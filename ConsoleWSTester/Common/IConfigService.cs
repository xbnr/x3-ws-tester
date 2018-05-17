using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTester.Common
{
    public interface IConfigService
    {
        string GetTitle();

        string GetFormFullName();

        string GetConfigPrefixFilename();
    }
}
