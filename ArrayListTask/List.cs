using System.Collections;
using System.Text;

namespace ArrayListTask;

public class List<T> : IList<T>
{
    private T?[] _items;

    public int Count { get; private set; }

    private int _modCount;

    public List()
    {
        _items = new T[10];
    }

    public List(int capacity)
    {
        if (capacity < 0)
        {
            throw new ArgumentException($"Capacity must be >= 0. Capacity: {capacity}", nameof(capacity));
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

        List<T> list = (List<T>)o;

        if (Count != list.Count)
        {
            return false;
        }

        for (int i = 0; i < Count; i++)
        {
            if (!_items[i]!.Equals(list._items[i]))
            {
                return false;
            }
        }

        return true;
    }

    public override int GetHashCode()
    {
        const int prime = 31;

        int hash = 1;

        hash = prime * hash + Count.GetHashCode();
        hash = prime * hash + _modCount.GetHashCode();

        foreach (T? item in _items)
        {
            if (item == null)
            {
                continue;
            }

            hash = prime * hash + item.GetHashCode();
        }

        return hash;
    }

    public override string ToString()
    {
        if (Count == 0)
        {
            return "[]";
        }

        StringBuilder stringBuilder = new StringBuilder("[");

        for (int i = 0; i < Count - 1; i++)
        {
            stringBuilder.Append(_items[i]).Append(", ");
        }

        stringBuilder.Append(_items[Count - 1]).Append(']');

        return stringBuilder.ToString();
    }

    public T this[int index]
    {
        get
        {
            CheckIndex(index);

            return _items[index]!;
        }

        set
        {
            CheckIndex(index);
            _modCount++;

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
                throw new InvalidOperationException($"New capacity must be equal or greater than Count. Count: {Count}, capacity: {value}");
            }

            Array.Resize(ref _items, value);
        }
    }

    public void TrimExcess()
    {
        if (Convert.ToDouble(Count) / _items.Length <= 0.9)
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
            return;
        }

        Capacity *= 2;
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
        bool isContains = false;

        if (IndexOf(item) != -1)
        {
            isContains = true;
        }

        return isContains;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        ArgumentNullException.ThrowIfNull(array);

        if (array.Length - arrayIndex < Count)
        {
            throw new ArgumentException($"Array has not enough size from index to end to copy. Array size to copy: {array.Length - arrayIndex}, list's count: {Count}", nameof(array));
        }

        if (arrayIndex < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(arrayIndex));
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

            yield return _items[i]!;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public int IndexOf(T item)
    {
        if (item == null)
        {
            return -1;
        }

        for (int i = 0; i < Count; i++)
        {
            if (_items[i] is null)
            {
                continue;
            }

            if (Equals(_items[i], item))
            {
                return i;
            }
        }

        return -1;
    }

    public void Insert(int index, T item)
    {
        CheckIndex(index);

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
        if (item == null)
        {
            return false;
        }

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
        CheckIndex(index);

        if (index < Count - 1)
        {
            Array.Copy(_items, index + 1, _items, index, Count - index - 1);
        }

        _items[Count - 1] = default;
        Count--;
        _modCount++;
    }

    private void CheckIndex(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new IndexOutOfRangeException($"Index {index} is outside the count of list's elements: from 0 to {Count - 1}");
        }
    }
}
