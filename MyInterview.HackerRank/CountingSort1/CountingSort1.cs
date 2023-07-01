namespace MyInterview.Test;

//https://www.hackerrank.com/challenges/countingsort1/problem
public class CountingSort1
{
    public static int[] Run(int[] arr)
    {
        int[] ret = new int[arr.Length];
        foreach (int item in arr)
        {
            ret[item]++;
        }

        return new ArraySegment<int>(ret, 0, 100).ToArray();
    }
}