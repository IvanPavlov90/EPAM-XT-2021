using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaTime.Classes
{
    public class Pizzeria
    {
        public delegate void OrderStatus(string message);
        public event OrderStatus ShowInfo;
        public delegate void OrderFinished(List<Pizza> pizzaList);
        public event OrderFinished OrderCreated;

        private List<Pizza> _pizzaList = new List<Pizza>();

        /// <summary>
        /// Dictionary, that contains Tuple<string, int> with pizza name and it's price 
        /// also this dictionary has int value for cooking time of piiza.
        /// </summary>
        private Dictionary<(string, int), int> _menu = new Dictionary<(string, int), int>
        {
            { ("Margarita (25 cm)", 100), 8 },
            { ("Margarita (30 cm)", 120), 12 },
            { ("Europe (25 cm)", 85), 6 },
            { ("Europe (30 cm)", 100), 8 },
            { ("El Diablo (25 cm)", 110), 11 },
            { ("El Diablo (30 cm)", 130), 18 },
        };

        /// <summary>
        /// Method that shows customer menu and where he could make an order.
        /// This method contains main logic.
        /// </summary>
        /// <param name="username"></param>
        public void ChosingPizza(string username)
        {
            int result;
            do
            {
                PizzeriaMenu();
                Console.WriteLine("Choose your Pizza:");
                string value = Console.ReadLine();
                Int32.TryParse(value, out result);
                switch (result)
                {
                    case 1:
                        Tuple<string, int, int> pizzaInfo = FindPizzaInDataBase(result);
                        _pizzaList.Add(new Pizza(pizzaInfo.Item1, pizzaInfo.Item2, pizzaInfo.Item3));
                        ShowInfo?.Invoke($"{username}, you choose {pizzaInfo.Item1}, cost {pizzaInfo.Item2}");
                        break;
                    case 2:
                        Tuple<string, int, int> pizzaInfo2 = FindPizzaInDataBase(result);
                        _pizzaList.Add(new Pizza(pizzaInfo2.Item1, pizzaInfo2.Item2, pizzaInfo2.Item3));
                        ShowInfo?.Invoke($"{username}, you choose {pizzaInfo2.Item1}, cost {pizzaInfo2.Item2}");
                        break;
                    case 3:
                        Tuple<string, int, int> pizzaInfo3 = FindPizzaInDataBase(result);
                        _pizzaList.Add(new Pizza(pizzaInfo3.Item1, pizzaInfo3.Item2, pizzaInfo3.Item3));
                        ShowInfo?.Invoke($"{username}, you choose {pizzaInfo3.Item1}, cost {pizzaInfo3.Item2}");
                        break;
                    case 4:
                        Tuple<string, int, int> pizzaInfo4 = FindPizzaInDataBase(result);
                        _pizzaList.Add(new Pizza(pizzaInfo4.Item1, pizzaInfo4.Item2, pizzaInfo4.Item3));
                        ShowInfo?.Invoke($"{username}, you choose {pizzaInfo4.Item1}, cost {pizzaInfo4.Item2}");
                        break;
                    case 5:
                        Tuple<string, int, int> pizzaInfo5 = FindPizzaInDataBase(result);
                        _pizzaList.Add(new Pizza(pizzaInfo5.Item1, pizzaInfo5.Item2, pizzaInfo5.Item3));
                        ShowInfo?.Invoke($"{username}, you choose {pizzaInfo5.Item1}, cost {pizzaInfo5.Item2}");
                        break;
                    case 6:
                        Tuple<string, int, int> pizzaInfo6 = FindPizzaInDataBase(result);
                        _pizzaList.Add(new Pizza(pizzaInfo6.Item1, pizzaInfo6.Item2, pizzaInfo6.Item3));
                        ShowInfo?.Invoke($"{username}, you choose {pizzaInfo6.Item1}, cost {pizzaInfo6.Item2}");
                        break;
                    case 7:
                        OrderCreated?.Invoke(_pizzaList);
                        Order order = new Order(_pizzaList);
                        order.TimeToWait += InfoTable.CountTime;
                        order.CookingTime(username);
                        break;
                    default:
                        break;
                }
            } while (result >= 1 && result <= 6);
        }

        /// <summary>
        /// The only aim of this method is to show menu.
        /// </summary>
        private void PizzeriaMenu()
        {
            int count = 1;
            foreach (var item in _menu)
            {
                Console.WriteLine($"{count} {item.Key.Item1}");
                count++;
            }
            Console.WriteLine($"{count} Finish oredring");
        }

        /// <summary>
        /// Method that find data in dictionary. It takes user's choise, then find appropriate value in dictionary,
        /// takes information from int and returns Tuple.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>
        /// Tuple<string, int, int> string is the name of the pizza, first int - it's price
        /// second int - cooking time.
        /// </returns>
        private Tuple<string, int, int> FindPizzaInDataBase(int value)
        {
            int count = 1;
            foreach (var item in _menu)
            {
                if (count == value)
                {
                    var pizzaInfo = Tuple.Create(item.Key.Item1, item.Key.Item2, item.Value);
                    return pizzaInfo;
                }
                count++;
            }
            return Tuple.Create("default", 0, 0);
        }
    }
}
