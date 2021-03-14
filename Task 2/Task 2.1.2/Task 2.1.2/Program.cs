using System;
using System.Collections.Generic;

namespace Task_2._1._2
{
    class Program
    {
        public enum Figures
        {
            Круг = 1,
            Кольцо = 2,
            Линия = 3,
            Квадрат = 4,
            Прямоугольник = 5,
            Треугольник = 6,
            Сфера = 7,
            Цилиндр = 8
        }

        static void Main(string[] args)
        {
            StartApp();
        }

        static void StartApp ()
        {
            List<User> users = new List<User>();
            User currentuser = SetUser(users);
            Console.WriteLine($"Добро пожаловать, {currentuser.Name}");
            CustomPaint(currentuser.Name, currentuser.ShowFigures());
        }

        /// <summary>
        /// Основное меню приложения, в котором происходит выбор действия.
        /// </summary>
        static void CustomPaint(string name, List<object> figures)
        {
            showMainMenu();
            string usersChoise = Console.ReadLine();
            switch (usersChoise)
            {
                case "1":
                    ShowFiguresMenu();
                    int value = CheckUsersChoise();
                    ShowFigures(name, figures, CheckFigure(value));
                    break;
                case "2":
                    if (figures.Count == 0)
                    {
                        Console.WriteLine($"{name}, Вы ничего еще не нарисовали");
                    }
                    else
                    {
                        foreach (object item in figures)
                        {
                            Console.WriteLine(item.ToString());
                        }
                    }
                    Console.WriteLine($"{name}, нажмите клавишу для продолжения");
                    Console.ReadKey();
                    CustomPaint(name, figures);
                    break;
                case "3":
                    figures.Clear();
                    Console.Clear();
                    Console.WriteLine($"{name}, перед Вами чистый холст, то, что Вы здесь изобразите зависит только от Вас!");
                    CustomPaint(name, figures);
                    break;
                case "4":
                    Console.Clear();
                    StartApp();
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine($"{name}, такой команды не существует! Введите другую команду.");
                    CustomPaint(name, figures);
                    break;
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Метод для вывода основного меню.
        /// </summary>
        static void showMainMenu ()
        {
            List<string> menu = new List<string>()
            {
                "Выберите действие:",
                "1. Добавить фигуру",
                "2. Вывести фигуры",
                "3. Очистить холст",
                "4. Сменить пользователя",
                "5. Выход"
            };

            foreach (string item in menu)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// Метод, выводящий меню выбора фиугр.
        /// </summary>
        static void ShowFiguresMenu ()
        {
            foreach (Figures item in Enum.GetValues(typeof(Figures)))
            {
                Console.WriteLine($"{(int)item}. {item}");
            }
        }

        /// <summary>
        /// Метод, использощуйся для проверки, введенного пользователем значения при выборе фигуры.
        /// Если пользователь ввел значение не соответствующее интовому значению из перечисления Figures, 
        /// метод будет просить переввести это значение.
        /// </summary>
        /// <returns>Корректное значение</returns>
        public static int CheckUsersChoise ()
        {
            string uservalue = Console.ReadLine();
            Int32.TryParse(uservalue, out int value);
            while (value <= 0 || value > 8)
            {
                Console.WriteLine("Вы ввели некорректное значение. Попробуйте еще раз");
                uservalue = Console.ReadLine();
                Int32.TryParse(uservalue, out value);
            }
            return value;
        }

        /// <summary>
        /// Метод, отвечающий за выбор фигуры.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Возвращает выбранную из перечисления фигуру. Тк значение которое попадает в этом метод уже прошло проверку на корректность,
        /// то строчка "return Figures.Кольцо;" никогда не должна выполниться.
        /// </returns>
        public static Figures CheckFigure (int value)
        {
            foreach (Figures item in Enum.GetValues(typeof(Figures)))
            {
                if ((int)item == value)
                {
                    return item;
                }
            }

            return Figures.Кольцо;
        }

        /// <summary>
        /// Метод, который создает фигуры, в зависимости от выбора пользователя.
        /// </summary>
        static void ShowFigures (string name, List<object> figures, Figures figure)
        {
            switch (figure)
            {
                case Figures.Круг:
                    Console.WriteLine("Введите параметры фигуры Круг.");
                    Console.WriteLine("Введите координаты центра круга и значение радиуса (дробный радиус вводится через запятую).");
                    Circle circle = new Circle(InputCoordinats(), InputCoordinats(), CheckingValues(0));
                    Console.WriteLine("Круг создан");
                    figures.Add(circle);
                    CustomPaint(name, figures);
                    break;
                case Figures.Кольцо:
                    Console.WriteLine("Введите параметры фигуры Кольцо.");
                    Console.WriteLine("Введите координаты центра кольца, а также значения внешнего и внутреннего радиусов (дробный радиус вводится через запятую).");
                    Ring ring = new Ring(InputCoordinats(), InputCoordinats(), CheckingValues(0), CheckingValues(0));
                    Console.WriteLine("Проверка на корректность введенных радиусов, перевведите значение внешенго радиуса, оно должно быть не меньше значения внутреннего радиуса.");
                    ring.Radius = CheckingValues(ring.InnerRadius);
                    Console.WriteLine("Кольцо создано");
                    figures.Add(ring);
                    CustomPaint(name, figures);
                    break;
                case Figures.Линия:
                    Console.WriteLine("Введите начальные  и конечные координаты Линии:");
                    Line line = new Line(InputCoordinats(), InputCoordinats(), InputCoordinats(), InputCoordinats());
                    Console.WriteLine("Линия создана");
                    figures.Add(line);
                    CustomPaint(name, figures);
                    break;
                case Figures.Квадрат:
                    Console.WriteLine("Введите координаты вершины квадрата и длину стороны квадрата.");
                    Quadrate square = new Quadrate(InputCoordinats(), InputCoordinats(), CheckingValues(0));
                    Console.WriteLine("Квадрат создан");
                    figures.Add(square);
                    CustomPaint(name, figures);
                    break;
                case Figures.Прямоугольник:
                    Console.WriteLine("Введите координаты вершины прямоугольника и длины его сторон.");
                    Rectangle rectangle = new Rectangle(InputCoordinats(), InputCoordinats(), CheckingValues(0), CheckingValues(0));
                    Console.WriteLine("Прямоугольник создан.");
                    figures.Add(rectangle);
                    CustomPaint(name, figures);
                    break;
                case Figures.Треугольник:
                    Console.WriteLine("Введите координаты вершины треугольника и длины его сторон.");
                    Triangle triangle = new Triangle(InputCoordinats(), InputCoordinats(), CheckingValues(0), CheckingValues(0), CheckingValues(0));
                    Console.WriteLine("Проверка треугольника на валидность.");
                    IsTriangleValid(triangle);
                    Console.WriteLine("Треугольник создан.");
                    figures.Add(triangle);
                    CustomPaint(name, figures);
                    break;
                case Figures.Сфера:
                    Console.WriteLine("Введите координаты центра сферы и её радиус:");
                    Sphere sphere = new Sphere(InputCoordinats(), InputCoordinats(), CheckingValues(0));
                    Console.WriteLine("Сфера создана.");
                    figures.Add(sphere);
                    CustomPaint(name, figures);
                    break;
                case Figures.Цилиндр:
                    Console.WriteLine("Введите радиус и высоту цилиндра");
                    Cylinder cylinder = new Cylinder(0, 0, CheckingValues(0), CheckingValues(0));
                    Console.WriteLine("Цилиндр создан.");
                    figures.Add(cylinder);
                    CustomPaint(name, figures);
                    break;
                default:
                    Console.WriteLine("Такой команды не существует! Введите другую команду.");
                    CustomPaint(name, figures);
                    break;
            }
        }

        /// <summary>
        /// Метод, использующися для ввода координат точки фигуры. Например, центр курга, конечной точки линии или вершины треугольника.
        /// </summary>
        /// <returns>Возвращает float значение координаты</returns>
        static float InputCoordinats ()
        {
            Console.WriteLine("Введите координату (только число):");
            do
            {
                string usercoordinate = Console.ReadLine();
                if (float.TryParse(usercoordinate, out float coordinate))
                    return coordinate;
            }
            while (true);
        }

        /// <summary>
        /// Метод, использующися для проверки введеных значений.
        /// </summary>
        /// <returns>Возвращает удовлетворяющее условиям проверки float значение</returns>
        static float CheckingValues (float checkvalue)
        {
            string uservalue = Console.ReadLine();
            float.TryParse(uservalue, out float value);
            while (value <= checkvalue)
            {
                Console.WriteLine("Вы ввели некорректное значение. Попробуйте еще раз");
                uservalue = Console.ReadLine();
                float.TryParse(uservalue, out value);
            }
            return value;
        }

        /// <summary>
        /// Метод, использующися для проверки существования треугольника. 
        /// Сумма двух меньших сторон треугольника должна быть больше или равна величине его большей стороны.
        /// </summary>
        static void IsTriangleValid(Triangle triangle)
        {
            if (triangle.SideA >= triangle.SideB && triangle.SideA >= triangle.SideC && triangle.SideA <= triangle.SideB + triangle.SideC)
            {
                Console.WriteLine("Треугольник валиден.");

            }
            else if (triangle.SideB >= triangle.SideA && triangle.SideB >= triangle.SideC && triangle.SideB <= triangle.SideA + triangle.SideC)
            {
                Console.WriteLine("Треугольник валиден.");

            }
            else if (triangle.SideC >= triangle.SideA && triangle.SideC >= triangle.SideB && triangle.SideC <= triangle.SideA + triangle.SideB)
            {
                Console.WriteLine("Треугольник валиден.");
            }
            else
            {
                Console.WriteLine("Такого треугольника не существует, придется вам переввести значения его сторон.");
                triangle.SideA = CheckingValues(0);
                triangle.SideB = CheckingValues(0);
                triangle.SideC = CheckingValues(0);
                Console.WriteLine("И теперь еще раз пройти проверку на валидность.");
                IsTriangleValid(triangle);
            }
        }


        /// <summary>
        /// Метод, принимающий список текущих юзеров. Внутри этого метода есть применение еще одного метода,
        /// который осуществляет поиск юзеров в списке по введенному имени.
        /// </summary>
        /// <param name="users"></param>
        /// <returns>В зависимости от того, нашелся ли пользовтаель по имени или нет, создается новый юзер или возвращается ранее созданный.</returns>
        public static User SetUser(List<User> users)
        {
            Console.WriteLine("Введите имя пользователя:");
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
    abstract class Figure
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

    abstract class OpenFigures : Figure
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

    abstract class ClosedFigures: Figure
    {
        public virtual double GetSquare { get; }
    }

    abstract class VolumeFigures : ClosedFigures
    {
        public virtual double GetVolume { get; }
    }

    abstract class FlatFigures : ClosedFigures
    {
        public virtual double GetPerimeter { get; }
    }

    class Circle: FlatFigures
    {
        public Circle (float pointX, float pointY, float radius)
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

        public override double GetSquare
        {
            get
            {
                return Math.PI * Radius * Radius;
            }
        }

        public override double GetPerimeter
        {
            get
            {
                return 2 * Math.PI * Radius;
            }
        }

        public override string ToString()
        {
            return $"Круг.\n" +
                   $"Координаты центра круга - х: {StartpointX}, у: {StartpointY},\n" +
                   $"радиус круга - {Radius},\n" +
                   $"площадь круга - {Math.Round(GetSquare, 2, MidpointRounding.AwayFromZero)},\n" +
                   $"длина окружности - {Math.Round(GetPerimeter, 2, MidpointRounding.AwayFromZero)}";
        }
    }

    class Ring : Circle
    {
        public Ring(float pointX, float pointY, float radius, float innerRadius) : base(pointX, pointY, radius)
        {
            StartpointX = pointX;
            StartpointY = pointY;
            Radius = radius;
            InnerRadius = innerRadius;
        }

        private float _innerRadius;
        public float InnerRadius 
        {
            get => _innerRadius;
            set => _innerRadius = value;
        }

        public override double GetSquare
        {
            get
            {
                return Math.PI * (Radius * Radius - InnerRadius * InnerRadius);
            }
        }

        public override double GetPerimeter
        {
            get
            {
                return 2 * Math.PI * (Radius + InnerRadius);
            }
        }

        public override string ToString()
        {
            return $"Кольцо.\n" +
                   $"Координаты центра кольца - {StartpointX} и {StartpointY},\n" +
                   $"внешний радиус кольца - {Radius},\n" +
                   $"внутренний радиус кольца - {InnerRadius},\n" +
                   $"площадь кольца - {Math.Round(GetSquare, 2, MidpointRounding.AwayFromZero)},\n" +
                   $"суммарная длина внешней и внутренней окружностей - {Math.Round(GetPerimeter, 2, MidpointRounding.AwayFromZero)}";
        }
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

    class Triangle : FlatFigures
    {
        public Triangle (float pointX, float pointY, float sideA, float sideB, float sideC)
        {
            StartpointX = pointX;
            StartpointY = pointY;
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        private float _sideA;

        public float SideA
        {
            get => _sideA;
            set => _sideA = value;
        }

        private float _sideB;

        public float SideB
        {
            get => _sideB;
            set => _sideB = value;
        }

        private float _sideC;

        public float SideC
        {
            get => _sideC;
            set => _sideC = value;
        }

        public override double GetSquare
        {
            get
            {
                float p = (SideA + SideA + SideC) / 2;
                return Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
            }
        }

        public override double GetPerimeter
        {
            get
            {
                return SideA + SideB + SideC;
            }
        }

        public override string ToString()
        {
            return $"Треугольник.\n" +
                   $"Координаты вершины теругольника - (x:, y:) {StartpointX} {StartpointY},\n" +
                   $"площадь треугольника - {Math.Round(GetSquare, 2, MidpointRounding.AwayFromZero)}\n" +
                   $"периметр треугольника - {Math.Round(GetPerimeter, 2, MidpointRounding.AwayFromZero)}";
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

        public override double GetSquare
        {
            get
            {
                return Side * Side;
            }
        }

        public override double GetPerimeter
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
                   $"площадь квадрата - {Math.Round(GetSquare, 2, MidpointRounding.AwayFromZero)}\n" +
                   $"периметр квадрата - {Math.Round(GetPerimeter, 2, MidpointRounding.AwayFromZero)}";
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

        public override double GetSquare
        {
            get
            {
                return Side * Height;
            }
        }

        public override double GetPerimeter
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
                   $"площадь прямоугольника - {Math.Round(GetSquare, 2, MidpointRounding.AwayFromZero)}\n" +
                   $"периметр прямоугольника - {Math.Round(GetPerimeter, 2, MidpointRounding.AwayFromZero)}";
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

        public override double GetSquare
        {
            get
            {
                return 4 * Math.PI * Radius * Radius;
            }
        }

        public override double GetVolume
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
                   $"площадь сферы - {Math.Round(GetSquare, 2, MidpointRounding.AwayFromZero)}\n" +
                   $"объем сферы - {Math.Round(GetVolume, 2, MidpointRounding.AwayFromZero)}";
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

        public override double GetSquare
        {
            get
            {
                return 2 * Math.PI * Radius *(Height + Radius);
            }
        }

        public override double GetVolume
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
                   $"Площадь цилиндра - {Math.Round(GetSquare, 2, MidpointRounding.AwayFromZero)}\n" +
                   $"Объем цилиндра - {Math.Round(GetVolume, 2, MidpointRounding.AwayFromZero)}";
        }
    }

    class User
    {
        public User (string name)
        {
            Name = name;
        }

        private string _name;

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        private List<object> _figures = new List<object>();

        public List<object> ShowFigures()
        {
            return _figures;
        }

        public List<object> AddFigure
        {
            set => _figures.Add(value);
        }
    }
}
