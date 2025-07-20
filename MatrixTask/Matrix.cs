using System.Data.Common;
using System.Text;
using VectorTask;

namespace MatrixTask
{
    public class Matrix
    {
        public int n { get; set; }
        public int m { get; set; }

        public Vector[] Values { get; set; }

        public Matrix(int m, int n)
        {
            this.n = n;
            this.m = m;
            Values = new Vector[this.m];

            for (int i = 0; i < this.m; i++)
            {
                Values[i] = new Vector(n);
            }
        }

        public Matrix(Matrix matrix)
        {
            n = matrix.n;
            m = matrix.m;

            Vector[] vectorsArray = new Vector[m];

            for (int i = 0; i < m; i++)
            {
                vectorsArray[i] = new Vector(matrix.Values[i]);
            }

            Values = vectorsArray;
        }

        public Matrix(double[,] array)
        {
            m = array.GetUpperBound(0) + 1;
            n = array.GetUpperBound(1) + 1;
            Values = new Vector[m];

            double[][] newArray = new double[m][];

            for (int i = 0; i < m; i++)
            {
                newArray[i] = new double[n];

                for (int j = 0; j < n; j++)
                {
                    newArray[i][j] = array[i, j];
                }
            }

            for (int i = 0; i < m; i++)
            {
                Values[i] = new Vector(newArray[i]);
            }
        }

        public Matrix(Vector[] array)
        {
            m = array.GetUpperBound(0) + 1;
            n = array[0].GetSize();
            Values = new Vector[m];

            for (int i = 0; i < m; i++)
            {
                Values[i] = array[i];
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder("{");

            for (int i = 0; i < m; i++)
            {
                if (i == m - 1)
                {
                    stringBuilder.Append("{ " + string.Join(", ", Values[i].Components) + " }}");
                    continue;
                }

                stringBuilder.Append("{ " + string.Join(", ", Values[i].Components) + " }, ");
            }

            return stringBuilder.ToString();
        }

        public int[] GetSize()
        {
            return new int[2] { m, n };
        }

        public Vector GetRow(int row)
        {
            if (row <= 0 || row > m)
                throw new ArgumentException($"row must be > 0 and < {m}", nameof(m));

            return Values[row];
        }

        public void ChangeRow(int row, Vector vector)
        {
            if (row <= 0 || row > m)
                throw new ArgumentException($"row must be > 0 and < {m}", nameof(m));

            if (vector.GetSize() > n)
                throw new ArgumentException($"size of new vector must be <= {n}", nameof(n));

            if (vector.GetSize() != n)
            {
                double[] array = new double[n];

                for (int i = 0; i < vector.GetSize(); i++)
                {
                    array[i] = vector.Components[i];
                }

                vector = new Vector(array);
            }

            Values[row] = vector;
        }

        public Vector GetColumn(int column)
        {
            if (column <= 0 || column >= n)
                throw new ArgumentException("column must be > 0 and < n", nameof(n));

            double[] array = new double[m];

            for (int i = 0; i < m; i++)
            {
                array[i] = Values[i].GetComponent(column);
            }

            return new Vector(array);
        }

        public void DoTransposition()
        {
            int newN = m;
            int newM = n;

            Vector[] vectorsArray = new Vector[n];

            for (int i = 0; i < n; i++)
            {
                double[] array = new double[m];

                for (int j = 0; j < m; j++)
                {
                    array[j] = this.GetElement(j, i);
                }

                vectorsArray[i] = new Vector(array);
            }

            n = newN;
            m = newM;
            Values = vectorsArray;
        }

        public void DoMultiplicationByScalar(double scalar)
        {
            for (int i = 0; i < m; i++)
            {
                Values[i].GetMultiplicationByScalar(scalar);
            }
        }

        public double GetElement(int row, int column)
        {
            return this.Values[row].GetComponent(column);
        }

        public Matrix GetSubMatrix(int row, int column)
        {
            double[,] array = new double[this.m - 1, this.n - 1];

            int tempRow = 0;

            for (int i = 0; i < this.m; i++)
            {
                if (i == row)
                {
                    continue;
                }

                int tempColumn = 0;

                for (int j = 0; j < n; j++)
                {
                    if (j == column)
                    {
                        continue;
                    }

                    array[tempRow, tempColumn] = this.GetElement(i, j);

                    tempColumn++;
                }

                tempRow++;
            }

            return new Matrix(array);
        }


        public double GetDeterminant()
        {
            if (n != m)
                throw new ArgumentException($"matrix have to be square");

            if (n == 1)
            {
                return this.GetElement(0, 0);
            }

            if (n == 2)
            {
                return this.GetElement(0, 0) * this.GetElement(1, 1) - this.GetElement(0, 1) * this.GetElement(1, 0);
            }

            if (n == 3)
            {
                return this.GetElement(0, 0) * this.GetElement(1, 1) * this.GetElement(2, 2) + this.GetElement(0, 1) * this.GetElement(1, 2) * this.GetElement(2, 0) +
                    this.GetElement(0, 2) * this.GetElement(1, 0) * this.GetElement(2, 1) - this.GetElement(0, 2) * this.GetElement(1, 1) * this.GetElement(2, 0) -
                    this.GetElement(0, 0) * this.GetElement(1, 2) * this.GetElement(2, 1) - this.GetElement(0, 1) * this.GetElement(1, 0) * this.GetElement(2, 2);
            }

            double determinant = 0;           

            for (int i = 0; i < n; i++)
            {
                determinant += Math.Pow(-1, i) * this.GetElement(i, 0) * this.GetSubMatrix(i, 0).GetDeterminant();
            }

            return determinant;
        }

        public Matrix GetMultiplicationByVector(Vector vector)
        {
            if (n != 1)
                throw new ArgumentException("n must be 1", nameof(n));

            double[,] array = new double[m, m];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    array[i, j] = this.GetElement(i, 0) * vector.GetComponent(j);
                }
            }

