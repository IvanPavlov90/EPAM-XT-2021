using System;
using System.Collections.Generic;
using System.Text;

namespace GameApp
{
    public class Player
    {
        public Player(string name, int speed, int coordinatX, int coordinatY)
        {
            Name = name;
            Speed = speed;
            CoordinatX = coordinatX;
            CoordinatY = coordinatY;
            Health = 100;
        }


        private string _name;

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        private int _speed;

        public int Speed
        {
            get => _speed;
            set => _speed = value;
        }

        private int _coordinatX;

        public int CoordinatX
        {
            get => _coordinatX;
            set => _coordinatX = value;
        }

        private int _coordinatY;

        public int CoordinatY
        {
            get => _coordinatY;
            set => _coordinatY = value;
        }

        private int _health;

        public int Health
        {
            get => _health;
            set => _health = value;
        }

        public void MoveForward()
        {
            CoordinatY += Speed;
        }

        public void MoveBackward()
        {
            CoordinatY -= Speed;
        }

        public void MoveLeft()
        {
            CoordinatX -= Speed;
        }

        public void MoveRight()
        {
            CoordinatX += Speed;
        }

        public void Print()
        {
            Console.WriteLine($"{Name} X - {CoordinatX} Y - {CoordinatY} Скорость - {Speed} Здоровье - {Health}");
        }
    }
}
