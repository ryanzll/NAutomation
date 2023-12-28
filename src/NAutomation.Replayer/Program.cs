using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAutomation.Core;

namespace NAutomation.Replayer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = args[0];
            RecordReplayer recordReplayer = new RecordReplayer();
            recordReplayer.Replay(filePath);
        }
    }
}
