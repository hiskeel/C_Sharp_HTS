namespace _18_01_HT
{
    

    class Program
    {
        class Square
        {
            public double A { get; set; }

            public Square() { }

            public Square(double a)
            {
                A = a;
            }

            public static Square operator ++(Square square)
            {
                square.A++;
                return square;
            }

            public static Square operator --(Square square)
            {
                if (square.A > 0)
                    square.A--;
                return square;
            }

            public static Square operator +(Square square, double value)
            {
                if (value >= 0)
                    square.A += value;
                return square;
            }

            public static Square operator -(Square square, double value)
            {
                if (value >= 0)
                    square.A -= value;
                return square;
            }

            public static Square operator *(Square square, double value)
            {
                if (value >= 0)
                    square.A *= value;
                return square;
            }

            public static Square operator /(Square square, double value)
            {
                if (value > 0)
                    square.A /= value;
                return square;
            }

            public static bool operator <(Square square1, Square square2)
            {
                return square1.A < square2.A;
            }

            public static bool operator >(Square square1, Square square2)
            {
                return square1.A > square2.A;
            }

            public static bool operator <=(Square square1, Square square2)
            {
                return square1.A <= square2.A;
            }

            public static bool operator >=(Square square1, Square square2)
            {
                return square1.A >= square2.A;
            }

            public static bool operator ==(Square square1, Square square2)
            {
                if (ReferenceEquals(square1, square2))
                    return true;
                if (square1 is null || square2 is null)
                    return false;
                return square1.A == square2.A;
            }

            public static bool operator !=(Square square1, Square square2)
            {
                return !(square1 == square2);
            }

            public static bool operator true(Square square)
            {
                return square.A != 0;
            }

            public static bool operator false(Square square)
            {
                return square.A == 0;
            }

            public static implicit operator Rectangle(Square square)
            {
                return new Rectangle(square.A, square.A);
            }

            public static implicit operator int(Square square)
            {
                return (int)square.A;
            }

            public override string ToString()
            {
                return $"Side A: {A}";
            }
        }

        class Rectangle
        {
            public double A { get; set; }
            public double B { get; set; }

            public Rectangle() { }

            public Rectangle(double a, double b)
            {
                A = a;
                B = b;
            }

            public static Rectangle operator ++(Rectangle rectangle)
            {
                rectangle.A++;
                rectangle.B++;
                return rectangle;
            }

            public static Rectangle operator --(Rectangle rectangle)
            {
                if (rectangle.A > 0 && rectangle.B > 0)
                {
                    rectangle.A--;
                    rectangle.B--;
                }
                return rectangle;
            }

            public static Rectangle operator +(Rectangle rectangle, double value)
            {
                if (value >= 0)
                {
                    rectangle.A += value;
                    rectangle.B += value;
                }
                return rectangle;
            }

            public static Rectangle operator -(Rectangle rectangle, double value)
            {
                if (value >= 0)
                {
                    rectangle.A -= value;
                    rectangle.B -= value;
                }
                return rectangle;
            }

            public static Rectangle operator *(Rectangle rectangle, double value)
            {
                if (value >= 0)
                {
                    rectangle.A *= value;
                    rectangle.B *= value;
                }
                return rectangle;
            }

            public static Rectangle operator /(Rectangle rectangle, double value)
            {
                if (value > 0)
                {
                    rectangle.A /= value;
                    rectangle.B /= value;
                }
                return rectangle;
            }

            public static bool operator <(Rectangle rectangle1, Rectangle rectangle2)
            {
                return rectangle1.A * rectangle1.B < rectangle2.A * rectangle2.B;
            }

            public static bool operator >(Rectangle rectangle1, Rectangle rectangle2)
            {
                return rectangle1.A * rectangle1.B > rectangle2.A * rectangle2.B;
            }

            public static bool operator <=(Rectangle rectangle1, Rectangle rectangle2)
            {
                return rectangle1.A * rectangle1.B <= rectangle2.A * rectangle2.B;
            }

            public static bool operator >=(Rectangle rectangle1, Rectangle rectangle2)
            {
                return rectangle1.A * rectangle1.B >= rectangle2.A * rectangle2.B;
            }

            public static bool operator ==(Rectangle rectangle1, Rectangle rectangle2)
            {
                if (ReferenceEquals(rectangle1, rectangle2))
                    return true;
                if (rectangle1 is null || rectangle2 is null)
                    return false;
                return rectangle1.A == rectangle2.A && rectangle1.B == rectangle2.B;
            }

            public static bool operator !=(Rectangle rectangle1, Rectangle rectangle2)
            {
                return !(rectangle1 == rectangle2);
            }

            public static bool operator true(Rectangle rectangle)
            {
                return rectangle.A != 0 && rectangle.B != 0;
            }

            public static bool operator false(Rectangle rectangle)
            {
                return rectangle.A == 0 || rectangle.B == 0;
            }

            public static explicit operator Square(Rectangle rectangle)
            {
                if (rectangle.A != rectangle.B)
                {
                    throw new InvalidCastException("Cannot convert non-square rectangle to square.");
                }
                return new Square(rectangle.A);
            }

            public static explicit operator int(Rectangle rectangle)
            {
                return (int)(rectangle.A * rectangle.B);
            }

            public override string ToString()
            {
                return $"Side A: {A}, Side B: {B}";
            }
        }
        static void Main()
        {
            Square square = new Square(5);
            Rectangle rectangle = new Rectangle(4, 6);

            Console.WriteLine("Square: " + square);
            Console.WriteLine("Rectangle: " + rectangle);

            Console.WriteLine("++square: " + ++square);
            Console.WriteLine("--square: " + --square);

            Console.WriteLine("rectangle + 2: " + (rectangle + 2));
            Console.WriteLine("rectangle - 2: " + (rectangle - 2));
            Console.WriteLine("rectangle * 2: " + (rectangle * 2));
            Console.WriteLine("rectangle / 2: " + (rectangle / 2));

            Console.WriteLine("square < rectangle: " + (square < rectangle));
            Console.WriteLine("square > rectangle: " + (square > rectangle));
            Console.WriteLine("square <= rectangle: " + (square <= rectangle));
            Console.WriteLine("square >= rectangle: " + (square >= rectangle));
            Console.WriteLine("square == rectangle: " + (square == rectangle));
            Console.WriteLine("square != rectangle: " + (square != rectangle));

            Console.WriteLine("Is square true? " + (square ? "Yes" : "No"));
            Console.WriteLine("Is rectangle false? " + (rectangle ? "Yes" : "No"));
            try
            {
                //Square squareFromRectangle = (Square)rectangle;
                //Console.WriteLine("Square created from rectangle: " + squareFromRectangle);

                Rectangle rectangleFromSquare = (Rectangle)square;
                Console.WriteLine("Rectangle created from square: " + rectangleFromSquare);

                int areaOfSquare = (int)square;
                Console.WriteLine("Area of square (int): " + areaOfSquare);

                int areaOfRectangle = (int)rectangle;
                Console.WriteLine("Area of rectangle (int): " + areaOfRectangle);
            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }
        }
    }


}