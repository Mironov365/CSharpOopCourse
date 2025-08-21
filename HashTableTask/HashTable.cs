using System.Collections;
using System.Text;

namespace HashTableTask;

public class HashTable<T> : ICollection<T>
{
    private List<T>?[] _listsArray;

    public int Count { get; private set; }

    private int _modCount = 0;

    public bool IsReadOnly => false;

    public HashTable()
    {
        _listsArray = new List<T>[102];
    }

    public HashTable(int capacity)
    {
        _listsArray = new List<T>[capacity];
    }

    public List<T>? this[int index]
    {
        get
        {
            if (index < 0 || index >= _listsArray.Length)
            {
                throw new ArgumentOutOfRangeException($"Index {index} is outside the hash table. It must be from {0} to {_listsArray.Length - 1}");
            }

            return _listsArray[index];
        }

        set
        {
            if (index < 0 || index >= _listsArray.Length)
            {
                throw new ArgumentOutOfRangeException($"Index {index} is outside the hash table. It must be from {0} to {_listsArray.Length - 1}");
            }

            _listsArray[index] = value;
        }
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        
        for (int i = 0; i < _listsArray.Length - 1; i++)
        {
            if (_listsArray[i] == null)
            {
                continue;
            }

            AppendListToStringBilder(stringBuilder, _listsArray[i]!);
        }

        return stringBuilder.ToString();
    }

    private void AppendListToStringBilder(StringBuilder stringBuilder, List<T> list)
    {
        stringBuilder.Append('{');

        for (int i = 0; i < list.Count - 1; i++)
        {
            stringBuilder.Append(list[i]).Append(", ");
        }

        stringBuilder.Append(list[list.Count - 1]).Append('}');
    }

    public void Add(T item)
    {
        ArgumentNullException.ThrowIfNull(item);

        int itemHash = Math.Abs(item.GetHashCode() % _listsArray.Length);

        if (_listsArray[itemHash] == null)
        {
            _listsArray[itemHash] = new List<T>();
        }

        _listsArray[itemHash]!.Add(item);

        Count++;
        _modCount++;
    }

    public void Clear()
    {
        if (Count == 0)
        {
            return;
        }

        for (int i = 0; i < _listsArray.Length; i++)
        {
            _listsArray[i] = null;
        }

        Count = 0;
        _modCount++;
    }

    public bool Contains(T item)
    {
        ArgumentNullException.ThrowIfNull(item);

        int itemHash = Math.Abs(item.GetHashCode() % _listsArray.Length);

        if (_listsArray[itemHash] is null)
        {
            return false;
        }

        if (_listsArray[itemHash]!.Contains(item))
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

        for (int i = 0; i < _listsArray.Length; i++)
        {
            if (_listsArray[i] is null)
            {
                continue;
            }

            _listsArray[i]!.CopyTo(array, tempIndex);
            tempIndex += _listsArray[i]!.Count;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        int modCount = _modCount;

        for (int i = 0; i < Count; i++)
        {
            if (_listsArray[i] == null)
            {
                continue;
            }

            for (int j = 0; j < _listsArray[i]!.Count; j++)
            {
                if (modCount != _modCount)
                {
                    throw new InvalidOperationException("List was modified");
                }

                yield return _listsArray[i]![j];
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public bool Remove(T item)
    {
        ArgumentNullException.ThrowIfNull(item);

        int itemHash = Math.Abs(item.GetHashCode() % _listsArray.Length);

        if (_listsArray[itemHash] is null)
        {
            return false;
        }

        bool isElementRemoved = _listsArray[itemHash]!.Remove(item);

        if (_listsArray[itemHash]!.Count == 0)
        {
            _listsArray[itemHash] = null;
        }

        return isElementRemoved;
    }
}
