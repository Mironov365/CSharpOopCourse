namespace ListTask;

internal class Program
{
    static void Main(string[] args)
    {
        ListItem<int> item1 = new(34);
        ListItem<int> item2 = new(15);
        ListItem<int> item3 = new(10);
        ListItem<int> item4 = new(20);
        ListItem<int> item5 = new(29);
        ListItem<int> item6 = new(11);

        SinglyLinkedList<int> singlyLinkedList = new(item1);

        Console.WriteLine("Проверка добавление элементов в начало");
        singlyLinkedList.InsertAtBeginning(item2);
        Console.WriteLine(singlyLinkedList);
        Console.WriteLine($"Длина: {singlyLinkedList.GetCount()}");
        singlyLinkedList.InsertAtBeginning(item3);
        Console.WriteLine(singlyLinkedList);
        Console.WriteLine($"Длина: {singlyLinkedList.GetCount()}");
        singlyLinkedList.InsertAtBeginning(item4);
        Console.WriteLine(singlyLinkedList);
        Console.WriteLine($"Длина: {singlyLinkedList.GetCount()}");
        singlyLinkedList.InsertAtBeginning(item5);
        Console.WriteLine(singlyLinkedList);
        Console.WriteLine($"Длина: {singlyLinkedList.GetCount()}");
        Console.WriteLine();

        Console.WriteLine("Получение значения первого элемента");
        Console.WriteLine(singlyLinkedList.GetHeadData());
        Console.WriteLine();

        Console.WriteLine("Получение значения по индексу 2");
        Console.WriteLine(singlyLinkedList.GetDataAtIndex(2));
        Console.WriteLine();

        Console.WriteLine("Изменение значения по индексу 2 на 43");
        Console.WriteLine(singlyLinkedList.SetDataAtIndex(2, 43));
        Console.WriteLine(singlyLinkedList);
        Console.WriteLine($"Длина: {singlyLinkedList.GetCount()}");
        Console.WriteLine();

        Console.WriteLine("Удаление элемента по индексу 1");
        Console.WriteLine(singlyLinkedList.RemoveAtIndex(1));
        Console.WriteLine(singlyLinkedList);
        Console.WriteLine($"Длина: {singlyLinkedList.GetCount()}");
        Console.WriteLine();

        Console.WriteLine("Вставка элемента 11 по индексу 4");
        singlyLinkedList.InsertAtIndex(4, item6);
        Console.WriteLine(singlyLinkedList);
        Console.WriteLine($"Длина: {singlyLinkedList.GetCount()}");
        Console.WriteLine();

        Console.WriteLine("Удаление узла по значению 16");
        Console.WriteLine(singlyLinkedList.Remove(16));
        Console.WriteLine(singlyLinkedList);
        Console.WriteLine("Удаление узла по значению 15");
        Console.WriteLine(singlyLinkedList.Remove(15));
        Console.WriteLine(singlyLinkedList);
        Console.WriteLine($"Длина: {singlyLinkedList.GetCount()}");
        Console.WriteLine();

        Console.WriteLine("Удаление первого элемента");
        Console.WriteLine(singlyLinkedList.RemoveAtBeginning());
        Console.WriteLine(singlyLinkedList);
        Console.WriteLine($"Длина: {singlyLinkedList.GetCount()}");
        Console.WriteLine();

        Console.WriteLine("Разворот списка");
        singlyLinkedList.InsertAtBeginning(item2);
        singlyLinkedList.InsertAtBeginning(item3);
        singlyLinkedList.InsertAtBeginning(item4);
        Console.WriteLine(singlyLinkedList);
        singlyLinkedList.Reverse();
        Console.WriteLine(singlyLinkedList);
        Console.WriteLine($"Длина: {singlyLinkedList.GetCount()}");
        Console.WriteLine();

        Console.WriteLine("Копирование списка");
        SinglyLinkedList<int> newSinglyLinkedList = SinglyLinkedList<int>.Copy(singlyLinkedList);
        Console.WriteLine("Новый список после копирования");
        Console.WriteLine(newSinglyLinkedList);
    }
}
