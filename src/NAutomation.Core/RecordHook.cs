using System;
using System.Windows.Forms;
using Gma.System.MouseKeyHook;

namespace NAutomation.Core
{
    internal class RecordHook
    {
        private IKeyboardMouseEvents m_hook;
        private FileRecorder m_fileRecorder;

        public void Init()
        {
            m_hook = Hook.AppEvents();
            m_hook.MouseClick += MouseClick;
            m_hook.MouseDoubleClick += MouseDoubleClick;

            m_fileRecorder = new FileRecorder();
            m_fileRecorder.Init("Test.txt");
        }

        public void UnInit()
        {
            m_fileRecorder.Close();
        }

        private void MouseDoubleClick(object sender, MouseEventArgs e)
        {
            m_fileRecorder.WriteLine($"JournalCommand.MouseDClick({e.X}, {e.Y});");
        }

        private void MouseClick(object sender, MouseEventArgs e)
        {
            m_fileRecorder.WriteLine($"JournalCommand.MouseClick({e.X}, {e.Y});");
        }
    }
}
