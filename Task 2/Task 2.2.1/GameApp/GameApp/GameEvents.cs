using System;
using System.Collections.Generic;
using System.Linq;

namespace GameApp
{
    public static class GameEvents
    {
        /// <summary>
        /// Method checks if player picks special bonus or not.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="gameobjects"></param>
        public static void IsPlayerStandingOnTheGameObject(Player player, Field field)
        {
            Sword sword = CheckImpositionOfObjects<Sword>(player, field.Swords);
            if (sword != null)
            {
                if (player.HasSword == false)
                {
                    Console.WriteLine($"You find {sword.Name}");
                    player.TakeSword(sword);
                    field.Swords.Remove(sword);
                }
                else if (player.HasSword == true)
                {
                    string playerAnswer;
                    Console.WriteLine($"You already have a sword. Do you want to change it? Press Y to accept, N - to decline.");
                    Console.WriteLine($"Your sword - {player.MySword.Name}, attack range - {player.MySword.IncreaseAttackRange}" +
                                      $"this sword - {sword.Name}, attack range - {sword.IncreaseAttackRange}.");

                    playerAnswer = Console.ReadLine();
                    if (playerAnswer == "Y") player.TakeSword(sword);
                }
            }
            //foreach (Bonus item in gamebonuses)
            //{
            //    if (item.CoordinatX == player.CoordinatX && item.CoordinatY == player.CoordinatY && item.HaveBeenVisited == false)
            //    {
            //        Console.WriteLine($"You find {item.Name}");
            //        if (item is Sword)
            //        {
            //            if (!player.HasSword)
            //            {
            //                item.BonusWasTaken();
            //                player.TakingSword();
            //                Console.WriteLine($"You attack rang has been increased on {item.Increase}");
            //                player.IncreaseAttackrange(item.Increase);
            //            } 
            //            else
            //                Console.WriteLine($"You already have a sword");
            //        }
            //        if (item is Potion)
            //        {
            //            item.BonusWasTaken();
            //            player.IncreaseCountBonus();
            //            Console.WriteLine($"You collect Potion. You health has been increased on {item.Increase}");
            //            player.IncreaseHealth(item.Increase);
            //        }
            //    }
            //}
        }

        public static void IsPlayerMeetEnemy(Player player, List <Enemy> enemies)
        {
            foreach (Enemy item in enemies)
            {
                if (item.CoordinatX == player.CoordinatX && item.CoordinatY == player.CoordinatY && item.HaveBeenVisited == false)
                {
                    item.EnemyWasVisited();
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
            System.Threading.Thread.Sleep(2000);
            while (player.Health > 0 && enemy.Health > 0)
            {
                enemy.DecreaseHealth(player.AttackRange);
                Console.WriteLine($"You striked {enemy.Name}, his health is now {enemy.Health}");
                if (enemy.Health <= 0) break;
                System.Threading.Thread.Sleep(850);
                player.DecreaseHealth(enemy.AttackRange);
                Console.WriteLine($"Enemy striked you, your health is now {player.Health}");
                if (player.Health <= 0) break;
                System.Threading.Thread.Sleep(850);
            }

            if (player.Health <= 0)
            {
                Console.WriteLine($"Unfourtanetly, your journey end here. Fight against {enemy.Name} costed you your life.");
                Environment.Exit(0);
            } 
            else
                Console.WriteLine($"You win this fight. But journey continues...");
        }

        public static void Victory(Player player, Field field)
        {
            if (player.CountBonus == field.QuantityOfPotions)
            {
                Console.WriteLine($"You journey through this rough and dangerous lands was succesfull. Greetings, {player.Name}, you win....");
                Environment.Exit(0);
            }
        }

        private static T CheckImpositionOfObjects<T> (Player player, List<T> gameobjects) where T: GameObject
        {
            T gameobject = gameobjects.FirstOrDefault(item => item.CoordinatX == player.CoordinatX & item.CoordinatY == player.CoordinatY);
            return gameobject;
        }
    }
}
