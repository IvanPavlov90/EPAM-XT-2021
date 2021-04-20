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
    public class FileEventsInfo
    {
        public FileEventsInfo()
        {

        }

        public FileEventsInfo(string path, string oldPath, DateTime changes, string typeOfEvent, string content)
        {
            FullPath = CheckPathAndEventType(path);
            OldFullPath = CheckContentAndOldPath(oldPath);
            LastChangesTime = changes;
            EventType = CheckPathAndEventType(typeOfEvent);
            Content = CheckContentAndOldPath(content);
        }

        public string FullPath { get; set; }

        public string OldFullPath { get; set; }

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

        private string CheckPathAndEventType (string str)
        {
            if (str == String.Empty || str == null)
            {
                throw new ArgumentException("You can't put empty string or null here.");
            }
            return str;
        }

        private string CheckContentAndOldPath (string str)
        {
            if (str == null)
            {
                throw new ArgumentException("You can't put empty string or null here.");
            }
            return str;
        }
    }
}
