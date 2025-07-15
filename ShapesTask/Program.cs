namespace ShapesTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IShape[] shapesArray =
            {
                new Square(5),
                new Triangle(1,2,5,8,6,4),
                new Rectangle(3,8),
                new Circle(5),
                new Square(3),
                new Triangle(3,6,1,5,8,3),
                new Rectangle(5,9),
                new Circle(2)
            };

            double[] shapesArrayAreaToCheck =
            {
                new Square(5).GetArea(),
                new Triangle(1,2,5,8,6,4).GetArea(),
                new Rectangle(3,8).GetArea(),
                new Circle(5).GetArea(),
                new Square(3).GetArea(),
                new Triangle(3,6,1,5,8,3).GetArea(),
                new Rectangle(5,9).GetArea(),
                new Circle(2).GetArea()
            };

            double[] shapesArrayPerimeterToCheck =
            {
                new Square(5).GetPerimeter(),
                new Triangle(1,2,5,8,6,4).GetPerimeter(),
                new Rectangle(3,8).GetPerimeter(),
                new Circle(5).GetPerimeter(),
                new Square(3).GetPerimeter(),
                new Triangle(3,6,1,5,8,3).GetPerimeter(),
                new Rectangle(5,9).GetPerimeter(),
                new Circle(2).GetPerimeter()
            };

            Array.Sort(shapesArray, new ShareAreaComparer());

            Console.WriteLine("Фигура с наибольшей площадью:");
            Console.WriteLine($"Форма: {shapesArray[0].ToString()}");
            Console.WriteLine($"Площадь: {shapesArray[0].GetArea()}");

            Array.Sort(shapesArray, new SharePerimeterComparer());

            Console.WriteLine();
            Console.WriteLine("Фигура с вторым наибольшим периметром:");
            Console.WriteLine($"Форма: {shapesArray[1].ToString()}");
            Console.WriteLine($"Периметр: {shapesArray[1].GetPerimeter()}");
        }
    }
}
