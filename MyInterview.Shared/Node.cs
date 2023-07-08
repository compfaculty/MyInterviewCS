namespace MyInterview.Shared;

public class Node<T>
{
    public T Value;
    public Node<T> Left = null!, Right = null!;
    public Node<T> Parent = null!;

    public Node(T value)
    {
        Value = value;
    }

    public Node(T value, Node<T> left, Node<T> right)
    {
        Value = value;
        Left = left;
        Right = right;

        left.Parent = right.Parent = this;
    }
}