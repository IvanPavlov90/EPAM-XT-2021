using System;
using System.Collections.Generic;
using System.Text;

namespace Text_Analysis.Classes
{
    public class AppMenu
    {
        public enum MenuElements
        {
            CountWords = 1,
            PercentageWord = 2,
            IncorrectAction = 0
        }

        /// <summary>
        /// Method for showing main menu.
        /// </summary>
        public static void ShowMenu()
        {
            foreach (MenuElements item in Enum.GetValues(typeof(MenuElements)))
            {
                if ((int)item != 0)
                    Console.WriteLine($"{(int)item}. {item}");
            }
        }

        /// <summary>
        /// Method that reads users input value and convert it into enum member.
        /// </summary>
        /// <returns>Returns enum member</returns>
        public static MenuElements ReadAction()
        {
            string value = Console.ReadLine();
            if (Enum.TryParse<MenuElements>(value, out MenuElements result))
                return result;
            else
                return MenuElements.IncorrectAction;
        }

        public static void DoAction(MenuElements value, Text usertext)
        {
            switch(value)
            {
                case MenuElements.CountWords:
                    string[] words = Analysis.Splittext(usertext.UserText, Analysis.GetSeparators(usertext.UserText));
                    Analysis.CountWords(words);
                    Program.StartApp(usertext);
                    break;
                case MenuElements.PercentageWord:
                    string[] words2 = Analysis.Splittext(usertext.UserText, Analysis.GetSeparators(usertext.UserText));
                    Analysis.CountPercent(words2);
                    Program.StartApp(usertext);
                    break;
                default:
                    Console.WriteLine("Incorrect action. Try again, please.");
                    Program.StartApp(usertext);
                    break;
            }
        }
    }
}
