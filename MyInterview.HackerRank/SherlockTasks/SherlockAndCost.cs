namespace MyInterview.Test.SherlockTasks;

// https://www.hackerrank.com/challenges/sherlock-and-cost/
public class SherlockAndCost
{
    public static int Run(int[] data)
    {
        var N = data.Length;
        int[,] dp = new int[N, 2];
        for (int i = 0; i < N - 1; i++)
        {
            dp[i + 1, 0] = Math.Max(dp[i, 0], dp[i, 1] + Math.Abs(1 - data[i]));
            dp[i + 1, 1] = Math.Max(dp[i, 0] + Math.Abs(data[i + 1] - 1), dp[i, 1] + Math.Abs(data[i + 1] - data[i]));
        }

        return Math.Max(dp[N - 1, 0], dp[N - 1, 1]);
    }
}