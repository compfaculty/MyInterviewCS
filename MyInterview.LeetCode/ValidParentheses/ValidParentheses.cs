namespace MyInterview.LeetCode.ValidParentheses;

public class ValidParentheses
{
    public static bool Run(string s)
    {
        var data = new Stack<char>(s.Length);
        foreach (var ch in s)
        {
            if (ch.Equals('[') || ch.Equals('(') || ch.Equals('{'))
                data.Push(ch);
            else
            {
                if (data.Count == 0) return false;
                var tmp = data.Pop();
                if (!ch.Equals((char)(tmp + (tmp == 40 ? 1 : 2)))) return false;
            }
        }

        return data.Count == 0;
    }
}