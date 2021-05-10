using System;
using System.Collections.Generic;
using System.Text;

namespace GameApp
{
    public class Field
    {
        private int _width = 10;
        private int _height = 10;

        private List<Obstacle> _obstacles = new List<Obstacle> { };
        private List<Sword> _swords = new List<Sword> { };
        private List<Potion> _potions = new List<Potion> { };
        private List<Enemy> _enemies = new List<Enemy> { };

        public int GetWidth => _width;

        public int GetHeight => _height;

        private int _quantityOfPotions;

        public int QuantityOfPotions
        {
            get => _quantityOfPotions;
            set => _quantityOfPotions = value;
        }

        public List<Obstacle> Obstacles => _obstacles;

        public void AddObject(Obstacle obj) => _obstacles.Add(obj);

        public List<Sword> Swords => _swords;

        public List<Potion> Potions => _potions;

        public void AddEnemy(Enemy obj)
        {
            _enemies.Add(obj);
        }

        public List<Enemy> Enemy
        {
            get
            {
                return _enemies;
            }
        }
    }
}
