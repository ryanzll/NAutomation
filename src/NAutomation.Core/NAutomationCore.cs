using Autofac;
using Autofac.Core;
using NAutomation.Core.Recorder;
using System;
using System.ComponentModel;

namespace NAutomation.Core
{
    public class NAutomationCore
    {
        private static Autofac.IContainer m_container;
        private static Autofac.ILifetimeScope m_lifeTimeScope;

        public static void Init()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterAssemblyModules(typeof(AutofacModule).Assembly);
            m_container = builder.Build();
            m_container.Resolve<RecordHook>().Init();
            //m_lifeTimeScope = m_container.BeginLifetimeScope();
            //var test = m_lifeTimeScope.ResolveNamed<IControlRecorder>(nameof(ButtonRecorder));
        }

        public static void UnInit()
        {
            m_container.Resolve<RecordHook>().UnInit();
        }

        public static void Replay(string filePath)
        {

        }
    }
}
