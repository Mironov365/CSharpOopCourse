using VectorTask;

namespace MatrixTask;

internal class Program
{
    static void Main(string[] args)
    {
        double[,] twoDimensionalArray1 =
        {
            { 1, 2 },
            { 3, 4 }
        };

        double[,] twoDimensionalArray2 =
       {
            { 5, 6, 7 },
            { 3, 4, 8 },
            { 5, 4, 3 }
        };

        double[,] twoDimensionalArray3 =
{
            { 5, 6, 7, 5, 8 },
            { 3, 4, 8, 4, 3 },
            { 5, 4, 3, 5, 2 },
            { 6, 4, 3, 1, 2 },
            { 7, 3, 5, 4, 8 }
        };

        double[,] twoDimensionalArray4 =
{
            { 5 },
            { 3 },
            { 5 },
            { 6 },
            { 7 }
        };

        double[] oneDimensionalArray1 = { 4, 6, 8, 10, 11 };
        double[] oneDimensionalArray2 = { 5, 4, 10, 3, 8 };

        Vector vector = new Vector(oneDimensionalArray1);

        Vector[] vectorsArray = new Vector[2] {new Vector(oneDimensionalArray1), new Vector(oneDimensionalArray2) };

        Matrix matrix1 = new Matrix(4, 3);
        Matrix matrix2 = new Matrix(twoDimensionalArray1);
        Matrix matrix3 = new Matrix(twoDimensionalArray2);
        Matrix matrix4 = new Matrix(matrix3);
        Matrix matrix5 = new Matrix(vectorsArray);
        Matrix matrix6 = new Matrix(twoDimensionalArray3);
        Matrix matrix7 = new Matrix(twoDimensionalArray4);

        Console.WriteLine("Проверка создания матриц:");
        Console.WriteLine($"Матрица 1 = {matrix1}");
        Console.WriteLine($"Матрица 2 = {matrix2}");
        Console.WriteLine($"Матрица 3 = {matrix3}");
        Console.WriteLine($"Матрица 4 = {matrix4}");
        Console.WriteLine($"Матрица 5 = {matrix5}");
        Console.WriteLine($"Матрица 6 = {matrix6}");
        Console.WriteLine($"Матрица 7 = {matrix7}");
        Console.WriteLine();

        Console.WriteLine("Проверка методов:");

        Console.WriteLine("Получение размера матрицы 1:");
        Console.WriteLine(matrix1.GetSize()[0]+ ", " + matrix1.GetSize()[1]);
        Console.WriteLine();

        Console.WriteLine("Получение вектора-строки матрицы 3 по индексу 1:");
        Console.WriteLine(matrix3.GetRow(1));
        Console.WriteLine();

        Console.WriteLine("Изменение вектора-строки матрицы 3 по индексу 1:");            
        matrix3.ChangeRow(1, new Vector(new double[2] { 2, 1 }));
        Console.WriteLine(matrix3);
        Console.WriteLine();

        Console.WriteLine("Получение вектора-столбца матрицы 5 по индексу 3:");
        Console.WriteLine(matrix5.GetColumn(3));
        Console.WriteLine();

        Console.WriteLine("Транспонирование матрицы 5:");
        matrix5.DoTransposition();
        Console.WriteLine(matrix5);
        Console.WriteLine();

        Console.WriteLine("Умножение матрицы 5 на скаляр 5:");
        matrix5.DoMultiplicationByScalar(5);
        Console.WriteLine(matrix5);
        Console.WriteLine();

        Console.WriteLine("Вычисление определителя матрицы 2:");
        Console.WriteLine(matrix2.GetDeterminant());
        Console.WriteLine("Вычисление определителя матрицы 4:");
        Console.WriteLine(matrix4.GetDeterminant());
        Console.WriteLine("Вычисление определителя матрицы 6:");
        Console.WriteLine(matrix6.GetDeterminant());
        Console.WriteLine();

        Console.WriteLine("Умножение матрицы 7 на вектор :");
        Console.WriteLine(matrix7.GetMultiplicationByVector(vector));            
        Console.WriteLine();

        Console.WriteLine("Сложение матриц 3 и 4:");
        Console.WriteLine(matrix3.GetSum(matrix4));
        Console.WriteLine();

        Console.WriteLine("Вычитание матриц 3 и 4:");
        Console.WriteLine(matrix3.GetSubtraction(matrix4));
        Console.WriteLine();

        Console.WriteLine("Сложение матриц 3 и 4 статическое:");
        Console.WriteLine(Matrix.MatrixSum(matrix3, matrix4));
        Console.WriteLine();

        Console.WriteLine("Вычитание матриц 3 и 4 статическое:");
        Console.WriteLine(Matrix.MatrixSubtraction(matrix3, matrix4));
        Console.WriteLine();

        Console.WriteLine("Умножение матриц 2 и 3 статическое:");
        matrix5.DoTransposition();
        Console.WriteLine(Matrix.MatrixMultiplication(matrix2, matrix5));
        Console.WriteLine();
    }
}
