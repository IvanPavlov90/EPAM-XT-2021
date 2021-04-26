using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Task_4
{
    public static class Reader
    {
        /// <summary>
        /// This method reads content from file
        /// </summary>
        public static string ReadContent(string path)
        {
            string content;
            using (StreamReader reader = new StreamReader(path, System.Text.Encoding.Default))
            {
                content = reader.ReadToEnd();
            }
            return content;
        }
    }
}
