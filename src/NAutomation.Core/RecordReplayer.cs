using Microsoft.ClearScript.V8;
using System;

namespace NAutomation.Core
{
    public class RecordReplayer
    {
        public void Replay(string filePath)
        {
            using(var engine = new V8ScriptEngine())
{
    engine.AddHostType("Console", typeof(Console));
    engine.AddHostType("JournalCommand", typeof(JournalCommand));
    //engine.AddHostObject("journalCommand", new JournalCommand());
    //engine.Execute(@"
    //    Console.WriteLine('Test');
    //");
    engine.Execute(@"
        /*[2023-11-30 14:56:11(342)]*/ 
        //[FYI      ][TID:668] 
        JournalCommand.MouseMove();
    ");
}
        }
    }
}
