using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaTime.Classes
{
    public static class InfoTable
    {

        /// <summary>
        /// Method for showing information about customer's choise.
        /// </summary>
        /// <param name="message"></param>
        public static void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Method for showing information about customer's whole order.
        /// </summary>
        /// <param name="pizzaList"></param>
        public static void OrderInformation(List<Pizza> pizzaList)
        {
            string order = String.Empty;
            int sumOrder = 0;
            int waitingTime = 0;
            foreach (var item in pizzaList)
            {
                order += item.Name + " ";
                sumOrder += item.Cost;
                waitingTime += item.CookingTime;
            }
            Console.WriteLine($"Your order: {order}, order sum: {sumOrder}, time to wait: {waitingTime} seconds");
        }

        /// <summary>
        /// Method that shows information about remaining time for order is ready.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="count"></param>
        public static void CountTime(string username, int count)
        {
            if (count % 5 == 0 && count != 0)
                Console.WriteLine($"Dear {username}, your order will be ready at {count} seconds");
            if (count % 5 == 0 && count == 0)
                Console.WriteLine($"Dear {username}, your order is ready!");
        }
    }

}
