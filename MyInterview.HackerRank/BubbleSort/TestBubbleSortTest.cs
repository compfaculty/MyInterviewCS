using Xunit.Abstractions;

namespace MyInterview.Test.BubbleSort;

public class TestBubbleSortTest
{
    private readonly ITestOutputHelper _output;

    public TestBubbleSortTest(ITestOutputHelper output)
    {
        this._output = output;
    }

    [Fact]
    public void TestRun()
    {
        var ret = BubbleSortTest.Run(new List<int>(){3,2,1});
        // _output.WriteLine($"{String.Join(",", ret)}");
        Assert.Equal(new List<int>(){1,2,3}, ret);
    }
}