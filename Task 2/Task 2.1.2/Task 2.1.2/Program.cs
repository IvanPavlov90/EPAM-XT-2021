using System;
using System.Collections.Generic;

namespace Task_2._1._2
{
    class Program
    {
        public enum Figures
        {
            Circle = 1,
            Ring = 2,
            Line = 3,
            Square = 4,
            Rectangle = 5,
            Triangle = 6,
            Sphere = 7,
            Cylinder = 8
        }

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
        /// Метод, который создает фигуры, в зависимости от выбора пользователя.
        /// </summary>
        //static void ShowFigures (string name, List<object> figures, Figures figure)
        //{
        //    switch (figure)
        //    {
        //        case Figures.Circle:
        //            Console.WriteLine("Введите параметры фигуры Круг.");
        //            Console.WriteLine("Введите координаты центра круга и значение радиуса (дробный радиус вводится через запятую).");
        //            Circle circle = new Circle(Validator.InputCoordinats(), Validator.InputCoordinats(), Validator.CheckIfValueMoreThanVerificationValue(0));
        //            Console.WriteLine("Круг создан");
        //            figures.Add(circle);
        //            CustomPaint(name, figures);
        //            break;
        //        case Figures.Ring:
        //            Console.WriteLine("Введите параметры фигуры Кольцо.");
        //            Console.WriteLine("Введите координаты центра кольца, а также значения внешнего и внутреннего радиусов (дробный радиус вводится через запятую).");
        //            Ring ring = new Ring(Validator.InputCoordinats(), Validator.InputCoordinats(), Validator.CheckIfValueMoreThanVerificationValue(0), Validator.CheckIfValueMoreThanVerificationValue(0));
        //            Console.WriteLine("Проверка на корректность введенных радиусов, перевведите значение внешенго радиуса, оно должно быть не меньше значения внутреннего радиуса.");
        //            ring.Radius = Validator.CheckIfValueMoreThanVerificationValue(ring.InnerRadius);
        //            Console.WriteLine("Кольцо создано");
        //            figures.Add(ring);
        //            CustomPaint(name, figures);
        //            break;
        //        case Figures.Line:
        //            Console.WriteLine("Введите начальные  и конечные координаты Линии:");
        //            Line line = new Line(Validator.InputCoordinats(), Validator.InputCoordinats(), Validator.InputCoordinats(), Validator.InputCoordinats());
        //            Console.WriteLine("Линия создана");
        //            figures.Add(line);
        //            CustomPaint(name, figures);
        //            break;
        //        case Figures.Square:
        //            Console.WriteLine("Введите координаты вершины квадрата и длину стороны квадрата.");
        //            Quadrate square = new Quadrate(Validator.InputCoordinats(), Validator.InputCoordinats(), Validator.CheckIfValueMoreThanVerificationValue(0));
        //            Console.WriteLine("Квадрат создан");
        //            figures.Add(square);
        //            CustomPaint(name, figures);
        //            break;
        //        case Figures.Rectangle:
        //            Console.WriteLine("Введите координаты вершины прямоугольника и длины его сторон.");
        //            Rectangle rectangle = new Rectangle(Validator.InputCoordinats(), Validator.InputCoordinats(), Validator.CheckIfValueMoreThanVerificationValue(0), Validator.CheckIfValueMoreThanVerificationValue(0));
        //            Console.WriteLine("Прямоугольник создан.");
        //            figures.Add(rectangle);
        //            CustomPaint(name, figures);
        //            break;
        //        case Figures.Triangle:
        //            Console.WriteLine("Введите координаты вершины треугольника и длины его сторон.");
        //            Triangle triangle = new Triangle(Validator.InputCoordinats(), Validator.InputCoordinats(), Validator.CheckIfValueMoreThanVerificationValue(0), Validator.CheckIfValueMoreThanVerificationValue(0), Validator.CheckIfValueMoreThanVerificationValue(0));
        //            Console.WriteLine("Треугольник создан.");
        //            figures.Add(triangle);
        //            CustomPaint(name, figures);
        //            break;
        //        case Figures.Sphere:
        //            Console.WriteLine("Введите координаты центра сферы и её радиус:");
        //            Sphere sphere = new Sphere(Validator.InputCoordinats(), Validator.InputCoordinats(), Validator.CheckIfValueMoreThanVerificationValue(0));
        //            Console.WriteLine("Сфера создана.");
        //            figures.Add(sphere);
        //            CustomPaint(name, figures);
        //            break;
        //        case Figures.Cylinder:
        //            Console.WriteLine("Введите радиус и высоту цилиндра");
        //            Cylinder cylinder = new Cylinder(0, 0, Validator.CheckIfValueMoreThanVerificationValue(0), Validator.CheckIfValueMoreThanVerificationValue(0));
        //            Console.WriteLine("Цилиндр создан.");
        //            figures.Add(cylinder);
        //            CustomPaint(name, figures);
        //            break;
        //        default:
        //            Console.WriteLine("Такой команды не существует! Введите другую команду.");
        //            CustomPaint(name, figures);
        //            break;
        //    }
        //}

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
    public abstract class Figure
    {
        private float _startpointX;

