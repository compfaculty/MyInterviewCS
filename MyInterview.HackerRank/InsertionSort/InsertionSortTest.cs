namespace MyInterview.Test.InsertionSort;

public class InsertionSortTest
{
    public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { new[] { 3, 2, 1, 0 }, new[] { 0, 1, 2, 3 } },
            // new object[] { new[] { 1, 2, 2, 4 }, new[] { 1, 2, 2, 4 } },
            // new object[] { new int[] { }, new int[] { } },
            // new object[] { new[] { 999, 99, 9 }, new[] { 9, 99, 999 } }
        };

    [Theory]
    [MemberData(nameof(Data))]
    public void TestRun(int[] arr, int[] retVal)
    {
        var res = InsertionSort.Run(arr);
        Assert.Equal(retVal, res);
    }
}