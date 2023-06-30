namespace MyInterview.Test;

// https://www.hackerrank.com/challenges/frequency-queries/problem?isFullScreen=true&h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=dictionaries-hashmaps
public class FrequencyQueries
{
    public static List<int> Run(List<List<int>> queries)
    {
        var data = new Dictionary<int, int>();
        var ret = new List<int>();
        foreach (var q in queries)
        {
            switch (q[0], q[1])
            {
                case (1, var x1):
                    if (data.ContainsKey(x1))
                    {
                        data[x1]++;
                    }
                    else
                    {
                        data[x1] = 1;
                    }

                    break;
                case (2, var x2):
                    if (data.ContainsKey(x2) && data[x2] > 0)
                    {
                        data[x2]--;
                    }

                    break;
                case (3, var x3):
                    ret.Add(data.ContainsValue(x3) ? 1 : 0);
                    break;
            }
        }

        return ret;
    }
}

public class FrequencyQueriesTest
{
    [Theory]
    [MemberData(nameof(FrequencyQueriesData))]
    public void TestRun(List<List<int>> queries, List<int> retVal)
    {
        var res = FrequencyQueries.Run(queries);
        Assert.Equal(retVal, res);
    }

    public static IEnumerable<object[]> FrequencyQueriesData =>
        new List<object[]>
        {
            new object[]
            {
                new List<List<int>>
                {
                    new() { 1, 5 },
                    new() { 1, 6 },
                    new() { 3, 2 },
                    new() { 1, 10 },
                    new() { 1, 10 },
                    new() { 1, 6 },
                    new() { 2, 5 },
                    new() { 3, 2 },
                },
                new List<int> { 0, 1 }
            }
        };
}