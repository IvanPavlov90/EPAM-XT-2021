using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Task_3._3
{
    public abstract class SuperString
    {
        public static void CheckLanguage(string text)
        {
            Regex english = new Regex(@"^\W*([a-zA-z]+\W*\s*)+$");
            Regex russian = new Regex(@"^\W*([а-яА-Я]+\W*\s*)+$");
            Regex digits = new Regex(@"^\W*([0-9]+\W*\s*)+$");
            Regex mixed = new Regex(@"[a-zA-z]+[а-яА-Я]+\d* | [a-zA-z]+[а-яА-Я]*\d+ | [a-zA-z]*[а-яА-Я]+\d+");
            if (english.IsMatch(text))
            {
                Console.WriteLine("English");
            }
            else if (russian.IsMatch(text))
            {
                Console.WriteLine("Russian");
            }
            else if (digits.IsMatch(text))
            {
                Console.WriteLine("Digits");
            }
            else 
            {
                Console.WriteLine("Mixed");
            }
        }
    }
}
