using System;
using System.Collections.Generic;

namespace GameApp
{
    public static class Program
    {

        static void Main(string[] args)
        {
            Player player = new Player("Geralt", 1, 0, 0);
            Field field = new Field();
            Horse horse1 = new Horse("Лошадь Плотва", 2, 2);
            Potion potion1 = new Potion("Зелье молодости", 4, 2);
            Obstacle obcstacle1 = new Obstacle("Непроходимая река", 1, 0);
            field.AddBonus(horse1);
            field.AddBonus(potion1);
            field.AddObject(obcstacle1);
            StartApp(player, field);
        }

        public static void StartApp(Player player, Field field)
        {
            GameMenu.ShowMenu();
            Console.WriteLine("Выберите действие");
            GameMenu.DoAction(GameMenu.ReadAction(), player, field);
        }
    }
}
