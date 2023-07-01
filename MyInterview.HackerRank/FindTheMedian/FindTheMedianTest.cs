namespace MyInterview.Test.FindTheMedian;

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