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
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Your value is uncorrect, side should be greater then 0.");
                    value = Validator.CheckIfValueMoreThanVerificationValue(0);
                    _sideA = value;
                }
                else
                {
                    _sideA = value;
                }
            }
        }

        private float _sideB;

        public float SideB
        {
            get => _sideB;
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Your value is uncorrect, side should be greater then 0.");
                    value = Validator.CheckIfValueMoreThanVerificationValue(0);
                    _sideB = value;
                }
                else
                {
                    _sideB = value;
                }
            }
        }

        private float _sideC;

        public float SideC
        {
            get => _sideC;
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Your value is uncorrect, side should be greater then 0.");
                    value = Validator.CheckIfValueMoreThanVerificationValue(0);
                    if (value > SideA + SideB)
                    {
                        value = Math.Abs(SideA + SideB - 1);
                        Console.WriteLine("Your value is greater than sum of lines A and B. It can't be. " +
                                          "That's why SideC = SideA + SideB - 1");
                        _sideC = value;
                    }
                    else if (value > SideA && value < SideB)
                    {
                        if (SideB > SideA + value)
                        {
                            value = Math.Abs(SideB - SideA + 1);
                            Console.WriteLine("Sum of the line B of triangle is greater than sum of line A and your value. " +
                                              "That's why your value will be set on SideC = SideB -  SideA + 1");
                            _sideC = value;
                        }
                        else
                        {
                            _sideC = value;
                        }
                    }
                    else if (value > SideB && value < SideA)
                    {
                        if (SideA > SideB + value)
                        {
                            value = Math.Abs(SideA - SideB + 1);
                            Console.WriteLine("Sum of the line A of triangle is greater than sum of line B and your value. " +
                                              "That's why your value will be set on SideC = SideA -  SideB + 1");
                            _sideC = value;
                        }
                        else
                        {
                            _sideC = value;
                        }
                    }
                    else if (value < SideB && value < SideA)
                    {
                        if (SideA + value < SideB)
                        {
                            value = Math.Abs(SideB - SideA + 1);
                            Console.WriteLine("Sum of the line B of triangle is greater than sum of line A and your value. " +
                                              "That's why your value will be set on SideC = SideB -  SideA + 1");
                            _sideC = value;
                        }
                        else if (SideB + value < SideA)
                        {
                            value = Math.Abs(SideA - SideB + 1);
                            Console.WriteLine("Sum of the line A of triangle is greater than sum of line B and your value. " +
                                              "That's why your value will be set on SideC = SideA -  SideB + 1");
                            _sideC = value;
                        }
                        else
                        {
                            _sideC = value;
                        }
                    }
                }
                else
                {
                    if (value > SideA + SideB)
                    {
                        value = Math.Abs(SideA + SideB - 1);
                        Console.WriteLine("Your value is greater than sum of lines A and B. It can't be. " +
                                          "That's why SideC = SideA + SideB - 1");
                        _sideC = value;
                    }
                    else if (value > SideA && value < SideB)
                    {
                        if (SideB > SideA + value)
                        {
                            value = Math.Abs(SideB - SideA + 1);
                            Console.WriteLine("Sum of the line B of triangle is greater than sum of line A and your value. " +
                                              "That's why your value will be set on SideC = SideB -  SideA + 1");
                            _sideC = value;
                        }
                        else
                        {
                            _sideC = value;
                        }
                    }
                    else if (value > SideB && value < SideA)
                    {
                        if (SideA > SideB + value)
                        {
                            value = Math.Abs(SideA - SideB + 1);
                            Console.WriteLine("Sum of the line A of triangle is greater than sum of line B and your value. " +
                                              "That's why your value will be set on SideC = SideA -  SideB + 1");
                            _sideC = value;
                        }
                        else
                        {
                            _sideC = value;
                        }
                    }
                    else if (value < SideB && value < SideA)
                    {
                        if (SideA + value < SideB)
                        {
                            value = Math.Abs(SideB - SideA + 1);
                            Console.WriteLine("Sum of the line B of triangle is greater than sum of line A and your value. " +
                                              "That's why your value will be set on SideC = SideB -  SideA + 1");
                            _sideC = value;
                        }
                        else if (SideB + value < SideA)
                        {
                            value = Math.Abs(SideA - SideB + 1);
                            Console.WriteLine("Sum of the line A of triangle is greater than sum of line B and your value. " +
                                              "That's why your value will be set on SideC = SideA -  SideB + 1");
                            _sideC = value;
                        }
                        else
                        {
                            _sideC = value;
                        }
                    }
                }
            }   
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

        public override string ToString()
        {
            return $"Triangle.\n" +
                   $"Triangle's sides - (А:, В:, С:) {SideA}, {SideB}, {SideC},\n" +
                   $"area - {Math.Round(Area, 2, MidpointRounding.AwayFromZero)}\n" +
                   $"perimeter - {Math.Round(Perimeter, 2, MidpointRounding.AwayFromZero)}\n";
        }
    }
}
