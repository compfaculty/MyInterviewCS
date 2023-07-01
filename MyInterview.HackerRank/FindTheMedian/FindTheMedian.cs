namespace MyInterview.Test.FindTheMedian;

public class FindTheMedian
{
    public static long Run(int[] arr)
    {
        Array.Sort(arr);
        var length = arr.Length;
        var oddeven = length % 2;
        var middle = length / 2;
        return oddeven switch
        {
            1 => arr[length / 2],
            0 => (arr[middle] + arr[middle - 1]) / 2,
            _ => throw new ArithmeticException()
        };
    }
}