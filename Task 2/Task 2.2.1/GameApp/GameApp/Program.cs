using System;
using System.Collections.Generic;
using GameClasses;

namespace GameApp
{
    class Program
    {
        public enum MenuElements
        {
            MoveForward = 1,
            MoveBackward = 2,
            MoveLeft = 3,
            MoveRight = 4
        }

        static void Main(string[] args)
        {
            Player player = new Player("Geralt", 1, 0, 0);
            Field field = new Field();
            Horse horse1 = new Horse("Лошадь Плотва", 2, 2);
            field.AddObject(horse1);
            StartApp(player, field);
        }

        public static void StartApp(Player player, Field field)
        {
            ShowMenu();
            Console.WriteLine("Выберите действие");
            MenuElements userChoise = UserChoise();
            Game(userChoise, player, field);
        }

        /// <summary>
        /// Метод, выводящий пользовательское меню.
        /// </summary>
        public static void ShowMenu()
        {
            foreach (MenuElements element in Enum.GetValues(typeof(MenuElements)))
            {
                Console.WriteLine($"{(int)element} {element}");
            }
        }

        /// <summary>
        /// Метод, осуществляющий проверку введенных пользователем значений.
        /// </summary>
        /// <returns>Булево значение, в зависмости от правильности выбора.</returns>
        public static bool CountMenuElements(string choise)
        {
            int count = 0;
            Int32.TryParse(choise, out int userChoise);

            foreach (MenuElements element in Enum.GetValues(typeof(MenuElements)))
            {
                count++;
            }

            if (userChoise < 1 || userChoise > count)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Метод, с помощью которого пользователь выбирает действие.
        /// </summary>
        /// <returns></returns>
        public static MenuElements UserChoise()
        {
            string choise = Console.ReadLine();
            while (!CountMenuElements(choise))
            {
                Console.WriteLine("Нет такой команды, перевыберите действие.");
                choise = Console.ReadLine();
                CountMenuElements(choise);

            }
            Enum.TryParse(choise, out MenuElements result);
            return result;
        }


        /// <summary>
        /// Метод, проверяющий не вышел ли грок за игровое поле.
        /// </summary>
        /// <param name="coordintaXplayer"></param>
        /// <param name="coordintaYplayer"></param>
        /// <param name="fieldXborder"></param>
        /// <param name="fieldYborder"></param>
        /// <returns>Булево значение, в зависимости от результатов проверки.</returns>
        public static bool CheckingPositionOfThePlayerAndBordersOfTheField(int coordinatplayer, int speed, int fieldborder, MenuElements action)
        {
            switch (action)
            {
                case MenuElements.MoveForward:
                    if (coordinatplayer + speed > fieldborder)
                    {
                        return false;
                    } else
                    {
                        return true;
                    }
                case MenuElements.MoveBackward:
                    if (coordinatplayer - speed < fieldborder)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                case MenuElements.MoveLeft:
                    if (coordinatplayer - speed < fieldborder)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                case MenuElements.MoveRight:
                    if (coordinatplayer + speed > fieldborder)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                default:
                    return false;
            }
        }

        /// <summary>
        /// Метод проверяет, не подобрал ли пользователь после своего хода на какой-либо объект.
        /// Если подобрал, то в зависимости от того, что это был за объект, выводится сообщение и 
        /// происходит действие.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="gameobjects"></param>
        public static void IsPlayerStandingOnTheGameObject(Player player, List <GameObject> gameobjects)
        {
            foreach (GameObject item in gameobjects)
            {
                if (item.CoordinatX == player.CoordinatX && item.CoordinatY == player.CoordinatY)
                {
                    Console.WriteLine($"Вы нашли {item.Name}");
                    if (item is Horse)
                    {
                        Console.WriteLine($"Ваша скорость увеличилась на {item.IncreaseSpeed}");
                        player.Speed += item.IncreaseSpeed;
                    }
                }
            }
        }

            /// <summary>
            /// Метод, производящий игровые действия.
            /// </summary>
            /// <param name="action"></param>
            /// <param name="player"></param>
            public static void Game(MenuElements action, Player player, Field field)
            {
                switch (action)
                {
                    case MenuElements.MoveForward:
                        if (CheckingPositionOfThePlayerAndBordersOfTheField(player.CoordinatY, player.Speed, field.GetHeight, MenuElements.MoveForward))
                        {
                            player.MoveForward();
                            IsPlayerStandingOnTheGameObject(player, field.GetObjects);
                            player.Print();
                            StartApp(player, field);
                        }
                        else
                        {
                            Console.WriteLine("Данное действие совершить невозможно, Вы находитесь у верхней границы поля.");
                            player.Print();
                            StartApp(player, field);
                        }
                        break;
                    case MenuElements.MoveBackward:
                        if (CheckingPositionOfThePlayerAndBordersOfTheField(player.CoordinatY, player.Speed, 0, MenuElements.MoveBackward))
                        {
                            player.MoveBackward();
                            IsPlayerStandingOnTheGameObject(player, field.GetObjects);
                            player.Print();
                            StartApp(player, field);
                        } else
                        {
                            Console.WriteLine("Данное действие совершить невозможно, Вы находитесь у нижней границы поля.");
                            player.Print();
                            StartApp(player, field);
                        }
                        break;
                    case MenuElements.MoveLeft:
                        if (CheckingPositionOfThePlayerAndBordersOfTheField(player.CoordinatX, player.Speed, 0, MenuElements.MoveLeft))
                        {
                            player.MoveLeft();
                            IsPlayerStandingOnTheGameObject(player, field.GetObjects);
                            player.Print();
                            StartApp(player, field);
                        }
                        else
                        {
                            Console.WriteLine("Данное действие совершить невозможно, Вы находитесь у левой границы поля.");
                            player.Print();
                            StartApp(player, field);
                        }
                        break;
                    case MenuElements.MoveRight:
                        if (CheckingPositionOfThePlayerAndBordersOfTheField(player.CoordinatX, player.Speed, field.GetWidth, MenuElements.MoveRight))
                        {
                            player.MoveRight();
                            IsPlayerStandingOnTheGameObject(player, field.GetObjects);
                            player.Print();
                            StartApp(player, field);
                        }
                        else
                        {
                            Console.WriteLine("Данное действие совершить невозможно, Вы находитесь у правой границы поля.");
                            player.Print();
                            StartApp(player, field);
                        }
                        break;
                    default:
                        break;
                }
            }
    }
}
