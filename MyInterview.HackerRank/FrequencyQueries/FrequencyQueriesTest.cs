namespace MyInterview.Test.FrequencyQueries;

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