            return new Matrix(array);
        }

        public Matrix GetSum(Matrix matrix)
        {
            if (n != matrix.n || m != matrix.m)
                throw new ArgumentException("matrixs size must be same");

            double[,] array = new double[m, n];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    array[i, j] = this.GetElement(i, j) + matrix.GetElement(i, j);
                }
            }

            return new Matrix(array);
        }

        public Matrix GetSubtraction(Matrix matrix)
        {
            if (n != matrix.n || m != matrix.m)
                throw new ArgumentException("matrixs size must be same");

            double[,] array = new double[m, n];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    array[i, j] = this.GetElement(i, j) - matrix.GetElement(i, j);
                }
            }

            return new Matrix(array);
        }

        public static Matrix MatrixSum(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
                throw new ArgumentException("matrixs size must be same");

            double[,] array = new double[matrix1.m, matrix1.n];

            for (int i = 0; i < matrix1.m; i++)
            {
                for (int j = 0; j < matrix1.n; j++)
                {
                    array[i, j] = matrix1.GetElement(i, j) + matrix2.GetElement(i, j);
                }
            }

            return new Matrix(array);
        }

        public static Matrix MatrixSubtraction(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
                throw new ArgumentException("matrixs size must be same");

            double[,] array = new double[matrix1.m, matrix1.n];

            for (int i = 0; i < matrix1.m; i++)
            {
                for (int j = 0; j < matrix1.n; j++)
                {
                    array[i, j] = matrix1.GetElement(i, j) - matrix2.GetElement(i, j);
                }
            }

            return new Matrix(array);
        }

        public static Matrix MatrixMultiplication(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.n != matrix2.m)
                throw new ArgumentException("the number of columns in the first matrix must be equal to the number of rows in the second matrix");

            double[,] array = new double[matrix1.m, matrix2.n];

            for (int i = 0; i < matrix1.m; i++)
            {
                for (int j = 0; j < matrix2.n; j++)
                {
                    double value = 0;

                    for (int k = 0; k < matrix1.n; k++)
                    {
                        value += matrix1.GetElement(i, k) * matrix2.GetElement(k, j);
                    }

                    array[i, j] = value;
                }
            }

            return new Matrix(array);
        }
    }
}
