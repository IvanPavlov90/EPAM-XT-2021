using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1._2
{
    public class Line : OpenFigures
    {
        public Line(float pointX, float pointY, float endpointX, float endpointY)
        {
            StartpointX = pointX;
            StartpointY = pointY;
            EndlinepointX = endpointX;
            EndlinepointY = endpointY;
        }
        public override double Length
        {
            get
            {
                float width;
                float heigth;

                width = Math.Abs(EndlinepointX - StartpointX);
                heigth = Math.Abs(EndlinepointY - StartpointY);

                return Math.Sqrt(width * width + heigth * heigth);
            }
        }

        public override string ToString()
        {
            return $"Line.\n" +
                   $"Coordinats of the beginnig of line - (x:, y:) {StartpointX} {StartpointY},\n" +
                   $"Coordinats of the end of line - (x:, y:) {EndlinepointX} {EndlinepointY},\n" +
                   $"length - {Math.Round(Length, 2, MidpointRounding.AwayFromZero)}\n";
        }
    }
}
