using ShapesTask;

namespace ShapesTask
{
    public interface IShape
    {
        double GetWidth();
        double GetHeight();
        double GetArea();
        double GetPerimeter();
    }

    class ShareAreaComparer : IComparer<IShape>
    {
        public int Compare(IShape? s1, IShape? s2)
        {
            if (s1 is null || s2 is null)
                throw new ArgumentException("Некорректное значение параметра");
            return (int)s2.GetArea() - (int)s1.GetArea();
        }
    }

    class SharePerimeterComparer : IComparer<IShape>
    {
        public int Compare(IShape? s1, IShape? s2)
        {
            if (s1 is null || s2 is null)
                throw new ArgumentException("Некорректное значение параметра");
            return (int)s2.GetPerimeter() - (int)s1.GetPerimeter();
        }
    }

    public class Square : IShape
    {
        public double SideLength { get; set; }

        public override int GetHashCode()
        {
            return (int)SideLength;
        }

        public override bool Equals(object? o)
        {
            if (ReferenceEquals(o, this)) return true;
            if (ReferenceEquals(o, null) || o.GetType() != GetType()) return false;
            Square p = (Square)o;
            return SideLength == p.SideLength;
        }

        public override string ToString()
        {
            return $"Квадрат со стороной {SideLength}";
        }


        public Square(double sideLength)
        {
            SideLength = sideLength;
        }

        public double GetWidth()
        {
            return SideLength;
        }

        public double GetHeight()
        {
            return SideLength;
        }

        public double GetArea()
        {
            return SideLength * SideLength;
        }

        public double GetPerimeter()
        {
            return SideLength * 4;
        }
    }

    public class Triangle : IShape
    {
        public double x1 { get; set; }
        public double x2 { get; set; }
        public double x3 { get; set; }
        public double y1 { get; set; }
        public double y2 { get; set; }
        public double y3 { get; set; }

        public override int GetHashCode()
        {
            return (int)(x1 + x2 + x3 + y1 + y2 + y3);
        }

        public override bool Equals(object? o)
        {
            if (ReferenceEquals(o, this)) return true;
            if (ReferenceEquals(o, null) || o.GetType() != GetType()) return false;
            Triangle p = (Triangle)o;
            return x1 == p.x1 && x2 == p.x2 && x3 == p.x3 && y1 == p.y1 && y2 == p.y2 && y3 == p.y3;
        }

        public override string ToString()
        {
            return $"Треугольник с координатами ({x1}, {y1}), ({x2}, {y2}), ({x3}, {y3})";
        }

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            this.x1 = x1;
            this.x2 = x2;
            this.x3 = x3;
            this.y1 = y1;
            this.y2 = y2;
            this.y3 = y3;
        }

        public double GetWidth()
        {
            double maxX = Math.Max(x1, x2);

            if (maxX < x3)
            {
                maxX = x3;
            }

            double minX = Math.Min(x1, x2);

            if (minX > x3)
            {
                minX = x3;
            }

            return maxX - minX;
        }

        public double GetHeight()
        {
            double maxY = Math.Max(y1, y2);

            if (maxY < y3)
            {
                maxY = y3;
            }

            double minY = Math.Min(y1, y2);

            if (minY > y3)
            {
                minY = y3;
            }

            return maxY - minY;
        }

        public double GetArea()
        {
            return Math.Abs((x2 - x1) * (y3 - y1) - (x3 - x1) * (y2 - y1)) / 2;
        }

        public double GetPerimeter()
        {
            double side12 = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            double side23 = Math.Sqrt(Math.Pow(x3 - x2, 2) + Math.Pow(y3 - y2, 2));
            double side31 = Math.Sqrt(Math.Pow(x1 - x3, 2) + Math.Pow(y1 - y3, 2));

            return side12 + side23 + side31;
        }
    }

    public class Rectangle : IShape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public override int GetHashCode()
        {
            return (int)(Height + Width);
        }

        public override bool Equals(object? o)
        {
            if (ReferenceEquals(o, this)) return true;
            if (ReferenceEquals(o, null) || o.GetType() != GetType()) return false;
            Rectangle p = (Rectangle)o;
            return Height == p.Height && Width == p.Width;
        }

        public override string ToString()
        {
            return $"Прямоугольник со сторонами {Width} и {Height}";
        }

        public Rectangle(double width, double height)
        {
            Height = height;
            Width = width;
        }

        public double GetWidth()
        {
            return Width;
        }

        public double GetHeight()
        {
            return Height;
        }

        public double GetArea()
        {
            return Height * Width;
        }

        public double GetPerimeter()
        {
            return (Height + Width) * 2;
        }
    }

    public class Circle : IShape
    {
        public double Radius { get; set; }

        public override string ToString()
        {
            return $"Круг с радиусом {Radius}";
        }

        public override int GetHashCode()
        {
            return (int)Radius;
        }

        public override bool Equals(object? o)
        {
            if (ReferenceEquals(o, this)) return true;
            if (ReferenceEquals(o, null) || o.GetType() != GetType()) return false;
            Circle p = (Circle)o;
            return Radius == p.Radius;
        }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double GetWidth()
        {
            return Radius * 2;
        }

        public double GetHeight()
        {
            return Radius * 2;
        }

        public double GetArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        public double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }
    }
}