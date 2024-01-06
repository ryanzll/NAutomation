using System.Windows;
using System.Windows.Controls;

namespace NAutomation.Core.Recorder
{
    internal class ButtonRecorder: IControlRecorder
    {
        private Button m_button;

        private IJournal m_journal;
        
        public ButtonRecorder(IJournal journal)
        {
            m_journal = journal;
        }

        public bool SetControl(DependencyObject control)
        {
            Button button = control as Button;
            if (button == null)
            {
                return false;
            }
            m_button = button;
            m_button.Click += Button_Click;
            return true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(m_journal == null)
            {
                return;
            }

            m_journal.WriteLine($"JrnBtn.Click({m_button.Name})");
        }

        public bool Stop()
        {
            if(m_button != null)
            {
                m_button.Click -= Button_Click;
            }
            return true;
        }
    }
}
