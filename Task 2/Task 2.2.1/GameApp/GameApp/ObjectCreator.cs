using System;
using System.Collections.Generic;
using System.Linq;

namespace GameApp
{
    public static class ObjectCreator
    {
        private static List <(int, int)> coordinatsObjects = new List<(int, int)> { };

        public static Player CreatePlayer()
        {
            Console.WriteLine("Please your name: ");
            string name = Console.ReadLine();
            return new Player(name, 0, 0, 100);
        }

        /// <summary>
        /// Method for creating irresistible objects.
        /// </summary>
        /// <returns>new obstacle</returns>
        private static Obstacle CreateObstacle(int width, int height)
        {
            string name = GetObstacleName();
            Random rnd = new Random();
            int coordinatX = rnd.Next(0, width);
            int coordinatY = rnd.Next(0, height);
            return new Obstacle(name, coordinatX, coordinatY);
        }

        public static Enemy CreateEnemy(int width, int height)
        {
            string name = "Enemy";
            Random rnd = new Random();
            int coordinatX = rnd.Next(0, width + 1);
            int coordinatY = rnd.Next(1, height + 1);
            if (!CheckingCoordinats(coordinatsObjects, coordinatX, coordinatY))
            {
                coordinatsObjects.Add((coordinatX, coordinatY));
                return new Enemy(name, coordinatX, coordinatY, 75);
            }
            else
            {
                return null;
            }
        }

        public static Sword CreateSword(int width, int height)
        {
            (string, int) parametres = GetSwordParametres();
            Random rnd = new Random();
            int coordinatX = rnd.Next(0, width);
            int coordinatY = rnd.Next(0, height);
            return new Sword(parametres.Item1, coordinatX, coordinatY, parametres.Item2);
        }

        public static Bonus CreatePotion(int width, int height)
        {
            string name = "Potion";
            Random rnd = new Random();
            int coordinatX = rnd.Next(0, width);
            int coordinatY = rnd.Next(1, height);
            if (!CheckingCoordinats(coordinatsObjects, coordinatX, coordinatY))
            {
                coordinatsObjects.Add((coordinatX, coordinatY));
                return new Potion(name, coordinatX, coordinatY);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Method for checking if coordinats of one odjects are the same with others.
        /// </summary>
        /// <param name="coordinatX"></param>
        /// <param name="coordinatY"></param>
        /// <returns>true if the yare similar, false if they are not.</returns>
        private static bool CheckingCoordinats (List<(int, int)> coordinatsObjects, int coordinatX, int coordinatY)
        {
            foreach ((int, int) item in coordinatsObjects)
            {
                if (item == (coordinatX, coordinatY))
                {
                    return true;
                }
            }

            return false;
        }


        /// <summary>
        /// Method for placing irresistible objects.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public static void PlaceObjects(Field field)
        {
            int count = 20;
            while (count > 0)
            {
                Obstacle obstacle = CreateObstacle(field.GetWidth, field.GetHeight);
                if (!CheckImpositionOfObjects(obstacle, field))
                {
                    field.AddObject(obstacle);
                    count--;
                }
            }

            int count1 = 10;
            while (count1 > 0)
            {
                Enemy enemy = CreateEnemy(field.GetWidth, field.GetHeight);
                if (enemy != null)
                {
                    field.AddEnemy(enemy);
                    count1--;
                }
            }

            int count2 = 7;
            while (count2 > 0)
            {
                Sword sword = CreateSword(field.GetWidth, field.GetHeight);
                field.AddBonus(sword);
                Bonus potion = CreatePotion(field.GetWidth, field.GetHeight);
                if (potion != null)
                {
                    field.QuantityOfPotions++;
                    field.AddBonus(potion);
                    count2--;
                }
            }
        }

        /// <summary>
        /// Method for appointment obstacle name.
        /// </summary>
        /// <returns>Obstacle name</returns>
        private static string GetObstacleName ()
        {
            List<string> obstacleNames = DataBase.ObstacleNames;
            Random rnd = new Random();
            int value = rnd.Next(0, obstacleNames.Count());
            return obstacleNames[value];
        }

        private static (string, int) GetSwordParametres ()
        {
            List<(string, int)> swordParametres = DataBase.SwordParametres;
            Random rnd = new Random();
            int value = rnd.Next(0, swordParametres.Count());
            return swordParametres[value];
        }

        /// <summary>
        /// Method for checking imposition of object's coordinats. 
        /// If there is any object in List that has the same coordinates with just created object
        /// method returns true, else it returns false.
        /// </summary>
        private static bool CheckImpositionOfObjects (Obstacle obstacle, Field field)
        {
            List <Obstacle> obstacles = field.Obstacles;
            if (obstacle.CoordinatX == 0 & obstacle.CoordinatY == 0) return false;
            bool result = obstacles.Any(item => item.CoordinatX == obstacle.CoordinatX & item.CoordinatY == obstacle.CoordinatY);
            return result;
        }
    }
}
