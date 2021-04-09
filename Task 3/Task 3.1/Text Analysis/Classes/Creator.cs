using System;
using System.Collections.Generic;
using System.Text;

namespace Text_Analysis.Classes
{
    public static class Creator
    {
        public static Text CreateText ()
        {
            Console.WriteLine("Please enter you text (only one paragraph).");
            var text = IsTextEmptyOrOnlySpaces();
            Text document = new Text(text);
            Console.ReadKey();
            return document;
        }

        public static string IsTextEmptyOrOnlySpaces()
        {
            do
            {
                string usertext = Console.ReadLine();
                if (usertext.Trim().Length != 0)
                {
                    var outputtext = usertext.Trim();
                    return outputtext;
                }
            } while (true);
        }
    }
}
