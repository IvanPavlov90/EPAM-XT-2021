using System;
using System.Collections.Generic;
using System.Text;

namespace GameApp
{
    public static class ObjectCreator
    {
        public static List <(int, int)> coordinatsObstacles = new List<(int, int)> { };

        public static Player CreatePlayer()
        {
            Console.WriteLine("Please your name: ");
            string name = Console.ReadLine();
            return new Player(name, 0, 0);
        }

        /// <summary>
        /// Method for creating irresistible objects.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns>new obstacle</returns>
        public static Obstacle CreateObstacle(int width, int height)
        {
            string name = "Mountain";
            Random rnd = new Random();
            int coordinatX = rnd.Next(0, width);
            int coordinatY = rnd.Next(1, height - 1);
            if (!CheckingCoordinats(coordinatsObstacles, coordinatX, coordinatY))
            {
                coordinatsObstacles.Add((coordinatX, coordinatY));
                return new Obstacle(name, coordinatX, coordinatY);
            } 
            else
            {
                return new Obstacle(name, -coordinatX, -coordinatY);
            }
        }

        public static Enemy CreateEnemy(int width, int height)
        {
            string name = "Enemy";
            Random rnd = new Random();
            int coordinatX = rnd.Next(0, width);
            int coordinatY = rnd.Next(1, height - 1);
            return new Enemy(name, coordinatX, coordinatY);
        }

        public static Bonus CreateSword(int width, int height)
        {
            string name = "Sword";
            Random rnd = new Random();
            int coordinatX = rnd.Next(0, width);
            int coordinatY = rnd.Next(1, height - 1);
            return new Sword(name, coordinatX, coordinatY);
        }

        public static Bonus CreatePotion(int width, int height)
        {
            string name = "Potion";
            Random rnd = new Random();
            int coordinatX = rnd.Next(0, width);
            int coordinatY = rnd.Next(1, height - 1);
            return new Potion(name, coordinatX, coordinatY);
        }

        /// <summary>
        /// Method for checking if coordinats of one odjects are the same with others.
        /// </summary>
        /// <param name="coordinatX"></param>
        /// <param name="coordinatY"></param>
        /// <returns>true if the yare similar, false if they are not.</returns>
        public static bool CheckingCoordinats (List<(int, int)> coordinatsObjects, int coordinatX, int coordinatY)
        {
            foreach ((int, int) item in coordinatsObstacles)
            {
                if (item == (coordinatX, coordinatY))
                {
                    //Console.WriteLine($"Совпадение! {item}");
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
            int count = 15;
            while (count > 0)
            {
                field.AddObject(CreateObstacle(field.GetWidth, field.GetHeight));
                count--;
            }

            int count1 = 10;
            while (count1 > 0)
            {
                Enemy enemy = CreateEnemy(field.GetWidth, field.GetHeight);
                if (!CheckingCoordinats(coordinatsObstacles, enemy.CoordinatX, enemy.CoordinatY))
                {
                    field.AddEnemy(enemy);
                    count1--;
                }
            }

            int count2 = 6;
            while (count2 > 0)
            {
                Bonus sword = CreateSword(field.GetWidth, field.GetHeight);
                if (!CheckingCoordinats(coordinatsObstacles, sword.CoordinatX, sword.CoordinatY))
                {
                    field.AddBonus(sword);
                }
                Bonus potion = CreatePotion(field.GetWidth, field.GetHeight);
                if (!CheckingCoordinats(coordinatsObstacles, potion.CoordinatX, potion.CoordinatY))
                {
                    field.AddBonus(potion);
                    count2--;
                }
            }
        }
    }
}
