using System;
using System.Collections.Generic;
using System.Text;

namespace GameApp
{
    public class Potion : Bonus
    {
        public Potion(string name, int coordinatX, int coordinatY)
        {
            Name = name;
            CoordinatX = coordinatX;
            CoordinatY = coordinatY;
        }

        public override int Increase { get; } = 10;
    }
}
