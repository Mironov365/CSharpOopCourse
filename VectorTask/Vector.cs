using System.Numerics;
using System.Runtime.Intrinsics;

namespace VectorTask
{
    public class Vector
    {
        public int n { get; set; }
        public double[] Components { get; set; }

        public Vector(int n)
        {
            if (n <= 0)
                throw new ArgumentException("n must be > 0", nameof(n));

            this.n = n;
            Components = new double[n];
        }

        public Vector(Vector vector)
        {
            n = vector.n;
            Components = vector.Components;
        }

        public Vector(double[] array)
        {
            n = array.Length;
            Components = array;
        }

        public Vector(int n, double[] array)
        {
            if (n <= 0)
                throw new ArgumentException("n must be > 0", nameof(n));

            this.n = n;
            Components = new double[n];

            for (int i = 0; i < array.Length; i++)
            {
                Components[i] = array[i];
            }

        }

        public int GetSize()
        {
            return n;
        }

        public override string ToString()
        {
            return "{ " + string.Join(", ", Components) + " }";
        }

        public override int GetHashCode()
        {
            return n;
        }

        public override bool Equals(object? o)
        {
            if (ReferenceEquals(o, this)) return true;
            if (ReferenceEquals(o, null) || o.GetType() != GetType()) return false;
            Vector p = (Vector)o;

            bool componentsCheck = true;

            for (int i = 0; i < n; i++)
            {
                if (Components[i] != p.Components[i])
                {
                    componentsCheck = false;
                    break;
                }
            }

            return n == p.n && componentsCheck;
        }

        public Vector GetSum(Vector vector)
        {
            int nMax = Math.Max(n, vector.n);
            int nMin = Math.Min(n, vector.n);
            double[] array = new double[nMax];

            for (int i = 0; i < nMin; i++)
            {
                array[i] = Components[i] + vector.Components[i];
            }

            for (int i = nMin; i < nMax; i++)
            {
                if (nMax == n)
                {
                    array[i] = Components[i];
                }

                if (nMax == vector.n)
                {
                    array[i] = vector.Components[i];
                }
            }

            return new Vector(array);
        }

        public Vector GetSubtraction(Vector vector)
        {
            int nMax = Math.Max(n, vector.n);
            int nMin = Math.Min(n, vector.n);
            double[] array = new double[nMax];

            for (int i = 0; i < nMin; i++)
            {
                array[i] = Components[i] - vector.Components[i];
            }

            for (int i = nMin; i < nMax; i++)
            {
                if (nMax == n)
                {
                    array[i] = Components[i];
                }

                if (nMax == vector.n)
                {
                    array[i] = vector.Components[i];
                }
            }

            return new Vector(array);
        }

        public Vector GetMultiplication(double scalar)
        {
            double[] array = new double[n];

            for (int i = 0; i < n; i++)
            {
                array[i] = Components[i] * scalar;
            }

            return new Vector(array);
        }

        public void GetReverse()
        {
            double[] array = new double[n];

            for (int i = 0; i < n; i++)
            {
                array[i] = Components[i] * (-1);
            }

            Components = array;
        }

        public double GetLength()
        {
            double length = 0;

            foreach (double e in Components)
            {
                length += Math.Pow(e, 2);
            }

            return Math.Sqrt(length);
        }

        public double GetComponent(int index)
        {
            return Components[index];
        }

        public Vector ChangeComponent(int index, double newComponent)
        {
            double[] array = Components;
            array[index] = newComponent;

            return new Vector(array);
        }

        public static Vector VectorsSum(Vector v1, Vector v2)
        {
            int nMax = Math.Max(v1.n, v2.n);
            int nMin = Math.Min(v1.n, v2.n);
            double[] array = new double[nMax];

            for (int i = 0; i < nMin; i++)
            {
                array[i] = v1.Components[i] + v2.Components[i];
            }

            for (int i = nMin; i < nMax; i++)
            {
                if (nMax == v1.n)
                {
                    array[i] = v1.Components[i];
                }

                if (nMax == v2.n)
                {
                    array[i] = v2.Components[i];
                }
            }

            return new Vector(array);
        }

        public static Vector VectorsSubtraction(Vector v1, Vector v2)
        {
            int nMax = Math.Max(v1.n, v2.n);
            int nMin = Math.Min(v1.n, v2.n);
            double[] array = new double[nMax];

            for (int i = 0; i < nMin; i++)
            {
                array[i] = v1.Components[i] - v2.Components[i];
            }

            for (int i = nMin; i < nMax; i++)
            {
                if (nMax == v1.n)
                {
                    array[i] = v1.Components[i];
                }

                if (nMax == v2.n)
                {
                    array[i] = v2.Components[i];
                }
            }

            return new Vector(array);
        }

        public static double VectorsScalarProduct(Vector v1, Vector v2)
        {
            int nMax = Math.Max(v1.n, v2.n);
            int nMin = Math.Min(v1.n, v2.n);

            double scalarProduct = 0;

            for (int i = 0; i < nMin; i++)
            {
                scalarProduct += v1.Components[i] * v2.Components[i];
            }

            for (int i = nMin; i < nMax; i++)
            {
                if (nMax == v1.n)
                {
                    scalarProduct += v1.Components[i];
                }

                if (nMax == v2.n)
                {
                    scalarProduct += v2.Components[i];
                }
            }

            return scalarProduct;
        }
    }
}
