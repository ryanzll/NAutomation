using System.Windows;
using System.Windows.Controls;

namespace NAutomation.Core.Recorder
{
    internal interface IControlRecorder
    {
        bool SetControl(DependencyObject control);

        bool Stop();
    }
}
