namespace MyInterview.Test.SherlockTasks;

public class SherlockAndAnagramsTest
{
    [Theory]
    [InlineData("abba", 4)]
    [InlineData("abcd", 0)]
    [InlineData("", 0)]
    public void TestRun(string s, int retVal)
    {
        var res = SherlockTasks.SherlockAndAnagrams.Run(s);
        Assert.Equal(retVal, res);
    }
}