using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3._1.Classes
{
    public static class PrintData
    {
        public static void Print(int round, int value, int count)
        {
            Console.WriteLine($"Раунд - {round}, был вычеркнут человек - {value}. Людей осталось {count}");
        }

        public static void PrintWinner(int value)
        {
            Console.WriteLine($"В эту игру выиграл человек с номером - {value}");
        }
    }
}
