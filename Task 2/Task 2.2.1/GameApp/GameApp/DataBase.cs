using System;
using System.Collections.Generic;
using System.Text;

namespace GameApp
{
    public static class DataBase
    {
        private static List<string> _obstacleNames = new List<string> {"Mountain", "River", "Dark Forest"};

        private static List<(string, int)> _swordParametres = new List<(string, int)> { ("Sword", 3), ("Blade Of Shadow", 5), ("Fire Mace", 7) };

        public static List<string> ObstacleNames => _obstacleNames;

        public static List<(string, int)> SwordParametres => _swordParametres;
    }
}
