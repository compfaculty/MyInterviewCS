namespace MyIntervew.Udemy.DesignPatternCourse.Iterator;

/*
Iterator Coding Exercise
Given the following definition of a Node<T>, implement preorder traversal that returns a sequence of Ts.
*/
public class IteratorCodingExercise
{
    public static BinaryTree CreateBinaryTree()
    {
        return new BinaryTree();
    }
}

public class BinaryTree
{
}

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

    public IEnumerable<T> PreOrder
    {
        get
        {
            List<T> result = new List<T>();
            Stack<Node<T>> stack = new Stack<Node<T>>();
            stack.Push(this);

            while (stack.Count > 0)
            {
                Node<T> current = stack.Pop();
                result.Add(current.Value);

                stack.Push(current.Right);

                stack.Push(current.Left);
            }

            return result;
        }
    }
}