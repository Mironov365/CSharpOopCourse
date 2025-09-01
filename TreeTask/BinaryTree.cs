namespace TreeTask;

public class BinaryTree<T> 
{
    private TreeNode<T> _root;

    public BinaryTree(T data)
    {
        _root = new TreeNode<T>(data);
    }

    public BinaryTree()
    {
        _root = null;
    }

    public void Insert(T data)
    {                
        if (_root == null)
        {
            _root = new TreeNode<T>(data);
            return;
        }

        TreeNode<T> node = _root;

        if (Compare(data, node.Data))
        {
            
        }

    }

    Insert

    IsInTree

    Remove

    Count


}
