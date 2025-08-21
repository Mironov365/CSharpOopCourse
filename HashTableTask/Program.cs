namespace HashTableTask;

internal class Program
{
    static void Main(string[] args)
    {
        HashTable<string> stringsHashTable = new HashTable<string>(30);

        string string1 = "string one";
        string string2 = "string two";
        string string3 = "string three";

        stringsHashTable.Add(string1);
        stringsHashTable.Add(string2);
        stringsHashTable.Add(string3);

        Console.WriteLine("Проверка методов класса HashTable<T>");
        Console.WriteLine(stringsHashTable);
    }
}
