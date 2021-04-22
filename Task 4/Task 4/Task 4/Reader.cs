using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Task_4
{
    public static class Reader
    {
        public static string ReadContent(string path)
        {
            string content;
            using (StreamReader reader = new StreamReader(path, System.Text.Encoding.Default))
            {
                content = reader.ReadToEnd();
            }
            return content;
        }

        public static List<FileEventsInfo> ReadLog(string path)
        {
            string content;
            using (StreamReader reader = new StreamReader(path, System.Text.Encoding.UTF8))
            {
                content = reader.ReadToEnd();
            }
            List <FileEventsInfo> fileEvent = JsonSerializer.Deserialize<List<FileEventsInfo>>(content);
            return fileEvent;
        }
    }
}
