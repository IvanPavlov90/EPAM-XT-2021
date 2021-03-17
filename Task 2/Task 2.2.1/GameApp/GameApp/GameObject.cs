using System;
using System.Collections.Generic;
using System.Text;

namespace GameApp
{
    public abstract class GameObject
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
}
