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
            //Console.WriteLine("Введите Вашу строку: ");
            //string firstPhrase = Console.ReadLine();
            //Console.WriteLine("Введите строку для дублирования: ");
            //string secondPhrase = Console.ReadLine();
            //Doubler(ref firstPhrase, secondPhrase);

            /* Task 1.2.3 */
            //Console.WriteLine("Please enter you text here:");
            //string text = Console.ReadLine();
            //Lowercase(text);

            /* Task 1.2.4 */
            Console.WriteLine("Please enter you text here:");
            string text = Console.ReadLine();
            Validator(text);
        }

        /* Task 1.2.1 */
        //static void Averages(string text)
        //{
        //    char[] charSeparators = GetArrayOfSeparators(text);
        //    string[] array = text.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
        //    float sumLetters = 0;
        //    float sumWords = 0;

        //    foreach (string elem in array)
        //    {
        //        sumLetters += elem.Length;
        //        sumWords++;
        //        Console.WriteLine(elem);
        //    }

        //    float result = sumLetters / sumWords;
        //    //Округление до целого числа
        //    Console.WriteLine($"{sumLetters}, {sumWords}, {result}");
        //    Console.WriteLine(Math.Round(result));
        //    Console.ReadKey();
        //}

        //static int FindNumberOfSeparators(string text) 
        //{
        //    int countSeparators = 1;

        //    foreach (char elem in text)
        //    {
        //        if (!Char.IsLetterOrDigit(elem) && !Char.IsWhiteSpace(elem)) countSeparators++;
        //    }

        //    return countSeparators;
        //}

        //static char[] GetArrayOfSeparators(string text)
        //{
        //    char[] Separators = new char[FindNumberOfSeparators(text)];
        //    int i = 0;

        //    foreach (char elem in text)
        //    {
        //        if (!Char.IsLetterOrDigit(elem) && !Char.IsWhiteSpace(elem)) 
        //        {
        //            Separators[i] = elem;
        //            i++;
        //        }
        //    }

        //    Separators[i] = ' ';

        //    return Separators;
        //}

        /* Task 1.2.2 */
        //static void Doubler(ref string firstPhrase, string secondPhrase)
        //{
        //    char[] charSecondPhrase = secondPhrase.ToCharArray();
        //    DeleteDoubles(charSecondPhrase);

        //    foreach (char elem in charSecondPhrase)
        //    {
        //        string forReplacing = elem.ToString() + elem.ToString();
        //        firstPhrase = firstPhrase.Replace(elem.ToString(), forReplacing);
        //    }

        //    Console.WriteLine(firstPhrase);
        //}

        //public static char[] DeleteDoubles (char[] charSecondPhrase)
        //{
        //    for (int firstCount = 0; firstCount < charSecondPhrase.Length - 1; firstCount++)
        //    {
        //        for (int secondCount = firstCount + 1; secondCount < charSecondPhrase.Length; secondCount++)
        //        {
        //            if (charSecondPhrase[firstCount] == charSecondPhrase[secondCount])
        //            {
        //                Array.Clear(charSecondPhrase, secondCount, 1);
        //            }

        //        }
        //    }

        //    return charSecondPhrase;
        //}

        /* Task 1.2.3 */
        //static void Lowercase(string text)
        //{
        //    char[] Separators = GetArrayOfSeparators(text);
        //    string[] array = text.Split(Separators, StringSplitOptions.RemoveEmptyEntries);
        //    int sumWords = 0;

        //    foreach (string elem in array)
        //    {
        //        char[] letters = elem.ToCharArray();
        //        if (Char.IsLower(letters[0])) sumWords++;
        //    }

        //    Console.WriteLine($"{sumWords}");
        //    Console.ReadKey();
        //}

        //static int FindNumberOfSeparators(string text)
        //{
        //    int countSeparators = 1;

        //    foreach (char elem in text)
        //    {
        //        if (!Char.IsLetterOrDigit(elem) && !Char.IsWhiteSpace(elem)) countSeparators++;
        //    }

        //    return countSeparators;
        //}

        //static char[] GetArrayOfSeparators(string text)
        //{
        //    char[] Separators = new char[FindNumberOfSeparators(text)];
        //    int i = 0;

        //    foreach (char elem in text)
        //    {
        //        if (!Char.IsLetterOrDigit(elem) && !Char.IsWhiteSpace(elem))
        //        {
        //            Separators[i] = elem;
        //            i++;
        //        }
        //    }

        //    Separators[i] = ' ';

        //    return Separators;
        //}

        /* Task 1.2.4 */
        static void Validator(string text)
        {
            char[] charSeparators = GetArrayOfSeparators(text);
            string result = "";
            switch (charSeparators.Length) 
            {
                case 0:
                    result += ChangeSymbols(text);
                    break;
                default:
                    string[] array = text.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);

                    for (int count = 0; count < array.Length; count++)
                    {
                        result += ChangeSymbols(array[count]) + charSeparators[count];
                    }
                    break;
            }
            
            Console.WriteLine(result);
            Console.ReadKey();
        }

        static string ChangeSymbols(string text)
        {
            char[] symbols = text.ToCharArray();

            int i = 0;
            while (!Char.IsLetterOrDigit(symbols[i]))
            {
                i++;
            }

            symbols[i] = Char.ToUpper(symbols[i]);

            string output = new string(symbols);

            return output;
        }


        static int FindNumberOfSeparators(string text)
        {
            int countSeparators = 0;

            foreach (char elem in text)
            {
                if (!Char.IsLetterOrDigit(elem) && !Char.IsWhiteSpace(elem)) countSeparators++;
            }

            return countSeparators;
        }

        static char[] GetArrayOfSeparators(string text)
        {
            char[] Separators = new char[FindNumberOfSeparators(text)];
            int i = 0;

            foreach (char elem in text)
            {
                if (!Char.IsLetterOrDigit(elem) && !Char.IsWhiteSpace(elem) && (elem == '.' || elem == '?' || elem == '!'))
                {
                    Separators[i] = elem;
                    i++;
                }
            }

            return Separators;
        }
    }
}
