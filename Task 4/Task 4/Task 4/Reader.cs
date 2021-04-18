using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

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

        public static List<FileEventsInfoLog> ReadLog(string path)
        {
            string content;
            using (StreamReader reader = new StreamReader(path, System.Text.Encoding.UTF8))
            {
                content = reader.ReadToEnd();
            }
            List <FileEventsInfoLog> fileEvent = JsonSerializer.Deserialize<List<FileEventsInfoLog>>(content);
            return fileEvent;
        }
    }
}
