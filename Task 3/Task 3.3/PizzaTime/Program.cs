using System;
using PizzaTime.Classes;

namespace PizzaTime
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User(InputHelper.InputName());
            Pizzeria tashir = new Pizzeria();
            tashir.ShowInfo += InfoTable.ShowMessage;
            tashir.OrderCreated += InfoTable.OrderInformation;
            tashir.ChosingPizza(user.Name);
        }
    }
}
