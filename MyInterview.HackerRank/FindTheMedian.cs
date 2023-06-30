namespace MyInterview.Test;

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

public class FindTheMedianTest
{
    [Theory]
    [InlineData(new[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59 }, 23)]
    [InlineData(new[] { 1, 1, 1 }, 1)]
    public void TestRun(int[] data, long retVal)
    {
        var res = FindTheMedian.Run(data);
        Assert.Equal(retVal, res);
    }
}