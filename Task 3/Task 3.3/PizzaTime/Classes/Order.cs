using System;
using System.Collections.Generic;
using System.Threading;
using System.Text;

namespace PizzaTime.Classes
{
    public class Order
    {
        public delegate void WaitingTime(string name, int value);
        public event WaitingTime TimeToWait;

        public Order(List<Pizza> pizzalist)
        {
            OrderDetails = pizzalist;
        }

        private List<Pizza> _OrderDetails;

        public List<Pizza> OrderDetails
        {
            get
            {
                return _OrderDetails;
            }
            private set
            {
                if (value == null || value.Count == 0)
                    throw new ArgumentException("Order can't be empty or null");
                else
                    _OrderDetails = value;
            }
        }

        /// <summary>
        /// Method that finds time for cook customer's order.
        /// </summary>
        /// <returns></returns>
        private int CountTime()
        {
            int waitingTime = 0;

            foreach (var item in OrderDetails)
            {
                waitingTime += item.CookingTime;
            }

            return waitingTime;
        }

        /// <summary>
        /// Method, that simulates waiting for pizza is ready))
        /// </summary>
        /// <param name="username"></param>
        public void CookingTime(string username)
        {
            int count = CountTime();

            while (count >= 0)
            {
                if (count % 5 == 0)
                    TimeToWait?.Invoke(username, count);
                count--;
                Thread.Sleep(1000);
            }
        }
    }

}
