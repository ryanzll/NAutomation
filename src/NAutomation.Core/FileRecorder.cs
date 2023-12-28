using System;
using System.IO;

namespace NAutomation.Core
{
    internal class FileRecorder
    {
        private StreamWriter m_sw;

        public void Init(string filePath)
        {
            m_sw = new StreamWriter(filePath);
        }

        public void WriteLine(string text)
        {
            m_sw.WriteLine(text);     
        }

        public void Close()
        {
            m_sw.Flush();
            m_sw.Close();
        }
    }
}
