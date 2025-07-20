namespace ShapesTask;

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

    public override int GetHashCode()
    {
        int prime = 31;
        int hash = 1;
        hash = prime * hash + (int)x1;
        hash = prime * hash + x2.GetHashCode();
        hash = prime * hash + x3.GetHashCode();
        hash = prime * hash + y1.GetHashCode();
        hash = prime * hash + y2.GetHashCode();
        hash = prime * hash + y3.GetHashCode();

        return hash;
    }

    public override bool Equals(object? o)
    {
        if (ReferenceEquals(o, this)) return true;
        if (ReferenceEquals(o, null) || o.GetType() != GetType()) return false;
        Triangle triangle = (Triangle)o;
        return x1 == triangle.x1 && x2 == triangle.x2 && x3 == triangle.x3 && y1 == triangle.y1 && y2 == triangle.y2 && y3 == triangle.y3;
    }

    public override string ToString()
    {
        return $"Треугольник с координатами ({x1}, {y1}), ({x2}, {y2}), ({x3}, {y3})";
    }

    public double GetWidth()
    {
        double maxX = Math.Max(x1, Math.Max(x2, x3));
        double minX = Math.Min(x1, Math.Min(x2, x3));

        return maxX - minX;
    }

    public double GetHeight()
    {
        double maxY = Math.Max(y1, Math.Max(y2, y3));
        double minY = Math.Min(y1, Math.Min(y2, y3));

        return maxY - minY;
    }

    public double GetArea()
    {
        return Math.Abs((x2 - x1) * (y3 - y1) - (x3 - x1) * (y2 - y1)) / 2;
    }

    public double GetPerimeter()
    {
        return GetSideLength(x1, x2, y1, y2) + GetSideLength(x2, x3, y2, y3) + GetSideLength(x3, x1, y3, y1);
    }

    public double GetSideLength(double x1, double x2, double y1, double y2)
    {
        return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
    }
}