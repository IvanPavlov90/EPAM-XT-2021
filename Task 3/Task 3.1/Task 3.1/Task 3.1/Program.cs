using System;
using Task_3._1.Classes;

namespace Task_3._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите N:");
            var value = Validator.CheckValue(Validator.InputValue());
            Console.WriteLine("Введите, какой по счету человек будет вычеркнут каждый раунд:");
            var value2 = Validator.CheckValue(Validator.InputValue());
            Validator.CrossOffPeople(value, value2);
        }
    }
}
