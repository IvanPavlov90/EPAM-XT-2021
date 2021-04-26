using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Task_4
{
    public class LogsSerializer
    {
        public LogsSerializer(string path)
        {
            if (path == null || path == String.Empty)
                throw new ArgumentException("Path to log can't be null or empty.");

            _logPath = path;
        }

        private string _logPath { get; set; }

        /// <summary>
        /// This method wrties infromation in log.
        /// </summary>
        public void Record(List<FileEventsInfo> log)
        {
            File.WriteAllText(_logPath, String.Empty);
            using (StreamWriter writer = new StreamWriter(_logPath, true, System.Text.Encoding.UTF8))
            {
                writer.WriteLine(Serialize(log));
            }
        }

        /// <summary>
        /// This method serialize information from objects of FileEventsinfo class into json.
        /// </summary>
        /// <returns>String in json format.</returns>
        private string Serialize(List<FileEventsInfo> log)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            string json = JsonSerializer.Serialize<List<FileEventsInfo>>(log, options);
            return json;
        }

        /// <summary>
        /// This method deserialize log into list of FileEventsInfo objects.
        /// </summary>
        public List<FileEventsInfo> ReadLog()
        {
            string content;
            using (StreamReader reader = new StreamReader(_logPath, System.Text.Encoding.UTF8))
            {
                content = reader.ReadToEnd();
            }
            List<FileEventsInfo> fileEvent = JsonSerializer.Deserialize<List<FileEventsInfo>>(content);
            return fileEvent;
        }
    }
}
