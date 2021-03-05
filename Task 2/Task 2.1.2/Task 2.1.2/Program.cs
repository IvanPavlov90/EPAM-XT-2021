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
                    foreach (object item in figures)
                    {
                        foreach (FieldInfo field in item.GetType().GetFields())
                        {
                            Console.WriteLine($"{field.Name} - {field.GetValue(item)}");
                        }
                    }
                    Console.WriteLine("Нажмите клавишу для продолжения");
                    Console.ReadKey();
                    CustomPaint(figures);
                    break;
                default:
                    Console.ReadKey();
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
                "4. Вывод"
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
                    Console.WriteLine("Введите координаты центра");
                    Circle circle = new Circle();
                    figures.Add(circle);
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
    }

    class Circle
    {
        public string name = "Круг";
        public float centerX;
        public float centerY;
        public double radius
        {
            get
            {
                return radius;
            }
            set
            {
                if (radius <= 0)
                {
                    Console.WriteLine("Такого просто не может быть.");
                } else
                {
                    radius = value;
                }
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
