using System;
using System.Collections.Generic;
using System.Text;

namespace GameApp
{
    /// <summary>
    /// Class for AI, this class isn't implemented into game, it is just for showing my thoughts.
    /// This class decides what enemies should do in depence of player's position. 
    /// </summary>
    public static class AI
    {
        public static void EnemyMove (List<Enemy> enemies, List<GameObject> obstacles, Player player)
        {
            foreach (Enemy item in enemies)
            {
                if (player.CoordinatX < item.CoordinatX)
                {
                    item.CoordinatX -= 1;
                    if (CheckingEnemyAndObstacles(item, obstacles))
                        item.CoordinatX += 1;
                }
                else if (player.CoordinatX == item.CoordinatX)
                {
                    if (player.CoordinatY < item.CoordinatY)
                    {
                        item.CoordinatY -= 1;
                        if (CheckingEnemyAndObstacles(item, obstacles))
                            item.CoordinatY += 1;
                    }
                    else if (player.CoordinatY > item.CoordinatY)
                    {
                        item.CoordinatY += 1;
                        if (CheckingEnemyAndObstacles(item, obstacles))
                            item.CoordinatY -= 1;
                    }
                }
                else if (player.CoordinatX > item.CoordinatX)
                {
                    item.CoordinatX += 1;
                    if (CheckingEnemyAndObstacles(item, obstacles))
                        item.CoordinatX -= 1;
                }
            }
        }

        public static bool CheckingEnemyAndObstacles(Enemy enemy, List<GameObject> gameobjects)
        {
            foreach (GameObject item in gameobjects)
            {
                if (item.CoordinatX == enemy.CoordinatX && item.CoordinatY == enemy.CoordinatY)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
