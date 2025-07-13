namespace RangeTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создание объекта и задание его свойств

            Range range1 = new Range(2, 17.5);

            Console.WriteLine("Создание объекта и задание его свойств");
            Console.WriteLine(range1.From);
            Console.WriteLine(range1.To);

            // Проверка функции GetLength

            double distance = range1.GetLength();

            Console.WriteLine("\nПроверка функции GetLength");
            Console.WriteLine(distance);

            // Проверка функции IsInside

            double point1 = 0;
            double point2 = 10;

            Console.WriteLine("\nПроверка функции IsInside");
            Console.WriteLine(range1.IsInside(point1));
            Console.WriteLine(range1.IsInside(point2));

            // Проверка функции GetIntersection

            Console.WriteLine("\nПроверка функции GetIntersection");

            Range range2 = new Range(3.5, 20);
            Range range3 = new Range(20, 25);
            Range range4 = new Range(-15, -3);
            Range range5 = new Range(-6, -2);

            Range?[] IntersectionArray = new Range?[] { range1.GetIntersection(range2), range2.GetIntersection(range3),
            range4.GetIntersection(range5), range4.GetIntersection(range3) };

            foreach (Range? range in IntersectionArray)
            {
                if (range is not null)
                {
                    Console.WriteLine($"{range.From}, {range.To}");
                }
                else
                {
                    Console.WriteLine("Is Null");
                }
            }

            // Проверка функции GetUnion

            Console.WriteLine("\nПроверка функции GetUnion");

            Range[][] UnionArray = new Range[][] { range1.GetUnion(range2), range2.GetUnion(range3), range3.GetUnion(range4), range4.GetUnion(range5) };

            foreach (Range[] rangeArray in UnionArray)
            {
                if (rangeArray.Length == 2)
                {
                    Console.WriteLine($"{rangeArray[0].From}, {rangeArray[0].To} and {rangeArray[1].From}, {rangeArray[1].To}");
                }
                else
                {
                    Console.WriteLine($"{rangeArray[0].From}, {rangeArray[0].To}");
                }
            }

            // Проверка функции GetDifference

            Console.WriteLine("\nПроверка функции GetDifference");

            Range range6 = new Range(1, 26);
            Range range7 = new Range(-10, -7);

            Range[][] DifferenceArray = new Range[][] { range1.GetDifference(range2), range2.GetDifference(range3), range3.GetDifference(range4), range4.GetDifference(range5),
            range2.GetDifference(range6), range4.GetDifference(range7)};

            foreach (Range[] rangeArray in DifferenceArray)
            {
                if (rangeArray.Length == 2)
                {
                    Console.WriteLine($"{rangeArray[0].From}, {rangeArray[0].To} and {rangeArray[1].From}, {rangeArray[1].To}");
                }
                else
                {
                    Console.WriteLine($"{rangeArray[0].From}, {rangeArray[0].To}");
                }
            }
        }
    }
}
