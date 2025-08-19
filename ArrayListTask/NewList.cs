using System;
using System.Collections;
using System.Text;

namespace ArrayListTask;

public class NewList<T> : IList<T>
{
    private T[] _items;

    public int Count { get; private set; }

    private int _modCount = 0;

    public NewList()
    {
        _items = new T[10];
    }

    public NewList(int capacity)
    {
        if (capacity < 0)
        {
            throw new IndexOutOfRangeException($"Capacity must be > 0. Capacity: {capacity}");
        }

        _items = new T[capacity];
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

        NewList<T> list = (NewList<T>)o;

        if (!_items.Equals(list._items))
        {
            return false;
        }

        if (Count != list.Count)
        {
            return false;
        }

        return true;
    }

    public override int GetHashCode()
    {
        const int prime = 31;

        int hash = 1;

        hash = prime * hash + Count.GetHashCode();

        foreach (T item in _items)
        {
            hash = prime * hash + item.GetHashCode();
        }

        return hash;
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder("{");

        for (int i = 0; i < Count - 1; i++)
        {
            stringBuilder.Append(_items[i]).Append(", ");
        }

        stringBuilder.Append(_items[Count - 1]).Append('}');

        return stringBuilder.ToString();
    }

    public T this[int index]
    {
        get
        {
            IndexCheck(index);

            return _items[index];
        }

        set
        {
            IndexCheck(index);

            _items[index] = value;
        }
    }

    public bool IsReadOnly => false;

    public int Capacity
    {
        get => _items.Length;

        set
        {
            if (value < Count)
            {
                throw new IndexOutOfRangeException($"New capacity must be equal or greater than Count. Count: {Count}, capacity: {value}");
            }

            Array.Resize(ref _items, value);
        }
    }

    public void TrimExcess()
    {
        if (Count / _items.Length <= 0.9)
        {
            Array.Resize(ref _items, Count);
        }
    }

    public void Add(T item)
    {
        if (Count >= _items.Length)
        {
            IncreaseCapacity();
        }

        _items[Count] = item;
        Count++;
        _modCount++;
    }

    private void IncreaseCapacity()
    {
        if (Capacity == 0)
        {
            Capacity = 1;
        }

        Capacity = _items.Length * 2;
    }

    public void Clear()
    {
        if (Count == 0)
        {
            return;
        }

        Array.Clear(_items, 0, Count);
        Count = 0;
        _modCount++;
    }

    public bool Contains(T item)
    {
        ArgumentNullException.ThrowIfNull(item);

        if (IndexOf(item) != -1)
        {
            return true;
        }

        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        ArgumentNullException.ThrowIfNull(array);

        if (array.Length - arrayIndex < Count)
        {
            throw new ArgumentException($"Array has not enough size from index to end to copy. Array size to copy: {array.Length - arrayIndex}, list's count: {Count}", nameof(array));
        }

        Array.Copy(_items, 0, array, arrayIndex, Count);
    }

    public IEnumerator<T> GetEnumerator()
    {
        int modCount = _modCount;

        for (int i = 0; i < Count; i++)
        {
            if (modCount != _modCount)
            {
                throw new InvalidOperationException("List was modified");
            }

            yield return _items[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public int IndexOf(T item)
    {
        ArgumentNullException.ThrowIfNull(item);

        for (int i = 0; i < Count; i++)
        {
            if (_items[i] is null)
            {
                continue;
            }

            if (_items[i].Equals(item))
            {
                return i;
            }
        }

        return -1;
    }

    public void Insert(int index, T item)
    {
        IndexCheck(index);

        if (Count >= _items.Length)
        {
            IncreaseCapacity();
        }

        Array.Copy(_items, index, _items, index + 1, Count - index);

        _items[index] = item;
        Count++;
        _modCount++;
    }

    public bool Remove(T item)
    {
        ArgumentNullException.ThrowIfNull(item);

        int index = IndexOf(item);

        if (index == -1)
        {
            return false;
        }

        RemoveAt(index);

        return true;

    }

    public void RemoveAt(int index)
    {
        IndexCheck(index);

        if (index < Count - 1)
        {
            Array.Copy(_items, index + 1, _items, index, Count - index - 1);
        }

        _items[Count - 1] = default;
        Count--;
        _modCount++;
    }

    private void IndexCheck(int index)
    {
        if (index < 0 || index > Count)
        {
            throw new IndexOutOfRangeException($"Index {index} is outside the count of list's elements: from {0} to {Count}");
        }
    }
}
