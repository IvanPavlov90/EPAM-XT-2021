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
        private List<Bonus> _bonuses = new List<Bonus> { };
        private List<Enemy> _enemies = new List<Enemy> { };

        public int GetWidth
        {
            get => _width;
        }

        public int GetHeight
        {
            get => _height;
        }

        private int _quantityOfPotions;

        public int QuantityOfPotions
        {
            get => _quantityOfPotions;
            set => _quantityOfPotions = value;
        }

        public void AddObject(Obstacle obj)
        {
            _obstacles.Add(obj);
        }

        public List <Obstacle> Obstacles => _obstacles;

        public void AddBonus(Bonus obj)
        {
            _bonuses.Add(obj);
        }

        public List<Bonus> Bonus
        {
            get
            {
                return _bonuses;
            }
        }

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
