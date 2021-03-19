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
            SideA = CheckSide(sideA);
            SideB = CheckSide(sideB);
            SideC = IsTriangleValid(SideA, SideB, sideC);
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

        public static float IsTriangleValid (float sideA, float sideB, float sideC)
        {
            while (sideC >= sideA + sideB || sideA >= sideC + sideB || sideB >= sideC + sideA)
            {
                Console.WriteLine($"Your value is uncorrect. Please, try once again. Sum of the smallest sides should be greater then the biggest one.");
                string uservalue = Console.ReadLine();
                float.TryParse(uservalue, out sideC);
            }
            return sideC;
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
