using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4
{
    public class FileEventsInfoLog
    {
        public string FullPath { get; set; }

        public DateTime LastChangesTime { get; set; }

        public string EventType { get; set; }

        public string Content { get; set; }

        public void PrintState()
        {
            Print.PrintMessage($"FullPath: {FullPath}" + Environment.NewLine +
                                   $"Time Of Changes: {LastChangesTime} " + Environment.NewLine +
                                   $"Type Of Changes: {EventType} " + Environment.NewLine +
                                   $"Content: {Content}" + Environment.NewLine);
        }
    }
}
