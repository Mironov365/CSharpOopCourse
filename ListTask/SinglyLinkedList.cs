using System.Text;

namespace ListTask;

public class SinglyLinkedList<T>
{
    private ListItem<T>? _head = null;

    public int Count { get; private set; }

    public SinglyLinkedList() { }

    public override string ToString()
    {
        if (_head == null)
        {
            throw new InvalidOperationException("List is empty");
        }

        StringBuilder stringBuilder = new StringBuilder();

        stringBuilder.Append('{');

        for (int i = 0; i < Count - 1; i++)
        {
            stringBuilder.Append(this[i]).Append(", ");
        }

        stringBuilder.Append(this[Count - 1]).Append('}');

        return stringBuilder.ToString();
    }

    public T GetFirst()
    {
        if (_head == null)
        {
            throw new InvalidOperationException("List is empty");
        }

        return _head.Data;
    }

    public T this[int i]
    {
        get
        {
            if (i < 0 || i >= Count)
            {
                throw new IndexOutOfRangeException($"Index {i} is outside the count of list's elements: from {0} to {Count}");
            }

            return GetItemAtIndex(i).Data;
        }

        set
        {
            if (i < 0 || i >= Count)
            {
                throw new IndexOutOfRangeException($"Index {i} is outside the count of list's elements: from {0} to {Count}");
            }

            GetItemAtIndex(i).Data = value;
        }
    }

    private ListItem<T> GetItemAtIndex(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new IndexOutOfRangeException($"Index {index} is outside the count of list's elements: from {0} to {Count}");
        }

        ListItem<T> item = _head;

        for (int i = 0; i < index; i++)
        {
            item = item.Next;
        }

        return item;
    }

    public T SetDataAtIndex(int index, T data)
    {
        T oldData = this[index];
        this[index] = data;

        return oldData;
    }

    public T RemoveAtIndex(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new IndexOutOfRangeException($"Index {index} is outside the count of list's elements: from {0} to {Count - 1}");
        }

        if (index == 0)
        {
            return RemoveFirst();
        }

        ListItem<T> previousItem = GetItemAtIndex(index - 1);
        ListItem<T> item = previousItem.Next;
        ListItem<T> nextItem = item.Next;

        previousItem.Next = nextItem;
        Count--;

        return item.Data;
    }

    public void InsertFirst(T item)
    {
        ArgumentNullException.ThrowIfNull(item);

        _head = new ListItem<T>(item, _head);
        Count++;
    }

    public void Insert(int index, T item)
    {
        ArgumentNullException.ThrowIfNull(item);

        if (index == 0)
        {
            InsertFirst(item);
            return;
        }

        if (index < 0 || index > Count)
        {
            throw new IndexOutOfRangeException($"Index {index} is outside the count of list's elements: from {0} to {Count - 1}");
        }

        if (index == Count)
        {
            GetItemAtIndex(Count - 1).Next = new ListItem<T>(item);
            Count++;
            return;
        }

        ListItem<T> previousItem = GetItemAtIndex(index - 1);
        ListItem<T> currentItem = previousItem.Next;

        ListItem<T> newItem = new ListItem<T>(item);

        previousItem.Next = newItem;
        newItem.Next = currentItem;
        Count++;
    }

    public T RemoveFirst()
    {
        if (_head == null)
        {
            throw new InvalidOperationException("List is empty");
        }

        T data = _head.Data;
        _head = _head.Next;
        Count--;

        return data;
    }

    public bool Remove(T data)
    {
        if (data == null)
        {
            return false;
        }

        int i = 0;

        for (ListItem<T> item = _head; item != null; item = item.Next, i++)
        {
            if (item.Data.Equals(data))
            {
                RemoveAtIndex(i);
                return true;
            }
        }

        return false;
    }

    public void Reverse()
    {
        if (Count <= 1)
        {
            return;
        }

        ListItem<T>? previousItem = null;
        ListItem<T>? currentItem = _head;

        while (currentItem != null)
        {
            ListItem<T>? nextItem = currentItem.Next;
            currentItem.Next = previousItem;
            previousItem = currentItem;
            currentItem = nextItem;
        }

        _head = previousItem;
    }

    public SinglyLinkedList<T> Copy()
    {
        if (_head == null)
        {
            return new SinglyLinkedList<T>();
        }

        SinglyLinkedList<T> newSinglyLinkedList = new();

        int i = 0;

        for (ListItem<T> item = _head; item != null; item = item.Next, i++)
        {
            newSinglyLinkedList.Insert(i, item.Data);
        }

        return newSinglyLinkedList;
    }
}