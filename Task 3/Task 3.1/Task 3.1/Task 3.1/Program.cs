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
            List<int> value2 = new List<int> { };
            PeopleList<int> people = new PeopleList<int> (value2);
            Validator.FillList(people, value);
            Validator.CrossPeopleOut(people, 2, false, 1);
        }
    }
}
