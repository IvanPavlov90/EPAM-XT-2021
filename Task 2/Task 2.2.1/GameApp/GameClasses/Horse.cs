using System;
using System.Collections.Generic;
using System.Text;

namespace GameClasses
{
    public class Horse : GameObject
    {
        public Horse(string name, int coordinatX, int coordinatY)
        {
            Name = name;
            CoordinatX = coordinatX;
            CoordinatY = coordinatY;
        }

        private int _increaseSpeed = 1;
        public override int IncreaseSpeed
        {
            get => _increaseSpeed;
        }
    }
}
