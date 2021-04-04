using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaTime.Classes
{
    public static class InfoTable
    {
        public static void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static void OrderInformation (List<Pizza> pizzaList)
        {
            string order = String.Empty;
            int sumOrder = 0;
            int waitingTime = 0;
            foreach (var item in pizzaList)
            {
                order += item.name + " ";
                sumOrder += item.Cost;
                waitingTime += item.CookingTime;
            }
            Console.WriteLine($"Ваш заказ: {order}, Сумма заказа: {sumOrder}, Время ожидания заказа: {waitingTime}");
        }
    }
}
