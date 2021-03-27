using System;
using System.Linq;
using Text_Analysis.Classes;

namespace Text_Analysis
{
    public class Program
    {
        static void Main(string[] args)
        {
            StartApp();
        }

        public static void StartApp()
        {
            Text usertext = Creator.CreateText();
            ShowMenu(usertext);
        }

        public static void ShowMenu(Text usertext)
        {
            string[] words = Analysis.Splittext(usertext.UserText, Analysis.GetSeparators(usertext.UserText));
            Data data = Analysis.CountWords(words);
            AppMenu.ShowMenu();
            AppMenu.DoAction(AppMenu.ReadAction(), usertext, data);
        }
    }
}
