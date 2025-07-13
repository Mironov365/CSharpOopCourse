namespace ShapesTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создание Квадрата
            Console.WriteLine("Создание квадрата");

            Square square = new Square(15);

            Console.WriteLine($"Высота = {square.GetHeight()}");
            Console.WriteLine($"Ширина = {square.GetWidth()}");
            Console.WriteLine($"Площадь = {square.GetArea()}");
            Console.WriteLine($"Периметр = {square.GetPerimeter()}");
        }
    }
}
