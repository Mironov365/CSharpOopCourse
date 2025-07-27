using System.Numerics;

namespace VectorTask;

public class Vector
{
    private double[] _components;

    public Vector(int n)
    {
        if (n <= 0)
        {
            throw new ArgumentException($"Vector size {n} must be > 0", nameof(n));
        }

        _components = new double[n];
    }

    public Vector(Vector vector)
    {
        double[] array = new double[vector.GetSize()];

        Array.Copy(vector._components, array, array.Length);

        _components = array;
    }

    public Vector(double[] array)
    {
        if (array is null)
        {
            throw new ArgumentNullException(nameof(array));
        }

        if (array.Length == 0)
        {
            throw new ArgumentException($"Array minVectorSize {array.Length} must be > 0", nameof(array));
        }

        _components = new double[array.Length];

        Array.Copy(array, _components, array.Length);
    }

    public Vector(int n, double[] array)
    {
        if (array is null)
        {
            throw new ArgumentNullException(nameof(array));
        }

        if (n < array.Length)
        {
            throw new ArgumentException($"New vector size {n} must be >= minVectorSize of array {array.Length}", nameof(n)); ;
        }

        _components = new double[n];

        Array.Copy(array, _components, array.Length);
    }

    public int GetSize()
    {
        return _components.Length;
    }

    public override string ToString()
    {
        string vector = string.Join(", ", _components);

        return $"{{{vector}}}";
    }

    public override int GetHashCode()
    {
        int prime = 31;
        int hash = 1;

        foreach (double e in _components)
        {
            hash = prime * hash + e.GetHashCode();
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

        Vector vector = (Vector)o;

        if (_components.Length != vector.GetSize())
        {
            return false;
        }

        for (int i = 0; i < _components.Length; i++)
        {
            if (_components[i] != vector._components[i])
            {
                return false;
            }
        }

        return true;
    }

    public void Add(Vector vector)
    {
        if (_components.Length < vector.GetSize())
        {
            Array.Resize(ref _components, vector.GetSize());
        }

        for (int i = 0; i < vector.GetSize(); i++)
        {
            _components[i] += vector._components[i];
        }
    }

    public void Subtract(Vector vector)
    {
        if (_components.Length < vector.GetSize())
        {
            Array.Resize(ref _components, vector.GetSize());
        }

        for (int i = 0; i < vector.GetSize(); i++)
        {
            _components[i] -= vector._components[i];
        }
    }

    public void MultiplyByScalar(double scalar)
    {
        for (int i = 0; i < _components.Length; i++)
        {
            _components[i] *= scalar;
        }
    }

    public void Reverse()
    {
        MultiplyByScalar(-1);
    }

    public double GetLength()
    {
        double result = 0;

        foreach (double component in _components)
        {
            result += component * component;
        }

        return Math.Sqrt(result);
    }

    public double this[int index]
    {
        get => _components[index];
        set => _components[index] = value;
    }

    public static Vector GetSum(Vector vector1, Vector vector2)
    {
        Vector vector = new Vector(vector1);
        vector.Add(vector2);

        return vector;
    }

    public static Vector GetDifference(Vector vector1, Vector vector2)
    {
        Vector vector = new Vector(vector1);
        vector.Subtract(vector2);

        return vector;
    }

    public static double GetScalarProduct(Vector vector1, Vector vector2)
    {
        int minVectorSize = Math.Min(vector1.GetSize(), vector2.GetSize());

        double result = 0;

        for (int i = 0; i < minVectorSize; i++)
        {
            result += vector1[i] * vector2[i];
        }

        return result;
    }
}
