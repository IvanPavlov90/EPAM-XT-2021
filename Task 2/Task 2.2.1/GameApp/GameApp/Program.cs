using System;
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
            Horse horse1 = new Horse("Plotva", 2, 2);
            StartApp(player, field);
        }

        public static void StartApp (Player player, Field field)
        {
            ShowMenu();
            Console.WriteLine("Выберите действие");
            MenuElements userChoise = UserChoise();
            Action(userChoise, player, field);
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
        public static bool CheckingPositionOfThePlayerAndBordersOfTheField (int coordintaXplayer, int coordintaYplayer, int fieldXborder, int fieldYborder)
        {
            if (coordintaXplayer <= 0 || coordintaXplayer > fieldXborder)
            {
                return false;
            } else if (coordintaYplayer <= 0 || coordintaYplayer > fieldYborder)
            {
                return false;
            }
            return true;
        } 

        /// <summary>
        /// Метод, производящий игровые действия.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="player"></param>
        public static void Action(MenuElements action, Player player, Field field)
        {
            switch (action)
            {
                case MenuElements.MoveForward:
                    if (CheckingPositionOfThePlayerAndBordersOfTheField(player.CoordinatX, player.CoordinatY, field.GetWidth, field.GetHeight))
                    {
                        player.MoveBackward();
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
                    if (CheckingPositionOfThePlayerAndBordersOfTheField(player.CoordinatX, player.CoordinatY, field.GetWidth, field.GetHeight))
                    {
                        player.MoveBackward();
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
                    if (CheckingPositionOfThePlayerAndBordersOfTheField(player.CoordinatX, player.CoordinatY, field.GetWidth, field.GetHeight))
                    {
                        player.MoveBackward();
                        player.Print();
                        StartApp(player, field);
                    }
                    else
                    {
                        Console.WriteLine("Данное действие совершить невозможно, Вы находитесь у нижней левой поля.");
                        player.Print();
                        StartApp(player, field);
                    }
                    break;
                case MenuElements.MoveRight:
                    if (CheckingPositionOfThePlayerAndBordersOfTheField(player.CoordinatX, player.CoordinatY, field.GetWidth, field.GetHeight))
                    {
                        player.MoveBackward();
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
