using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace NAutomation.Core.Recorder
{
    internal class TextBoxRecorder : IControlRecorder
    {
        TextBox m_textBox;

        IJournal m_journal;
        
        public TextBoxRecorder(IJournal journal)
        {
            m_journal = journal;
        }

        public bool SetControl(DependencyObject control)
        {
            TextBox textBox = control as TextBox;
            if(null == textBox)
            {
                return false;
            }

            m_textBox = textBox;
            m_textBox.TextChanged += TextBox_TextChanged;

            return true;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(m_journal == null)
            {
                return;
            }
            
            m_journal.WriteLine($"JrnTextBox.Text({m_textBox.Name}, {m_textBox.Text})");
        }

        public bool Stop()
        {
            if(null != m_textBox)
            {
                m_textBox.TextChanged -= TextBox_TextChanged;
                m_textBox = null;
            }
            return true;
        }
    }
}
