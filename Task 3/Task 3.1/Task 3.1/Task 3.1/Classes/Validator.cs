using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3._1.Classes
{
    public static class Validator
    {
        public static int InputValue ()
        {
            string uservalue = Console.ReadLine();
            int.TryParse(uservalue, out int value);
            return value;
        }

        public static int CheckValue(int value)
        {
            while (value <= 0)
            {
                Console.WriteLine($"Вы ввели неверное значение. Исправьте, пожалуйста.");
                string uservalue = Console.ReadLine();
                int.TryParse(uservalue, out value);
            }
            return value;
        }

        public static void CrossOffPeople (int value, int value2)
        {
            if (value < value2) {
                Console.WriteLine("Игра окончена. Невозможно вычеркнуть больше людей.");
            } else
            {
                int roundCount = 1;
                Console.WriteLine($"Сгенерирован круг людей. Начинаем вычеркивать каждого {value2}-го.");
                while (value >= value2)
                {
                    value--;
                    Console.WriteLine($"Раунд {roundCount}. Вычеркнут человек. Людей осталось: {value}");
                    roundCount++;
                }
                Console.WriteLine("Игра окончена. Невозможно вычеркнуть больше людей.");
            }
        }
    }
}
