using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaTime.Classes
{
    public class Pizza
    {
        public Pizza(string pizzaname, int pizzacost, int cookTime)
        {
            if (pizzaname == string.Empty)
                throw new ArgumentException("Name can't be empty.");
            else 
                name = pizzaname;
            Cost = pizzacost;
            CookingTime = cookTime;
        }

        private int _cost;

        private int _cookingTime;

        public string name { get;  }

        public int CookingTime 
        {
            get
            {
                return _cookingTime;
            }
            private set
            {
                if (value <= 0)
                    throw new ArgumentException("CookingTime can'te be less then 0.");
                else
                    _cookingTime = value;
            }
        }

        public int Cost 
        {
            get
            {
                return _cost;
            }
            private set
            {
                if (value <= 0)
                    throw new ArgumentException("Pizza can't costs less then 0.");
                else
                    _cost = value;
            } 
        }
    }
}
