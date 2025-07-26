using ShapesTask.Shapes;
using ShapesTask.Comparers;

namespace ShapesTask;

internal class Program
{
    static void Main(string[] args)
    {
        IShape[] shapesArray =
        {
            new Square(5),
            new Triangle(1, 2, 5, 8, 6, 4),
            new Rectangle(3, 8),
            new Circle(5),
            new Square(3),
            new Triangle(3, 6, 1, 5, 8, 3),
            new Rectangle(5, 9),
            new Circle(2)
        };        

        Array.Sort(shapesArray, new ShareAreaComparer());

        Console.WriteLine("Фигура с наибольшей площадью:");
        Console.WriteLine($"Фигура: {shapesArray[0]}");
        Console.WriteLine($"Площадь: {shapesArray[0].GetArea()}");

        Array.Sort(shapesArray, new SharePerimeterComparer());

        Console.WriteLine();
        Console.WriteLine("Фигура с вторым наибольшим периметром:");
        Console.WriteLine($"Фигура: {shapesArray[1]}");
        Console.WriteLine($"Периметр: {shapesArray[1].GetPerimeter()}");
    }
}