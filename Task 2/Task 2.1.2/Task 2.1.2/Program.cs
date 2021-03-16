using System;
using System.Collections.Generic;

namespace Task_2._1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            StartApp();
        }

        public static void StartApp ()
        {
            List<User> users = new List<User>();
            User currentuser = SetUser(users);
            Console.WriteLine($"Welcome, {currentuser.Name}");
            CustomPaint(currentuser.Name, currentuser.ShowFigures());
        }

        public static void CustomPaint(string name, List<object> figures)
        {
            MainMenu.ShowMenu();
            MainMenu.DoAction(MainMenu.ReadAction(), name, figures);
        }

        /// <summary>
        /// Метод, принимающий список текущих юзеров. Внутри этого метода есть применение еще одного метода,
        /// который осуществляет поиск юзеров в списке по введенному имени.
        /// </summary>
        /// <param name="users"></param>
        /// <returns>В зависимости от того, нашелся ли пользовтаель по имени или нет, создается новый юзер или возвращается ранее созданный.</returns>
        public static User SetUser(List<User> users)
        {
            Console.WriteLine("Please enter your name:");
            string username = Console.ReadLine();
            if (users.Count == 0)
            {
                User user = new User(username);
                users.Add(user);
                return user;
            }
            else 
            {
                int index;
                bool result = SearchUser(username, users, out index);
                if (result)
                {
                    return users[index];
                }
                else
                {
                    User user = new User(username);
                    users.Add(user);
                    return user;
                }
            } 
        }

        /// <summary>
        /// Метод, который ищет пользователя по имени в списке юзеров. 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="users"></param>
        /// <param name="index"></param>
        /// <returns>Если юзер найдет возвращает true и индекс этого пользователя, если нет, то возвращает false  и индекс - 1,
        /// в случае. если позователь не найдет индекс -1 нигде не применяется и используется в качестве заглушки.</returns>
        public static bool SearchUser (string username, List <User> users, out int index)
        {
            bool flag = false;
            index = -1;
            for (int i = 0; i <= users.Count; i++)
            {
                if (users[i].Name == username)
                {
                    flag = true;
                    index = i;
                }
            }

            return flag;
        }
    }

    /// <summary>
    /// Ниже расположена иерархия наследования фигур. В качестве самого первого и основного параметра, который потом
    /// наследуют все классы, я взял координаты точки, в которой мы начинаем рисование. В целом, я идею с проверкой 
    /// по точкам развивать не стал и в большинстве случаев, стал просто оперировать значениями сторон.
    /// </summary>

    class Quadrate : FlatFigures
    {
        public Quadrate(float pointX, float pointY, float side)
        {
            StartpointX = pointX;
            StartpointY = pointY;
            Side = side;
        }

        private float _side;

        public float Side
        {
            get => _side;
            set => _side = value;
        }

        public override double Area
        {
            get
            {
                return Side * Side;
            }
        }

        public override double Perimeter
        {
            get
            {
                return Side * 4;
            }
        }

        public override string ToString()
        {
            return $"Квадрат.\n" +
                   $"Координаты вершин квадрата - (x:, y:) {StartpointX} {StartpointY}, {StartpointX + Side} {StartpointY}, {StartpointX + Side} {StartpointY + Side}, {StartpointX} {StartpointY + Side}\n" +
                   $"площадь квадрата - {Math.Round(Area, 2, MidpointRounding.AwayFromZero)}\n" +
                   $"периметр квадрата - {Math.Round(Perimeter, 2, MidpointRounding.AwayFromZero)}";
        }
    }
}
