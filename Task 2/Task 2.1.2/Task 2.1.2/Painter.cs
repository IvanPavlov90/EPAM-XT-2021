using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1._2
{
    /// <summary>
    /// Class for menu that is responsible for printing figures.
    /// </summary>
    public static class  Painter
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

        public static void ShowMenu()
        {
            foreach (Figures item in Enum.GetValues(typeof(Figures)))
            {
                Console.WriteLine($"{(int)item}. {item}");
            }
        }

        /// <summary>
        /// Method that reads users input value and convert it into enum member.
        /// </summary>
        /// <returns>Returns enum member</returns>
        public static Figures ReadAction()
        {
            do
            {
                Console.WriteLine("Please enter your action");
                string value = Console.ReadLine();
                if (Enum.TryParse<Figures>(value, out Figures result))
                    return result;

            } while (true);
        }

        /// <summary>
        /// Method that contains main logic.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="name"></param>
        /// <param name="figures"></param>
        public static void DoAction(Figures value, string name, List<object> figures)
        {
            switch (value)
            {
                case Figures.Circle:
                    Console.WriteLine("Please enter coordinats of the circle's center and it's radius.");
                    figures.Add(CreateCircle(Validator.InputValues(), Validator.InputValues(), Validator.InputValues()));
                    Program.CustomPaint(name, figures);
                    break;
                case Figures.Ring:
                    Console.WriteLine("Please enter coordinats of the ring's center and it's ineer and outer radiuses.");
                    figures.Add(CreateRing(Validator.InputValues(), Validator.InputValues(), Validator.InputValues(), Validator.InputValues()));
                    Program.CustomPaint(name, figures);
                    break;
                case Figures.Line:
                    Console.WriteLine("Line");
                    Program.CustomPaint(name, figures);
                    break;
                case Figures.Square:
                    Console.WriteLine("Square");
                    Program.CustomPaint(name, figures);
                    break;
                case Figures.Rectangle:
                    Console.WriteLine("Rectangle");
                    Program.CustomPaint(name, figures);
                    break;
                case Figures.Triangle:
                    Console.WriteLine("Triangle");
                    Program.CustomPaint(name, figures);
                    break;
                case Figures.Sphere:
                    Console.WriteLine("Sphere");
                    Program.CustomPaint(name, figures);
                    break;
                case Figures.Cylinder:
                    Console.WriteLine("Cylinder");
                    Program.CustomPaint(name, figures);
                    break;
                default:
                    Console.WriteLine($"{name}, You have entered wrong action.");
                    Program.CustomPaint(name, figures);
                    break;
            };
        }

        public static Circle CreateCircle (float pointX, float pointY, float radius)
        {
            Circle circle = new Circle(pointX, pointY, radius);
            Console.WriteLine("Circle has been created.");
            return circle;
        }

        public static Ring CreateRing(float pointX, float pointY, float radius, float innerRadius)
        {
            Ring ring = new Ring (pointX, pointY, radius, innerRadius);
            Console.WriteLine("Ring has been created.");
            return ring;
        }
    }
}
