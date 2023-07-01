namespace MyInterview.LeetCode.TwoSumTask;

public class TwoSumTaskTest
{
    [Theory]
    [MemberData(nameof(TwoSumData))]
    public void TestTwoSumBetter(int[] nums, int target, int[] retVal)
    {
        Assert.Equal(retVal, TwoSumTask.Run(nums, target));
    }

    public static IEnumerable<object[]> TwoSumData =>
        new List<object[]>
        {
            new object[] { new[] { 1, 2, 3 }, 5, new[] { 1, 2 } },
            new object[] { new[] { 3, 3 }, 6, new[] { 0, 1 } },
            new object[] { new[] { 3, 2, 4 }, 6, new[] { 1, 2 } },
            new object[] { new[] { 2, 7, 11, 15 }, 9, new[] { 0, 1 } },
        };
}