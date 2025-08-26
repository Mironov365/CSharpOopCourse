using System.Text;

namespace ListTask;

public class SinglyLinkedList<T>
{
    private ListItem<T>? _head;

    public int Count { get; private set; }

    public SinglyLinkedList() { }

    public override string ToString()
    {
        if (_head == null)
        {
            return "[]";
        }

        StringBuilder stringBuilder = new StringBuilder();
        ListItem<T> item = _head;

        stringBuilder.Append($"[{item.Data}");

        if (item.Next == null)
        {
            stringBuilder.Append(']');
        }

        for (item = _head.Next!; item.Next != null; item = item.Next)
        {
            stringBuilder.Append(", ").Append(item.Data);
        }

        stringBuilder.Append(", ").Append(item.Data).Append(']');

        return stringBuilder.ToString();
    }

    public T? GetFirst()
    {
        if (_head == null)
        {
            throw new InvalidOperationException("List is empty");
        }

        return _head.Data;
    }

    public T? this[int i]
    {
        get
        {
            if (i < 0 || i >= Count)
            {
                throw new IndexOutOfRangeException($"Index {i} is outside the Count range: from 0 to {Count - 1}");
            }

            return GetItemAtIndex(i).Data;
        }

        set
        {
            if (i < 0 || i >= Count)
            {
                throw new IndexOutOfRangeException($"Index {i} is outside the Count range: from 0 to {Count - 1}");
            }

            GetItemAtIndex(i).Data = value;
        }
    }

    private ListItem<T> GetItemAtIndex(int index)
    {
        ListItem<T>? item = _head;

        for (int i = 0; i < index; i++)
        {
            item = item!.Next;
        }

        return item!;
    }

    public T? RemoveAtIndex(int index)
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
        ListItem<T>? item = previousItem.Next;

        if (index == Count - 1)
        {
            previousItem.Next = null;
        }

        previousItem.Next = item!.Next;
        Count--;

        return item.Data;
    }

    public void InsertFirst(T? item)
    {
        ArgumentNullException.ThrowIfNull(item);

        _head = new ListItem<T>(item, _head!);
        Count++;
    }

    public void Insert(int index, T item)
    {
        if (index == 0)
        {
            InsertFirst(item);
            return;
        }

        if (index < 0 || index > Count)
        {
            throw new IndexOutOfRangeException($"Index {index} is outside the count of list's elements: from {0} to {Count}");
        }

        ListItem<T> previousItem = GetItemAtIndex(index - 1);

        ListItem<T> newItem = new ListItem<T>(item, previousItem.Next);

        previousItem.Next = newItem;
        Count++;
    }

    public T? RemoveFirst()
    {
        if (_head == null)
        {
            throw new InvalidOperationException("List is empty");
        }

        T? data = _head.Data;
        _head = _head.Next;
        Count--;

        return data;
    }

    public bool Remove(T? data)
    {
        int i = 0;

        for (ListItem<T>? item = _head; item != null; item = item.Next, i++)
        {
            if (Equals(item.Data, data))
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

        for (ListItem<T>? item = _head; item != null; item = item.Next!)
        {
            newSinglyLinkedList.InsertFirst(item.Data);
        }

        newSinglyLinkedList.Reverse();

        return newSinglyLinkedList;
    }
}