using System;
using System.Collections.Generic;
using System.Text;

namespace GameApp
{
    public static class Validator
    {
        /// <summary>
        /// Метод, проверяющий не вышел ли грок за игровое поле.
        /// </summary>
        /// <param name="coordintaXplayer"></param>
        /// <param name="coordintaYplayer"></param>
        /// <param name="fieldXborder"></param>
        /// <param name="fieldYborder"></param>
        /// <returns>Булево значение, в зависимости от результатов проверки.</returns>
        public static bool CheckingPlayerAndBorders(int coordinatplayer, int speed, int fieldborder, int action)
        {
            switch (action)
            {
                case 1:
                    if (coordinatplayer + speed > fieldborder) return false;
                    else return true;
                case 2:
                    if (coordinatplayer - speed < fieldborder) return false;
                    else return true;
                case 3:
                    if (coordinatplayer - speed < fieldborder) return false;
                    else return true;
                case 4:
                    if (coordinatplayer + speed > fieldborder) return false;
                    else return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Метод, который сообщает пользователю о том, что находится на гарнице игрового поля.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="field"></param>
        public static void TellUserHeIsNearBordersOfTheField (Player player, Field field)
        {
            Console.WriteLine("Данное действие совершить невозможно, Вы находитесь у границы поля.");
            player.Print();
            Program.StartApp(player, field);
        }

        public static bool CheckingPlayerAndObstacles(Player player, int action, List <GameObject> gameobjects)
        {
            switch (action)
            {
                case 1:
                    foreach (GameObject item in gameobjects)
                    {
                        if (item.CoordinatX == player.CoordinatX && item.CoordinatY + player.Speed == player.CoordinatY)
                        {
                            Console.WriteLine($"Впереди {item.Name}. Вы не можете пройти дальше");
                            return true;
                        }
                    }
                    return false;
                case 2:
                    foreach (GameObject item in gameobjects)
                    {
                        if (item.CoordinatX == player.CoordinatX && item.CoordinatY - player.Speed == player.CoordinatY)
                        {
                            Console.WriteLine($"Впереди {item.Name}. Вы не можете пройти дальше");
                            return true;
                        }
                    }
                    return false;
                case 3:
                    foreach (GameObject item in gameobjects)
                    {
                        if (item.CoordinatX == player.CoordinatX - player.Speed && item.CoordinatY == player.CoordinatY)
                        {
                            Console.WriteLine($"Впереди {item.Name}. Вы не можете пройти дальше");
                            return true;
                        }
                    }
                    return false;
                case 4:
                    foreach (GameObject item in gameobjects)
                    {
                        if (item.CoordinatX == player.CoordinatX + player.Speed && item.CoordinatY == player.CoordinatY)
                        {
                            Console.WriteLine($"Впереди {item.Name}. Вы не можете пройти дальше");
                            return true;
                        }
                    }
                    return false;
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
        public static void IsPlayerStandingOnTheGameObject(Player player, List <Bonus> gamebonuses)
        {
            foreach (Bonus item in gamebonuses)
            {
                if (item.CoordinatX == player.CoordinatX && item.CoordinatY == player.CoordinatY)
                {
                    Console.WriteLine($"Вы нашли {item.Name}");
                    if (item is Horse)
                    {
                        Console.WriteLine($"Ваша скорость увеличилась на {item.Increase}");
                        player.Speed += item.Increase;
                    }
                    if (item is Potion)
                    {
                        Console.WriteLine($"Ваше здоровье увеличилось на {item.Increase}");
                        player.Health += item.Increase;
                    }
                }
            }
        }
    }
}
