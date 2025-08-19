namespace ArrayListTask;

internal class Program
{
    static void Main(string[] args)
    {
        NewList<double> myList = new NewList<double>();

        Console.WriteLine("Проверка метода Add:");
        myList.Add(33);
        myList.Add(23);
        myList.Add(13);
        myList.Add(3);
        Console.WriteLine(myList);
        Console.WriteLine($"Размер списка: {myList.Count}");
        Console.WriteLine();

        Console.WriteLine("Проверка метода CopyTo (index: 5):");
        double[] doubleArray = new double[20];
        myList.CopyTo(doubleArray, 5);
        Console.WriteLine(string.Join(", ", doubleArray));
        Console.WriteLine();

        Console.WriteLine("Проверка метода TrimExcess() и Capacity");
        Console.WriteLine("Вместимость списка до расширения:");
        Console.WriteLine(myList.Capacity);
        Console.WriteLine(myList);
        myList.Capacity = 30;
        Console.WriteLine("Вместимость списка после расширения:");
        Console.WriteLine(myList.Capacity);
        Console.WriteLine(myList);
        myList.TrimExcess();
        Console.WriteLine("Вместимость списка после TrimExcess():");
        Console.WriteLine(myList.Capacity);
        Console.WriteLine(myList);
        Console.WriteLine();

        Console.WriteLine("Проверка метода Contains");
        Console.WriteLine("Поиск элемента 22");
        Console.WriteLine(myList.Contains(22));
        Console.WriteLine("Поиск элемента 23");
        Console.WriteLine(myList.Contains(23));
        Console.WriteLine();

        Console.WriteLine("Проверка метода IndexOf");
        Console.WriteLine("Индекс элемента 22");
        Console.WriteLine(myList.IndexOf(22));
        Console.WriteLine("Индекс элемента 23");
        Console.WriteLine(myList.IndexOf(23));
        Console.WriteLine();

        Console.WriteLine("Проверка метода Insert");
        myList.Insert(3, 111);
        Console.WriteLine(myList);
        Console.WriteLine($"Размер списка: {myList.Count}");
        myList.Insert(2, 95);
        Console.WriteLine(myList);
        Console.WriteLine($"Размер списка: {myList.Count}");
        myList.Insert(5, 88);
        Console.WriteLine(myList);
        Console.WriteLine($"Размер списка: {myList.Count}");
        Console.WriteLine();

        Console.WriteLine("Проверка метода Remove и RemoveAt");
        Console.WriteLine($"Удаление элемента 112: {myList.Remove(112)}");
        Console.WriteLine($"Удаление элемента 111: {myList.Remove(111)}");
        Console.WriteLine(myList);
        Console.WriteLine($"Размер списка: {myList.Count}");
        Console.WriteLine("Удаление элемента по индексу 4:");
        myList.RemoveAt(4);
        Console.WriteLine(myList);
        Console.WriteLine($"Размер списка: {myList.Count}");
        Console.WriteLine();
    }
}