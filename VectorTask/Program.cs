namespace VectorTask;

internal class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        double[] array1 = new double[5];
        double[] array2 = { 3, 5, 1 };

        for (int i = 0; i < 5; i++)
        {
            array1[i] = random.Next(10);
        }

        Vector vector1 = new Vector(3);
        Vector vector2 = new Vector(array1);
        Vector vector3 = new Vector(7, array1);
        Vector vector4 = new Vector(array2);
        Vector vector5 = new Vector(vector4);
        Vector vector6 = new Vector(vector4);

        Console.WriteLine(vector1);
        Console.WriteLine(vector2);
        Console.WriteLine(vector3);
        Console.WriteLine(vector4);
        Console.WriteLine(vector5);

        Console.WriteLine(vector1.GetSize());
        Console.WriteLine(vector2.GetSize());
        Console.WriteLine(vector3.GetSize());
        Console.WriteLine(vector4.GetSize());
        Console.WriteLine();

        Console.WriteLine("Проверка нестатических методов");
        Console.WriteLine("Сумма векторов 4 и 2");
        vector4.Add(vector2);
        Console.WriteLine(vector4);
        Console.WriteLine();

        Console.WriteLine("Разность векторов 3 и 4");
        vector3.Subtract(vector4);
        Console.WriteLine(vector3);
        Console.WriteLine();

        Console.WriteLine("Умножение вектора 3 на скаляр 5");
        vector3.MultiplyByScalar(5);
        Console.WriteLine(vector3);
        Console.WriteLine();

        Console.WriteLine("Разворот вектора 3");
        vector3.Reverse();
        Console.WriteLine(vector3);
        Console.WriteLine();

        Console.WriteLine("Получение длины вектора 4");
        Console.WriteLine(vector4.GetLength());
        Console.WriteLine();

        Console.WriteLine("Замена и получение компоненты 1 вектора 3");
        vector3[1] = 555;
        Console.WriteLine(vector3[1]);
        Console.WriteLine(vector3);
        Console.WriteLine();

        Console.WriteLine("Проверка корректности метода Equals на векторах 3, 5, 6");
        Console.WriteLine(vector3);
        Console.WriteLine(vector5);
        Console.WriteLine(vector6);

        Console.WriteLine("Сравниваем 3 и 6");
        Console.WriteLine(vector3.Equals(vector6));
        Console.WriteLine("Сравниваем 5 и 6");
        Console.WriteLine(vector5.Equals(vector6));
        Console.WriteLine();

        Console.WriteLine("Проверка статических методов");
        Console.WriteLine("Сложение векторов 3 и 4");
        Console.WriteLine(vector3);
        Console.WriteLine(vector4);
        Console.WriteLine(Vector.GetSum(vector3, vector4));
        Console.WriteLine();

        Console.WriteLine("Вычитание векторов 2 и 5");
        Console.WriteLine(vector2);
        Console.WriteLine(vector5);
        Console.WriteLine(Vector.GetDifference(vector2, vector5));
        Console.WriteLine();

        Console.WriteLine("Скалярное произведение векторов 2 и 5");
        Console.WriteLine(vector2);
        Console.WriteLine(vector5);
        Console.WriteLine(Vector.GetScalarProduct(vector2, vector5));
        Console.WriteLine();
    }
}