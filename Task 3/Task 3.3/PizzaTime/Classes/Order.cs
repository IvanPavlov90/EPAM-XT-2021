using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaTime.Classes
{
    public class Order
    {
        public Order(List<Pizza> pizzalist)
        {
            OrderDetails = pizzalist;
        }

        private List<Pizza> _orderDetails;

        public List<Pizza> OrderDetails { 
            get
            {
                return _orderDetails;
            } 
            private set
            {
                if (value == null || value.Count == 0)
                    throw new ArgumentException("Order can't be empty or null");
                else
                    _orderDetails = value;
            } 
        }
    }
}
