namespace ShapesTask
{
    public interface IShape
    {
        double GetWidth();
        double GetHeight();
        double GetArea();
        double GetPerimeter();
    }

    public class Square : IShape
    {
        public double SideLength { get; set; }

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
            
        }

        public double GetArea()
        {
            
        }

        public double GetPerimeter()
        {
            
        }
    }
}
