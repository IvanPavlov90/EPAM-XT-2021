using System;
using System.Collections.Generic;
using System.Text;

namespace GameClasses
{
    public class Field
    {
        private int _width = 10;
        private int _height = 10;

        private List<GameObject> _gameObjects = new List<GameObject> { };

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
            _gameObjects.Add(obj);
        }

        public List<GameObject> GetObjects
        {
            get
            {
                return _gameObjects;
            }
        }

    }
}
