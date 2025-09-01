using System.Collections;
using System.Text;

namespace HashTableTask;

public class HashTable<T> : ICollection<T>
{
    private List<T>[] _lists;

    public int Count { get; private set; }

    private int _modCount;

    public bool IsReadOnly => false;

    public HashTable()
    {
        _lists = new List<T>[20];
    }

    public HashTable(int capacity)
    {
        if (capacity <= 0)
        {
            throw new IndexOutOfRangeException($"Capacity must be > 0. Capacity: {capacity}");
        }

        _lists = new List<T>[capacity];
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();

        stringBuilder.Append('{');

        foreach (List<T> list in _lists)
        {
            if (list == null || list.Count == 0)
            {
                stringBuilder.Append("{null}");
                continue;
            }

            stringBuilder.Append('{');

            for (int i = 0; i < list.Count; i++)
            {
                stringBuilder.Append(list[i]).Append(", ");
            }

            stringBuilder.Remove(stringBuilder.Length - 2, 2).Append('}');
        }

        stringBuilder.Append('}');

        return stringBuilder.ToString();
    }

    public void Add(T item)
    {
        int index = GetIndex(item);

        if (_lists[index] == null)
        {
            _lists[index] = new List<T>();
        }

        _lists[index]!.Add(item);

        Count++;
        _modCount++;
    }

    public void Clear()
    {
        if (Count == 0)
        {
            return;
        }

        foreach (List<T> list in _lists)
        {
            if (list != null)
            {
                list.Clear();
            }
        }

        Count = 0;
        _modCount++;
    }

    public bool Contains(T item)
    {
        if (item is null)
        {
            return false;
        }

        int index = GetIndex(item);

        return _lists[index].Contains(item);
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        ArgumentNullException.ThrowIfNull(array);

        if (array.Length - arrayIndex < Count)
        {
            throw new ArgumentException($"Array has not enough size from index to end to copy. Array size to copy: {array.Length - arrayIndex}, count of elemenst to copy: {Count}", nameof(array));
        }

        if (arrayIndex < 0)
        {
            throw new ArgumentOutOfRangeException($"Index has to be more then 0. Index: {arrayIndex}");
        }

        int tempIndex = arrayIndex;

        foreach (List<T> list in _lists)
        {
            if (list is null)
            {
                continue;
            }

            list.CopyTo(array, tempIndex);
            tempIndex += list.Count;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        int modCount = _modCount;

        foreach (List<T> list in _lists)
        {
            if (list == null)
            {
                continue;
            }

            foreach (T item in list)
            {
                if (modCount != _modCount)
                {
                    throw new InvalidOperationException("Count of elements was changed");
                }

                yield return item;
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public bool Remove(T item)
    {
        int index = GetIndex(item);

        if (_lists[index] is null)
        {
            return false;
        }

        return _lists[index].Remove(item);
    }

    private int GetIndex(T item)
    {
        return Math.Abs(item.GetHashCode() % _lists.Length);
    }
}
