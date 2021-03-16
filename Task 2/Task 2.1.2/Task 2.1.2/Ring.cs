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
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Your value is uncorrect, inner radius should be greater then 0.");
                    value = Validator.CheckIfValueMoreThanVerificationValue(0);
                    if (value > Radius)
                    {
                        Console.WriteLine("This is uncorrect. Inner radius shoudn't be greater then outer. It will be set as default Radius/2");
                        value = Radius/2;
                        _innerRadius = value;
                    }
                    else
                    {
                        _innerRadius = value;
                    }
                }
                else if (value > Radius)
                {
                    Console.WriteLine("This is uncorrect. Inner radius shoudn't be greater then outer. It will be set as default Radius/2");
                    value = Radius/2;
                    _innerRadius = value;
                }
                else
                {
                    _innerRadius = value;
                }
            }
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

        public override string ToString()
        {
            return $"Кольцо.\n" +
                   $"Координаты центра кольца - {StartpointX} и {StartpointY},\n" +
                   $"внешний радиус кольца - {Radius},\n" +
                   $"внутренний радиус кольца - {InnerRadius},\n" +
                   $"площадь кольца - {Math.Round(Area, 2, MidpointRounding.AwayFromZero)},\n" +
                   $"суммарная длина внешней и внутренней окружностей - {Math.Round(Perimeter, 2, MidpointRounding.AwayFromZero)}";
        }
    }
}
