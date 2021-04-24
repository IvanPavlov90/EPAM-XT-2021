using System;
using System.Collections.Generic;
using System.Text;

namespace GameApp
{
    public class Obstacle : GameObject
    {
        public Obstacle(string name, int coordinatX, int coordinatY)
        {
            Name = name;
            CoordinatX = coordinatX;
            CoordinatY = coordinatY;
        }
    }
}
