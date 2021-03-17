using System;
using System.Collections.Generic;
using System.Text;

namespace GameClasses
{
    public static class GameMenu
    {
        public enum MenuElements
        {
            MoveForward = 1,
            MoveBackward = 2,
            MoveLeft = 3,
            MoveRight = 4,
            PrintCurrentState = 5
        }

        /// <summary>
        /// Method for showing main menu.
        /// </summary>
        public static void ShowMenu()
        {
            foreach (MenuElements item in Enum.GetValues(typeof(MenuElements)))
            {
                Console.WriteLine($"{(int)item}. {item}");
            }
        }

        /// <summary>
        /// Method that reads users input value and convert it into enum member.
        /// </summary>
        /// <returns>Returns enum member</returns>
        public static MenuElements ReadAction()
        {
            do
            {
                Console.WriteLine("Please enter your action");
                string value = Console.ReadLine();
                if (Enum.TryParse<MenuElements>(value, out MenuElements result))
                    return result;

            } while (true);
        }

        /// <summary>
        /// Method that contains main logic.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="name"></param>
        /// <param name="figures"></param>
        public static void DoAction(MenuElements value, Player player, Field field)
        {
            switch (value)
            {
                case MenuElements.MoveForward:
                    if (Validator.CheckingPositionOfThePlayerAndBordersOfTheField(player.CoordinatY, player.Speed, field.GetHeight, (int)MenuElements.MoveForward)) 
                    {
                        player.MoveForward();
                    }
                    else
                    {

                    }
                    break;
                case MenuElements.MoveBackward:
                    Validator.CheckingPositionOfThePlayerAndBordersOfTheField(player.CoordinatY, player.Speed, 0, (int)MenuElements.MoveBackward);
                    break;
                case MenuElements.MoveLeft:
                    Validator.CheckingPositionOfThePlayerAndBordersOfTheField(player.CoordinatX, player.Speed, 0, (int)MenuElements.MoveLeft);
                    break;
                case MenuElements.MoveRight:
                    Validator.CheckingPositionOfThePlayerAndBordersOfTheField(player.CoordinatX, player.Speed, field.GetWidth, (int)MenuElements.MoveRight);
                    break;
                case MenuElements.PrintCurrentState:
                    player.Print();
                    break;
                default:
                    break;
            };
        }
    }
}
