namespace ArrayListHomeTask;

internal class Program
{
    public static List<string> GetFileLines(string filePath)
    {
        using StreamReader streamReader = new StreamReader(filePath);

        List<string> fileLines = new List<string>();

        string? line;

        while ((line = streamReader.ReadLine()) != null)
        {
            fileLines.Add(line);
        }

        return fileLines;

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

    public static List<T> ListWithoutDuplicates<T>(List<T> list)
    {
        ArgumentNullException.ThrowIfNull(list);

        List<T> listWithoutDuplicates = new List<T>(list.Count);

        for (int i = 0; i < list.Count; i++)
        {
            if (!listWithoutDuplicates.Contains(list[i]))
            {
                listWithoutDuplicates.Add(list[i]);
            }           
        }

        return listWithoutDuplicates;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Задание 1:");

        List<string> lines = GetFileLines("..\\..\\..\\text.txt");
        Console.WriteLine(string.Join(", ", lines));
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

        List<int> numbersWithoutDuplicates = ListWithoutDuplicates(numbers);

        Console.WriteLine(string.Join(", ", numbersWithoutDuplicates));
    }
}
