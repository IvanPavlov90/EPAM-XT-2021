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
                Name = pizzaname;
            Cost = pizzacost;
            CookingTime = cookTime;
        }

        private int _Cost;

        private int _CookingTime;

        public string Name { get; }

        public int CookingTime 
        {
            get
            {
                return _CookingTime;
            }
            private set
            {
                if (value <= 0)
                    throw new ArgumentException("CookingTime can'te be less then 0.");
                else
                    _CookingTime = value;
            }
        }

        public int Cost 
        {
            get
            {
                return _Cost;
            }
            private set
            {
                if (value <= 0)
                    throw new ArgumentException("Pizza can't costs less then 0.");
                else
                    _Cost = value;
            } 
        }
    }
}
