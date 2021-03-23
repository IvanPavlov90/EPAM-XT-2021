using System;
using System.Collections.Generic;
using System.Text;

namespace Text_Analysis.Classes
{
    public class AppMenu
    {
        public enum MenuElements
        {
            EnterText = 1,
            GetAnalysis = 2,
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

        public static void DoAction(MenuElements value)
        {
            switch(value)
            {
                case MenuElements.EnterText:
                    Console.WriteLine("Please enter you text");
                    var text = Console.ReadLine();
                    TextAnalysis document = new TextAnalysis(text);
                    Console.WriteLine(document.Text);
                    break;
                case MenuElements.GetAnalysis:
                    break;
                default:
                    Console.WriteLine("Incorrect action. Try again, please.");
                    Program.StartApp();
                    break;
            }
        }
    }
}
