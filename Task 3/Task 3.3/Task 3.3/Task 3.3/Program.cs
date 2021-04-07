using System;
using System.Text.RegularExpressions;

namespace Task_3._3
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "ЁЁЁЁЁёж";
            text.CheckLanguage();
            byte[] array = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 0 };
            Console.WriteLine(array.MostRepeatedByteElement());
            int[] array2 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 0 };
            array2.EachElement(item => item - 2);
            foreach (var i in array2)
            {
                Console.WriteLine(i);
            }
        }
    }
}
