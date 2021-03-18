using System;
using System.Collections.Generic;
using System.Text;

namespace GameApp
{
    public class Player : Character
    {
        public Player(string name, int coordinatX, int coordinatY) : base(name, coordinatX, coordinatY) { }

        private int _speed = 1;

        public int Speed 
        { 
            get => _speed;
        }

        private int _health = 100;

        public int Health
        {
            get => _health;
            set => _health = value;
        }

        private int _attackrange = 5;

        public int AttackRange
        {
            get => _attackrange;
            set => _attackrange = value;
        }

        /// <summary>
        /// Method for moving
        /// </summary>
        /// <param name="border"></param>
        /// <param name="obstacles"></param>
        public void MoveForward(int border, List<GameObject> obstacles)
        {
            if (CoordinatY + Speed > border)
            {
                CoordinatY = CoordinatY;
                Console.WriteLine("You have riched border of the field, you cannot go through");
            } else
            {
                CoordinatY += Speed;
                if (CheckingPlayerAndObstacles(obstacles))
                {
                    CoordinatY -= Speed;
                }
            }
        }

        public void MoveBackward(int border, List<GameObject> obstacles)
        {
            if (CoordinatY - Speed < border)
            {
                CoordinatY = CoordinatY;
                Console.WriteLine("You have riched border of the field, you cannot go through");
            }
            else
            {
                CoordinatY -= Speed;
                if (CheckingPlayerAndObstacles(obstacles))
                {
                    CoordinatY += Speed;
                }
            }
        }

        public void MoveLeft(int border, List<GameObject> obstacles)
        {
            if (CoordinatX - Speed < border)
            {
                CoordinatX = CoordinatX;
                Console.WriteLine("You have riched border of the field, you cannot go through");
            }
            else
            {
                CoordinatX -= Speed;
                if (CheckingPlayerAndObstacles(obstacles))
                {
                    CoordinatX += Speed;
                }
            }
        }

        public void MoveRight(int border, List<GameObject> obstacles)
        {
            if (CoordinatX + Speed > border)
            {
                CoordinatX = CoordinatX;
                Console.WriteLine("You have riched border of the field, you cannot go through");
            }
            else
            {
                CoordinatX += Speed;
                if (CheckingPlayerAndObstacles(obstacles))
                {
                    CoordinatX -= Speed;
                }
            }
        }

        /// <summary>
        /// Method for printing current player's stage.
        /// </summary>
        public void Print()
        {
            Console.WriteLine($"{Name} X - {CoordinatX} Y - {CoordinatY} Attack - {AttackRange} Health - {Health}");
        }

        /// <summary>
        /// Method for checking player's position and irresistible objects.
        /// </summary>
        /// <param name="gameobjects"></param>
        /// <returns>If true, player can't go to this coordinat.</returns>
        public bool CheckingPlayerAndObstacles(List<GameObject> gameobjects)
        {
            foreach (GameObject item in gameobjects)
            {
                if (item.CoordinatX == CoordinatX && item.CoordinatY == CoordinatY)
                {
                    Console.WriteLine($"There is {item.Name} ahead. You can't go through.");
                    return true;
                }
            }
            return false;
        }
    }
}
