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
    }
}
