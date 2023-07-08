using MyInterview.Shared;

namespace MyIntervew.Udemy.DesignPatternCourse.Iterator;

/*
Iterator Coding Exercise
Given the following definition of a Node<T>, implement preorder traversal that returns a sequence of Ts.
*/

public class TreeNode<T> : Node<T>
{
    public TreeNode(T value) : base(value)
    {
    }

    public TreeNode(T value, Node<T> left, Node<T> right) : base(value, left, right)
    {
    }

    public IEnumerable<T> PreOrder
    {
        get
        {
            List<T> result = new List<T>();
            Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();
            stack.Push(this);

            while (stack.Count > 0)
            {
                TreeNode<T>? current = stack.Pop();
                if (current is null) continue;
                result.Add(current.Value);
              
                stack.Push((TreeNode<T>)current.Right);
               
                stack.Push((TreeNode<T>)current.Left);
            }

            return result;
        }
    }
}