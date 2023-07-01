namespace MyInterview.Test.CountTriplets;

public class CountTripletsTest
{
    public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { new List<long> { 1, 2, 2, 4 }, 2, 2 },
            new object[] { new List<long> { 1, 3, 9, 9, 27, 81 }, 3, 6 },
            new object[] { new List<long> { 1, 1, 1, 1 }, 1, 4 }
        };

    [Theory]
    [MemberData(nameof(Data))]
    public void TestRun(List<long> arr, long r, int retVal)
    {
        var res = CountTriplets.Run(arr, r);
        Assert.Equal(retVal, res);
    }
}