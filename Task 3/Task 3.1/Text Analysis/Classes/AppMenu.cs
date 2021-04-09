using System;
using System.Collections.Generic;
using System.Text;

namespace Text_Analysis.Classes
{
    public class AppMenu
    {
        public enum MenuElements
        {
            FiveMostFrequentlyWords = 1,
            WordsThatMakeUpMoreThenOnePercentOfTheText = 2,
            FullStatisticAboutWords = 3,
            ShowFullStatisticAboutText = 4,
            EnterAnontherText = 5,
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
            switch (value)
            {
                case MenuElements.FiveMostFrequentlyWords:
                    data.ShowQuantityWordsData();
                    AppMenu.ShowMenu();
                    AppMenu.DoAction(AppMenu.ReadAction(), usertext, data);
                    break;
                case MenuElements.WordsThatMakeUpMoreThenOnePercentOfTheText:
                    data.ShowPercentWordsData();
                    AppMenu.ShowMenu();
                    AppMenu.DoAction(AppMenu.ReadAction(), usertext, data);
                    break;
                case MenuElements.FullStatisticAboutWords:
                    data.ShowFullStatisticAboutWords();
                    AppMenu.ShowMenu();
                    AppMenu.DoAction(AppMenu.ReadAction(), usertext, data);
                    break;
                case MenuElements.EnterAnontherText:
                    Console.Clear();
                    Program.StartApp();
                    break;
                case MenuElements.ShowFullStatisticAboutText:
                    data.ShowFullStatisticAboutText();
                    AppMenu.ShowMenu();
                    AppMenu.DoAction(AppMenu.ReadAction(), usertext, data);
                    break;
                default:
                    PrintData.PrintMessage("Incorrect action. Try again, please.");
                    AppMenu.ShowMenu();
                    AppMenu.DoAction(AppMenu.ReadAction(), usertext, data);
                    break;
            }
        }
    }
}
