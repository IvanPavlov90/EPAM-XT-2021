using System;
using System.Collections.Generic;
using System.Text;

namespace GameApp
{
    public abstract class Character : GameObject
    {
        protected Character (string name, int coordinatX, int coordinatY, int health)
        {
            Name = name;
            CoordinatX = coordinatX;
            CoordinatY = coordinatY;
            Health = health;
        }

        public int Health { get; private set; }

        public void IncreaseHealth(int value) => Health += value;

        public void DecreaseHealth(int value) => Health -= value;
    }
}
