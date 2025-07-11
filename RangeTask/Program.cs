namespace RangeTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создание объекта и задание его свойств

            Range r1 = new Range();

            Console.WriteLine(r1.From.ToString());
            Console.WriteLine(r1.To.ToString());

            r1.From = 2;
            r1.To = 17.5;

            Console.WriteLine(r1.From.ToString());
            Console.WriteLine(r1.To.ToString());

            // Проверка функции GetDistance

            double distance = r1.GetDistance();
            Console.WriteLine(distance.ToString());

            // Проверка функции IsInside

            double point1 = 0;
            double point2 = 10;
            Console.WriteLine(r1.IsInside(point1));
            Console.WriteLine(r1.IsInside(point2));

            // Проверка функции RangesIntersection

            Range r2 = new Range(3.5, 20);
            Range r3 = new Range(20, 25);
            Range r4 = new Range(-15, -3);
            Range r5 = new Range(-6, -2);

            Range rangeIntersection1 = r1.RangesIntersection(r2);
            Range rangeIntersection2 = r2.RangesIntersection(r3);
            Range rangeIntersection3 = r4.RangesIntersection(r5);
            Range rangeIntersection4 = r4.RangesIntersection(r3);           

            // Проверка функции RangesUnion

            Range[] rangeUnion1 = r1.RangesUnion(r2);
            Range[] rangeUnion2 = r2.RangesUnion(r3);
            Range[] rangeUnion3 = r3.RangesUnion(r4);
            Range[] rangeUnion4 = r4.RangesUnion(r3);

            // Проверка функции RangesDifference

            Range r6 = new Range(1, 26);
            Range r7 = new Range(-10, -7);

            Range[] rangeDifference1 = r1.RangesDifference(r2);
            Range[] rangeDifference2 = r2.RangesDifference(r3);
            Range[] rangeDifference3 = r3.RangesDifference(r4);
            Range[] rangeDifference4 = r4.RangesDifference(r5);
            Range[] rangeDifference5 = r2.RangesDifference(r6);
            Range[] rangeDifference6 = r4.RangesDifference(r7);
        }
    }
}
