using System;
using System.Reflection;
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

        stringBuilder.Append('[');

        for (item = _head; item != null; item = item.Next!)
        {
            stringBuilder.Append(item.Data).Append(", ");
        }

        stringBuilder.Remove(stringBuilder.Length - 2, 2).Append(']');

        return stringBuilder.ToString();
    }

    public T GetFirst()
    {
        if (_head == null)
        {
            throw new InvalidOperationException("List is empty");
        }

        return _head.Data!;
    }

    public T this[int i]
    {
        get
        {
            CheckIndex(i);

            return GetItemAtIndex(i).Data!;
        }

        set
        {
            CheckIndex(i);

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

    public T RemoveAtIndex(int index)
    {
        CheckIndex(index);

        if (index == 0)
        {
            return RemoveFirst();
        }

        ListItem<T> previousItem = GetItemAtIndex(index - 1);
        ListItem<T> item = previousItem.Next!;

        previousItem.Next = item.Next;
        Count--;

        return item.Data!;
    }

    public void InsertFirst(T item)
    {
        _head = new ListItem<T>(item, _head);
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
            throw new IndexOutOfRangeException($"Index {index} is outside the range: from 0 to {Count}");
        }

        ListItem<T> previousItem = GetItemAtIndex(index - 1);

        previousItem.Next = new ListItem<T>(item, previousItem.Next);
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
        if (_head is null)
        {
            return false;
        }

        if (Equals(_head.Data, data))
        {
            RemoveFirst();
        }

        ListItem<T> previousItem = _head;
        ListItem<T> item;

        for (item = previousItem.Next!; item != null; item = item.Next!, previousItem = previousItem.Next!)
        {
            if (Equals(item.Data, data))
            {
                previousItem.Next = item.Next;
                Count--;

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

        for (ListItem<T>? item = _head; item != null; item = item.Next)
        {
            newSinglyLinkedList.Insert(newSinglyLinkedList.Count, item.Data);
        }

        return newSinglyLinkedList;
    }

    private void CheckIndex(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new IndexOutOfRangeException($"Index {index} is outside the range: from 0 to {Count - 1}");
        }
    }
}