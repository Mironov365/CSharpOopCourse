namespace ShapesTask.Shapes;

public class Rectangle : IShape
{
    public double Width { get; set; }

    public double Height { get; set; }

    public Rectangle(double width, double height)
    {
        Height = height;
        Width = width;
    }

    public override int GetHashCode()
    {
        const int prime = 31;
        int hash = 1;
        hash = prime * hash + Width.GetHashCode();
        hash = prime * hash + Height.GetHashCode();

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

        Rectangle rectangle = (Rectangle)o;
        return Height == rectangle.Height && Width == rectangle.Width;
    }

    public override string ToString()
    {
        return $"Прямоугольник с шириной {Width} и высотой {Height}";
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
