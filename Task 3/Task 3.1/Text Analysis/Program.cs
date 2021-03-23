using System;
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
            AppMenu.ShowMenu();
            AppMenu.DoAction(AppMenu.ReadAction());
        }
    }
}
