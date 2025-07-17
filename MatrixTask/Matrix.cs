using VectorTask;

namespace MatrixTask
{
    public class Matrix
    {
        public int n { get; set; }
        public int m { get; set; }

        public Vector[] Values { get; set; }

        public Matrix(int n, int m)
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
            Values = matrix.Values;
        }

        public Matrix(double[,] array)
        {
            m = array.GetUpperBound(0) + 1;
            n = array.GetUpperBound(1) + 1;
            Values = new Vector[m];

            //double[] values = array[0,]; 

            double[][] newArray = new double[m][];

            for (int i = 0; i < m; i++)
            {
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
                throw new ArgumentException($"column must be > 0 and < {n}", nameof(n));

            double[] array = new double[m];

            for (int i = 0; i < m; i++)
            {
                array[i] = Values[i].GetComponent(column);
            }

            return new Vector(array);
        }
    }
}
