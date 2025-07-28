using System;
using System.Text;
using VectorTask;

namespace MatrixTask;

public class Matrix
{
    private Vector[] Rows;

    private int _rowsCount;

    private int _columnsCount;

    public Matrix(int m, int n)
    {
        if (m <= 0)
        {
            throw new ArgumentException($"Number of matrix rows {m} must be > 0", nameof(m));
        }

        if (n <= 0)
        {
            throw new ArgumentException($"Number of matrix columns {n} must be > 0", nameof(n));
        }

        _rowsCount = m;
        _columnsCount = n;
        Rows = new Vector[m];

        for (int i = 0; i < m; i++)
        {
            Rows[i] = new Vector(n);
        }
    }

    public Matrix(Matrix matrix)
    {
        _columnsCount = matrix._columnsCount;
        _rowsCount = matrix._rowsCount;

        Vector[] vectorsArray = new Vector[_rowsCount];

        for (int i = 0; i < _rowsCount; i++)
        {
            vectorsArray[i] = new Vector(matrix.Rows[i]);
        }

        Rows = vectorsArray;
    }

    public Matrix(double[,] array)
    {
        if (array is null)
        {
            throw new ArgumentNullException(nameof(array));
        }

        _rowsCount = array.GetUpperBound(0) + 1;
        _columnsCount = array.GetUpperBound(1) + 1;
        Rows = new Vector[_rowsCount];

        double[][] newArray = new double[_rowsCount][];

        for (int i = 0; i < _rowsCount; i++)
        {
            newArray[i] = new double[_columnsCount];

            for (int j = 0; j < _columnsCount; j++)
            {
                newArray[i][j] = array[i, j];
            }
        }

        for (int i = 0; i < _rowsCount; i++)
        {
            Rows[i] = new Vector(newArray[i]);
        }
    }

    public Matrix(Vector[] array)
    {
        if (array is null)
        {
            throw new ArgumentNullException(nameof(array));
        }

        _rowsCount = array.GetUpperBound(0) + 1;
        _columnsCount = array[0].GetSize();
        Rows = new Vector[_rowsCount];

        for (int i = 0; i < _rowsCount; i++)
        {
            Rows[i] = array[i];
        }
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder("{");

        for (int i = 0; i < _rowsCount; i++)
        {
            if (i == _rowsCount - 1)
            {
                stringBuilder.Append("{ " + string.Join(", ", Rows[i]) + " }}");
                continue;
            }

            stringBuilder.Append("{ " + string.Join(", ", Rows[i]) + " }, ");
        }

        return stringBuilder.ToString();
    }

    public Vector GetRow(int row)
    {
        if (row < 0 || row >= _rowsCount)
        {
            throw new ArgumentException($"Row {row} must be >= 0 and < {_rowsCount}", nameof(row));
        }

        return Rows[row];
    }

    public void SetRow(int row, Vector vector)
    {
        if (row < 0 || row >= _rowsCount)
        {
            throw new ArgumentException($"Row {row} must be >= 0 and < {_rowsCount}", nameof(row));
        }

        if (vector.GetSize() != _columnsCount)
        {
            throw new ArgumentException($"Vector size must be = {_columnsCount}", nameof(vector));
        }

        Vector newVector = (vector);

        Rows[row] = newVector;
    }

    public Vector GetColumn(int column)
    {
        if (column <= 0 || column >= _columnsCount)
        {
            throw new ArgumentException($"Column {column} must be > 0 and < {_columnsCount}", nameof(column));
        }

        double[] array = new double[_rowsCount];

        for (int i = 0; i < _rowsCount; i++)
        {
            array[i] = Rows[i][column];
        }

        return new Vector(array);
    }

    public void Transpose()
    {
        int newN = _rowsCount;
        int newM = _columnsCount;

        Vector[] vectorsArray = new Vector[_columnsCount];

        for (int i = 0; i < _columnsCount; i++)
        {
            double[] array = new double[_rowsCount];

            for (int j = 0; j < _rowsCount; j++)
            {
                array[j] = Rows[i][j];
            }

            vectorsArray[i] = new Vector(array);
        }

        _columnsCount = newN;
        _rowsCount = newM;
        Rows = vectorsArray;
    }

    public void MultiplyByScalar(double scalar)
    {
        foreach (Vector row in Rows)
        {
            row.MultiplyByScalar(scalar);
        }
    }

    /* 
     * public double GetElement(int row, int column)
    {
        return Rows[row][column];
    }
    */

