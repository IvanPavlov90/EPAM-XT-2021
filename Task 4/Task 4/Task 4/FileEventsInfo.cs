using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Task_4
{
    public class FileEventsInfo
    {
        public FileEventsInfo()
        {

        }

        public FileEventsInfo(string path, string oldPath, DateTime changes, FileActions typeOfEvent, string content)
        {
            FullPath = CheckFullPath(path);
            OldFullPath = oldPath;
            LastChangesTime = changes;
            EventType = typeOfEvent;
            Content = CheckContent(content);
        }

        [JsonInclude]
        public string FullPath { get; private set;  }

        [JsonInclude]
        public string OldFullPath { get; private set; }

        [JsonInclude]
        public DateTime LastChangesTime { get; private set; }

        [JsonInclude]
        public FileActions EventType { get; private set; }

        [JsonInclude]
        public string Content { get; private set; }

        public void PrintState()
        {
            Console.WriteLine($"FullPath: {FullPath}" + Environment.NewLine +
                              $"Time Of Changes: {LastChangesTime} " + Environment.NewLine +
                              $"Type Of Changes: {EventType} " + Environment.NewLine);
        }

        private string CheckFullPath (string str)
        {
            if (String.IsNullOrWhiteSpace(str))
                throw new ArgumentException("You can't put null or white spaces into {FullPath}");
            return str;
        }

        private string CheckContent (string str)
        {
            if (str == null)
                throw new ArgumentException(String.Format("You can't put null into {0}", Content));
            return str;
        }
    }
}
