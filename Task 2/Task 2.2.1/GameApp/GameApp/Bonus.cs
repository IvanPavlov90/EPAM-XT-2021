using System;
using System.Collections.Generic;
using System.Text;

namespace GameApp
{
    public abstract class Bonus : GameObject
    {
        public bool HaveBeenVisited { get; private set; } = false;

        public void BonusWasTaken() => HaveBeenVisited = true;
    }
}
