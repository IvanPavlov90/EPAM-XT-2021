using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1._2
{
    /// <summary>
    /// Class for menu that is responsible for printing figures.
    /// </summary>
    public static class  PaintMenu
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
                    figures.Add(Painter.CreateCircle(Validator.InputValues(), Validator.InputValues(), Validator.InputValues()));
                    Program.CustomPaint(name, figures);
                    break;
                case Figures.Ring:
                    Console.WriteLine("Please enter coordinats of the ring's center and it's inner and outer radiuses.");
                    figures.Add(Painter.CreateRing(Validator.InputValues(), Validator.InputValues(), Validator.InputValues(), Validator.InputValues()));
                    Program.CustomPaint(name, figures);
                    break;
                case Figures.Line:
                    Console.WriteLine("Please enter coordinats of start and of the end of line.");
                    figures.Add(Painter.CreateLine(Validator.InputValues(), Validator.InputValues(), Validator.InputValues(), Validator.InputValues()));
                    Program.CustomPaint(name, figures);
                    break;
                case Figures.Square:
                    Console.WriteLine("Square");
                    Program.CustomPaint(name, figures);
                    break;
                case Figures.Rectangle:
                    Console.WriteLine("Please enter coordinats of the rectangle's start top it's sudes.");
                    figures.Add(Painter.CreateRectangle(Validator.InputValues(), Validator.InputValues(), Validator.InputValues(), Validator.InputValues()));
                    Program.CustomPaint(name, figures);
                    break;
                case Figures.Triangle:
                    Console.WriteLine("Please enter values for the triangle's sides.");
                    figures.Add(Painter.CreateTriangle(0, 0, Validator.InputValues(), Validator.InputValues(), Validator.InputValues()));
                    Program.CustomPaint(name, figures);
                    break;
                case Figures.Sphere:
                    Console.WriteLine("Please enter coordinats of the sphere's center and it's radius.");
                    figures.Add(Painter.CreateSphere(Validator.InputValues(), Validator.InputValues(), Validator.InputValues()));
                    Program.CustomPaint(name, figures);
                    break;
                case Figures.Cylinder:
                    Console.WriteLine("Please enter values for the cylinder's radius and height.");
                    figures.Add(Painter.CreateCylinder(0, 0, Validator.InputValues(), Validator.InputValues()));
                    Program.CustomPaint(name, figures);
                    break;
                default:
                    Console.WriteLine($"{name}, You have entered wrong action.");
                    Program.CustomPaint(name, figures);
                    break;
            };
        }
    }
}
