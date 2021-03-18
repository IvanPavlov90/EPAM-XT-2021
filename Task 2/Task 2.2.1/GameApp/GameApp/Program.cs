using System;
using System.Collections.Generic;

namespace GameApp
{
    public static class Program
    {

        static void Main(string[] args)
        {
            Player player = new Player("Geralt", 0, 0);
            Field field = new Field();
            Sword horse1 = new Sword("King's Arthur Sword", 2, 2);
            Potion potion1 = new Potion("Potion of Youth", 4, 2);
            Obstacle obcstacle1 = new Obstacle("River Volga", 1, 0);
            Enemy enemy1 = new Enemy("Ktulhu", 3, 2);
            field.AddBonus(horse1);
            field.AddBonus(potion1);
            field.AddObject(obcstacle1);
            field.AddEnemy(enemy1);
            StartApp(player, field);
        }

        public static void StartApp(Player player, Field field)
        {
            GameMenu.ShowMenu();
            Console.WriteLine("Your move");
            GameMenu.DoAction(GameMenu.ReadAction(), player, field);
        }
    }
}
