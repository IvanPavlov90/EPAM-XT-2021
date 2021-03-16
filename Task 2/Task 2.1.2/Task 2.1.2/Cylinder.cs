using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1._2
{
    public class Cylinder : VolumeFigures
    {
        public Cylinder(float pointX, float pointY, float radius, float height)
        {
            StartpointX = pointX;
            StartpointY = pointY;
            Radius = radius;
            Height = height;
        }

        private float _radius;
        public float Radius
        {
            get => _radius;
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Your value is uncorrect, cylinder radius should be greater then 0.");
                    value = Validator.CheckIfValueMoreThanVerificationValue(0);
                    _radius = value;
                }
                else
                {
                    _radius = value;
                }
            }
        }

        private float _height;

        public float Height
        {
            get => _height;
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Your value is uncorrect, cylinder height should be greater then 0.");
                    value = Validator.CheckIfValueMoreThanVerificationValue(0);
                    _height = value;
                }
                else
                {
                    _height = value;
                }
            }
        }

        public override double Area
        {
            get
            {
                return 2 * Math.PI * Radius * (Height + Radius);
            }
        }

        public override double Volume
        {
            get
            {
                return Math.PI * Radius * Radius * Height;
            }
        }

        public override string ToString()
        {
            return $"Cylinder.\n" +
                   $"Radius - {Radius}\n" +
                   $"Height - {Height}\n" +
                   $"Area - {Math.Round(Area, 2, MidpointRounding.AwayFromZero)}\n" +
                   $"Volume - {Math.Round(Volume, 2, MidpointRounding.AwayFromZero)}\n";
        }
    }
}
