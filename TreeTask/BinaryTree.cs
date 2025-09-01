using System.Text;

namespace TreeTask;

public class BinaryTree<T> where T : IComparable<T>
{
    private TreeNode<T>? _root;

    public BinaryTree(T data)
    {
        _root = new TreeNode<T>(data);
    }

    public BinaryTree()
    {
        _root = null;
    }

    private void InsertWithRecursion(TreeNode<T> node, T data)
    {
        if (data.CompareTo(node.Data) < 0)
        {
            if (node.Left != null)
            {
                InsertWithRecursion(node.Left, data);
            }
            else
            {
                node.Left = new TreeNode<T>(data);
            }
        }
        else
        {
            if (node.Right != null)
            {
                InsertWithRecursion(node.Right, data);
            }
            else
            {
                node.Right = new TreeNode<T>(data);
            }
        }
    }

    public void Insert(T data)
    {
        if (_root == null)
        {
            _root = new TreeNode<T>(data);
            return;
        }

        TreeNode<T> node = _root;

        InsertWithRecursion(node, data);
    }

    private bool IsInTreeWithRecusrion(TreeNode<T> node, T data)
    {
        if (Equals(node.Data, data))
        {
            return true;
        }
        else if (data.CompareTo(node.Data) < 0)
        {
            if (node.Left != null)
            {
                return IsInTreeWithRecusrion(node.Left, data);
            }
            else
            {
                return false;
            }
        }
        else
        {
            if (node.Right != null)
            {
                return IsInTreeWithRecusrion(node.Right, data); ;
            }
            else
            {
                return false;
            }
        }
    }

    public bool IsInTree(T data)
    {
        if (_root == null)
        {
            return false;
        }

        TreeNode<T> node = _root;

        return IsInTreeWithRecusrion(node, data);
    }

    private TreeNode<T> FindNode(TreeNode<T> node, T data)
    {
        if (Equals(node.Data, data))
        {
            return node;
        }

        if (data.CompareTo(node.Data) < 0)
        {
            if (node.Left != null)
            {
                FindNode(node.Left, data);
            }
            else
            {
                return;
            }
        }
    }
    
    public bool Remove(T data)
    {
        if (_root == null)
        {
            return false;
        }

       


    }

    //Remove

    // Count


}
