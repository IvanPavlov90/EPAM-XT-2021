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
            var text = Console.ReadLine();
            Text document = new Text(text);
            Console.ReadKey();
            return document;
        }
    }
}
