using System.Text;
using VectorTask;

namespace MatrixTask;

public class Matrix
{
    private Vector[] Rows;

    private int _rowsCount;

    private int _columnsCount;

    public Matrix(int rows, int columns)
    {
        if (rows <= 0)
        {
            throw new ArgumentException($"Rows count {rows} must be > 0", nameof(rows));
        }

        if (columns <= 0)
        {
            throw new ArgumentException($"Columns count {columns} must be > 0", nameof(columns));
        }

        _rowsCount = rows;
        _columnsCount = columns;
        Rows = new Vector[rows];

        for (int i = 0; i < rows; i++)
        {
            Rows[i] = new Vector(columns);
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

        for (int i = 0; i < array.Length - 2; i++)
        {
            if (array[i].Size() != array[i + 1].Size())
            {
                throw new ArgumentException($"Size of array's vectors must be same", nameof(array));
            }
        }

        _rowsCount = array.GetUpperBound(0) + 1;
        _columnsCount = array[0].Size();
        Rows = new Vector[_rowsCount];

        for (int i = 0; i < _rowsCount; i++)
        {
            Rows[i] = new Vector(array[i]);
        }
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder("{");

        for (int i = 0; i < _rowsCount - 1; i++)
        {
            stringBuilder.Append($"{Rows[i]}, ");
        }

        stringBuilder.Append($"{Rows[_rowsCount - 1]}}}");

        return stringBuilder.ToString();
    }

    public override int GetHashCode()
    {
        int prime = 31;
        int hash = 1;

        hash = prime * hash + _rowsCount.GetHashCode();
        hash = prime * hash + _columnsCount.GetHashCode();

        for (int i = 0; i < _rowsCount; i++)
        {
            for (int j = 0; j < _columnsCount; i++)
            {
                hash = prime * hash + Rows[i][j].GetHashCode();
            }
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

        if (_rowsCount != matrix._rowsCount)
        {
            return false;
        }

        if (_columnsCount != matrix._columnsCount)
        {
            return false;
        }

        for (int i = 0; i < _rowsCount; i++)
        {
            for (int j = 0; j < _columnsCount; i++)
            {
                if (Rows[i][j] != matrix.Rows[i][j])
                {
                    return false;
                }
            }
        }

        return true;
    }

    public string GetSize()
    {
        return $"{_rowsCount}x{_columnsCount}";
    }

    public Vector GetRow(int row)
    {
        if (row < 0 || row >= _rowsCount)
        {
            throw new ArgumentException($"Row index {row} must be >= 0 and < {_rowsCount}", nameof(row));
        }

        return new Vector(Rows[row]);
    }

    public void SetRow(int row, Vector vector)
    {
        if (row < 0 || row >= _rowsCount)
        {
            throw new ArgumentException($"Row index {row} must be >= 0 and < {_rowsCount}", nameof(row));
        }

        if (vector.Size() != _columnsCount)
        {
            throw new ArgumentException($"Vector size must be = {_columnsCount}", nameof(vector));
        }

        Vector newVector = (vector);

        Rows[row] = newVector;
    }

    public Vector GetColumn(int column)
    {
        if (column < 0 || column >= _columnsCount)
        {
            throw new ArgumentException($"Column index {column} must be >= 0 and < {_columnsCount}", nameof(column));
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
        int newColumns = _rowsCount;
        int newRows = _columnsCount;

        Vector[] vectorsArray = new Vector[_columnsCount];

        for (int i = 0; i < _columnsCount; i++)
        {
            vectorsArray[i] = GetColumn(i);
        }

        _columnsCount = newColumns;
        _rowsCount = newRows;
        Rows = vectorsArray;
    }

    public void MultiplyByScalar(double scalar)
    {
        foreach (Vector row in Rows)
        {
            row.MultiplyByScalar(scalar);
        }
    }

    private Matrix GetSubMatrix(int rowIndex, int columnIndex)
    {
        if (rowIndex > _rowsCount)
        {
            throw new ArgumentException($"Row index {rowIndex} must be <= count of matrix rows {_rowsCount}", nameof(rowIndex));
        }

        if (columnIndex > _columnsCount)
        {
            throw new ArgumentException($"Column index {columnIndex} must be <= count of matrix columns {_columnsCount}", nameof(columnIndex));
        }

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
            determinant += Math.Pow(-1, i) * Rows[i][0] * GetSubMatrix(i, 0).GetDeterminant();
        }

        return determinant;
    }

    public Vector MultiplyByVector(Vector vector)
    {
        if (_columnsCount != vector.Size())
        {
            throw new ArgumentException($"Vector size {vector.Size()} must be equal to columns count {_columnsCount}", nameof(vector));
        }

        double[] array = new double[_columnsCount];

        for (int i = 0; i < _rowsCount; i++)
        {
            for (int j = 0; j < _columnsCount; j++)
            {
                array[i] += Rows[i][j] * vector[j];
            }
        }

        return new Vector(array);
    }

    public void Add(Matrix matrix)
    {
        if (_columnsCount != matrix._columnsCount || _rowsCount != matrix._rowsCount)
        {
            throw new ArgumentException($"Matrices size must be same", nameof(matrix));
        }

        for (int i = 0; i < _rowsCount; i++)
        {
            Rows[i].Add(matrix.Rows[i]);
        }
    }

    public void Subtract(Matrix matrix)
    {
        if (_columnsCount != matrix._columnsCount || _rowsCount != matrix._rowsCount)
        {
            throw new ArgumentException($"Matrices size must be same", nameof(matrix));
        }

        for (int i = 0; i < _rowsCount; i++)
        {
            Rows[i].Subtract(matrix.Rows[i]);
        }
    }

    public static Matrix GetSum(Matrix matrix1, Matrix matrix2)
    {
        if (matrix1._columnsCount != matrix2._columnsCount || matrix1._rowsCount != matrix2._rowsCount)
        {
            throw new ArgumentException("Matrices size must be same");
        }

        Matrix matrix = new(matrix1);

        matrix.Add(matrix2);

        return matrix;
    }

    public static Matrix GetDifference(Matrix matrix1, Matrix matrix2)
    {
        if (matrix1._columnsCount != matrix2._columnsCount || matrix1._rowsCount != matrix2._rowsCount)
        {
            throw new ArgumentException("Matrices size must be same");
        }

        Matrix matrix = new(matrix1);

        matrix.Subtract(matrix2);

        return matrix;
    }

    public static Matrix GetProduct(Matrix matrix1, Matrix matrix2)
    {
        if (matrix1._columnsCount != matrix2._rowsCount)
        {
            throw new ArgumentException("Count of columns in the first matrix must be equal to the count of rows in the second matrix");
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