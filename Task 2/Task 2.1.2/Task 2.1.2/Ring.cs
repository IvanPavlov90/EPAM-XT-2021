using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1._2
{
    public class Ring : Circle
    {
        public Ring(float pointX, float pointY, float radius, float innerRadius) : base(pointX, pointY, radius)
        {
            InnerRadius = CheckInnerRadius(innerRadius, Radius);
        }

        public float InnerRadius { get; set; }

        public override double Area
        {
            get
            {
                return Math.PI * (Radius * Radius - InnerRadius * InnerRadius);
            }
        }

        public override double Perimeter
        {
            get
            {
                return 2 * Math.PI * (Radius + InnerRadius);
            }
        }

        public static float CheckInnerRadius(float value, float checkvalue)
        {
            while (value >= checkvalue || value <= 0)
            {
                Console.WriteLine($"Your innerradius value is uncorrect. It should be less then {checkvalue} and greater then 0. Please, try once again.");
                string uservalue = Console.ReadLine();
                float.TryParse(uservalue, out value);
            }
            return value;
        }

        public override string ToString()
        {
            return $"Ring.\n" +
                   $"Coordinats of the center of the ring- {StartpointX} и {StartpointY},\n" +
                   $"outer radius - {Radius},\n" +
                   $"inner radius - {InnerRadius},\n" +
                   $"area - {Math.Round(Area, 2, MidpointRounding.AwayFromZero)},\n" +
                   $"sum of outer and inner lengths - {Math.Round(Perimeter, 2, MidpointRounding.AwayFromZero)}\n";
        }
    }
}
