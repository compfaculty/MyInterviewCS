using Xunit.Abstractions;

namespace MyIntervew.Udemy.DesignPatternCourse.Interpreter;

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
    public void TestRun(string p, int retVal)
    {
        var processor = new ExpressionProcessor();
        var ret = processor.Calculate(p);
        Assert.Equal(retVal, ret);
    }
}