using System;
using System.Collections.Generic;
using System.Text;

namespace GameApp
{
    public class Enemy : Character
    {
        public Enemy(string name, int coordinatX, int coordinatY) : base (name, coordinatX, coordinatY) { }

        private int _health = 75;

        public int Health
        {
            get => _health;
            set => _health = value;
        }

        private int _attackrange = 7;

        public int AttackRange
        {
            get => _attackrange;
        }

        private bool _havebeenvisited = false;

        public bool HaveBeenVisited
        {
            get => _havebeenvisited;
            set => _havebeenvisited = value;
        }
    }
}
