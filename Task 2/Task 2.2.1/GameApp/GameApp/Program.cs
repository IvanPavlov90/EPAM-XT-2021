using System;

namespace GameApp
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    abstract class GameObject
    {
        private string _name;

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        private bool _canBeAttacked;

        public bool CanBeAttacked
        {
            get => _canBeAttacked;
            set => _canBeAttacked = value;
        }

        private int _positionX;

        public int PositionX
        {
            get => _positionX;
            set => _positionX = value;
        }

        private int _positionY;

        public int PositionY
        {
            get => _positionY;
            set => _positionY = value;
        }
    }

    abstract class Character : GameObject
    {
        private float _health;

        public float Health
        {
            get => _health;
            set => _health = value;
        }

        private int _attackrange;

        public int AttackRange
        {
            get => _attackrange;
            set => _attackrange = value;
        }

        private int _defenserange;

        public int DefenseRange
        {
            get => _defenserange;
            set => _defenserange = value;
        }

        private int _speed;

        public int Speed
        {
            get => _speed;
            set => _speed = value;
        }

        public void Attack()
        {

        }
    }

    class Player : Character
    {
        public Player(string name, float health, int attackrange, int defenserange, int speed, int positionX, int positionY, bool beAttacked)
        {
            Name = name;
            Health = health;
            AttackRange = attackrange;
            DefenseRange = defenserange;
            Speed = speed;
            PositionX = positionX;
            PositionY = positionY;
            CanBeAttacked = beAttacked;
        }

        public void MoveForward()
        {
            PositionY += Speed;
        }

        public void MoveBackward()
        {
            PositionY -= Speed;
        }

        public void MoveLeft()
        {
            PositionX -= Speed;
        }

        public void MoveRight()
        {
            PositionX += Speed;
        }
    }

    class Enemy : Character
    {
        public Enemy(string name, float health, int attackrange, int defenserange, int speed, int positionX, int positionY, bool beAttacked)
        {
            Name = name;
            Health = health;
            AttackRange = attackrange;
            DefenseRange = defenserange;
            Speed = speed;
            PositionX = positionX;
            PositionY = positionY;
            CanBeAttacked = beAttacked;
        }
    }
}
