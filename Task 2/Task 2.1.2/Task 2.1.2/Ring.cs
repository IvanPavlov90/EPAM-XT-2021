using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1._2
{
    public class Ring : Circle
    {
        public Ring(float pointX, float pointY, float radius, float innerRadius) : base(pointX, pointY, radius)
        {
            StartpointX = pointX;
            StartpointY = pointY;
            Radius = radius;
            InnerRadius = innerRadius;
        }

        private float _innerRadius;
        public float InnerRadius
        {
            get => _innerRadius;
            set => _innerRadius = value;
        }

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

        public static float CheckInnerRadius(float checkvalue)
        {
            Console.WriteLine("Please enter innerradius value.");
            string uservalue = Console.ReadLine();
            float.TryParse(uservalue, out float value);
            while (value >= checkvalue)
            {
                Console.WriteLine($"Your value is uncorrect. It should be less then {checkvalue}. Please, try once again.");
                uservalue = Console.ReadLine();
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
