using System;
using System.Collections.Generic;

namespace Task_2._1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<User> users = new List<User>();
            StartApp();
        }

        public static void StartApp()
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
        public static bool SearchUser(string username, List<User> users, out int index)
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
}
