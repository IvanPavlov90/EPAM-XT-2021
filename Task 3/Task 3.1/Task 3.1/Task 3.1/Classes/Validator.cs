using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3._1.Classes
{
    public static class Validator
    {
        /// <summary>
        /// Method for user input
        /// </summary>
        /// <returns></returns>
        public static int InputValue ()
        {
            string uservalue = Console.ReadLine();
            int.TryParse(uservalue, out int value);
            return value;
        }

        /// <summary>
        /// Method for checking user input
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
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


        /// <summary>
        /// Method for filling collection
        /// </summary>
        /// <param name="people"></param>
        /// <param name="value"></param>
        public static void FillList (PeopleList<int> people, int value)
        {
            int count = 1;
            while (count <= value)
            {
                people.Add(count);
                count++;
            }
            Console.WriteLine("Сгенерирован круг людей. Начинаем вычеркивать каждого второго.");
        }


        /// <summary>
        /// Method for crossing people
        /// </summary>
        /// <param name="people"></param>
        /// <param name="value"></param>
        /// <param name="count"></param>
        /// <param name="round"></param>
        public static void CrossPeopleOut(PeopleList<int> people, int value, bool count, int round)
        {
            foreach (var item in people)
            {
                if (count == true)
                {
                    people.Remove(item);
                    Console.WriteLine($"Раунд - {round}, был вычеркнут человек - {item}. Людей осталось {people.Count}");
                    if (people.Count == 1)
                    {
                        break;
                    }
                    count = true;
                    round++;
                }
                else
                {
                    count = true;
                }
            }
            if (people.Count < value)
            {
                Console.WriteLine($"Игра окончена. Невозможно вычеркнуть больше людей.");
            } 
            else
            {
                CrossPeopleOut(people, value, !count, round);
            }
        }
    }
}
