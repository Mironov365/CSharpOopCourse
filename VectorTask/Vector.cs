namespace VectorTask;

public class Vector
{
    private double[] _components;

    public int Size { get; private set; }

    public Vector(int size)
    {
        if (size <= 0)
        {
            throw new ArgumentException($"Vector size must be > 0. Size: {size}", nameof(size));
        }

        _components = new double[size];
        Size = size;
    }

    public Vector(Vector vector)
    {
        _components = new double[vector.Size];

        Array.Copy(vector._components, _components, _components.Length);

        Size = _components.Length;
    }

    public Vector(double[] array)
    {
        ArgumentNullException.ThrowIfNull(array);

        if (array.Length == 0)
        {
            throw new ArgumentException($"Array length ({array.Length}) must be > 0", nameof(array));
        }

        _components = new double[array.Length];

        Array.Copy(array, _components, array.Length);

        Size = _components.Length;
    }

    public Vector(int size, double[] array)
    {
        ArgumentNullException.ThrowIfNull(array);

        if (size <= 0)
        {
            throw new ArgumentException($"Vector size ({size}) must be > 0", nameof(size));
        }

        _components = new double[size];

        Array.Copy(array, _components, Math.Min(array.Length, size));

        Size = size;
    }

    public override string ToString()
    {
        return $"{{{string.Join(", ", _components)}}}";
    }

    public override int GetHashCode()
    {
        const int prime = 31;

        int hash = 1;

        hash = prime * hash + Size.GetHashCode();

        foreach (double component in _components)
        {
            hash = prime * hash + component.GetHashCode();
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

        if (_components.Length != vector.Size)
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
        if (_components.Length < vector.Size)
        {
            Array.Resize(ref _components, vector.Size);
        }

        for (int i = 0; i < vector.Size; i++)
        {
            _components[i] += vector._components[i];
        }

        Size = _components.Length;
    }

    public void Subtract(Vector vector)
    {
        if (_components.Length < vector.Size)
        {
            Array.Resize(ref _components, vector.Size);
        }

        for (int i = 0; i < vector.Size; i++)
        {
            _components[i] -= vector._components[i];
        }

        Size = _components.Length;
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
        double sum = 0;

        foreach (double component in _components)
        {
            sum += component * component;
        }

        return Math.Sqrt(sum);
    }

    public double this[int index]
    {
        get => _components[index];
        set => _components[index] = value;
    }

    public static Vector GetSum(Vector vector1, Vector vector2)
    {
        Vector resultVector = new Vector(vector1);
        resultVector.Add(vector2);

        return resultVector;
    }

    public static Vector GetDifference(Vector vector1, Vector vector2)
    {
        Vector resultVector = new Vector(vector1);
        resultVector.Subtract(vector2);

        return resultVector;
    }

    public static double GetScalarProduct(Vector vector1, Vector vector2)
    {
        int minVectorSize = Math.Min(vector1.Size, vector2.Size);

        double result = 0;

        for (int i = 0; i < minVectorSize; i++)
        {
            result += vector1._components[i] * vector2._components[i];
        }

        return result;
    }
}
