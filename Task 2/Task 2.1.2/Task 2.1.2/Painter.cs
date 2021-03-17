using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1._2
{
    public static class Painter
    {
        public static Circle CreateCircle(float pointX, float pointY, float radius)
        {
            Circle circle = new Circle(pointX, pointY, radius);
            Console.WriteLine("Circle has been created.");
            return circle;
        }

        public static Ring CreateRing(float pointX, float pointY, float radius)
        {
            float innerRadius = Ring.CheckInnerRadius(radius);
            Ring ring = new Ring(pointX, pointY, radius, innerRadius);
            Console.WriteLine("Ring has been created.");
            return ring;
        }

        public static Triangle CreateTriangle(float pointX, float pointY, float sideA, float sideB)
        {
            float sideC = Triangle.IsTriangleValid(sideA, sideB);
            Triangle triangle = new Triangle(pointX, pointY, sideA, sideB, sideC);
            Console.WriteLine("Trinagle has been created.");
            return triangle;
        }

        public static Cylinder CreateCylinder(float pointX, float pointY, float radius, float height)
        {
            Cylinder cylinder  = new Cylinder(pointX, pointY, radius, height);
            Console.WriteLine("Cylinder has been created.");
            return cylinder;
        }

        public static Sphere CreateSphere(float pointX, float pointY, float radius)
        {
            Sphere sphere = new Sphere(pointX, pointY, radius);
            Console.WriteLine("Sphere has been created.");
            return sphere;
        }

        public static Line CreateLine(float pointX, float pointY, float endpointX, float endpointY)
        {
            Line line = new Line(pointX, pointY, endpointX, endpointY);
            Console.WriteLine("Line has been created.");
            return line;
        }

        public static Rectangle CreateRectangle(float pointX, float pointY, float width, float height)
        {
            Rectangle rectangle = new Rectangle(pointX, pointY, width, height);
            Console.WriteLine("Rectangle has been created.");
            return rectangle;
        }

        public static Square CreateSquare(float pointX, float pointY, float width)
        {
            Square square = new Square (pointX, pointY, width);
            Console.WriteLine("Square has been created.");
            return square;
        }
    }
}
