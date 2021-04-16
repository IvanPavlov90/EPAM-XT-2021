using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
    }
}
