namespace ListTask;

internal class Program
{
    static void Main(string[] args)
    {
        int item1 = 35;
        int item2 = 15;
        int item3 = 10;
        int item4 = 20;
        int item5 = 29;
        int item6 = 11;

        SinglyLinkedList<int> singlyLinkedList = new();

        Console.WriteLine("Проверка добавление элементов в начало");
        singlyLinkedList.InsertFirst(item1);
        singlyLinkedList.InsertFirst(item2);
        Console.WriteLine(singlyLinkedList);
        Console.WriteLine($"Длина: {singlyLinkedList.Count}");
        singlyLinkedList.InsertFirst(item3);
        Console.WriteLine(singlyLinkedList);
        Console.WriteLine($"Длина: {singlyLinkedList.Count}");
        singlyLinkedList.InsertFirst(item4);
        Console.WriteLine(singlyLinkedList);
        Console.WriteLine($"Длина: {singlyLinkedList.Count}");
        singlyLinkedList.InsertFirst(item5);
        Console.WriteLine(singlyLinkedList);
        Console.WriteLine($"Длина: {singlyLinkedList.Count}");
        Console.WriteLine();

        Console.WriteLine("Получение значения первого элемента");
        Console.WriteLine(singlyLinkedList.GetFirst());
        Console.WriteLine();

        Console.WriteLine("Получение значения по индексу 2");
        Console.WriteLine(singlyLinkedList[2]);
        Console.WriteLine();

        Console.WriteLine("Изменение значения по индексу 2 на 43");
        Console.WriteLine(singlyLinkedList[2] = 43);
        Console.WriteLine(singlyLinkedList);
        Console.WriteLine($"Длина: {singlyLinkedList.Count}");
        Console.WriteLine();

        Console.WriteLine("Удаление элемента по индексу 0");
        Console.WriteLine(singlyLinkedList.RemoveAtIndex(0));
        Console.WriteLine(singlyLinkedList);
        Console.WriteLine($"Длина: {singlyLinkedList.Count}");
        Console.WriteLine();

        Console.WriteLine("Вставка элемента 11 по индексу 4");
        singlyLinkedList.Insert(4, item6);
        Console.WriteLine(singlyLinkedList);
        Console.WriteLine($"Длина: {singlyLinkedList.Count}");
        Console.WriteLine("Вставка элемента 19 по индексу 2");
        singlyLinkedList.Insert(2, 19);
        Console.WriteLine(singlyLinkedList);
        Console.WriteLine($"Длина: {singlyLinkedList.Count}");
        Console.WriteLine();

        Console.WriteLine("Удаление узла по значению 16");
        Console.WriteLine(singlyLinkedList.Remove(16));
        Console.WriteLine(singlyLinkedList);
        Console.WriteLine("Удаление узла по значению 15");
        Console.WriteLine(singlyLinkedList.Remove(15));
        Console.WriteLine(singlyLinkedList);
        Console.WriteLine($"Длина: {singlyLinkedList.Count}");
        Console.WriteLine();

        Console.WriteLine("Удаление первого элемента");
        Console.WriteLine(singlyLinkedList.RemoveFirst());
        Console.WriteLine(singlyLinkedList);
        Console.WriteLine($"Длина: {singlyLinkedList.Count}");
        Console.WriteLine();

        Console.WriteLine("Разворот списка");
        singlyLinkedList.InsertFirst(item2);
        singlyLinkedList.InsertFirst(item3);
        singlyLinkedList.InsertFirst(item4);
        Console.WriteLine(singlyLinkedList);
        singlyLinkedList.Reverse();
        Console.WriteLine(singlyLinkedList);
        Console.WriteLine($"Длина: {singlyLinkedList.Count}");
        Console.WriteLine();

        Console.WriteLine("Копирование списка");
        SinglyLinkedList<int> newSinglyLinkedList = singlyLinkedList.Copy();
        Console.WriteLine("Новый список после копирования");
        Console.WriteLine(newSinglyLinkedList);
        Console.WriteLine($"Длина: {newSinglyLinkedList.Count}");
    }
}
