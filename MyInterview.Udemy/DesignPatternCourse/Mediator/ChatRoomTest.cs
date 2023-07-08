using Xunit.Abstractions;

namespace MyIntervew.Udemy.DesignPatternCourse.Mediator;

public class ChatRoomTest
{
    private readonly ITestOutputHelper _output;

    public ChatRoomTest(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void TestChatRoom()
    {
        var room = new ChatRoom();

        var john = new ChatRoom.Person("John", room);
        var jane = new ChatRoom.Person("Jane", room);

        room.Join(john);
        room.Join(jane);

        john.Say("hi room");
        jane.Say("oh, hey john");

        var simon = new ChatRoom.Person("Simon", room);
        room.Join(simon);
        simon.Say("hi everyone!");

        jane.PrivateMessage("Simon", "glad you could join us!");
    }
}