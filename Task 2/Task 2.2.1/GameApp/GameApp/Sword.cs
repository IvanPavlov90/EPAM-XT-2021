using System;
using System.Collections.Generic;
using System.Text;

namespace GameApp
{
    public class Sword : Bonus
    {
        public Sword(string name, int coordinatX, int coordinatY, int increase)
        {
            Name = name;
            CoordinatX = coordinatX;
            CoordinatY = coordinatY;
            _increaseAttackrange = CheckIncreaseAttackRangeLessOrEqualZero(increase);
        }

        private int _increaseAttackrange;

        public int IncreaseAttackrange
        {
            get => _increaseAttackrange;
        }

        private int CheckIncreaseAttackRangeLessOrEqualZero (int value)
        {
            if (value <= 0) throw new ArgumentException($"{nameof(_increaseAttackrange)} value can't be less or equal zero");
            return value;
        }
    }
}
