using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1._2
{
    public class Sphere : VolumeFigures
    {
        public Sphere(float pointX, float pointY, float radius)
        {
            StartpointX = pointX;
            StartpointY = pointY;
            Radius = radius;
        }

        private float _radius;
        public float Radius
        {
            get => _radius;
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Your value is uncorrect, sphere's radius should be greater then 0.");
                    value = Validator.CheckIfValueMoreThanVerificationValue(0);
                    _radius = value;
                }
                else
                {
                    _radius = value;
                }
            }
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
