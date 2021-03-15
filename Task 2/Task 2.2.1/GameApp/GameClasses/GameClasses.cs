using System;
using System.Collections.Generic;

namespace GameClasses
{
    public class Field
    {
        private int _width = 100;
        private int _height = 100;

        List <object> gameObjects = new List<object> { };

        public int GetWidth
        {
            get
            {
                return _width;
            }
        }

        public int GetHeight
        {
            get
            {
                return _height;
            }
        }

    }

    public class Player
    {
        public Player (string name, int speed, int coordinatX, int coordinatY)
        {
            Name = name;
            Speed = speed;
            CoordinatX = coordinatX;
            CoordinatY = coordinatY;
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

        public void MoveForward ()
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

        public void Print ()
        {
            Console.WriteLine($"{Name} X - {CoordinatX} Y - {CoordinatY} Speed - {Speed}");
        }
    }

    public abstract class Bonus
    {
        private string _name;
        public string Name
        {
            get => _name;
            set => _name = value;
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
    }

    public class Horse : Bonus
    {
        public Horse(string name, int coordinatX, int coordinatY)
        {
            Name = name;
            CoordinatX = coordinatX;
            CoordinatY = coordinatY;
        }

        private int _increaseSpeed = 1;
        public int IncreaseSpeed
        {
            get => _increaseSpeed;
        }
    }
}