using System;
using System.Collections.Generic;
using System.Text;

namespace Text_Analysis.Classes
{
    public class AppMenu
    {
        public enum MenuElements
        {
            Five_Most_Frequently_Words = 1,
            Words_That_Make_Up_More_Then_One_Percent_Of_TheText = 2,
            Full_Statistic_About_Words = 3,
            Enter_Anonther_Text = 4,
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

        public static void DoAction(MenuElements value, Text usertext, Data data)
        {
            switch(value)
            {
                case MenuElements.Five_Most_Frequently_Words:
                    data.ShowQuantityWordsData();
                    Program.ShowMenu(usertext);
                    break;
                case MenuElements.Words_That_Make_Up_More_Then_One_Percent_Of_TheText:
                    data.ShowPercentWordsData();
                    Program.ShowMenu(usertext);
                    break;
                case MenuElements.Full_Statistic_About_Words:
                    data.ShowFullstatistic();
                    Program.ShowMenu(usertext);
                    break;
                case MenuElements.Enter_Anonther_Text:
                    Console.Clear();
                    Program.StartApp();
                    break;
                default:
                    Console.WriteLine("Incorrect action. Try again, please.");
                    Program.ShowMenu(usertext);
                    break;
            }
        }
    }
}
