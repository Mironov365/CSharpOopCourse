using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace HashTableTask;

public class HashTable<T> : ICollection<T>
{
    public readonly List<T>[] Lists;

    public int Count { get; private set; }

    private int _modCount;

    public bool IsReadOnly => false;

    public HashTable()
    {
        Lists = new List<T>[20];
    }

    public HashTable(int capacity)
    {
        if (capacity <= 0)
        {
            throw new IndexOutOfRangeException($"Capacity must be > 0. Capacity: {capacity}");
        }

        Lists = new List<T>[capacity];
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();

        stringBuilder.Append('{');


        for (int i = 0; i < Lists.Length; i++)
        {
            if (Lists[i] == null || Lists[i]!.Count == 0)
            {
                stringBuilder.Append("{null}");
                continue;
            }

            stringBuilder.Append('{');

            for (int j = 0; j < Lists[i]!.Count - 1; j++)
            {
                stringBuilder.Append(Lists[i][j]).Append(", ");
            }

            stringBuilder.Append(Lists[i][Lists[i]!.Count - 1]).Append("}");
        }

        stringBuilder.Append('}');

        return stringBuilder.ToString();
    }

    public void Add(T? item)
    {
        if (item == null)
        {
            return;
        }

        int itemHash = Math.Abs(item.GetHashCode() % Lists.Length);

        if (Lists[itemHash] == null)
        {
            Lists[itemHash] = new List<T>();
        }

        Lists[itemHash]!.Add(item);

        Count++;
        _modCount++;
    }

    public void Clear()
    {
        if (Count == 0)
        {
            return;
        }

        for (int i = 0; i < Lists.Length; i++)
        {
            if (Lists[i] != null)
            {
                Lists[i]!.Clear();
            }

        }

        Count = 0;
        _modCount++;
    }

    public bool Contains(T item)
    {
        if (item == null)
        {
            return false;
        }

        int itemHashCode = Math.Abs(item.GetHashCode() % Lists.Length);

        if (Lists[itemHashCode]!.Contains(item))
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

        if (arrayIndex >= array.Length)
        {
            throw new ArgumentOutOfRangeException($"Index has to be from 0 to {array.Length - 1}. Index: {arrayIndex}");
        }

        int tempIndex = arrayIndex;

        foreach (List<T> list in Lists)
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

        for (int i = 0; i < Count; i++)
        {
            if (Lists[i] == null)
            {
                continue;
            }

            foreach (T item in Lists[i])
            {
                if (modCount != _modCount)
                {
                    throw new InvalidOperationException("List was modified");
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
        if (item == null)
        {
            return false;
        }

        int itemHash = Math.Abs(item.GetHashCode() % Lists.Length);

        if (Lists[itemHash] is null)
        {
            return false;
        }

        bool isRemoved = Lists[itemHash]!.Remove(item);

        return isRemoved;
    }
}
