using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1._2
{
    public abstract class Figure
    {
        public float StartpointX { get; set; }

        public float StartpointY { get; set; }
    }

    public abstract class OpenFigures : Figure
    {
        public float EndlinepointX { get; set; }

        public float EndlinepointY { get; set; }

        public abstract double Length { get; }
    }

    public abstract class ClosedFigures : Figure
    {
        public abstract double Area { get; }
    }

    public abstract class VolumeFigures : ClosedFigures, IVolume
    {
        public abstract double Volume { get; }
    }

    abstract public class FlatFigures : ClosedFigures
    {
        public abstract double Perimeter { get; }
    }
}
