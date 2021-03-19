using System;
using System.Collections.Generic;
using System.Text;

namespace GameApp
{
    public static class ObjectCreator
    {
        public static List <(int, int)> coordinatsObjects = new List<(int, int)> { };

        public static Player CreatePlayer()
        {
            Console.WriteLine("Please your name: ");
            string name = Console.ReadLine();
            return new Player(name, 0, 0);
        }

        /// <summary>
        /// Method for creating irresistible objects. In this method I've tried to input logic that will be
        /// prohibit to create two mountains with the same coordinats. If method creates mountain with coordinats
        /// taht already has another mountain, method will create object with negative coordinats and player
        /// will never see them.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns>new obstacle</returns>
        public static Obstacle CreateObstacle(int width, int height)
        {
            string name = "Mountain";
            Random rnd = new Random();
            int coordinatX = rnd.Next(0, width);
            int coordinatY = rnd.Next(1, height);
            if (!CheckingCoordinats(coordinatsObjects, coordinatX, coordinatY))
            {
                coordinatsObjects.Add((coordinatX, coordinatY));
                return new Obstacle(name, coordinatX, coordinatY);
            } 
            else
            {
                return null;
            }
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
                return new Enemy(name, coordinatX, coordinatY);
            }
            else
            {
                return null;
            }
        }

        public static Bonus CreateSword(int width, int height)
        {
            string name = "Sword";
            Random rnd = new Random();
            int coordinatX = rnd.Next(0, width);
            int coordinatY = rnd.Next(1, height);
            if (!CheckingCoordinats(coordinatsObjects, coordinatX, coordinatY))
            {
                coordinatsObjects.Add((coordinatX, coordinatY));
                return new Sword(name, coordinatX, coordinatY);
            }
            else
            {
                return null;
            }
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
        public static bool CheckingCoordinats (List<(int, int)> coordinatsObjects, int coordinatX, int coordinatY)
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
                if (obstacle != null)
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
                Bonus sword = CreateSword(field.GetWidth, field.GetHeight);
                if (sword != null)
                {
                    field.AddBonus(sword);
                }
                Bonus potion = CreatePotion(field.GetWidth, field.GetHeight);
                if (potion != null)
                {
                    field.QuantityOfPotions++;
                    field.AddBonus(potion);
                    count2--;
                }
            }
        }
    }
}
