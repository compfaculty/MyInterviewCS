namespace MyIntervew.Udemy.DesignPatternCourse.Iterator;

using Xunit.Abstractions;



public class InterpreterCodingExerciseTest
{
    private readonly ITestOutputHelper _output;

    public InterpreterCodingExerciseTest(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void TestInterpreterCodingExercise()
    {
        var root = new TreeNode<int>(1, new TreeNode<int>(2), new TreeNode<int>(3));
        var ret = root.PreOrder.ToArray();
        Assert.Equal(ret, new []{1,2,3});
        
    }
}