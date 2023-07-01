namespace MyInterview.Test.SherlockTasks;

public class SherlockAndCostTest
{
    [Theory]
    [InlineData(new[] { 1, 2, 3, 4 }, 5)]
    public void TestRun(int[] data, int retVal)
    {
        var res = SherlockAndCost.Run(data);
        Assert.Equal(retVal, res);
    }
}