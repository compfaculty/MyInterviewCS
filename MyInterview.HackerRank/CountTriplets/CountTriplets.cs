namespace MyInterview.Test.CountTriplets;

// https://www.hackerrank.com/challenges/count-triplets-1/problem?isFullScreen=true&h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=dictionaries-hashmaps
public class CountTriplets
{
    public static long Run(List<long> arr, long r)
    {
        long count = 0;
        var allItems = new Dictionary<long, long>();
        var repeatedItems = new Dictionary<long, long>();
        arr.Reverse();
        foreach (var item in arr)
        {
            var xitem = item * r;
            if (repeatedItems.ContainsKey(xitem))
                count += repeatedItems[xitem];
            if (allItems.ContainsKey(xitem))
            {
                var tmp = repeatedItems.ContainsKey(item) ? repeatedItems[item] : 0;
                repeatedItems[item] = tmp + allItems[xitem];
            }

            var xtmp = allItems.ContainsKey(item) ? allItems[item] : 0;
            allItems[item] = xtmp + 1;
        }

        return count;
    }
}