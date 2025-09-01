namespace TreeTask;

public class Program
{
    static void Main(string[] args)
    {
        BinaryTree<int> tree = new BinaryTree<int>(5);

        tree.Insert(6);
        tree.Insert(4);
        tree.Insert(3);
        tree.Insert(9);
        tree.Insert(10);
        tree.Insert(8);
        tree.Insert(12);

        Console.WriteLine("Проверка метода Insert. Дерево сформировано.");
        Console.WriteLine();

        Console.WriteLine("Проверка метода IsInTree.");
        Console.WriteLine("Поиск элемента 7");
        Console.WriteLine(tree.IsInTree(7));
        Console.WriteLine("Поиск элемента 6");
        Console.WriteLine(tree.IsInTree(6));
        Console.WriteLine("Поиск элемента 8");
        Console.WriteLine(tree.IsInTree(8));
        Console.WriteLine();


    }
}
