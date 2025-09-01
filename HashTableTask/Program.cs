namespace HashTableTask;

internal class Program
{
    static void Main(string[] args)
    {
        HashTable<double> doublesHashTable = new HashTable<double>(10);

        double double1 = 11;
        double double2 = 22;
        double double3 = 33;
        double double4 = 44;
        double double5 = 55;

        doublesHashTable.Add(double1);
        doublesHashTable.Add(double2);
        doublesHashTable.Add(double3);
        doublesHashTable.Add(double4);
        doublesHashTable.Add(double5);

        Console.WriteLine("Проверка метода Add класса HashTable<T>");
        Console.WriteLine(doublesHashTable);
        Console.WriteLine();

        Console.WriteLine("Проверка метода Contains");
        Console.WriteLine("Элемент 23");
        Console.WriteLine(doublesHashTable.Contains(23));
        Console.WriteLine("Элемент 22");
        Console.WriteLine(doublesHashTable.Contains(22));
        Console.WriteLine();

        Console.WriteLine("Проверка метода CopyTo");
        Console.WriteLine("Скопируем в новый массив по индексу 4");
        double[] doubles = new double[15];
        doublesHashTable.CopyTo(doubles, 4);
        Console.WriteLine(string.Join(", ", doubles));
        Console.WriteLine();

        Console.WriteLine("Проверка метода Remove");
        Console.WriteLine("Удалим элемент 23");
        Console.WriteLine(doublesHashTable.Remove(23));
        Console.WriteLine(doublesHashTable);
        Console.WriteLine("Удалим элемент 33");
        Console.WriteLine(doublesHashTable.Remove(33));
        Console.WriteLine(doublesHashTable);
        Console.WriteLine("Удалим элемент 11");
        Console.WriteLine(doublesHashTable.Remove(11));
        Console.WriteLine(doublesHashTable);
        Console.WriteLine();

        Console.WriteLine("Проверка метода Clear");
        doublesHashTable.Clear();
        Console.WriteLine(doublesHashTable);
        Console.WriteLine();
    }
}
