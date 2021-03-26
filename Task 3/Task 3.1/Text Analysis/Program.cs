using System;
using Text_Analysis.Classes;

namespace Text_Analysis
{
    public class Program
    {
        static void Main(string[] args)
        {
            Text usertext = Creator.CreateText();
            StartApp(usertext);
        }

        public static void StartApp(Text usertext)
        {
            AppMenu.ShowMenu();
            AppMenu.DoAction(AppMenu.ReadAction(), usertext);
        }
    }
}