    private Matrix GetSubMatrix(int rowIndex, int columnIndex)
    {
        double[,] array = new double[_rowsCount - 1, _columnsCount - 1];

        int tempRowIndex = 0;

        for (int i = 0; i < _rowsCount; i++)
        {
            if (i == rowIndex)
            {
                continue;
            }

            int tempColumnIndex = 0;

            for (int j = 0; j < _columnsCount; j++)
            {
                if (j == columnIndex)
                {
                    continue;
                }

                array[tempRowIndex, tempColumnIndex] = Rows[i][j];

                tempColumnIndex++;
            }

            tempRowIndex++;
        }

        return new Matrix(array);
    }

    public double GetDeterminant()
    {
        if (_columnsCount != _rowsCount)
        {
            throw new InvalidOperationException($"Matrix rows {_rowsCount} and columns {_columnsCount} count must be equal");
        }

        if (_columnsCount == 1)
        {
            return Rows[0][0];
        }

        if (_columnsCount == 2)
        {
            return Rows[0][0] * Rows[1][1] - Rows[0][1] * Rows[1][0];
        }

        double determinant = 0;

        for (int i = 0; i < _columnsCount; i++)
        {
            determinant += Math.Pow(-1, i) * Rows[i][0] * this.GetSubMatrix(i, 0).GetDeterminant();
        }

        return determinant;
    }

    public Matrix MultiplyByVector(Vector vector)
    {
        if (_columnsCount != 1)
        {
            throw new ArgumentException("Columns count must be 1", nameof(_columnsCount));
        }

        double[,] array = new double[_rowsCount, _rowsCount];

        for (int i = 0; i < _rowsCount; i++)
        {
            for (int j = 0; j < _rowsCount; j++)
            {
                array[i, j] = Rows[i][0] * vector[j];
            }
        }

        return new Matrix(array);
    }

    public Matrix GetSum(Matrix matrix)
    {
        if (_columnsCount != matrix._columnsCount || _rowsCount != matrix._rowsCount)
        {
            throw new ArgumentException("Matrices size must be same");
        }

        double[,] array = new double[_rowsCount, _columnsCount];

        for (int i = 0; i < _rowsCount; i++)
        {
            for (int j = 0; j < _columnsCount; j++)
            {
                array[i, j] = Rows[i][j] + matrix.Rows[i][j];
            }
        }

        return new Matrix(array);
    }

    public Matrix GetSubtraction(Matrix matrix)
    {
        if (_columnsCount != matrix._columnsCount || _rowsCount != matrix._rowsCount)
        {
            throw new ArgumentException("Matrices size must be same");
        }

        double[,] array = new double[_rowsCount, _columnsCount];

        for (int i = 0; i < _rowsCount; i++)
        {
            for (int j = 0; j < _columnsCount; j++)
            {
                array[i, j] = Rows[i][j] - matrix.Rows[i][j];
            }
        }

        return new Matrix(array);
    }

    public static Matrix GetSum(Matrix matrix1, Matrix matrix2)
    {
        if (matrix1._columnsCount != matrix2._columnsCount || matrix1._rowsCount != matrix2._rowsCount)
        {
            throw new ArgumentException("Matrices size must be same");
        }

        double[,] array = new double[matrix1._rowsCount, matrix1._columnsCount];

        for (int i = 0; i < matrix1._rowsCount; i++)
        {
            for (int j = 0; j < matrix1._columnsCount; j++)
            {
                array[i, j] = matrix1.Rows[i][j] + matrix2.Rows[i][j];
            }
        }

        return new Matrix(array);
    }

    public static Matrix GetDifference(Matrix matrix1, Matrix matrix2)
    {
        if (matrix1._columnsCount != matrix2._columnsCount || matrix1._rowsCount != matrix2._rowsCount)
        {
            throw new ArgumentException("Matrices size must be same");
        }

        double[,] array = new double[matrix1._rowsCount, matrix1._columnsCount];

        for (int i = 0; i < matrix1._rowsCount; i++)
        {
            for (int j = 0; j < matrix1._columnsCount; j++)
            {
                array[i, j] = matrix1.Rows[i][j] - matrix2.Rows[i][j];
            }
        }

        return new Matrix(array);
    }

    public static Matrix GetProduct(Matrix matrix1, Matrix matrix2)
    {
        if (matrix1._columnsCount != matrix2._rowsCount)
        {
            throw new ArgumentException("COunt of columns in the first matrix must be equal to the count of rows in the second matrix");
        }

        double[,] array = new double[matrix1._rowsCount, matrix2._columnsCount];

        for (int i = 0; i < matrix1._rowsCount; i++)
        {
            for (int j = 0; j < matrix2._columnsCount; j++)
            {
                double value = 0;

                for (int k = 0; k < matrix1._columnsCount; k++)
                {
                    value += matrix1.Rows[i][k] * matrix2.Rows[k][j];
                }

                array[i, j] = value;
            }
        }

        return new Matrix(array);
    }
}
