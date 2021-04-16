using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4
{
    public class FileEventsInfo
    {
        public FileEventsInfo(string path, DateTime changes, string typeOfEvent, string content)
        {
            FullPath = path;
            LastChangesTime = changes;
            EventType = typeOfEvent;
            Content = content;
        }

        public string FullPath { get; set; }

        public DateTime LastChangesTime { get; set; }

        public string EventType { get; set; }

        public string Content { get; set; }
    }
}
