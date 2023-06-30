namespace MyInterview.Test.MarkAndToys;

// https://www.hackerrank.com/challenges/mark-and-toys/problem?isFullScreen=true&h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=sorting&h_r=next-challenge&h_v=zen
public class MarkAndToys
{
    public static int Run(List<int> prices, int k)
    {
        int count = 0;
        int total = 0;
       
        prices.Sort();
        var arr = prices.Where(i => i <= k).ToArray();
        for (int i = 0; total <= k && i < arr.Length; i++)
        {
            total += prices[i];
            if (total >= k) return count;
            count++;
        }

        return count;
    }
}