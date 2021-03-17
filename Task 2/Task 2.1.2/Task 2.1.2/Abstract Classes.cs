using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1._2
{
    public abstract class Figure
    {
        private float _startpointX;

        public float StartpointX
        {
            get => _startpointX;
            set => _startpointX = value;
        }

        private float _startpointY;

        public float StartpointY
        {
            get => _startpointY;
            set => _startpointY = value;
        }
    }
    public abstract class OpenFigures : Figure
    {
        private float _endlinepointX;

        public float EndlinepointX
        {
            get => _endlinepointX;
            set => _endlinepointX = value;
        }

        private float _endlinepointY;

        public float EndlinepointY
        {
            get => _endlinepointY;
            set => _endlinepointY = value;
        }
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
