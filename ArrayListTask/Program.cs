namespace ArrayListTask;

internal class Program
{
    static void Main(string[] args)
    {
        List<double> list = new List<double>();

        Console.WriteLine("Проверка метода Add:");
        list.Add(33);
        list.Add(23);
        list.Add(13);
        list.Add(3);
        Console.WriteLine(list);
        Console.WriteLine($"Размер списка: {list.Count}");
        Console.WriteLine();

        Console.WriteLine("Проверка метода CopyTo (index: 5):");
        double[] doubleArray = new double[20];
        list.CopyTo(doubleArray, 5);
        Console.WriteLine(string.Join(", ", doubleArray));
        Console.WriteLine();

        Console.WriteLine("Проверка метода TrimExcess() и Capacity");
        Console.WriteLine("Вместимость списка до расширения:");
        Console.WriteLine(list.Capacity);
        Console.WriteLine(list);
        list.Capacity = 30;
        Console.WriteLine("Вместимость списка после расширения:");
        Console.WriteLine(list.Capacity);
        Console.WriteLine(list);
        list.TrimExcess();
        Console.WriteLine("Вместимость списка после TrimExcess():");
        Console.WriteLine(list.Capacity);
        Console.WriteLine(list);
        Console.WriteLine();

        Console.WriteLine("Проверка метода Contains");
        Console.WriteLine("Поиск элемента 22");
        Console.WriteLine(list.Contains(22));
        Console.WriteLine("Поиск элемента 23");
        Console.WriteLine(list.Contains(23));
        Console.WriteLine();

        Console.WriteLine("Проверка метода IndexOf");
        Console.WriteLine("Индекс элемента 22");
        Console.WriteLine(list.IndexOf(22));
        Console.WriteLine("Индекс элемента 23");
        Console.WriteLine(list.IndexOf(23));
        Console.WriteLine();

        Console.WriteLine("Проверка метода Insert");
        list.Insert(3, 111);
        Console.WriteLine(list);
        Console.WriteLine($"Размер списка: {list.Count}");
        list.Insert(2, 95);
        Console.WriteLine(list);
        Console.WriteLine($"Размер списка: {list.Count}");
        list.Insert(5, 88);
        Console.WriteLine(list);
        Console.WriteLine($"Размер списка: {list.Count}");
        Console.WriteLine();

        Console.WriteLine("Проверка метода Equals");
        List<double> listToCompare = new List<double>();
        listToCompare.Add(33);
        listToCompare.Add(23);
        listToCompare.Add(95);
        listToCompare.Add(13);
        listToCompare.Add(111);
        listToCompare.Add(89);
        listToCompare.Add(3);
        Console.WriteLine(list);
        Console.WriteLine(listToCompare);
        Console.WriteLine(list.Equals(listToCompare));
        listToCompare[5] = 88;
        Console.WriteLine(list);
        Console.WriteLine(listToCompare);
        Console.WriteLine(list.Equals(listToCompare));
        Console.WriteLine();

        Console.WriteLine("Проверка метода Remove и RemoveAt");
        Console.WriteLine($"Удаление элемента 112: {list.Remove(112)}");
        Console.WriteLine($"Удаление элемента 111: {list.Remove(111)}");
        Console.WriteLine(list);
        Console.WriteLine($"Размер списка: {list.Count}");
        Console.WriteLine("Удаление элемента по индексу 4:");
        list.RemoveAt(4);
        Console.WriteLine(list);
        Console.WriteLine($"Размер списка: {list.Count}");
        Console.WriteLine();
    }
}