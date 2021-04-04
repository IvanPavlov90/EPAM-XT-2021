using System;
using PizzaTime.Classes;

namespace PizzaTime
{
    class Program
    {
        static void Main(string[] args)
        {
            Pizzeria tashir = new Pizzeria();
            tashir.ShowInfo += InfoTable.ShowMessage;
            tashir.OrderCreated += InfoTable.OrderInformation;
            tashir.ChosingPizza();
        }
    }
}