        public float StartpointX
        {
            get => _startpointX;
            set => _startpointX = value;
        }

        private float _startpointY;

        public float StartpointY
        {
            get => _startpointY;
            set => _startpointY = value;
        }
    }

    public abstract class OpenFigures : Figure
    {
        private float _endlinepointX;

        public float EndlinepointX
        {
            get => _endlinepointX;
            set => _endlinepointX = value;
        }

        private float _endlinepointY;

        public float EndlinepointY
        {
            get => _endlinepointY;
            set => _endlinepointY = value;
        }
        public virtual double Length { get; }
    }

    public abstract class ClosedFigures: Figure
    {
        public virtual double Area { get; }
    }

    public abstract class VolumeFigures : ClosedFigures
    {
        public virtual double Volume { get; }
    }

    abstract public class FlatFigures : ClosedFigures
    {
        public virtual double Perimeter { get; }
    }

    class Line : OpenFigures
    {
        public Line (float pointX, float pointY, float endpointX, float endpointY)
        {
            StartpointX = pointX;
            StartpointY = pointY;
            EndlinepointX = endpointX;
            EndlinepointY = endpointY;
        }
        public override double Length 
        {
            get
            {
                float width;
                float heigth;

                if (EndlinepointX > StartpointX)
                {
                    width = EndlinepointX - StartpointX;
                }
                else
                {
                    width = StartpointX - EndlinepointX;
                }

                if (EndlinepointY > StartpointY)
                {
                    heigth = EndlinepointY - StartpointY;
                }
                else
                {
                    heigth = StartpointY - EndlinepointY;
                }

                return Math.Sqrt(width * width + heigth * heigth);
            }
        }

        public override string ToString()
        {
            return $"Прямая линия.\n" +
                   $"Координаты начала линии - (x:, y:) {StartpointX} {StartpointY},\n" +
                   $"координаты окончания линии - (x:, y:) {EndlinepointX} {EndlinepointY},\n" +
                   $"длина линии - {Math.Round(Length, 2, MidpointRounding.AwayFromZero)}";
        }
    }

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

    class Rectangle : Quadrate
    {
        public Rectangle(float pointX, float pointY, float side, float height) : base (pointX, pointY, side)
        {
            StartpointX = pointX;
            StartpointY = pointY;
            Side = side;
            Height = height;
        }

        private float _height;

        public float Height
        {
            get => _height;
            set => _height = value;
        }

        public override double Area
        {
            get
            {
                return Side * Height;
            }
        }

        public override double Perimeter
        {
            get
            {
                return (Side + Height) * 2;
            }
        }

        public override string ToString()
        {
            return $"Прямоугольник.\n" +
                   $"Координаты вершины прямоугольника - (x:, y:) {StartpointX} {StartpointY}, {StartpointX + Side} {StartpointY}, {StartpointX + Side} {StartpointY + Height}, {StartpointX} {StartpointY + Height}\n" +
                   $"площадь прямоугольника - {Math.Round(Area, 2, MidpointRounding.AwayFromZero)}\n" +
                   $"периметр прямоугольника - {Math.Round(Perimeter, 2, MidpointRounding.AwayFromZero)}";
        }
    } 

    class Sphere : VolumeFigures
    {
        public Sphere(float pointX, float pointY, float radius)
        {
            StartpointX = pointX;
            StartpointY = pointY;
            Radius = radius;
        }

        private float _radius;
        public float Radius
        {
            get => _radius;
            set => _radius = value;
        }

        public override double Area
        {
            get
            {
                return 4 * Math.PI * Radius * Radius;
            }
        }

        public override double Volume
        {
            get
            {
                return (4 * Math.PI * Radius * Radius * Radius) / 3;
            }
        }

        public override string ToString()
        {
            return $"Сфера.\n" +
                   $"Координаты центра сферы - (x:, y:) {StartpointX} {StartpointY}\n" +
                   $"площадь сферы - {Math.Round(Area, 2, MidpointRounding.AwayFromZero)}\n" +
                   $"объем сферы - {Math.Round(Volume, 2, MidpointRounding.AwayFromZero)}";
        }
    }

    class Cylinder : Sphere
    {
        public Cylinder(float pointX, float pointY, float radius, float height) : base (pointX, pointY, radius)
        {
            StartpointX = pointX;
            StartpointY = pointY;
            Radius = radius;
            Height = height;
        }

        private float _height;

        public float Height
        {
            get => _height;
            set => _height = value;
        }

        public override double Area
        {
            get
            {
                return 2 * Math.PI * Radius *(Height + Radius);
            }
        }

        public override double Volume
        {
            get
            {
                return Math.PI * Radius * Radius * Height;
            }
        }

        public override string ToString()
        {
            return $"Цилиндр.\n" +
                   $"Радиус цилиндра - {Radius}\n" +
                   $"Высота цилиндра - {Height}\n" +
                   $"Площадь цилиндра - {Math.Round(Area, 2, MidpointRounding.AwayFromZero)}\n" +
                   $"Объем цилиндра - {Math.Round(Volume, 2, MidpointRounding.AwayFromZero)}";
        }
    }
}
