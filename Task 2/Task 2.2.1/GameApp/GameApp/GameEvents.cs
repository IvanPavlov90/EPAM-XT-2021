using System;
using System.Collections.Generic;
using System.Text;

namespace GameApp
{
    public static class GameEvents
    {
        /// <summary>
        /// Method checks if player picks special bonus or not.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="gameobjects"></param>
        public static void IsPlayerStandingOnTheGameObject(Player player, List <Bonus> gamebonuses)
        {
            foreach (Bonus item in gamebonuses)
            {
                if (item.CoordinatX == player.CoordinatX && item.CoordinatY == player.CoordinatY && item.HaveBeenVisited == false)
                {
                    Console.WriteLine($"You find {item.Name}");
                    if (item is Sword)
                    {
                        item.HaveBeenVisited = true;
                        Console.WriteLine($"You attack rang has been increased on {item.Increase}");
                        player.AttackRange += item.Increase;
                    }
                    if (item is Potion)
                    {
                        item.HaveBeenVisited = true;
                        Console.WriteLine($"You health has been increased on {item.Increase}");
                        player.Health += item.Increase;
                    }
                }
            }
        }

        public static void IsPlayerMeetEnemy(Player player, List <Enemy> enemies)
        {
            foreach (Enemy item in enemies)
            {
                if (item.CoordinatX == player.CoordinatX && item.CoordinatY == player.CoordinatY && item.HaveBeenVisited == false)
                {
                    item.HaveBeenVisited = true;
                    Console.WriteLine($"You meet {item.Name}. He attacks you!!!");
                    Battle(player, item);
                }
            }
        }

        /// <summary>
        /// Method for battles.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="enemy"></param>
        public static void Battle (Player player, Enemy enemy)
        {
            Console.WriteLine($"Before the fight starts, some statistic: " +
                $"Your enemy {enemy.Name}, health - {enemy.Health}, attackrange - {enemy.AttackRange}");
            while (player.Health > 0 && enemy.Health > 0)
            {
                enemy.Health -= player.AttackRange;
                Console.WriteLine($"You striked {enemy.Name}, his health is now {enemy.Health}");
                if (enemy.Health <= 0) break;
                player.Health -= enemy.AttackRange;
                Console.WriteLine($"Enemy striked you, your health is now {player.Health}");
                if (player.Health <= 0) break;
            }

            if (player.Health <= 0)
            {
                Console.WriteLine($"Unfourtanetly, your journey end here. Fight againnst {enemy.Name} costed you your life.");
                Environment.Exit(0);
            } 
            else
            {
                Console.WriteLine($"You win this fight. But journey continues...");
            }
        }
    }
}
