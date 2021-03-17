using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1._2
{
    /// <summary>
    /// Class for main menu of the program.
    /// </summary>
    public static class MainMenu
    {
        public enum Action
        {
            Add_Figure = 1,
            Print_Figures = 2,
            Clear_Screen = 3,
            Change_User = 4,
            Exit = 5
        }

        /// <summary>
        /// Method for showing main menu.
        /// </summary>
        public static void ShowMenu()
        {
            foreach (Action item in Enum.GetValues(typeof(Action)))
            {
                Console.WriteLine($"{(int)item}. {item}");
            }
        }

        /// <summary>
        /// Method that reads users input value and convert it into enum member.
        /// </summary>
        /// <returns>Returns enum member</returns>
        public static Action ReadAction()
        {
            do
            {
                Console.WriteLine("Please enter your action");
                string value = Console.ReadLine();
                if (Enum.TryParse<Action>(value, out Action result))
                    return result;

            } while (true);
        }

        /// <summary>
        /// Method that contains main logic.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="name"></param>
        /// <param name="figures"></param>
        public static void DoAction (Action value, string name, List<object> figures) 
        {
            switch (value)
            {
                case Action.Add_Figure:
                    PaintMenu.ShowMenu();
                    PaintMenu.DoAction(PaintMenu.ReadAction(), name, figures);
                    break;
                case Action.Print_Figures:
                    PrintFigures(name, figures);
                    Program.CustomPaint(name, figures);
                    break;
                case Action.Clear_Screen:
                    figures.Clear();
                    Console.Clear();
                    Console.WriteLine($"{name}, your screen is clear now.");
                    Program.CustomPaint(name, figures);
                    break;
                case Action.Change_User:
                    Console.Clear();
                    //string username = Validator.SetUser();
                    //Validator.SearchUser(username, out int index);
                    Program.StartApp();
                    break;
                case Action.Exit:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine($"{name}, You have entered wrong action.");
                    Program.CustomPaint(name, figures);
                    break;
            };
        }

        /// <summary>
        /// Method for printing figures.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="figures"></param>
        public static void PrintFigures(string name, List<object> figures)
        {
            if (figures.Count == 0)
            {
                Console.WriteLine($"{name}, you have nothing to show.");
            }
            else
            {
                foreach (object item in figures)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }
    }
}
