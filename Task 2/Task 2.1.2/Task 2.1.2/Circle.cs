using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1._2
{
    public class Circle : FlatFigures
    {
        public Circle(float pointX, float pointY, float radius)
        {
            StartpointX = pointX;
            StartpointY = pointY;
            Radius = radius;
        }

        private float _radius;
        public float Radius
        {
            get => _radius;
            set => _radius = value;

        }

        public override double Area
        {
            get
            {
                return Math.PI * Radius * Radius;
            }
        }

        public override double Perimeter
        {
            get
            {
                return 2 * Math.PI * Radius;
            }
        }

        public override string ToString()
        {
            return $"Circle.\n" +
                   $"Coordinats of the center of the circle - х: {StartpointX}, у: {StartpointY},\n" +
                   $"radius - {Radius},\n" +
                   $"circle's area - {Math.Round(Area, 2, MidpointRounding.AwayFromZero)},\n" +
                   $"length of the circle - {Math.Round(Perimeter, 2, MidpointRounding.AwayFromZero)}\n";
        }

        public static float CheckRadius()
        {
            Console.WriteLine("Please enter radius value.");
            string uservalue = Console.ReadLine();
            float.TryParse(uservalue, out float value);
            while (value <= 0)
            {
                Console.WriteLine($"Your value is uncorrect. It should be greater then 0. Please, try once again.");
                uservalue = Console.ReadLine();
                float.TryParse(uservalue, out value);
            }
            return value;
        }
    }
}
