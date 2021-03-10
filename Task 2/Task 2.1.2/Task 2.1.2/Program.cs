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
                    InputCoordinats(ref circle.startpointX, ref circle.startpointY);
                    Console.WriteLine("Введите радиус (дробный радиус вводится через запятую)");
                    CheckingValues(ref circle.radius, 0);
                    Console.WriteLine("Круг создан");
                    figures.Add(circle);
                    CustomPaint(figures);
                    break;
                case "2":
                    Console.WriteLine("Введите параметры фигуры Кольцо:");
                    Ring ring = new Ring();
                    Console.WriteLine("Введите координаты центра кольца:");
                    InputCoordinats(ref ring.startpointX, ref ring.startpointY);
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
                    Console.WriteLine("Кольцо создано");
                    figures.Add(ring);
                    CustomPaint(figures);
                    break;
                case "3":
                    Line line = new Line();
                    Console.WriteLine("Введите начальные координаты Линии:");
                    InputCoordinats(ref line.startpointX, ref line.startpointY);
                    Console.WriteLine("Введите конечные координаты Линии:");
                    InputCoordinats(ref line.endlinepointX, ref line.endlinepointY);
                    Console.WriteLine("Линия создана");
                    figures.Add(line);
                    CustomPaint(figures);
                    break;
                case "4":
                    Quadrate square = new Quadrate();
                    Console.WriteLine("Введите координаты вершины квадрата:");
                    InputCoordinats(ref square.startpointX, ref square.startpointY);
                    Console.WriteLine("Введите длину стороны квадрата:");
                    string userwidth = Console.ReadLine();
                    float width;
                    float.TryParse(userwidth, out width);
                    if (width <= 0)
                    {
                        Console.WriteLine("Сторона квадрата не может быть меньшем нуля, перевведите значения.");
                        goto case "4";
                    } else
                    {
                        square.width = width;
                    };
                    figures.Add(square);
                    CustomPaint(figures);
                    break;
                case "5":
                    Rectangle rectangle = new Rectangle();
                    Console.WriteLine("Введите координаты вершины прямоугольника:");
                    InputCoordinats(ref rectangle.startpointX, ref rectangle.startpointY);
                    Console.WriteLine("Введите ширину прямоугольника:");
                    string userrectanglewidth = Console.ReadLine();
                    float rectanglewidth;
                    float.TryParse(userrectanglewidth, out rectanglewidth);
                    if (rectanglewidth <= 0)
                    {
                        Console.WriteLine("Ширина прямоугольника не может быть меньше нуля, перевведите значения.");
                        goto case "5";
                    }
                    else
                    {
                        rectangle.width = rectanglewidth;
                    };
                    Console.WriteLine("Введите высоту прямоугольника:");
                    string userrectangleheigth = Console.ReadLine();
                    float rectangleheigth;
                    float.TryParse(userrectangleheigth, out rectangleheigth);
                    if (rectangleheigth <= 0)
                    {
                        Console.WriteLine("Высота прямоугольника не может быть меньше нуля, перевведите значения.");
                        goto case "5";
                    }
                    else
                    {
                        rectangle.heigth = rectangleheigth;
                    };
                    figures.Add(rectangle);
                    CustomPaint(figures);
                    break;
                case "6":
                    Triangle triangle = new Triangle();
                    Console.WriteLine("Введите координаты вершины прямоугольника:");
                    InputCoordinats(ref triangle.startpointX, ref triangle.startpointY);
                    Console.WriteLine("Введите длины сторон прямоугольника. Первая сторона");
                    string firstside = Console.ReadLine();
                    float trianglefirstside;
                    float.TryParse(firstside, out trianglefirstside);
                    CheckingValues(ref triangle.sideA, 0);
                    Console.WriteLine("Вторая сторона");
                    Console.WriteLine("Третья сторона");
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

        static void CheckingValues (ref float parameter, float checkvalue)
        {
            Console.WriteLine("Введите значение.");
            string uservalue = Console.ReadLine();
            float value;
            float.TryParse(uservalue, out value);
            if (value <= checkvalue)
            {
                Console.WriteLine("Вы ввели некорректное значение. Попробуйте еще раз");
                CheckingValues(ref parameter, checkvalue);
            }
            else
            {
                parameter = value;
            };
        }
    }

    class Figure
    {
        public float startpointX;
        public float startpointY;
    }

    class OpenPieces : Figure
    {
        public float endlinepointX;
        public float endlinepointY;
        public virtual double Length { get; }
    }

    class ClosedFigures: Figure
    {
        public virtual double GetSquare { get; }
    }
    
    class VolumeFigures : ClosedFigures
    {
        public virtual double GetVolume { get; }
    }

    class FlatFigures : ClosedFigures
    {
        public virtual double GetPerimeter { get; }
    }

    class Circle: FlatFigures
    {
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

        public override double GetSquare
        {
            get
            {
                return Math.PI * radius * radius;
            }
        }

        public override double GetPerimeter
        {
            get
            {
                return 2 * Math.PI * radius;
            }
        }

        public override string ToString()
        {
            return $"Круг.\n" +
                   $"Координаты центра круга - {startpointX} и {startpointY},\n" +
                   $"радиус круга - {radius},\n" +
                   $"площадь круга - {Math.Round(GetSquare, 2)},\n" +
                   $"длина окружности - {Math.Round(GetPerimeter, 2)}";
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

        public override double GetSquare
        {
            get
            {
                return Math.PI * (radius * radius - innerRadius * innerRadius);
            }
        }

        public override double GetPerimeter
        {
            get
            {
                return 2 * Math.PI * (radius + innerRadius);
            }
        }

        public override string ToString()
        {
            return $"Кольцо.\n" +
                   $"Координаты центра кольца - {startpointX} и {startpointY},\n" +
                   $"внешний радиус кольца - {radius},\n" +
                   $"внутренний радиус кольца - {innerRadius},\n" +
                   $"площадь кольца - {Math.Round(GetSquare, 2)},\n" +
                   $"суммарная длина внешней и внутренней окружностей - {Math.Round(GetPerimeter, 2)}";
        }
    }

    class Line : OpenPieces
    {
        /// <summary>
        /// Метод получающий начальные и конечные координаты линии.
        /// </summary>
        /// <returns>Возвращает длину линии</returns>
        public override double Length 
        {
            get
            {
                float width;
                float heigth;

                if (endlinepointX > startpointX)
                {
                    width = endlinepointX - startpointX;
                }
                else
                {
                    width = startpointX - endlinepointX;
                }

                if (endlinepointY > startpointY)
                {
                    heigth = endlinepointY - startpointY;
                }
                else
                {
                    heigth = startpointY - endlinepointY;
                }

                return Math.Sqrt(width * width + heigth * heigth);
            }
        }

        public override string ToString()
        {
            return $"Прямая линия.\n" +
                   $"Координаты начала линии - {startpointX} и {startpointY},\n" +
                   $"координаты окончания линии - {endlinepointX} и {endlinepointY},\n" +
                   $"длина линии - {Math.Round(Length, 2)}";
        }
    }

    class Triangle : FlatFigures
    {
        public float sideA;
        public float sideB;
        public float sideC;

        //public override double GetSquare
        //{
        //    get
        //    {

        //    }
        //}

        public override double GetPerimeter
        {
            get
            {
                return sideA + sideB + sideC;
            }
        }

        //public override string ToString()
        //{
        //    return $"Треугольник.\n" +
        //           $"Координаты вершины квадрата - {startpointX} и {startpointX}, {startpointX + width} и {startpointY}, {startpointX + width} и {startpointX + width}, {startpointX} и {startpointX + width}\n" +
        //           $"площадь треугольника - {Math.Round(GetSquare, 2)}\n" +
        //           $"периметр треугольника - {Math.Round(GetPerimeter, 2)}";
        //}
    }

    class Quadrate : FlatFigures
    {
        public float width;

        public override double GetSquare
        {
            get
            {
                return width * width;
            }
        }

        public override double GetPerimeter
        {
            get
            {
                return width * 4;
            }
        }

        public override string ToString()
        {
            return $"Квадрат.\n" +
                   $"Координаты вершины квадрата - {startpointX} и {startpointY}, {startpointX + width} и {startpointY}, {startpointX + width} и {startpointY + width}, {startpointX} и {startpointY + width}\n" +
                   $"площадь квадрата - {Math.Round(GetSquare, 2)}\n" +
                   $"периметр квадрата - {Math.Round(GetPerimeter, 2)}";
        }
    }

    class Rectangle : Quadrate
    {
        public float heigth;

        public override double GetSquare
        {
            get
            {
                return width * heigth;
            }
        }

        public override double GetPerimeter
        {
            get
            {
                return (width + heigth) * 2;
            }
        }

        public override string ToString()
        {
            return $"Прямоугольник.\n" +
                   $"Координаты вершины прямоугольника - {startpointX} и {startpointY}, {startpointX + width} и {startpointY}, {startpointX + width} и {startpointY + heigth}, {startpointX} и {startpointY + heigth}\n" +
                   $"площадь прямоугольника - {Math.Round(GetSquare, 2)}\n" +
                   $"периметр прямоугольника - {Math.Round(GetPerimeter, 2)}";
        }
    } 
}
