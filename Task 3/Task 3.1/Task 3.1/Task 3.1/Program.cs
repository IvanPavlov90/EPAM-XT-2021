using System;
using System.Collections.Generic;
using Task_3._1.Classes;

namespace Task_3._1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите N:");
            var value = Validator.CheckValue(Validator.InputValue());
            PeopleList<int> people = new PeopleList<int> (value);
            Console.WriteLine("Сгенерирован круг людей. Начинаем вычеркивать каждого второго.");
            TaskAction.CrossPeopleOut(people, true, 1);
        }
    }
}
