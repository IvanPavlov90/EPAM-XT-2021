using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1._2
{
    public class Square : FlatFigures
    {
        public Square(float pointX, float pointY, float side)
        {
            StartpointX = pointX;
            StartpointY = pointY;
            Side = CheckSide(side);
        }

        private float _side;

        public float Side
        {
            get => _side;
            set => _side = value;
        }

        public override double Area
        {
            get
            {
                return Side * Side;
            }
        }

        public override double Perimeter
        {
            get
            {
                return Side * 4;
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
            return $"Square.\n" +
                   $"Coordinats of the square's tops - (x:, y:) {StartpointX} {StartpointY}, {StartpointX + Side} {StartpointY}, {StartpointX + Side} {StartpointY + Side}, {StartpointX} {StartpointY + Side}\n" +
                   $"area - {Math.Round(Area, 2, MidpointRounding.AwayFromZero)}\n" +
                   $"perimeter - {Math.Round(Perimeter, 2, MidpointRounding.AwayFromZero)}";
        }
    }
}
