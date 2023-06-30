namespace MyInterview.LeetCode;

public class TwoSumTask
{
    public static int[] Run(int[] nums, int target)
    {
        var ret = new int[2];
        var found = false;
        for (int i = 0; i < nums.Length && !found; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                var tmpsum = nums[i] + nums[j];

                if (tmpsum == target)
                {
                    ret[0] = i;
                    ret[1] = j;
                    found = true;
                    break;
                }
            }
        }

        return ret;
    }

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
}