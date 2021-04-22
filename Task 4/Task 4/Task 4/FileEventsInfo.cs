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

        public FileEventsInfo(string path, string oldPath, DateTime changes, string typeOfEvent, string content)
        {
            FullPath = CheckEmptyOrNull(path);
            OldFullPath = CheckStrNull(oldPath);
            LastChangesTime = changes;
            EventType = CheckEmptyOrNull(typeOfEvent);
            Content = CheckStrNull(content);
        }

        [JsonInclude]
        public string FullPath { get; private set;  }

        [JsonInclude]
        public string OldFullPath { get; private set; }

        [JsonInclude]
        public DateTime LastChangesTime { get; private set; }

        [JsonInclude]
        public string EventType { get; private set; }

        [JsonInclude]
        public string Content { get; private set; }

        public void PrintState()
        {
            Print.PrintMessage($"FullPath: {FullPath}" + Environment.NewLine +
                                   $"Time Of Changes: {LastChangesTime} " + Environment.NewLine +
                                   $"Type Of Changes: {EventType} " + Environment.NewLine +
                                   $"Content: {Content}" + Environment.NewLine);
        }

        private string CheckEmptyOrNull (string str)
        {
            if (str == String.Empty || str == null)
            {
                throw new ArgumentException("You can't put empty string or null here.");
            }
            return str;
        }

        private string CheckStrNull (string str)
        {
            if (str == null)
            {
                throw new ArgumentException("You can't put empty null here.");
            }
            return str;
        }
    }
}
