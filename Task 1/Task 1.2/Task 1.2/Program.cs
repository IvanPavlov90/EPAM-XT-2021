using System;

namespace Task_1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Task 1.2.1 */
            Console.WriteLine("Please enter you text here:");
            string text = Console.ReadLine();
            averages(text);
        }

        static void averages (string text)
        {
            char[] charSeparators = new char[] { ' ', ',', ':', '-', ';', '?', '.'};
            string[] array;
            float sumLetters = 0;
            float stringsAreNotWhiteSpaces = 0;
            array = text.Split(charSeparators, StringSplitOptions.None);

            foreach (string elem in array)
            {
                if (!String.IsNullOrWhiteSpace(elem))
                {
                    sumLetters += elem.Length;
                    stringsAreNotWhiteSpaces++;
                    Console.WriteLine(elem);
                }
            }

            float result = sumLetters/stringsAreNotWhiteSpaces;
            /* Округление до целого числа */
            Console.WriteLine($"{result}, {sumLetters}, {stringsAreNotWhiteSpaces}");
            Console.WriteLine(Math.Round(result));
            Console.ReadKey();
        }
    }
}
