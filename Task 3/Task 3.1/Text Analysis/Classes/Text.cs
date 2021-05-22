using System;
using System.Collections.Generic;
using System.Text;

namespace Text_Analysis.Classes
{
    public class Text
    {
        public Text(string text)
        {
            UserText = IsTextEmptyOrOnlySpaces(text);
        }

        public string UserText { get; private set; }

        public static string IsTextEmptyOrOnlySpaces(string text)
        {
            if (text.Trim().Length == 0)
            {
                throw new Exception("You can't enter empty string here or string that contains only spaces.");
            } 
            else
            {
                var outputtext = text.Trim();
                return outputtext;
            }
        }
    }
}
