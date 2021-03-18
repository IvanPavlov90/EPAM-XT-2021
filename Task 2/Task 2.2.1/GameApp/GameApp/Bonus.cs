using System;
using System.Collections.Generic;
using System.Text;

namespace GameApp
{
    public abstract class Bonus : GameObject
    {
        public abstract int Increase
        {
            get;
        }

        private bool _havebeenvisited;

        public bool HaveBeenVisited
        {
            get => _havebeenvisited;
            set => _havebeenvisited = value;
        }
    }
}
