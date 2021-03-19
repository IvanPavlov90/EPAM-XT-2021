using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1._2
{
    public class Sphere : VolumeFigures, IVolume
    {
        public Sphere(float pointX, float pointY, float radius)
        {
            StartpointX = pointX;
            StartpointY = pointY;
            Radius = CheckRadius(radius);
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
                return 4 * Math.PI * Radius * Radius;
            }
        }

        public override double Volume
        {
            get
            {
                return (4 * Math.PI * Radius * Radius * Radius) / 3;
            }
        }

        public static float CheckRadius(float value)
        {
            while (value <= 0)
            {
                Console.WriteLine($"Your value is uncorrect. It should be greater then 0. Please, try once again.");
                string uservalue = Console.ReadLine();
                float.TryParse(uservalue, out value);
            }
            return value;
        }

        public override string ToString()
        {
            return $"Sphere.\n" +
                   $"Coordinats of the sphere's center - (x:, y:) {StartpointX} {StartpointY}\n" +
                   $"radius - {Radius}\n" +
                   $"area - {Math.Round(Area, 2, MidpointRounding.AwayFromZero)}\n" +
                   $"volume - {Math.Round(Volume, 2, MidpointRounding.AwayFromZero)}\n";
        }
    }
}
