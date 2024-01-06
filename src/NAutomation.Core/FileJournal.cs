using System;
using System.IO;

namespace NAutomation.Core
{
    internal class FileJournal: IJournal
    {
        private StreamWriter m_sw;

        public void Init(string filePath)
        {
            m_sw = new StreamWriter(filePath);
        }

        public void Write(string text)
        {
            m_sw.Write(text);     
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
