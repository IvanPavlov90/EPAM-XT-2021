using System;
using System.Collections.Generic;
using System.Text;

namespace Text_Analysis.Classes
{
    public static class Analysis
    {

        /// <summary>
        /// Method for finding separators in text
        /// </summary>
        /// <param name="text"></param>
        /// <returns>Return string with all separatos in the text</returns>
        public static string GetSeparators(string text)
        {
            string separators = String.Empty;

            foreach (char elem in text)
            {
                if (!Char.IsLetterOrDigit(elem))
                {
                    separators += elem;
                }
            }

            return separators;
        }

        /// <summary>
        /// Method for splitting text.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="separators"></param>
        /// <returns></returns>
        public static string[] Splittext (string text, string separators)
        {
            string[] textarray = text.Split(separators.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < textarray.Length; i++)
            {
                textarray[i] = textarray[i].ToLower();
            }

                return textarray;
        }

        /// <summary>
        /// Method that counts whole statistic and saves it to data class.
        /// </summary>
        /// <param name="textarray"></param>
        /// <returns></returns>
        public static Data CountWords (string[] textarray)
        {
            Data data = new Data();

            for (int i = 0; i < textarray.Length; i++)
            {
                if (textarray[i].Length > 1) 
                {
                    string word = textarray[i];

                    int count = 1;

                    for (int j = i + 1; j < textarray.Length; j++)
                    {
                        if (word == textarray[j])
                        {
                            count++;
                        }
                    }

                    data.AddData<string, int>(data.QuantityWordsData, word, count);
                    double percent = (double)count / (double)textarray.Length * 100;
                    data.AddData<string, double>(data.PercentWordsData, word, Math.Round(percent, 2, MidpointRounding.AwayFromZero));
                }
            }

            return data;
        }
    }
}
