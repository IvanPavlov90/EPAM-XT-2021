﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GameApp
{
    public class Player : Character
    {
        public Player(string name, int coordinatX, int coordinatY, int health) : base(name, coordinatX, coordinatY, health) { }

        public int AttackRange { get; private set; } = 6;

        public int Speed { get; } = 1;

        public bool HasSword { get; private set; } = false;

        public int CountBonus { get; private set; } = 0;

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

        public void IncreaseAttackrange(int value) => AttackRange += value;

        public void IncreaseCountBonus() => CountBonus ++;

        public void TakingSword() => HasSword = true;
    }
}
