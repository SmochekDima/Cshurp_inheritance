using System;
namespace pr
{
    abstract class GeometricFigure
    {
        public abstract double GetArea();
        public abstract double GetPerimeter();
    }

    class Triangle : GeometricFigure
    {
        private double a, b, c, height;

        public Triangle(double a, double b, double c, double height)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.height = height;
        }

        public override double GetArea()
        {
            return a * height / 2;
        }

        public override double GetPerimeter()
        {
            return a + b + c;
        }
    }
    class Square : GeometricFigure
    {
        private double side;

        public Square(double side)
        {
            this.side = side;
        }

        public override double GetArea()
        {
            return side * side;
        }

        public override double GetPerimeter()
        {
            return side * 4;
        }
    }

    class Rhombus : GeometricFigure
    {
        private double side, height;

        public Rhombus(double side, double height)
        {
            this.side = side;
            this.height = height;
        }

        public override double GetArea()
        {
            return side * height;
        }

        public override double GetPerimeter()
        {
            return side * 4;
        }
    }


    class Rectangle : GeometricFigure
    {
        private double width, height;

        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public override double GetArea()
        {
            return width * height;
        }

        public override double GetPerimeter()
        {
            return 2 * (width + height);
        }
    }
    
    class Parallelogram : GeometricFigure
    {
        private double a, b, height;

        public Parallelogram(double a, double b, double height)
        {
            this.a = a;
            this.b = b;
            this.height = height;
        }

        public override double GetArea()
        {
            return a * height;
        }

        public override double GetPerimeter()
        {
            return 2 * (a + b);
        }
    }

    class Trapezoid : GeometricFigure
    {
        private double a, b, c, d, height;

        public Trapezoid(double a, double b, double c, double d, double height)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
            this.height = height;
        }

        public override double GetArea()
        {
            return (a + b) * height / 2;
        }

        public override double GetPerimeter()
        {
            return a + b + c + d;
        }
    }

    class Circle : GeometricFigure
    {
        private double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public override double GetArea()
        {
            return Math.PI * radius * radius;
        }

        public override double GetPerimeter()
        {
            return 2 * Math.PI * radius;
        }
    }

    class Ellipse : GeometricFigure
    {
        private double a, b;

        public Ellipse(double a, double b)
        {
            this.a = a;
            this.b = b;
        }

        public override double GetArea()
        {
            return Math.PI * a * b;
        }

        public override double GetPerimeter()
        {
            double h = Math.Pow(a - b, 2) / Math.Pow(a + b, 2);

            return Math.PI * (a + b) *
                   (1 + 3 * h / (10 + Math.Sqrt(4 - 3 * h)));
        }
    }

    class CompositeFigure
    {
        private GeometricFigure[] figures;

        public CompositeFigure(params GeometricFigure[] figures)
        {
            this.figures = figures;
        }

        public double GetArea()
        {
            double sum = 0;

            foreach (GeometricFigure figure in figures)
            {
                sum += figure.GetArea();
            }

            return sum;
        }

        public double GetPerimeter()
        {
            double sum = 0;

            foreach (GeometricFigure figure in figures)
            {
                sum += figure.GetPerimeter();
            }

            return sum;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Triangle triangle = new Triangle(3, 4, 5, 4);
            Square square = new Square(5);
            Rhombus rhombus = new Rhombus(4, 3);
            Rectangle rectangle = new Rectangle(6, 3);
            Parallelogram parallelogram = new Parallelogram(5, 4, 3);
            Trapezoid trapezoid = new Trapezoid(6, 4, 3, 3, 2);
            Circle circle = new Circle(5);
            Ellipse ellipse = new Ellipse(5, 3);

            Console.WriteLine("Triangle area: " + triangle.GetArea());
            Console.WriteLine("Triangle perimeter: " + triangle.GetPerimeter());

            Console.WriteLine("\nSquare area: " + square.GetArea());
            Console.WriteLine("Square perimeter: " + square.GetPerimeter());

            Console.WriteLine("\nCircle area: " + circle.GetArea());
            Console.WriteLine("Circle perimeter: " + circle.GetPerimeter());

            CompositeFigure composite = new CompositeFigure(
                triangle,
                square,
                rhombus,
                rectangle,
                parallelogram,
                trapezoid,
                circle,
                ellipse
            );

            Console.WriteLine("\nComposite figure:");
            Console.WriteLine("Total area: " + composite.GetArea());
            Console.WriteLine("Total perimeter: " + composite.GetPerimeter());
        }
    }
}
