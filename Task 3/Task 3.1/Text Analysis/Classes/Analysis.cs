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
        public static string[] SplitText (string text, string separators)
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
            Data data = new Data(textarray.Length);

            for (int i = 0; i < textarray.Length; i++)
            {
                data.AddQuantityWordsData(textarray[i]);
            }

            return data;
        }
    }
}
