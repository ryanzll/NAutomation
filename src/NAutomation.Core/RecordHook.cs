using NAutomation.Core.Recorder;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace NAutomation.Core
{
    internal class RecordHook
    {
        private IJournal m_journal;
        private RecorderMgr m_recordMgr;
        private Window m_activeWindow;

        public RecordHook(IJournal jounal, RecorderMgr recorderMgr)
        {
            m_journal = jounal;
            m_recordMgr = recorderMgr;
        }

        public void Init()
        {
            FileJournal fileJournal = m_journal as FileJournal;
            fileJournal.Init("Test.txt");
            InitWindows();
        }

        public void UnInit()
        {
            m_journal.Close();
        }

        void InitWindows()
        {
            List<Window> allWindows = Application.Current.Windows.OfType<Window>().ToList();
            var activeWindow = allWindows.FirstOrDefault(w => w.IsActive);
            if(activeWindow != null)
            {
                m_activeWindow = activeWindow;
                m_activeWindow.Deactivated += Window_Deactivated;
                ListenChildrenControls(m_activeWindow);
            }
            else
            {
                foreach(Window window in allWindows)
                {
                    window.Activated += Window_Activated;
                }
                m_activeWindow = null;
            }
        }

        private void Window_Deactivated(object sender, System.EventArgs e)
        {
            List<Window> allWindows = Application.Current.Windows.OfType<Window>().ToList();
            foreach (Window curWindow in allWindows)
            {
                curWindow.Deactivated -= Window_Deactivated;
                curWindow.Activated -= Window_Activated;
                curWindow.Activated += Window_Activated;
            }
            m_activeWindow = null;
            m_recordMgr.RemoveAllControlRecorders();
        }

        private void Window_Activated(object sender, System.EventArgs e)
        {
            Window window = sender as Window;
            m_activeWindow = window;
            window.Activated -= Window_Activated;
            window.Deactivated -= Window_Deactivated;
            window.Deactivated += Window_Deactivated;

            ListenChildrenControls(window);
        }

        private void ListenChildrenControls(DependencyObject parent)
        {
            var childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for(int index = 0; index < childrenCount; index++)
            {
                var child = VisualTreeHelper.GetChild(parent, index);
                m_recordMgr.AddControlRecorder(child);
                ListenChildrenControls(child);
            }
        }
    }
}
