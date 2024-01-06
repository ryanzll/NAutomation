using Autofac;
using Autofac.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace NAutomation.Core.Recorder
{
    internal class RecorderMgr
    {
        IDictionary<Type, Type> m_controlRecorderMap;

        IList<IControlRecorder> m_controlRecorders;

        ILifetimeScope m_lifetimeScope;

        public RecorderMgr(ILifetimeScope scope)
        {
            m_lifetimeScope = scope;
            m_controlRecorderMap = new Dictionary<Type, Type>();
            m_controlRecorderMap.Add(typeof(Button), typeof(ButtonRecorder));
            m_controlRecorderMap.Add(typeof(TextBox), typeof(TextBoxRecorder));
            m_controlRecorders = new List<IControlRecorder>();
        }

        public bool AddControlRecorder(DependencyObject control)
        {
            Type controlType = control.GetType();
            if(!m_controlRecorderMap.ContainsKey(controlType))
            {
                return false;
            }

            Type recorderType = m_controlRecorderMap[controlType];
            var recoder = m_lifetimeScope.ResolveNamed<IControlRecorder>(recorderType.Name);
            recoder.SetControl(control);
            m_controlRecorders.Add(recoder);
            return true;
        }

        public bool RemoveAllControlRecorders()
        {
            foreach(var controlRecorder in m_controlRecorders)
            {
                controlRecorder.Stop();
            }
            m_controlRecorders.Clear();
            return true;
        }


    }
}
