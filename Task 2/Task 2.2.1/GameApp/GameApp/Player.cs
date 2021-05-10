using System;
using System.Collections.Generic;
using System.Text;

namespace GameApp
{
    public class Player : Character
    {
        public Player(string name, int coordinatX, int coordinatY, int health) : base(name, coordinatX, coordinatY, health) { }

        public int AttackRange { get; private set; } = 6;

        public int Speed { get; } = 1;

        private bool _hasSword = false;

        public bool HasSword => _hasSword;

        public int CountBonus { get; private set; } = 0;

        private Sword _mySword;

        public Sword MySword => _mySword;

        public void TakeSword (Sword sword)
        {
            _mySword = sword;
            AttackRange = 6 + sword.IncreaseAttackRange;
            _hasSword = true;
        }

        /// <summary>
        /// Method for moving
        /// </summary>
        /// <param name="border"></param>
        /// <param name="obstacles"></param>
        public void MoveForward(int border, List<Obstacle> obstacles)
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

        public void MoveBackward(int border, List<Obstacle> obstacles)
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

        public void MoveLeft(int border, List<Obstacle> obstacles)
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

        public void MoveRight(int border, List<Obstacle> obstacles)
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
        public bool CheckingPlayerAndObstacles(List<Obstacle> gameobjects)
        {
            foreach (Obstacle item in gameobjects)
            {
                if (item.CoordinatX == CoordinatX && item.CoordinatY == CoordinatY)
                {
                    Console.WriteLine($"There is {item.Name} ahead. You can't go through.");
                    return true;
                }
            }
            return false;
        }

        private void IncreaseAttackrange(int value) => AttackRange += value;

        public void IncreaseCountBonus() => CountBonus ++;
    }
}
