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
                    if (Validator.CheckingPlayerAndBorders(player.CoordinatY, player.Speed, field.GetHeight, (int)MenuElements.MoveForward)) 
                    {
                        if (Validator.CheckingPlayerAndObstacles(player, (int)MenuElements.MoveForward, field.Obstacles))
                        {
                            Program.StartApp(player, field);
                        } 
                        else
                        {
                            player.MoveForward();
                            Validator.IsPlayerStandingOnTheGameObject(player, field.Bonus);
                            Program.StartApp(player, field);
                        }
                    }
                    else
                    {
                        Validator.TellUserHeIsNearBordersOfTheField(player, field);
                    }
                    break;
                case MenuElements.MoveBackward:
                    if (Validator.CheckingPlayerAndBorders(player.CoordinatY, player.Speed, 0, (int)MenuElements.MoveBackward))
                    {
                        if (Validator.CheckingPlayerAndObstacles(player, (int)MenuElements.MoveBackward, field.Obstacles))
                        {
                            Program.StartApp(player, field);
                        }
                        else
                        {
                            player.MoveBackward();
                            Validator.IsPlayerStandingOnTheGameObject(player, field.Bonus);
                            Program.StartApp(player, field);
                        }
                    }
                    else
                    {
                        Validator.TellUserHeIsNearBordersOfTheField(player, field);
                    }
                    break;
                case MenuElements.MoveLeft:
                    if (Validator.CheckingPlayerAndBorders(player.CoordinatX, player.Speed, 0, (int)MenuElements.MoveLeft))
                    {
                        if (Validator.CheckingPlayerAndObstacles(player, (int)MenuElements.MoveLeft, field.Obstacles))
                        {
                            Program.StartApp(player, field);
                        }
                        else
                        {
                            player.MoveLeft();
                            Validator.IsPlayerStandingOnTheGameObject(player, field.Bonus);
                            Program.StartApp(player, field);
                        }
                    } 
                    else
                    {
                        Validator.TellUserHeIsNearBordersOfTheField(player, field);
                    }
                    break;
                case MenuElements.MoveRight:
                    if (Validator.CheckingPlayerAndBorders(player.CoordinatX, player.Speed, field.GetWidth, (int)MenuElements.MoveRight))
                    {
                        if (Validator.CheckingPlayerAndObstacles(player, (int)MenuElements.MoveRight, field.Obstacles))
                        {
                            Program.StartApp(player, field);
                        }
                        else
                        {
                            player.MoveRight();
                            Validator.IsPlayerStandingOnTheGameObject(player, field.Bonus);
                            Program.StartApp(player, field);
                        }
                    } 
                    else
                    {
                        Validator.TellUserHeIsNearBordersOfTheField(player, field);
                    }
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
