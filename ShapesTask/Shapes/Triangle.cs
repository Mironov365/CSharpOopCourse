namespace ShapesTask.Shapes;

public class Triangle : IShape
{
    public double X1 { get; set; }

    public double X2 { get; set; }

    public double X3 { get; set; }

    public double Y1 { get; set; }

    public double Y2 { get; set; }

    public double Y3 { get; set; }

    public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
    {
        this.X1 = x1;
        this.X2 = x2;
        this.X3 = x3;
        this.Y1 = y1;
        this.Y2 = y2;
        this.Y3 = y3;
    }

    public override int GetHashCode()
    {
        const int prime = 31;
        int hash = 1;
        hash = prime * hash + X1.GetHashCode();
        hash = prime * hash + X2.GetHashCode();
        hash = prime * hash + X3.GetHashCode();
        hash = prime * hash + Y1.GetHashCode();
        hash = prime * hash + Y2.GetHashCode();
        hash = prime * hash + Y3.GetHashCode();

        return hash;
    }

    public override bool Equals(object? o)
    {
        if (ReferenceEquals(o, this))
        {
            return true;
        }

        if (ReferenceEquals(o, null) || o.GetType() != GetType())
        {
            return false;
        }

        Triangle triangle = (Triangle)o;

        return X1 == triangle.X1 && X2 == triangle.X2 && X3 == triangle.X3 && Y1 == triangle.Y1 && Y2 == triangle.Y2 && Y3 == triangle.Y3;
    }

    public override string ToString()
    {
        return $"Треугольник с координатами ({X1}, {Y1}), ({X2}, {Y2}), ({X3}, {Y3})";
    }

    public double GetWidth()
    {
        double maxX = Math.Max(X1, Math.Max(X2, X3));
        double minX = Math.Min(X1, Math.Min(X2, X3));

        return maxX - minX;
    }

    public double GetHeight()
    {
        double maxY = Math.Max(Y1, Math.Max(Y2, Y3));
        double minY = Math.Min(Y1, Math.Min(Y2, Y3));

        return maxY - minY;
    }

    public double GetArea()
    {
        return Math.Abs((X2 - X1) * (Y3 - Y1) - (X3 - X1) * (Y2 - Y1)) / 2;
    }

    public double GetPerimeter()
    {
        return GetSideLength(X1, X2, Y1, Y2) + GetSideLength(X2, X3, Y2, Y3) + GetSideLength(X3, X1, Y3, Y1);
    }

    private static double GetSideLength(double x1, double y1, double x2, double y2)
    {
        return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
    }
}