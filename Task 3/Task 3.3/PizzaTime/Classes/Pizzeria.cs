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

        private List<Pizza> _pizzaList = new List<Pizza> ();

        private Dictionary<(string, int), int> _menu = new Dictionary<(string, int), int>
        {
            { ("Margarita (25 cm)", 100), 8 },
            { ("Margarita (30 cm)", 120), 12 },
            { ("Europe (25 cm)", 85), 6 },
            { ("Europe (30 cm)", 100), 8 },
            { ("El Diablo (25 cm)", 110), 11 },
            { ("El Diablo (30 cm)", 130), 18 },
        };

        public void ChosingPizza()
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
                        ShowInfo?.Invoke($"You choose {pizzaInfo.Item1}, cost {pizzaInfo.Item2}");
                        break;
                    case 2:
                        Tuple<string, int, int> pizzaInfo2 = FindPizzaInDataBase(result);
                        _pizzaList.Add(new Pizza(pizzaInfo2.Item1, pizzaInfo2.Item2, pizzaInfo2.Item3));
                        ShowInfo?.Invoke($"You choose {pizzaInfo2.Item1}, cost {pizzaInfo2.Item2}");
                        break;
                    case 3:
                        Tuple<string, int, int> pizzaInfo3 = FindPizzaInDataBase(result);
                        _pizzaList.Add(new Pizza(pizzaInfo3.Item1, pizzaInfo3.Item2, pizzaInfo3.Item3));
                        ShowInfo?.Invoke($"You choose {pizzaInfo3.Item1}, cost {pizzaInfo3.Item2}");
                        break;
                    case 4:
                        Tuple<string, int, int> pizzaInfo4 = FindPizzaInDataBase(result);
                        _pizzaList.Add(new Pizza(pizzaInfo4.Item1, pizzaInfo4.Item2, pizzaInfo4.Item3));
                        ShowInfo?.Invoke($"You choose {pizzaInfo4.Item1}, cost {pizzaInfo4.Item2}");
                        break;
                    case 5:
                        Tuple<string, int, int> pizzaInfo5 = FindPizzaInDataBase(result);
                        _pizzaList.Add(new Pizza(pizzaInfo5.Item1, pizzaInfo5.Item2, pizzaInfo5.Item3));
                        ShowInfo?.Invoke($"You choose {pizzaInfo5.Item1}, cost {pizzaInfo5.Item2}");
                        break;
                    case 6:
                        Tuple<string, int, int> pizzaInfo6 = FindPizzaInDataBase(result);
                        _pizzaList.Add(new Pizza(pizzaInfo6.Item1, pizzaInfo6.Item2, pizzaInfo6.Item3));
                        ShowInfo?.Invoke($"You choose {pizzaInfo6.Item1}, cost {pizzaInfo6.Item2}");
                        break;
                    case 7:
                        OrderCreated?.Invoke(_pizzaList);
                        Order order = new Order(_pizzaList);
                        break;
                    default:
                        break;
                }
            } while (result >= 1 && result <= 6);
        }

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
