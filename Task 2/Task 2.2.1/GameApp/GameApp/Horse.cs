using System;
using System.Collections.Generic;
using System.Text;

namespace GameApp
{
    public class Horse : Bonus
    {
        public Horse(string name, int coordinatX, int coordinatY)
        {
            Name = name;
            CoordinatX = coordinatX;
            CoordinatY = coordinatY;
        }

        private int _increaseSpeed = 1;
        public override int Increase
        {
            get => _increaseSpeed;
        }
    }
}
