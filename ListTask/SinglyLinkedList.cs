using System.Text;

namespace ListTask;
public class SinglyLinkedList<T>
{
    private ListItem<T> _head;
    private int _count = 1;

    public SinglyLinkedList(ListItem<T> head)
    {
        _head = head;
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();

        for (ListItem<T> item = _head; item != null; item = item.Next)
        {
            stringBuilder.Append(item.Data);

            if (item.Next != null)
            {
                stringBuilder.Append(", ");
            }
        }

        return stringBuilder.ToString();
    }

    public int GetCount()
    {
        return _count;
    }

    public T GetHeadData()
    {
        return _head.Data;
    }

    public T GetDataAtIndex(int index)
    {
        if (_head == null)
        {
            throw new InvalidOperationException("List is empty");
        }

        if (index < 0 || index >= _count)
        {
            throw new IndexOutOfRangeException("Index is outside the count of list's elements");
        }

        ListItem<T> item = _head;

        for (int i = 0; i < index; i++)
        {
            item = item.Next;
        }

        return item.Data;
    }

    public T SetDataAtIndex(int index, T newData)
    {
        if (_head == null)
        {
            throw new InvalidOperationException("List is empty");
        }

        if (index < 0 || index >= _count)
        {
            throw new IndexOutOfRangeException("Index is outside the count of list's elements");
        }

        ListItem<T> item = _head;

        for (int i = 0; i < index; i++)
        {
            item = item.Next;
        }

        T oldData = item.Data;
        item.Data = newData;

        return oldData;
    }

    public T RemoveAtIndex(int index)
    {
        if (_head == null)
        {
            throw new InvalidOperationException("List is empty");
        }

        if (index < 0 || index >= _count)
        {
            throw new IndexOutOfRangeException("Index is outside the count of list's elements");
        }

        if (index == 0)
        {
            throw new InvalidOperationException("For this operation you should use RemoveAtBeginning method");
        }

        ListItem<T> item = _head.Next;
        ListItem<T> previousItem = _head;
        ListItem<T> nextItem = _head.Next.Next;

        for (int i = 1; i < index; i++)
        {
            item = item.Next;
            previousItem = previousItem.Next;
            nextItem = nextItem.Next;
        }

        previousItem.Next = nextItem;
        _count--;

        return item.Data;
    }

    public void InsertAtBeginning(ListItem<T> item)
    {
        ArgumentNullException.ThrowIfNull(item);

        _head = new ListItem<T>(item.Data, _head);
        _count++;
    }

    public void InsertAtIndex(int index, ListItem<T> item)
    {
        ArgumentNullException.ThrowIfNull(item);

        if (index < 0 || index > _count)
        {
            throw new IndexOutOfRangeException("Index is outside the count of list's elements");
        }

        if (index == 0)
        {
            throw new InvalidOperationException("For this operation you should use InsertAtBeginning method");
        }

        ListItem<T> currentItem = _head.Next;
        ListItem<T> previousItem = _head;

        for (int i = 1; i < index; i++)
        {
            currentItem = currentItem.Next;
            previousItem = previousItem.Next;
        }

        previousItem.Next = item;
        item.Next = currentItem;
        _count++;
    }

    public T RemoveAtBeginning()
    {
        T data = _head.Data;

        if (_head.Next == null)
        {
            throw new InvalidOperationException("The list has only one item. You can't remove it");
        }

        _head = _head.Next;
        _count--;

        return data;
    }

    public bool Remove(T data)
    {
        ListItem<T> item = _head;

        for (int i = 0; i < _count; i++)
        {
            if (item.Data.Equals(data))
            {
                RemoveAtIndex(i);
                return true;
            }

            item = item.Next;
        }

        return false;
    }

    public void Reverse()
    {
        if (_count <= 1)
        {
            throw new InvalidOperationException("List has only one item. It can't be Revered");
        }

        ListItem<T> previousItem = _head;
        ListItem<T> currentItem = _head.Next;
        ListItem<T> nextItem;

        _head.Next = null;

        while (currentItem != null)
        {
            nextItem = currentItem.Next;

            currentItem.Next = previousItem;

            previousItem = currentItem;
            currentItem = nextItem;
        }

        _head = previousItem;
    }

    public static SinglyLinkedList<T> Copy(SinglyLinkedList<T> singlyLinkedList)
    {
        T headData = singlyLinkedList.GetHeadData();
        ListItem<T> newHead = new ListItem<T>(headData);

        SinglyLinkedList<T> newSinglyLinkedList = new(newHead);

        for (int i = 1; i < singlyLinkedList._count; i++)
        {
            newSinglyLinkedList.InsertAtIndex(i, new ListItem<T>(singlyLinkedList.GetDataAtIndex(i)));
        }

        return newSinglyLinkedList;
    }
}