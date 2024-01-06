using Autofac;
using NAutomation.Core.Recorder;

namespace NAutomation.Core
{
    internal class AutofacModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ButtonRecorder>().Named<IControlRecorder>(nameof(ButtonRecorder)).InstancePerDependency();
            builder.RegisterType<TextBoxRecorder>().Named<IControlRecorder>(nameof(TextBoxRecorder)).InstancePerDependency();
            builder.RegisterType<FileJournal>().As<IJournal>().SingleInstance();
            builder.RegisterType<RecordHook>().AsSelf().SingleInstance();
            builder.RegisterType<RecorderMgr>().AsSelf().SingleInstance();
        }
    }
}
