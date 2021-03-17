using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1._2
{
    public class Triangle : FlatFigures
    {
        public Triangle(float pointX, float pointY, float sideA, float sideB, float sideC)
        {
            StartpointX = pointX;
            StartpointY = pointY;
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        private float _sideA;

        public float SideA
        {
            get => _sideA;
            set => _sideA = value;
        }

        private float _sideB;

        public float SideB
        {
            get => _sideB;
            set => _sideB = value;
        }

        private float _sideC;

        public float SideC
        {
            get => _sideC;
            set => _sideC = value;
        }

        public override double Area
        {
            get
            {
                float p = (SideA + SideB + SideC) / 2;
                return Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
            }
        }

        public override double Perimeter
        {
            get
            {
                return SideA + SideB + SideC;
            }
        }

        public static float CheckSide()
        {
            Console.WriteLine("Please enter side value.");
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

        public static float IsTriangleValid (float sideA, float sideB)
        {
            Console.WriteLine("Please enter side value.");
            string uservalue = Console.ReadLine();
            float.TryParse(uservalue, out float value);
            while (value >= sideA + sideB || sideA >= value + sideB || sideB >= value + sideA)
            {
                Console.WriteLine($"Your value is uncorrect. Please, try once again.");
                uservalue = Console.ReadLine();
                float.TryParse(uservalue, out value);
            }
            return value;
        }

        public override string ToString()
        {
            return $"Triangle.\n" +
                   $"Triangle's sides - (А:, В:, С:) {SideA}, {SideB}, {SideC},\n" +
                   $"area - {Math.Round(Area, 2, MidpointRounding.AwayFromZero)}\n" +
                   $"perimeter - {Math.Round(Perimeter, 2, MidpointRounding.AwayFromZero)}\n";
        }
    }
}
