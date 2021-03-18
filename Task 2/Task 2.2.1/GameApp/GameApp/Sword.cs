using System;
using System.Collections.Generic;
using System.Text;

namespace GameApp
{
    public class Sword : Bonus
    {
        public Sword(string name, int coordinatX, int coordinatY)
        {
            Name = name;
            CoordinatX = coordinatX;
            CoordinatY = coordinatY;
        }

        private int _increaseAttackrange = 5;
        public override int Increase
        {
            get => _increaseAttackrange;
        }

        private bool _havebeenvisited = false;
    }
}
