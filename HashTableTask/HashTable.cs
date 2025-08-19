using System.Collections;

namespace HashTableTask;

public class HashTable<T> : ICollection<T>
{
    private List<T>[] _listsArray = new List<T>[102];

    public HashTable() { }

    public int Count { get; private set; }

    public bool IsReadOnly => false;

    public List<T> this[int index]
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

    public void Add(T item)
    {
        ArgumentNullException.ThrowIfNull(item);
        
        int itemHash = Math.Abs(item.GetHashCode() % _listsArray.Length);

        if (_listsArray[itemHash] == null)
        {
            _listsArray[itemHash] = new List<T>();
        }

        _listsArray[itemHash].Add(item);

        Count++;
    }

    public void Clear()
    {
        if (Count == 0)
        {
            return;
        }

        Array.Clear(_listsArray, 0, Count);
        Count = 0;
        _modCount++;
    }

    public bool Contains(T item)
    {
        throw new NotImplementedException();
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    public bool Remove(T item)
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
