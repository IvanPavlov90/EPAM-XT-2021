using System;
using System.Collections.Generic;
using System.Text;

namespace GameApp
{
    public class Sword : GameObject
    {
        public Sword(string name, int coordinatX, int coordinatY, int increase)
        {
            Name = name;
            CoordinatX = coordinatX;
            CoordinatY = coordinatY;
            _increaseAttackRange = CheckIncreaseAttackRangeLessOrEqualZero(increase);
        }

        private int _increaseAttackRange;

        public int IncreaseAttackRange => _increaseAttackRange;

        private int CheckIncreaseAttackRangeLessOrEqualZero (int value)
        {
            if (value <= 0) throw new ArgumentException($"{nameof(_increaseAttackRange)} value can't be less or equal zero");
            return value;
        }
    }
}
