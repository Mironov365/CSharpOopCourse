using System.Data.Common;
using System.Text;
using VectorTask;

namespace MatrixTask;

public class Matrix
{
    private Vector[] _rows;

    public int RowsCount => _rows.Length;

    public int ColumnsCount => _rows[0].Size;

    public Matrix(int rowsCount, int columnsCount)
    {
        if (rowsCount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(rowsCount), $"Rows count must be > 0. Rows count: {rowsCount}");
        }

        if (columnsCount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(columnsCount), $"Columns count must be > 0. Columns count: {columnsCount}");
        }

        _rows = new Vector[rowsCount];

        for (int i = 0; i < rowsCount; i++)
        {
            _rows[i] = new Vector(columnsCount);
        }
    }

    public Matrix(Matrix matrix)
    {
        ArgumentNullException.ThrowIfNull(matrix, nameof(matrix));

        _rows = new Vector[matrix.RowsCount];

        for (int i = 0; i < matrix.RowsCount; i++)
        {
            _rows[i] = new Vector(matrix._rows[i]);
        }
    }

    public Matrix(double[,] array)
    {
        ArgumentNullException.ThrowIfNull(array);

        if (array.Length == 0)
        {
            throw new ArgumentException($"Array length must be > 0. Length: {array.Length}", nameof(array));
        }

        int rowsCount = array.GetLength(0);
        int columnsCount = array.GetLength(1);

        _rows = new Vector[rowsCount];

        for (int i = 0; i < rowsCount; i++)
        {
            _rows[i] = new Vector(columnsCount);

            for (int j = 0; j < columnsCount; j++)
            {
                _rows[i][j] = array[i, j];
            }
        }
    }

    public Matrix(Vector[] array)
    {
        ArgumentNullException.ThrowIfNull(array);

        if (array.Length == 0)
        {
            throw new ArgumentException($"Array length must be > 0. Length: {array.Length}", nameof(array));
        }

        int columnsCount = 0;

        foreach (Vector vector in array)
        {
            if (columnsCount < vector.Size)
            {
                columnsCount = vector.Size;
            }
        }

        int rowsCount = array.Length;

        _rows = new Vector[rowsCount];

        for (int i = 0; i < rowsCount; i++)
        {
            _rows[i] = new Vector(columnsCount);
            _rows[i].Add(array[i]);
        }
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder("{");

        int iterationsCount = RowsCount - 1;

        for (int i = 0; i < iterationsCount; i++)
        {
            stringBuilder.Append(_rows[i]).Append(", ");
        }

        stringBuilder.Append(_rows[RowsCount - 1]).Append('}');

        return stringBuilder.ToString();
    }

    public override int GetHashCode()
    {
        const int prime = 31;

        int hash = 1;

        foreach (Vector vector in _rows)
        {
            hash = prime * hash + vector.GetHashCode();
        }

        return hash;
    }

    public override bool Equals(object? o)
    {
        if (ReferenceEquals(o, this))
        {
            return true;
        }

        if (ReferenceEquals(o, null) || o.GetType() != GetType())
        {
            return false;
        }

        Matrix matrix = (Matrix)o;

        if (RowsCount != matrix.RowsCount || ColumnsCount != matrix.ColumnsCount)
        {
            return false;
        }

        for (int i = 0; i < RowsCount; i++)
        {
            if (!_rows[i].Equals(matrix._rows[i]))
            {
                return false;
            }
        }

        return true;
    }

    public Vector GetRow(int rowIndex)
    {
        if (rowIndex < 0 || rowIndex >= RowsCount)
        {
            throw new ArgumentOutOfRangeException(nameof(rowIndex), $"Row index must be >= 0 and < {RowsCount}. Row index: {rowIndex}");
        }

        return new Vector(_rows[rowIndex]);
    }

    public void SetRow(int rowIndex, Vector vector)
    {
        if (rowIndex < 0 || rowIndex >= RowsCount)
        {
            throw new ArgumentOutOfRangeException(nameof(rowIndex), $"Row index must be >= 0 and < {RowsCount}. Row index: {rowIndex}");
        }

        if (vector.Size != ColumnsCount)
        {
            throw new ArgumentException($"Vector size must be = {ColumnsCount}. Vector size: {vector.Size}", nameof(vector));
        }

        _rows[rowIndex] = new Vector(vector);
    }

    public Vector GetColumn(int columnIndex)
    {
        if (columnIndex < 0 || columnIndex >= ColumnsCount)
        {
            throw new ArgumentOutOfRangeException(nameof(columnIndex), $"Column index must be >= 0 and < {ColumnsCount}. Column index: {columnIndex} ");
        }

        double[] array = new double[RowsCount];

        for (int i = 0; i < RowsCount; i++)
        {
            array[i] = _rows[i][columnIndex];
        }

        return new Vector(array);
    }

    public void Transpose()
    {
        Vector[] vectorsArray = new Vector[ColumnsCount];

        for (int i = 0; i < ColumnsCount; i++)
        {
            vectorsArray[i] = GetColumn(i);
        }

        _rows = vectorsArray;
    }

    public void MultiplyByScalar(double scalar)
    {
        foreach (Vector row in _rows)
        {
            row.MultiplyByScalar(scalar);
        }
    }

    private Matrix GetSubMatrix(int rowIndex, int columnIndex)
    {
        double[,] array = new double[RowsCount - 1, ColumnsCount - 1];

        int tempRowIndex = 0;

        for (int i = 0; i < RowsCount; i++)
        {
            if (i == rowIndex)
            {
                continue;
            }

            int tempColumnIndex = 0;

            for (int j = 0; j < ColumnsCount; j++)
            {
                if (j == columnIndex)
                {
                    continue;
                }

                array[tempRowIndex, tempColumnIndex] = _rows[i][j];

                tempColumnIndex++;
            }

            tempRowIndex++;
        }

        return new Matrix(array);
    }

    public double GetDeterminant()
    {
        if (ColumnsCount != RowsCount)
        {
            throw new InvalidOperationException($"Matrix rowsCount {RowsCount} and columnsCount {ColumnsCount} count must be equal");
        }

        if (ColumnsCount == 1)
        {
            return _rows[0][0];
        }

        if (ColumnsCount == 2)
        {
            return _rows[0][0] * _rows[1][1] - _rows[0][1] * _rows[1][0];
        }

        double determinant = 0;

        for (int i = 0; i < ColumnsCount; i++)
        {
            determinant += Math.Pow(-1, i) * _rows[i][0] * GetSubMatrix(i, 0).GetDeterminant();
        }

        return determinant;
    }

    public Vector MultiplyByVector(Vector vector)
    {
        if (ColumnsCount != vector.Size)
        {
            throw new ArgumentException($"Vector size must be equal to columnsCount count {ColumnsCount}. Vector size: {vector.Size}", nameof(vector));
        }

        double[] array = new double[RowsCount];

        for (int i = 0; i < RowsCount; i++)
        {
            array[i] = Vector.GetScalarProduct(_rows[i], vector);
        }

        return new Vector(array);
    }

    public void Add(Matrix matrix)
    {
        if (ColumnsCount != matrix.ColumnsCount || RowsCount != matrix.RowsCount)
        {
            throw new ArgumentException($"Matrices size must be same. Count of rows and columns in first matrix: {RowsCount} x {ColumnsCount}; " +
                $"in second matrix: {matrix.RowsCount} x {matrix.ColumnsCount}", nameof(matrix));
        }

        for (int i = 0; i < RowsCount; i++)
        {
            _rows[i].Add(matrix._rows[i]);
        }
    }

    public void Subtract(Matrix matrix)
    {
        if (ColumnsCount != matrix.ColumnsCount || RowsCount != matrix.RowsCount)
        {
            throw new ArgumentException($"Matrices size must be same. Count of rows and columns in first matrix: {RowsCount} x {ColumnsCount}; " +
                $"in second matrix: {matrix.RowsCount} x {matrix.ColumnsCount}", nameof(matrix));
        }

        for (int i = 0; i < RowsCount; i++)
        {
            _rows[i].Subtract(matrix._rows[i]);
        }
    }

    public static Matrix GetSum(Matrix matrix1, Matrix matrix2)
    {
        if (matrix1.ColumnsCount != matrix2.ColumnsCount || matrix1.RowsCount != matrix2.RowsCount)
        {
            throw new ArgumentException($"Matrices size must be same. Count of rows and columns in first matrix: {matrix1.RowsCount} x {matrix1.ColumnsCount}; " +
                $"in second matrix: {matrix2.RowsCount} x {matrix2.ColumnsCount}");
        }

        Matrix matrix = new(matrix1);

        matrix.Add(matrix2);

        return matrix;
    }

    public static Matrix GetDifference(Matrix matrix1, Matrix matrix2)
    {
        if (matrix1.ColumnsCount != matrix2.ColumnsCount || matrix1.RowsCount != matrix2.RowsCount)
        {
            throw new ArgumentException($"Matrices size must be same. Count of rows and columns in first matrix: {matrix1.RowsCount} x {matrix1.ColumnsCount}, in second matrix: {matrix2.RowsCount} x {matrix2.ColumnsCount}");
        }

        Matrix matrix = new(matrix1);

        matrix.Subtract(matrix2);

        return matrix;
    }

    public static Matrix GetProduct(Matrix matrix1, Matrix matrix2)
    {
        if (matrix1.ColumnsCount != matrix2.RowsCount)
        {
            throw new ArgumentException($"Count of columns in the first matrix ({matrix1.ColumnsCount}) must be equal to the count of rows in the second matrix ({matrix2.RowsCount})");
        }

        double[,] array = new double[matrix1.RowsCount, matrix2.ColumnsCount];

        for (int i = 0; i < matrix1.RowsCount; i++)
        {
            for (int j = 0; j < matrix2.ColumnsCount; j++)
            {
                double value = 0;

                for (int k = 0; k < matrix1.ColumnsCount; k++)
                {
                    value += matrix1._rows[i][k] * matrix2._rows[k][j];
                }

                array[i, j] = value;
            }
        }

        return new Matrix(array);
    }
}