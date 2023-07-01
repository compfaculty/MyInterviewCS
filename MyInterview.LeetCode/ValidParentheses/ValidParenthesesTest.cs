namespace MyInterview.LeetCode.ValidParentheses;

public class ValidParenthesesTest
{
    [Theory]
    [InlineData("()[]", true)]
    [InlineData("()}[]", false)]
    public void TestValidParentheses(string s, bool retVal)
    {
        Assert.Equal(retVal, ValidParentheses.Run(s));
    }
}g