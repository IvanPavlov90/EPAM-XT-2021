using System;
using System.Collections.Generic;
using System.Reflection;

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
                            FieldInfo[] fields = item.GetType().GetFields();
                            foreach (FieldInfo field in fields)
                            {
                                Console.WriteLine("{0} - {1}", field.Name, field.GetValue(item));
                            }
                            //MethodInfo[] methods = item.GetType().GetMethods();
                            //foreach (MethodInfo method in methods)
                            //{
                            //    Console.WriteLine("{0}", method.Name);
                            //}
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
                "3. Точка",
                "4. Линия",
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
                    InputCoordinats(ref circle.centerX, ref circle.centerY);
                    Console.WriteLine("Введите радиус (дробный радиус вводится через запятую)");
                    string userradius = Console.ReadLine();
                    float radius;
                    float.TryParse(userradius, out radius);
                    if (radius <= 0)
                    {
                        Console.WriteLine("Вы ввели некорректные параметры фигуры, перевведите значения.");
                        goto case "1";
                    }
                    else
                    {
                        circle._radius = radius;
                        Console.WriteLine("Фигура Круг создана");
                        figures.Add(circle);
                        CustomPaint(figures);
                        break;
                    }
                case "2":
                    Console.WriteLine("Введите параметры фигуры Кольцо:");
                    Ring ring = new Ring();
                    ring.name = "Кольцо";
                    Console.WriteLine("Введите координаты центра кольца:");
                    InputCoordinats(ref ring.centerX, ref ring.centerY);
                    Console.WriteLine("Введите внешний радиус (дробный радиус вводится через запятую)");
                    string userringradius = Console.ReadLine();
                    float outerringradius;
                    float.TryParse(userringradius, out outerringradius);
                    if (outerringradius <= 0)
                    {
                        Console.WriteLine("Вы ввели некорректные параметры фигуры, перевведите значения.");
                        goto case "2";
                    }
                    else
                    {
                        ring._radius = outerringradius;
                    }
                    Console.WriteLine("Введите внутренний радиус кольца (дробный радиус вводится через запятую)");
                    string userinnerringradius = Console.ReadLine();
                    float innerringradius;
                    float.TryParse(userinnerringradius, out innerringradius);
                    if (innerringradius <= 0 || innerringradius >= outerringradius)
                    {
                        Console.WriteLine("Внутренний радиус не может быть равен нулю или больше внешнего, перевведите значения.");
                        goto case "2";
                    } else
                    {
                        ring._innerRadius = innerringradius;
                    }
                    Console.WriteLine("Фигура Кольцо создана");
                    figures.Add(ring);
                    CustomPaint(figures);
                    break;
                case "3":
                    Console.WriteLine("Введите координаты Точки:");
                    Point point = new Point();
                    InputCoordinats(ref point.pointX, ref point.pointY);
                    Console.WriteLine("Точка создана");
                    figures.Add(point);
                    CustomPaint(figures);
                    break;
                case "4":
                    Line line = new Line();
                    line.name = "Линия";
                    Console.WriteLine("Введите начальные координаты Линии:");
                    InputCoordinats(ref line.pointX, ref line.pointY);
                    Console.WriteLine("Введите конечные координаты Линии:");
                    InputCoordinats(ref line.endlinepointX, ref line.endlinepointY);
                    Console.WriteLine("Линия создана");
                    figures.Add(line);
                    CustomPaint(figures);
                    break;
                default:
                    Console.WriteLine("Такой команды не существует! Введите другую команду.");
                    CustomPaint(figures);
                    break;
            }
        }

        /// <summary>
        /// Метод, принимающий любую фигуру и назначающий координаты какой-либо точки фигуры. Например, центр курга, конечную точку линии или вершину треугольника.
        /// </summary>
        /// <param name="coordinatX"></param>
        /// <param name="coordinatY"></param>
        static void InputCoordinats (ref float coordinatX, ref float coordinatY)
        {
            Console.WriteLine("Введите координату Х:");
            string userspointcenterX = Console.ReadLine();
            float pointcenterX;
            float.TryParse(userspointcenterX, out pointcenterX);
            coordinatX = pointcenterX;
            Console.WriteLine("Введите координату Y:");
            string userspointcenterY = Console.ReadLine();
            float pointcenterY;
            float.TryParse(userspointcenterY, out pointcenterY);
            coordinatY = pointcenterY;
        }
    }

    class Circle
    {
        public string name = "Круг";
        public float centerX;
        public float centerY;
        public float radius;
        public float _radius
        {
            get
            {
                return radius;
            }
            set
            {
                radius = value;
            }
        }

        public double CircleSquare
        {
            get
            {
                return Math.PI * radius * radius;
            }
        }

        public double CircleLength
        {
            get
            {
                return 2 * Math.PI * radius;
            }
        }
    }

    class Ring : Circle
    {
        public float innerRadius;
        public float _innerRadius 
        {
            get
            {
                return innerRadius;
            }
            set
            {
                innerRadius = value;
            } 
        }

        public double RingSquare
        {
            get
            {
                return Math.PI * (radius * radius - innerRadius * innerRadius);
            }
        }

        public double RingLength
        {
            get
            {
                return 2 * Math.PI * (radius + innerRadius);
            }
        }
    }

    class Point
    {
        public string name = "Точка";
        public float pointX;
        public float pointY;
    }

    class Line : Point
    {
        public float endlinepointX;
        public float endlinepointY;

        /// <summary>
        /// Метод получающий начальные и конечные координаты линии. В последствии должен использоваться при подсчете других величин, где необходимо знать длину стороны.
        /// </summary>
        /// <param name="startpointX"></param>
        /// <param name="startpointY"></param>
        /// <param name="endpointX"></param>
        /// <param name="endpointY"></param>
        /// <returns>Возвращает длину линии</returns>
        public double Length (float startpointX, float startpointY, float endpointX, float endpointY)
        {
            float width;
            float heigth;

            if (endpointX > startpointX)
            {
                width = endpointX - startpointX;
            }
            else
            {
                width = startpointX - endpointX;
            }

            if (endlinepointY > pointY)
            {
                heigth = endpointY - startpointY;
            }
            else
            {
                heigth = startpointY - endpointY;
            }

            return Math.Sqrt(width * width + heigth * heigth);
        }
    }
}
