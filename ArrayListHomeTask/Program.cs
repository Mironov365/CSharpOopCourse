namespace ArrayListHomeTask;

internal class Program
{
    public static string FileReader(string path)
    {
        using (StreamReader streamReader = new StreamReader(path))
        {
            List<string> fileStrings = new List<string>();

            string? line;

            while ((line = streamReader.ReadLine()) != null)
            {
                fileStrings.Add(line);
            }

            return string.Join(", ", fileStrings);
        }
    }

    public static void RemoveEvenNumbers(List<int> list)
    {
        ArgumentNullException.ThrowIfNull(list);

        for (int i = list.Count - 1; i >= 0; i--)
        {
            if (list[i] % 2 == 0)
            {
                list.RemoveAt(i);
            }
        }
    }

    public static void RemoveDublicates(List<int> list)
    {
        ArgumentNullException.ThrowIfNull(list);

        List<int> dublicates = new List<int>(list.Count);

        for (int i = list.Count - 1; i >= 0; i--)
        {
            if (!dublicates.Contains(list[i]))
            {
                dublicates.Add(list[i]);
            }
            else
            {
                list.RemoveAt(i);
            }
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Задание 1:");

        string line = FileReader("..\\..\\..\\text.txt");
        Console.WriteLine(line);
        Console.WriteLine();

        Console.WriteLine("Задание 2:");

        List<int> numbers = new List<int> { 1, 2, 3, 4, 3, 5, 6, 6, 7, 7, 8, 9, 10, 4, 13 };

        Console.WriteLine("Список до изменения:");
        Console.WriteLine(string.Join(", ", numbers));
        Console.WriteLine("Список после удаления чётных чисел:");
        RemoveEvenNumbers(numbers);
        Console.WriteLine(string.Join(", ", numbers));
        Console.WriteLine();

        Console.WriteLine("Задание 3:");

        Console.WriteLine("Список изначальный:");
        Console.WriteLine(string.Join(", ", numbers));
        Console.WriteLine("Список после удаления повторяющихся чисел:");
        RemoveDublicates(numbers);
        Console.WriteLine(string.Join(", ", numbers));
    }
}
