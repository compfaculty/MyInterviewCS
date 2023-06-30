namespace MyInterview.Test.MarkAndToys;

public sealed class MarkAndToysTest
{
    [Theory]
    [MemberData(nameof(Data))]
    public void TestRun(List<int> arr, int r, int retVal)
    {
        var res = MarkAndToys.Run(arr, r);
        Assert.Equal(retVal, res);
    }

    public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            // new object[] { new List<int> { 1, 1, 1, 1 }, 1, 1 },
            // new object[] { new List<int> { 1, 12, 5, 111, 200, 1000, 10, }, 50, 4},

            new object[] { new List<int> { 1, 2, 2, 4 }, 2, 1 },
            new object[] { new List<int> { 1, 3, 9, 9, 27, 81 }, 3, 1 }
        };
}