using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAutomation.Core
{
    internal interface IJournal
    {
        void Write(string text);
        void WriteLine(string text);

        void Close();
    }
}
