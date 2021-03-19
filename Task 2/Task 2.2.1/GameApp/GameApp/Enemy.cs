using System;
using System.Collections.Generic;
using System.Text;

namespace GameApp
{
    public class Enemy : Character
    {
        public Enemy(string name, int coordinatX, int coordinatY, int health) : base (name, coordinatX, coordinatY, health) { }

        public int AttackRange { get; } = 8;

        public bool HaveBeenVisited { get; private set; } = false;

        public void EnemyWasVisited() => HaveBeenVisited = true;
    }
}
