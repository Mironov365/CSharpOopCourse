using System;
using System.Text;

namespace ListTask;

public class SinglyLinkedList<T>
{
    private ListItem<T>? _head;
    private int _count { get; set; }

    public SinglyLinkedList()
    {
        _count = 0;
        _head = default;
    }

    public int GetCount()
    {
        return _count;
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();

        stringBuilder.Append('{');

        for (ListItem<T> item = _head; item != null; item = item.Next)
        {
            stringBuilder.Append(item.Data);

            if (item.Next != null)
            {
                stringBuilder.Append(", ");
            }
        }

        stringBuilder.Append('}');

        return stringBuilder.ToString();
    }

    public T GetFirst()
    {
        if (_head == null)
        {
            throw new NullReferenceException("List is empty");
        }

        return _head.Data;
    }

    private T this[int i]
    {
        get
        {
            ListItem<T> item = GetItemAtIndex(i);

            return item.Data;
        }

        set
        {
            ListItem<T> item = GetItemAtIndex(i);

            item.Data = value;
        }
    }

    private ListItem<T> GetItemAtIndex(int index)
    {
        ListItem<T> item = _head;

        for (int i = 0; i < index; i++)
        {
            item = item.Next;
        }

        return item;
    }

    public T GetDataAtIndex(int index)
    {
        if (index == 0)
        {
            throw new InvalidOperationException("For this operation you should use GetFirst() method");
        }

        if (index < 0 || index >= _count)
        {
            throw new IndexOutOfRangeException($"Index {index} is outside the count of list's elements: from {0} to {_count}");
        }

        return this[index];
    }

    public T SetDataAtIndex(int index, T data)
    {
        if (_head == null)
        {
            throw new NullReferenceException("List is empty");
        }

        if (index < 0 || index >= _count)
        {
            throw new IndexOutOfRangeException($"Index {index} is outside the count of list's elements: from {0} to {_count}");
        }

        T oldData = this[index];
        this[index] = data;

        return oldData;
    }

    public T RemoveAtIndex(int index)
    {
        if (_head == null)
        {
            throw new NullReferenceException("List is empty");
        }

        if (index < 0 || index > _count)
        {
            throw new IndexOutOfRangeException("Index is outside the count of list's elements");
        }

        if (index == 0)
        {
            T headData = _head.Data;
            RemoveFirst();

            return headData;
        }

        ListItem<T> item = GetItemAtIndex(index);
        ListItem<T> previousItem = GetItemAtIndex(index - 1);
        ListItem<T> nextItem = GetItemAtIndex(index + 1);

        previousItem.Next = nextItem;
        _count--;

        return item.Data;
    }

    public void InsertFirst(ListItem<T> item)
    {
        ArgumentNullException.ThrowIfNull(item);

        _head = new ListItem<T>(item.Data, _head);
        _count++;
    }

    public void Insert(int index, ListItem<T> item)
    {
        ArgumentNullException.ThrowIfNull(item);

        if (index == 0)
        {
            InsertFirst(item);
            return;
        }

        if (index < 0 || index >= _count)
        {
            throw new IndexOutOfRangeException($"Index {index} is outside the count of list's elements: from {0} to {_count - 1}");
        }

        ListItem<T> currentItem = GetItemAtIndex(index);
        ListItem<T> previousItem = GetItemAtIndex(index - 1);

        previousItem.Next = item;
        item.Next = currentItem;
        _count++;
    }

    public T RemoveFirst()
    {
        if (_head == null)
        {
            throw new NullReferenceException("List is empty");
        }

        if (_head.Next == null)
        {
            _head = default;
            _count = 0;
        }

        T data = _head.Data;
        _head = _head.Next;
        _count--;

        return data;
    }

    public bool Remove(T data)
    {
        ArgumentNullException.ThrowIfNull(data);

        for (int i = 0; i < _count; i++)
        {
            if (this[i].Equals(data))
            {
                RemoveAtIndex(i);
                return true;
            }
        }

        return false;
    }

    public void Reverse()
    {
        if (_count <= 1)
        {
            return;
        }

        ListItem<T>? previousItem = null;
        ListItem<T>? currentItem = _head;
        ListItem<T>? nextItem;

        while (currentItem.Next != null)
        {
            nextItem = currentItem.Next;
            currentItem.Next = previousItem;
            previousItem = currentItem;
            currentItem = nextItem;
        }

        currentItem.Next = previousItem;
        _head = currentItem;
    }

    public SinglyLinkedList<T> Copy()
    {
        if (_head == null)
        {
            return new SinglyLinkedList<T>();
        }

        SinglyLinkedList<T> newSinglyLinkedList = new();

        for (int i = 0; i < _count; i++)
        {
            newSinglyLinkedList.Add(new ListItem<T>(this[i]));
        }

        return newSinglyLinkedList;
    }

    public void Add(ListItem<T> item)
    {
        ArgumentNullException.ThrowIfNull(item);

        if (_head == null)
        {
            InsertFirst(item);
            return;
        }

        GetItemAtIndex(_count - 1).Next = item;
        _count++;
    }
}