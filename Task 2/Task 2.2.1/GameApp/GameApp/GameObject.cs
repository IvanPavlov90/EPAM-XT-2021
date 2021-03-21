using System;
using System.Collections.Generic;
using System.Text;

namespace GameApp
{
    public abstract class GameObject
    {
        public string Name { get; set; }

        public int CoordinatX { get; set; }

        public int CoordinatY { get; set; }
    }
}
