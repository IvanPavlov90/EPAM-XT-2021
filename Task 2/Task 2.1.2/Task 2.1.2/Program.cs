using System;
using System.Collections.Generic;

namespace Task_2._1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<object> figures = new List<object>();
            CustomPaint(figures);
        }

        /// <summary>
        /// Основное меню приложения, в котором происходит выбор действия.
        /// </summary>
        /// <param name="figures"></param>
        static void CustomPaint(List<object> figures)
        {
            showMainMenu();
            string usersChoise = Console.ReadLine();
            switch (usersChoise)
            {
                case "1":
                    ShowFiguresMenu();
                    string figuresChoise = Console.ReadLine();
                    ShowFigures(figures, figuresChoise);
                    break;
                case "2":
                    if (figures.Count == 0)
                    {
                        Console.WriteLine("Вы ничего еще не нарисовали");
                    }
                    else
                    {
                        foreach (object item in figures)
                        {
                            Console.WriteLine(item.ToString());
                        }
                    }
                    Console.WriteLine("Нажмите клавишу для продолжения");
                    Console.ReadKey();
                    CustomPaint(figures);
                    break;
                case "3":
                    figures.Clear();
                    Console.Clear();
                    Console.WriteLine("Перед Вами чистый холст, то, что Вы здесь изобразите зависит только от Вас!");
                    CustomPaint(figures);
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Такой команды не существует! Введите другую команду.");
                    CustomPaint(figures);
                    break;
            }
            Console.ReadKey();
        }

        static void showMainMenu ()
        {
            List<string> menu = new List<string>()
            {
                "Выберите действие:",
                "1. Добавить фигуру",
                "2. Вывести фигуры",
                "3. Очистить холст",
                "4. Выход"
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
            List<string> menu = new List<string>()
            {
                "Выберите тип фигуры:",
                "1. Круг",
                "2. Кольцо",
                "3. Прямая линия",
                "4. Квадрат",
                "5. Прямоугольник",
                "6. Треугольник",
                "7. Сфера",
                "8. Цилиндр",
            };

            foreach (string item in menu)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// Метод, который создает фигуры, в зависимости от выбора пользователя.
        /// </summary>
        /// <param name="figures"></param>
        /// <param name="figuresChoise"></param>
        static void ShowFigures (List<object> figures, string figuresChoise)
        {
            switch (figuresChoise)
            {
                case "1":
                    Console.WriteLine("Введите параметры фигуры Круг:");
                    Circle circle = new Circle();
                    Console.WriteLine("Введите координаты центра круга:");
                    circle.StartpointX = InputCoordinats();
                    circle.StartpointY = InputCoordinats();
                    Console.WriteLine("Введите радиус (дробный радиус вводится через запятую)");
                    circle.Radius = CheckingValues(0);
                    Console.WriteLine("Круг создан");
                    figures.Add(circle);
                    CustomPaint(figures);
                    break;
                case "2":
                    Console.WriteLine("Введите параметры фигуры Кольцо:");
                    Ring ring = new Ring();
                    Console.WriteLine("Введите координаты центра кольца:");
                    ring.StartpointX = InputCoordinats();
                    ring.StartpointY = InputCoordinats();
                    Console.WriteLine("Введите внутренний радиус кольца (дробный радиус вводится через запятую)");
                    ring.InnerRadius = CheckingValues(0);
                    Console.WriteLine("Введите внешний радиус кольца (дробный радиус вводится через запятую)");
                    ring.Radius = CheckingValues(ring.InnerRadius);
                    Console.WriteLine("Кольцо создано");
                    figures.Add(ring);
                    CustomPaint(figures);
                    break;
                case "3":
                    Line line = new Line();
                    Console.WriteLine("Введите начальные координаты Линии:");
                    line.StartpointX = InputCoordinats();
                    line.StartpointY = InputCoordinats();
                    Console.WriteLine("Введите конечные координаты Линии:");
                    line.EndlinepointX = InputCoordinats();
                    line.EndlinepointY = InputCoordinats();
                    Console.WriteLine("Линия создана");
                    figures.Add(line);
                    CustomPaint(figures);
                    break;
                case "4":
                    Quadrate square = new Quadrate();
                    Console.WriteLine("Введите координаты вершины квадрата:");
                    square.StartpointX = InputCoordinats();
                    square.StartpointY = InputCoordinats();
                    Console.WriteLine("Введите длину стороны квадрата:");
                    square.Side = CheckingValues(0);
                    figures.Add(square);
                    CustomPaint(figures);
                    break;
                case "5":
                    Rectangle rectangle = new Rectangle();
                    Console.WriteLine("Введите координаты вершины прямоугольника:");
                    rectangle.StartpointX = InputCoordinats();
                    rectangle.StartpointY = InputCoordinats();
                    Console.WriteLine("Введите ширину прямоугольника:");
                    rectangle.Side = CheckingValues(0);
                    Console.WriteLine("Введите высоту прямоугольника:");
                    rectangle.Height = CheckingValues(0);
                    Console.WriteLine("Прямоугольник создан.");
                    figures.Add(rectangle);
                    CustomPaint(figures);
                    break;
                case "6":
                    Triangle triangle = new Triangle();
                    Console.WriteLine("Введите координаты вершины прямоугольника:");
                    triangle.StartpointX = InputCoordinats();
                    triangle.StartpointY = InputCoordinats();
                    Console.WriteLine("Введите длины сторон прямоугольника. Первая сторона");
                    triangle.SideA = CheckingValues(0);
                    Console.WriteLine("Вторая сторона");
                    triangle.SideB = CheckingValues(0);
                    Console.WriteLine("Третья сторона");
                    triangle.SideC = CheckingValues(0);
                    Console.WriteLine("Треугольник создан.");
                    figures.Add(triangle);
                    CustomPaint(figures);
                    break;
                case "7":
                    Console.WriteLine("Введите параметры фигуры Круг:");
                    Sphere sphere = new Sphere();
                    Console.WriteLine("Введите координаты центра сферы:");
                    sphere.StartpointX = InputCoordinats();
                    sphere.StartpointY = InputCoordinats();
                    Console.WriteLine("Введите радиус (дробный радиус вводится через запятую)");
                    sphere.Radius = CheckingValues(0);
                    Console.WriteLine("Сфера создана.");
                    figures.Add(sphere);
                    CustomPaint(figures);
                    break;
                case "8":
                    Console.WriteLine("Введите параметры фигуры Круг:");
                    Cylinder cylinder = new Cylinder();
                    Console.WriteLine("Введите радиус (дробный радиус вводится через запятую)");
                    cylinder.Radius = CheckingValues(0);
                    Console.WriteLine("Введите высоту (дробный радиус вводится через запятую)");
                    cylinder.Height = CheckingValues(0);
                    Console.WriteLine("Цилиндр создан.");
                    figures.Add(cylinder);
                    CustomPaint(figures);
                    break;
                default:
                    Console.WriteLine("Такой команды не существует! Введите другую команду.");
                    CustomPaint(figures);
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
    }

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
                   $"площадь круга - {Math.Round(GetSquare, 2)},\n" +
                   $"длина окружности - {Math.Round(GetPerimeter, 2)}";
        }
    }

    class Ring : Circle
    {
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
                   $"площадь кольца - {Math.Round(GetSquare, 2)},\n" +
                   $"суммарная длина внешней и внутренней окружностей - {Math.Round(GetPerimeter, 2)}";
        }
    }

    class Line : OpenFigures
    {
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
                   $"длина линии - {Math.Round(Length, 2)}";
        }
    }

    class Triangle : FlatFigures
    {
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
                   $"Координаты вершины теругольника - {StartpointX} и {StartpointY},\n" +
                   $"площадь треугольника - {Math.Round(GetSquare, 2)}\n" +
                   $"периметр треугольника - {Math.Round(GetPerimeter, 2)}";
        }
    }

    class Quadrate : FlatFigures
    {
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
                   $"площадь квадрата - {Math.Round(GetSquare, 2)}\n" +
                   $"периметр квадрата - {Math.Round(GetPerimeter, 2)}";
        }
    }

    class Rectangle : Quadrate
    {
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
                   $"площадь прямоугольника - {Math.Round(GetSquare, 2)}\n" +
                   $"периметр прямоугольника - {Math.Round(GetPerimeter, 2)}";
        }
    } 

    class Sphere : VolumeFigures
    {
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
                   $"Координаты центра сферы - (x:, y:) {StartpointX} {StartpointY}" +
                   $"площадь сферы - {Math.Round(GetSquare, 2)}\n" +
                   $"объем сферы - {Math.Round(GetVolume, 2)}";
        }
    }

    class Cylinder : Sphere
    {
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
                   $"Площадь цилиндра - {Math.Round(GetSquare, 2)}\n" +
                   $"Объем цилиндра - {Math.Round(GetVolume, 2)}";
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

        private int _id;

        public int ID
        {
            get => _id;
        }

        private List<object> _figures = new List<object>();

        public List<object> ShowFigures
        {
            get => return _figures;
        }

        public List<object> AddFigure
        {
            set => _figures.Add(value);
        }
    }
}
