using System.ComponentModel;
using System.Numerics;
using System.Runtime.Intrinsics;

namespace VectorTask;

public class Vector
{
    private double[] Components;

    public Vector(int n)
    {
        if (n <= 0)
        {
            throw new ArgumentException("N must be > 0", nameof(n));
        }

        Components = new double[n];
    }

    public Vector(Vector vector)
    {
        double[] array = new double[vector.GetSize()];

        Array.Copy(vector.Components, array, array.Length);

        Components = array;
    }

    public Vector(double[] array)
    {
        if (array is null)
        {
            throw new ArgumentNullException("array must be not null", nameof(array));
        }

        int length = array.Length;
        double[] vectorArray = new double[length];

        Array.Copy(array, vectorArray, length);

        Components = vectorArray;
    }

    public Vector(int n, double[] array)
    {
        if (n <= 0)
        {
            throw new ArgumentException("n must be > 0", nameof(n));
        }

        if (array is null)
        {
            throw new ArgumentNullException("array must be not null", nameof(array));
        }

        Components = new double[n];

        for (int i = 0; i < array.Length; i++)
        {
            Components[i] = array[i];
        }
    }

    public int GetSize()
    {
        return Components.Length;
    }

    public override string ToString()
    {
        return "{ " + string.Join(", ", Components) + " }";
    }

    public override int GetHashCode()
    {
        int prime = 31;
        int hash = 1;

        hash = prime * hash + (Components != null ? Components.GetHashCode() : 0);

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

        Vector p = (Vector)o;

        if (this.GetSize() != p.GetSize())
        {
            return false;
        }

        for (int i = 0; i < this.GetSize(); i++)
        {
            if (this[i] != p[i])
            {
                return false;
            }
        }

        return true;
    }

    public void Add(Vector vector)
    {
        int length1 = this.GetSize();
        int length2 = vector.GetSize();

        if (length1 == length2)
        {
            for (int i = 0; i < length1; i++)
            {
                this[i] += vector[i];
            }
        }
        else
        {
            int arraysLengthMax = Math.Max(length1, length2);
            int arraysLengthMin = Math.Min(length1, length2);
            double[] array = new double[arraysLengthMax];

            for (int i = 0; i < arraysLengthMin; i++)
            {
                array[i] = this[i] + vector[i];
            }

            for (int i = arraysLengthMin; i < arraysLengthMax; i++)
            {
                if (arraysLengthMax == length1)
                {
                    array[i] = this[i];
                }

                if (arraysLengthMax == length2)
                {
                    array[i] = vector[i];
                }
            }

            this.Components = array;
        }
    }

    public void Subtract(Vector vector)
    {
        int length1 = this.GetSize();
        int length2 = vector.GetSize();

        if (length1 == length2)
        {
            for (int i = 0; i < length1; i++)
            {
                this[i] -= vector[i];
            }
        }
        else
        {
            int arraysLengthMax = Math.Max(length1, length2);
            int arraysLengthMin = Math.Min(length1, length2);
            double[] array = new double[arraysLengthMax];

            for (int i = 0; i < arraysLengthMin; i++)
            {
                array[i] = this[i] - vector[i];
            }

            for (int i = arraysLengthMin; i < arraysLengthMax; i++)
            {
                if (arraysLengthMax == length1)
                {
                    array[i] = this[i];
                }

                if (arraysLengthMax == length2)
                {
                    array[i] = vector[i];
                }
            }

            this.Components = array;
        }
    }

    public void MultiplicateByScalar(double scalar)
    {
        double[] array = new double[this.GetSize()];

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = Components[i] * scalar;
        }

        Components = array;
    }

    public void Reverse()
    {
        this.MultiplicateByScalar(-1);
    }

    public double GetLength()
    {
        double vectorLength = 0;

        foreach (double e in Components)
        {
            vectorLength += e * e;
        }

        return Math.Sqrt(vectorLength);
    }

    public double this[int index]
    {
        get { return Components[index]; }
        set { Components[index] = value; }
    }

    public static Vector GetSum(Vector vector1, Vector vector2)
    {
        Vector vector3 = new Vector(vector1);
        vector3.Add(vector2);

        return vector3;
    }

    public static Vector GetDifference(Vector vector1, Vector vector2)
    {
        Vector vector3 = new Vector(vector1);
        vector3.Subtract(vector2);

        return vector3;
    }

    public static double GetScalarProduct(Vector vector1, Vector vector2)
    {
        double result = 0;
        int length = vector1.GetSize() < vector2.GetSize() ? vector1.GetSize() : vector2.GetSize();

        for (int i = 0; i < length; i++)
        {
            result += vector1[i] * vector2[i];
        }

        return result;
    }
}
