namespace ShapesTask.Shapes;

public class Circle : IShape
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public override string ToString()
    {
        return $"Круг с радиусом {Radius}";
    }

    public override int GetHashCode()
    {
        const int prime = 31;
        int hash = 1;
        hash = prime * hash + Radius.GetHashCode();

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

        Circle circle = (Circle)o;
        return Radius == circle.Radius;
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
        return Math.PI * Radius * Radius;
    }

    public double GetPerimeter()
    {
        return 2 * Math.PI * Radius;
    }
}
