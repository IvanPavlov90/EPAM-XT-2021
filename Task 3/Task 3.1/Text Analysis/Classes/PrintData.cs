using System;
using System.Collections.Generic;
using System.Text;

namespace Text_Analysis.Classes
{
    public static class PrintData
    {
        public static void PrintMessage(string text)
        {
            Console.WriteLine(text);
        }

        public static void PrintQuantityOfWords(int QuantityOfWords)
        {
            Console.WriteLine($"There are {QuantityOfWords} words in your text");
        }

        public static void PrintInfo<T1, T2> (T1 value1, T2 value2)
        {
            Console.WriteLine(string.Format("{0} : {1}", value1, value2));
        }
    }
}
