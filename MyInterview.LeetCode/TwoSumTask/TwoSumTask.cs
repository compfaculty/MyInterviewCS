namespace MyInterview.LeetCode.TwoSumTask;

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
}