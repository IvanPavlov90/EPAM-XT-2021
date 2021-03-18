using System;
using System.Collections.Generic;
using System.Text;

namespace GameApp
{
    public class Field
    {
        private int _width = 10;
        private int _height = 10;

        private List<GameObject> _obstacles = new List<GameObject> { };
        private List<Bonus> _bonuses = new List<Bonus> { };
        private List<Enemy> _enemies = new List<Enemy> { };

        public int GetWidth
        {
            get
            {
                return _width;
            }
        }

        public int GetHeight
        {
            get
            {
                return _height;
            }
        }

        public void AddObject(GameObject obj)
        {
            _obstacles.Add(obj);
        }

        public List <GameObject> Obstacles
        {
            get
            {
                return _obstacles;
            }
        }

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
