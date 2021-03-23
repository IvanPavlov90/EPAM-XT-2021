using System;
using System.Collections.Generic;
using System.Text;

namespace Text_Analysis.Classes
{
    public class TextAnalysis
    {
        public TextAnalysis(string text)
        {
            Text = IsTextEmptyOrOnlySpaces(text);
        }

        public string Text { get; private set; }

        public static string IsTextEmptyOrOnlySpaces(string text)
        {
            if (text.Trim().Length == 0)
            {
                Console.WriteLine("Wrong text. Please enter it once again");
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
            else
            {
                var outputtext = text.Trim();
                return outputtext;
            }
        }

        public static List<char> GetListOfSeparators(string text)
        {
            List<char> Separators = new List<char> { };

            foreach (char elem in text)
            {
                if (!Char.IsLetterOrDigit(elem))
                {
                    Separators.Add(elem);
                }
            }

            return Separators;
        }

    }
}
