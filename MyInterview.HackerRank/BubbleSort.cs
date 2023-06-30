using Xunit.Abstractions;

namespace MyInterview.Test;

public class BubbleSortTest
{
    public static List<int> Run(List<int> a)
    {
        var swapCount = 0;
        for (int i = 0; i < a.Count; i++)
        {
            for (int j = 0; j < a.Count - 1; j++)
            {
                if (a[j] <= a[j + 1]) continue;
                a[j] = a[j] + a[j + 1];
                a[j + 1] = a[j] - a[j + 1];
                a[j] = a[j] - a[j + 1];
                swapCount++;
            }
        }

        Console.WriteLine($"Array is sorted in {swapCount} swaps.");
        Console.WriteLine($"First Element: {a[0]}");
        Console.WriteLine($"Last Element: {a[a.Count - 1]}");
        return a;
    }
}

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