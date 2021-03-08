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

        static void ShowFiguresMenu ()
        {
            List<string> menu = new List<string>()
            {
                "Выберите тип фигуры:",
                "1. Круг",
                "2. Кольцо"
            };

            foreach (string item in menu)
            {
                Console.WriteLine(item);
            }
        }

        static void ShowFigures (List<object> figures, string figuresChoise)
        {
            switch (figuresChoise)
            {
                case "1":
                    Console.WriteLine("Введите параметры фигуры Круг:");
                    Circle circle = new Circle();
                    Console.WriteLine("Введите координаты центра круга, координата Х:");
                    string userscirclecenterX = Console.ReadLine();
                    float circlecenterX;
                    float.TryParse(userscirclecenterX, out circlecenterX);
                    circle.centerX = circlecenterX;
                    Console.WriteLine("Введите координаты центра круга, координата Y:");
                    string userscirclecenterY = Console.ReadLine();
                    float circlecenterY;
                    float.TryParse(userscirclecenterY, out circlecenterY);
                    circle.centerY = circlecenterY;
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
                    Console.WriteLine("Введите координаты центра кольца, координата Х:");
                    string usersringcenterX = Console.ReadLine();
                    float ringcenterX;
                    float.TryParse(usersringcenterX, out ringcenterX);
                    ring.centerX = ringcenterX;
                    Console.WriteLine("Введите координаты центра кольца, координата Y:");
                    string usersringcenterY = Console.ReadLine();
                    float ringcenterY;
                    float.TryParse(usersringcenterY, out ringcenterY);
                    ring.centerY = ringcenterY;
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
                default: break;
            }
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
}
