namespace MyInterview.Test;

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