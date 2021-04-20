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
    public static class FileLog
    {
        public static void Record(List<FileEventsInfo> log)
        {
             using (StreamWriter writer = new StreamWriter(@"C:\Users\pavlo\Desktop\projects\EPAM-XT-2021\Task 4\Log.json", true, System.Text.Encoding.UTF8))
             {
                    writer.WriteLine(Serialize(log));
             }
        }

        private static string Serialize(List<FileEventsInfo> log)
        {
             var options = new JsonSerializerOptions
             {
                 WriteIndented = true
             };
             string json = JsonSerializer.Serialize<List<FileEventsInfo>>(log, options);
             return json;
        }
    }
}
