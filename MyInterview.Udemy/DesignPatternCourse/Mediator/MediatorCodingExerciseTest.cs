using Xunit.Abstractions;

namespace MyIntervew.Udemy.DesignPatternCourse.Mediator;

public class MediatorCodingExerciseTest
{
    private readonly ITestOutputHelper _output;
   
    public MediatorCodingExerciseTest(ITestOutputHelper output)
    {
        _output = output;
    }
    [Fact]
    public void TestChatMediatorCodingExercise()
    {
        var room = new Mediator();

        var john = new Participant(room);
        var jane = new Participant(room);

        room.Join(john);
        room.Join(jane);
        // _output.WriteLine($"john {john.Value},jane {jane.Value}");
        john.Say(2);
        Assert.Equal(2, jane.Value);
        Assert.Equal(0, john.Value);
        // _output.WriteLine($"john {john.Value},jane {jane.Value}");
        jane.Say(3);
        Assert.Equal(2, jane.Value);
        Assert.Equal(3, john.Value);
        // _output.WriteLine($"john {john.Value},jane {jane.Value}");

    }
}