using System;
using System.Collections.Generic;
using System.Text;

namespace GameApp
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
                string value = Console.ReadLine();
                if (Enum.TryParse<MenuElements>(value, out MenuElements result))
                    return result;

            } while (true);
        }

        /// <summary>
        /// Method that contains main game logic.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="name"></param>
        /// <param name="figures"></param>
        public static void DoAction(MenuElements value, Player player, Field field)
        {
            switch (value)
            {
                case MenuElements.MoveForward:
                    player.MoveForward(field.GetHeight, field.Obstacles);
                    GameEvents.IsPlayerMeetEnemy(player, field.Enemy);
                    GameEvents.IsPlayerStandingOnTheGameObject(player, field.Bonus);
                    Program.StartApp(player, field);
                    break;
                case MenuElements.MoveBackward:
                    player.MoveBackward(0, field.Obstacles);
                    GameEvents.IsPlayerMeetEnemy(player, field.Enemy);
                    GameEvents.IsPlayerStandingOnTheGameObject(player, field.Bonus);
                    Program.StartApp(player, field);
                    break;
                case MenuElements.MoveLeft:
                    player.MoveLeft(0, field.Obstacles);
                    GameEvents.IsPlayerMeetEnemy(player, field.Enemy);
                    GameEvents.IsPlayerStandingOnTheGameObject(player, field.Bonus);
                    Program.StartApp(player, field);
                    break;
                case MenuElements.MoveRight:
                    player.MoveRight(field.GetWidth, field.Obstacles);
                    GameEvents.IsPlayerMeetEnemy(player, field.Enemy);
                    GameEvents.IsPlayerStandingOnTheGameObject(player, field.Bonus);
                    Program.StartApp(player, field);
                    break;
                case MenuElements.PrintCurrentState:
                    player.Print();
                    Program.StartApp(player, field);
                    break;
                default:
                    break;
            };
        }
    }
}
