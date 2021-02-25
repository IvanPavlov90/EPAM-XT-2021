using System;
using System.Text;

namespace Task_1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Task 1.2.1 */
            //Console.WriteLine("Please enter you text here:");
            //string text = Console.ReadLine();
            //Averages(text);

            /* Task 1.2.2 */
            Console.WriteLine("Введите Вашу строку: ");
            string firstPhrase = Console.ReadLine();
            Console.WriteLine("Введите строку для дублирования: ");
            string secondPhrase = Console.ReadLine();
            Doubler(ref firstPhrase, secondPhrase);
        }

        /* Task 1.2.1 */
        //static void Averages (string text)
        //{
        //    char[] charSeparators = new char[] { ' ', ',', ':', '-', ';', '?', '.', '!' };
        //    string[] array;
        //    float sumLetters = 0;
        //    float stringsAreNotWhiteSpaces = 0;
        //    array = text.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);

        //    foreach (string elem in array)
        //    {
        //        sumLetters += elem.Length;
        //        stringsAreNotWhiteSpaces++;
        //        Console.WriteLine(elem);
        //    }

        //    float result = sumLetters/stringsAreNotWhiteSpaces;
        //    //Округление до целого числа
        //    Console.WriteLine($"{result}, {sumLetters}, {stringsAreNotWhiteSpaces}");
        //    Console.WriteLine(Math.Round(result));
        //    Console.ReadKey();
        //}

        /* Task 1.2.2 */
        static void Doubler(ref string firstPhrase, string secondPhrase)
        {
            char[] charSecondPhrase = secondPhrase.ToCharArray();
            DeleteDoubles(charSecondPhrase);

            foreach (char elem in charSecondPhrase)
            {
                string forReplacing = elem.ToString() + elem.ToString();
                firstPhrase = firstPhrase.Replace(elem.ToString(), forReplacing);
            }

            Console.WriteLine(firstPhrase);
        }

        public static char[] DeleteDoubles (char[] charSecondPhrase)
        {
            for (int firstCount = 0; firstCount < charSecondPhrase.Length - 1; firstCount++)
            {
                for (int secondCount = firstCount + 1; secondCount < charSecondPhrase.Length; secondCount++)
                {
                    if (charSecondPhrase[firstCount] == charSecondPhrase[secondCount])
                    {
                        Array.Clear(charSecondPhrase, secondCount, 1);
                    }

                }
            }

            return charSecondPhrase;
        }
    }
}
