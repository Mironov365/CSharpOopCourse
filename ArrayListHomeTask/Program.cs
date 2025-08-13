using Microsoft.VisualBasic;

namespace ArrayListHomeTask;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Задание 1:");
        using (StreamReader streamReader = new StreamReader("..\\..\\..\\text.txt"))
        {
            List<string> strings = new List<string>();

            string line;

            while ((line = streamReader.ReadLine()) != null)
            {
                strings.Add(line);
            }    

            Console.WriteLine(string.Join(", ", strings.ToArray()));
            Console.WriteLine();
        }

        Console.WriteLine("Задание 2:");

        List<int> numbers1 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        Console.WriteLine("Список до изменения:");
        Console.WriteLine(string.Join(", ", numbers1.ToArray()));

        for (int i = 0; i < numbers1.Count; i++)
        {
            if (numbers1[i] % 2 == 0)
            {
                numbers1.RemoveAt(i);
            }
        }

        Console.WriteLine("Список после изменения:");
        Console.WriteLine(string.Join(", ", numbers1.ToArray()));
        Console.WriteLine();

        Console.WriteLine("Задание 3:");

        List<int> numbers2 = new List<int> { 1, 5, 2, 1, 3, 5 };
        List<int> numbers3 = new List<int>();

        Console.WriteLine("Список изначальный:");
        Console.WriteLine(string.Join(", ", numbers2.ToArray()));

        foreach (int number in numbers2)
        {
            if (numbers3.Contains(number))
            {
                continue;
            }

            numbers3.Add(number);
        }

        Console.WriteLine("Список после переноса данных:");
        Console.WriteLine(string.Join(", ", numbers3.ToArray()));
    }
}
