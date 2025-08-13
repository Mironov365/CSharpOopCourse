using System.Collections;

namespace ArrayListTask;
public class MyList<T> : IList<T>
{
    private T[] _items;
    private int _count;

    public MyList()
    {
        _items = new T[10];
    }

    public MyList(int capacity)
    {
        _items = new T[capacity];
    }

    public T this[int index]
    {
        get
        {
            if (index >= _count)
            {
                throw new IndexOutOfRangeException();
            }

            return _items[index];
        }

        set
        {
            if (index >= _count)
            {
                throw new IndexOutOfRangeException();
            }

            _items[index] = value;
        }
    }

    public int Count
    {
        get => _count;
    }

    public bool IsReadOnly
    {
        get => false;
    }

    public int Capacity
    {
        get => _items.Length;

        set
        {
            if (value < _count)
            {
                throw new IndexOutOfRangeException();
            }

            Array.Resize(ref _items, value);
        }
    }

    public void TrimExcess()
    {
        if (_count * 100 / _items.Length < 90)
        {
            Array.Resize(ref _items, _count);
        }
    }

    public void Add(T item)
    {
        if (_count >= _items.Length)
        {
            IncreaseCapacity();
        }

        _items[_count] = item;
        _count++;
    }

    private void IncreaseCapacity()
    {
        Array.Resize(ref _items, _items.Length * 2);
    }

    public void Clear()
    {
        Array.Clear(_items);
        _count = 0;
    }

    public bool Contains(T item)
    {
        foreach (T it in _items)
        {
            if (it.Equals(item))
            {
                return true;
            }
        }

        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        if (array.Length - arrayIndex < _count)
        {
            throw new ArgumentException($"Array has not enought size from index to end to copy. Array size to copy: {array.Length - arrayIndex}, item's count: {_count}", nameof(array));
        }

        Array.Copy(_items, 0, array, arrayIndex, _count);
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < _count; i++)
        {
            yield return _items[i];
        }
    }

    public int IndexOf(T item)
    {
        for (int i = 0; i < _count; i++)
        {
            if (_items[i].Equals(item))
            {
                return i;
            }
        }

        return -1;
    }

    public void Insert(int index, T item)
    {
        if (index < 0 || index > _count)
        {
            throw new ArgumentOutOfRangeException();
        }

        if (_count + 1 > _items.Length)
        {
            IncreaseCapacity();
        }

        Array.Copy(_items, index, _items, index + 1, _count - index);

        _items[index] = item;
        _count++;
    }

    public bool Remove(T item)
    {
        for (int i = 0; i < _count; i++)
        {
            if (_items[i].Equals(item))
            {
                RemoveAt(i);

                return true;
            }
        }

        return false;
    }

    public void RemoveAt(int index)
    {
        if (index >= _count || index < 0)
        {
            throw new IndexOutOfRangeException();
        }

        if (index < _count - 1)
        {
            Array.Copy(_items, index + 1, _items, index, _count - index - 1);
        }

        _items[_count - 1] = default;
        _count--;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
