using System;

namespace NAutomation.Core
{
    public class NAutomationCore
    {
        private static RecordHook m_recordHook;

        public static void Init()
        {
            m_recordHook = new RecordHook();
            m_recordHook.Init();
        }

        public static void UnInit()
        {
            m_recordHook.UnInit();
        }

        public static void Replay(string filePath)
        {

        }
    }
}
