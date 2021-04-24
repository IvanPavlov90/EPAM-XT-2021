using System;
using System.Collections.Generic;

namespace Task_2._1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            User currentuser = User.SetUser();
            StartApp(currentuser);
        }

        public static void StartApp(User currentuser)
        {
            Console.WriteLine($"Welcome, {currentuser.Name}");
            CustomPaint(currentuser.Name, currentuser.ShowFigures());
        }

        public static void CustomPaint(string name, List<object> figures)
        {
            MainMenu.ShowMenu();
            MainMenu.DoAction(MainMenu.ReadAction(), name, figures);
        }
    }
}
