namespace MyInterview.Test.TwoStrings;

public class TwoStringsTest
{
    [Theory]
    [InlineData("asd", "azx", true)]
    [InlineData("sd", "zx", false)]
    [InlineData("", "", false)]
    [InlineData("", "1234", false)]
    public void TestRun(string s1, string s2, bool retVal)
    {
        var res = TwoStrings.Run(s1, s2);
        Assert.Equal(retVal, res);
    }
}