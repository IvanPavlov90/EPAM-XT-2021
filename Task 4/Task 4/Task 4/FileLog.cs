﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace Task_4
{
    public static class FileLog
    {
        public static void Record(FileEventsInfo file)
        {
            using (StreamWriter writer = new StreamWriter(@"C:\Users\pavlo\Desktop\projects\EPAM-XT-2021\Task 4\Log.json", true, System.Text.Encoding.UTF8))
            {
                writer.WriteLine(Serialize(file));
            }
        }

        //public static void Record(FileEventsInfo file)
        //{
        //    using (StreamWriter writer = new StreamWriter(@"C:\Users\pavlo\Desktop\projects\EPAM-XT-2021\Task 4\Log.txt", true, System.Text.Encoding.Default))
        //    {
        //        writer.WriteLine("FullPath: " + file.FullPath + " "
        //                         + "Time Of Changes: " + file.LastChangesTime + " "
        //                         + "Type Of Changes: " + file.EventType + " "
        //                         + "Content: " + file.Content);
        //    }
        //}

        private static string Serialize(FileEventsInfo file)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            string json = JsonSerializer.Serialize<FileEventsInfo>(file, options);
            return json;
        }
    }
}
