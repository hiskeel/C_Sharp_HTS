using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20_01_HT
{
    abstract class GeometricFigure
    {
        public abstract double GetArea();
        public abstract double GetPerimeter();
    }

    class Triangle : GeometricFigure
    {
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }

        public Triangle(double a, double b, double c)
        {
            SideA = a;
            SideB = b;
            SideC = c;
        }

        public override double GetArea()
        {
            double s = (SideA + SideB + SideC) / 2;
            return Math.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC));
        }

        public override double GetPerimeter()
        {
            return SideA + SideB + SideC;
        }
    }

    class Square : GeometricFigure
    {
        public double Side { get; set; }

        public Square(double side)
        {
            Side = side;
        }

        public override double GetArea()
        {
            return Side * Side;
        }

        public override double GetPerimeter()
        {
            return 4 * Side;
        }
    }

    class Rhombus : GeometricFigure
    {
        public double Diagonal1 { get; set; }
        public double Diagonal2 { get; set; }
        public double Side { get; set; }

        public Rhombus(double diagonal1, double diagonal2, double side)
        {
            Diagonal1 = diagonal1;
            Diagonal2 = diagonal2;
            Side = side;
        }

        public override double GetArea()
        {
            return (Diagonal1 * Diagonal2) / 2;
        }

        public override double GetPerimeter()
        {
            return 4 * Side;
        }
    }

    class Rectangle : GeometricFigure
    {
        public double Length { get; set; }
        public double Width { get; set; }

        public Rectangle(double length, double width)
        {
            Length = length;
            Width = width;
        }

        public override double GetArea()
        {
            return Length * Width;
        }

        public override double GetPerimeter()
        {
            return 2 * (Length + Width);
        }
    }

    class Parallelogram : GeometricFigure
    {
        public double Base { get; set; }
        public double Height { get; set; }
        public double Side { get; set; }

        public Parallelogram(double @base, double height, double side)
        {
            Base = @base;
            Height = height;
            Side = side;
        }

        public override double GetArea()
        {
            return Base * Height;
        }

        public override double GetPerimeter()
        {
            return 2 * (Base + Side);
        }
    }

    class Trapezoid : GeometricFigure
    {
        public double Base1 { get; set; }
        public double Base2 { get; set; }
        public double Height { get; set; }
        public double Side1 { get; set; }
        public double Side2 { get; set; }

        public Trapezoid(double base1, double base2, double height, double side1, double side2)
        {
            Base1 = base1;
            Base2 = base2;
            Height = height;
            Side1 = side1;
            Side2 = side2;
        }

        public override double GetArea()
        {
            return ((Base1 + Base2) / 2) * Height;
        }

        public override double GetPerimeter()
        {
            return Base1 + Base2 + Side1 + Side2;
        }
    }

    class Circle : GeometricFigure
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override double GetArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        public override double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }
    }

    class Ellipse : GeometricFigure
    {
        public double MajorAxis { get; set; }
        public double MinorAxis { get; set; }

        public Ellipse(double majorAxis, double minorAxis)
        {
            MajorAxis = majorAxis;
            MinorAxis = minorAxis;
        }

        public override double GetArea()
        {
            return Math.PI * MajorAxis * MinorAxis;
        }

        public override double GetPerimeter()
        {
            
            double h = Math.Pow(MajorAxis - MinorAxis, 2) / Math.Pow(MajorAxis + MinorAxis, 2);
            return Math.PI * (MajorAxis + MinorAxis) * (1 + (3 * h) / (10 + Math.Sqrt(4 - 3 * h)));
        }
    }

    class CompositeFigure : GeometricFigure
    {
        private readonly GeometricFigure[] figures;

        public CompositeFigure(params GeometricFigure[] figures)
        {
            this.figures = figures;
        }

        public override double GetArea()
        {
            double area = 0;
            foreach (var figure in figures)
            {
                area += figure.GetArea();
            }
            return area;
        }

        public override double GetPerimeter()
        {
            double perimeter = 0;
            foreach (var figure in figures)
            {
                perimeter += figure.GetPerimeter();
            }
            return perimeter;
        }
    }

    class Program
    {
        static void Main()
        {
            
            Triangle triangle = new Triangle(3, 4, 5);
            Square square = new Square(4);
            Rhombus rhombus = new Rhombus(6, 8, 5);
            Rectangle rectangle = new Rectangle(4, 6);
            Parallelogram parallelogram = new Parallelogram(5, 7, 6);
            Trapezoid trapezoid = new Trapezoid(4, 6, 5, 3, 4);
            Circle circle = new Circle(3);
            Ellipse ellipse = new Ellipse(8, 5);

            Console.WriteLine("Triangle - Area: " + triangle.GetArea() + ", Perimeter: " + triangle.GetPerimeter());
            Console.WriteLine("Square - Area: " + square.GetArea() + ", Perimeter: " + square.GetPerimeter());
            Console.WriteLine("Rhombus - Area: " + rhombus.GetArea() + ", Perimeter: " + rhombus.GetPerimeter());
            Console.WriteLine("Rectangle - Area: " + rectangle.GetArea() + ", Perimeter: " + rectangle.GetPerimeter());
            Console.WriteLine("Parallelogram - Area: " + parallelogram.GetArea() + ", Perimeter: " + parallelogram.GetPerimeter());
            Console.WriteLine("Trapezoid - Area: " + trapezoid.GetArea() + ", Perimeter: " + trapezoid.GetPerimeter());
            Console.WriteLine("Circle - Area: " + circle.GetArea() + ", Perimeter: " + circle.GetPerimeter());
            Console.WriteLine("Ellipse - Area: " + ellipse.GetArea() + ", Perimeter: " + ellipse.GetPerimeter());

            CompositeFigure compositeFigure = new CompositeFigure(triangle, square, circle);
            Console.WriteLine("Composite Figure - Area: " + compositeFigure.GetArea() + ", Perimeter: " + compositeFigure.GetPerimeter());
        }
    }
}
