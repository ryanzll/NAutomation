using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NAutomation.Core
{
    class RecordReplayerUtil
    {
        public static void Replay(string filePath)
        {
            string curDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string replayerExePath = Path.Combine(curDirectory, "NAutomation.Replayer.exe");
            Process process = new Process();
            process.StartInfo.FileName = replayerExePath;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.Arguments = filePath;
            process.Start();
        }
    }
}
