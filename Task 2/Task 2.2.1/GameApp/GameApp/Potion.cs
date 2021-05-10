using System;
using System.Collections.Generic;
using System.Text;

namespace GameApp
{
    public class Potion : GameObject
    {
        public Potion(string name, int coordinatX, int coordinatY, int increase)
        {
            Name = name;
            CoordinatX = coordinatX;
            CoordinatY = coordinatY;
            _increaseHealth = CheckIncreaseHealthLessOrEqualZero(increase);
        }

        private int _increaseHealth;

        public int IncreaseHealth => _increaseHealth;

        private int CheckIncreaseHealthLessOrEqualZero(int value)
        {
            if (value <= 0) throw new ArgumentException($"{nameof(_increaseHealth)} value can't be less or equal zero");
            return value;
        }
    }
}
