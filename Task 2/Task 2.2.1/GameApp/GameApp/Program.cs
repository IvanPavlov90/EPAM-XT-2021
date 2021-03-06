﻿using System;
using System.Collections.Generic;

namespace GameApp
{
    public static class Program
    {

        static void Main(string[] args)
        {
            Player player = ObjectCreator.CreatePlayer();
            Field field = new Field();
            ObjectCreator.PlaceObjects(field);
            foreach (var item in field.Swords)
            {
                Console.WriteLine($"{item.CoordinatX}, {item.CoordinatY}, {item.Name}, {item.IncreaseAttackRange}");
            }
            Console.WriteLine($"Greetings, {player.Name}. You start this game and I want to tell you the rules. They are very simple. " +
                $"You must collect all potions on the field (there are only {field.QuantityOfPotions} of them) - that is your main aim. Your start point " +
                $"is (0, 0). On each step you can move only by one piece in X, or y directions. You can see your current coordinats " +
                $"by using game menu. On your way " +
                $"you cam meet enemies, that of course will fight with you, or pick potions that will increase your health. Also " +
                $"you can find a sword that increse your attack level!!! It will be very useful. Good luck!");
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
