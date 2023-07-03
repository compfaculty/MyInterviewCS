namespace MyIntervew.Udemy.DesignPatternCourse.Iterator;

using Xunit.Abstractions;



public class InterpreterCodingExerciseTest
{
    private readonly ITestOutputHelper _output;

    public InterpreterCodingExerciseTest(ITestOutputHelper output)
    {
        _output = output;
    }

    [Theory]
    [InlineData("1+2", 3)]
    [InlineData("1+2-3", 0)]
    [InlineData("1+2+x", 103)]
    [InlineData("1+2+xy+1", 0)]
    [InlineData("0-0", 0)]
    [InlineData("q+1000", 0)]
    public void TestRun(string p, int[] retVal)
    {
        var root = new Node<int>(1);
        var ret = root.PreOrder.ToArray();
        Assert.Equal(retVal, ret);
    }
}