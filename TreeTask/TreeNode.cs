namespace TreeTask;

public class TreeNode<T> where T : IComparable<T>
{
    public TreeNode<T>? Left { get; set; }

    public TreeNode<T>? Right { get; set; }

    public T? Data;

    public TreeNode(T data)
    {
        Data = data;
        Left = null;
        Right = null;
    }


}
