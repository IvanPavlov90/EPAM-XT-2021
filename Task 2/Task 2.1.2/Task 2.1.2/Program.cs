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
                            foreach (FieldInfo field in item.GetType().GetFields())
                            {
                                Console.WriteLine($"{field.Name} - {field.GetValue(item)}");
                            }
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
                    Console.WriteLine("Введите координаты центра круга");
                    Circle circle = new Circle();
                    figures.Add(circle);
                    Console.WriteLine("Введите радиус");
                    CheckRadius(circle);
                    Console.WriteLine("Фигура Круг создана");
                    CustomPaint(figures);
                    break;
                case "2":
                    Console.WriteLine("Введите параметры фигуры Кольцо:");
                    Console.WriteLine("Введите координаты центра");
                    Ring ring = new Ring();
                    figures.Add(ring);
                    Console.WriteLine("Фигура Кольцо создана");
                    CustomPaint(figures);
                    break;
                default: break;
            }
        }

        static void CheckRadius (object circle)
        {
            string userradius = Console.ReadLine();
            double radius;
            Double.TryParse(userradius, out radius);
            if (radius <= 0)
            {
                Console.WriteLine("Такой радиус недопустим, введите его еще раз.");
                CheckRadius(circle);
            }
            else
            {
                circle.(userradius);
            }
        }
    }

    class Circle
    {
        public string name = "Круг";
        public float centerX;
        public float centerY;
        private double _radius;
        //public double radius
        //{
        //    get
        //    {
        //        return _radius;
        //    }
        //    set
        //    {
        //        if (value <= 0)
        //        {
        //            Console.WriteLine("Такого просто не может быть.");
        //        }
        //        else
        //        {
        //            _radius = value;
        //        }
        //    }
        //}

        public double radius;

        public void SetRadius(double value)
        {
            if (value <= 0)
            {
                Console.WriteLine("Неверное значение радиуса, введите его заново");
            } else
            {
                this.radius = value;
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
        public double innerRadius 
        {
            get
            {
                return innerRadius;
            }
            set
            {
                if (innerRadius >= radius)
                {
                    Console.WriteLine("Такого просто не может быть.");
                } else
                {
                    innerRadius = value;
                }
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
