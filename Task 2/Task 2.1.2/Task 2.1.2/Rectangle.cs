using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1._2
{
    public class Rectangle : FlatFigures
    {
        public Rectangle(float pointX, float pointY, float width, float height)
        {
            StartpointX = pointX;
            StartpointY = pointY;
            Width = CheckSide(width);
            Height = CheckSide(height);
        }

        public float Width { get; set; }

        public float Height { get; set; }

        public override double Area
        {
            get
            {
                return Width * Height;
            }
        }

        public override double Perimeter
        {
            get
            {
                return (Width + Height) * 2;
            }
        }

        public static float CheckSide(float side)
        {
            while (side <= 0)
            {
                Console.WriteLine($"Your value is uncorrect. It should be greater then 0. Please, try once again.");
                string uservalue = Console.ReadLine();
                float.TryParse(uservalue, out side);
            }
            return side;
        }

        public override string ToString()
        {
            return $"Rectangle.\n" +
                   $"Coordinats of the rectangle's tops - (x:, y:) {StartpointX} {StartpointY}, {StartpointX + Width} {StartpointY}, {StartpointX + Width} {StartpointY + Height}, {StartpointX} {StartpointY + Height}\n" +
                   $"width - {Width}\n" +
                   $"height - {Height}\n" +
                   $"area - {Math.Round(Area, 2, MidpointRounding.AwayFromZero)}\n" +
                   $"perimeter - {Math.Round(Perimeter, 2, MidpointRounding.AwayFromZero)}";
        }
    }
}
