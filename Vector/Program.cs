namespace VectorTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random();
            double[] array1 = new double[5];
            double[] array2 = { 3, 5, 1 };

            for (int i = 0; i < 5; i++)
            {
                array1[i] = rand.Next(10);
            }

            Vector vector1 = new Vector(3);
            Vector vector2 = new Vector(array1);
            Vector vector3 = new Vector(7, array1);
            Vector vector4 = new Vector(array2);
            Vector vector5 = new Vector(vector4);

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
            Console.WriteLine("Сумма векторов 2 и 4");
            Console.WriteLine(vector2.GetSum(vector4));
            Console.WriteLine();

            Console.WriteLine("Разность векторов 3 и 4");
            Console.WriteLine(vector3.GetSubtraction(vector4));
            Console.WriteLine();

            Console.WriteLine("Умножение вектора 3 на скаляр 5");
            Console.WriteLine(vector3.GetMultiplication(5));
            Console.WriteLine();

            Console.WriteLine("Разворот вектора 3");
            vector3.GetReverse();
            Console.WriteLine(vector3);
            Console.WriteLine();

            Console.WriteLine("Получение длины вектора ");
            Console.WriteLine(vector4.GetLength());
            Console.WriteLine();

            Console.WriteLine("Замена и получение компоненты 1 вектора 3");
            vector3.ChangeComponent(1, 555);
            Console.WriteLine(vector3.GetComponent(1));
            Console.WriteLine(vector3);
            Console.WriteLine();

            Console.WriteLine("Проверка корректности метода Equals на векторах 3, 4, 5");
            Console.WriteLine(vector3);
            Console.WriteLine(vector4);
            Console.WriteLine(vector5);

            Console.WriteLine("Сравниваем 4 и 5");
            Console.WriteLine(vector4.Equals(vector5));
            Console.WriteLine("Сравниваем 3 и 5");
            Console.WriteLine(vector3.Equals(vector5));
            Console.WriteLine();

            Console.WriteLine("Проверка статических методов");
            Console.WriteLine("Сложение векторов 3 и 4");
            Console.WriteLine(vector3);
            Console.WriteLine(vector4);
            Console.WriteLine(Vector.VectorsSum(vector3, vector4));
            Console.WriteLine();

            Console.WriteLine("Вычитание векторов 2 и 5");
            Console.WriteLine(vector2);
            Console.WriteLine(vector5);
            Console.WriteLine(Vector.VectorsSubtraction(vector2, vector5));
            Console.WriteLine();

            Console.WriteLine("Скалярное произведение векторов 1 и 2");
            Console.WriteLine(Vector.VectorsScalarProduct(vector1, vector2));
            Console.WriteLine();
        }
    }
}
