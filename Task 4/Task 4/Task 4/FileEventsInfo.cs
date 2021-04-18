using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Task_4
{
    public class FileEventsInfo : FileEventsInfoLog
    {
        public FileEventsInfo(string path, DateTime changes, string typeOfEvent, string content)
        {
            FullPath = path;
            LastChangesTime = changes;
            EventType = typeOfEvent;
            Content = content;
        }
    }
}
