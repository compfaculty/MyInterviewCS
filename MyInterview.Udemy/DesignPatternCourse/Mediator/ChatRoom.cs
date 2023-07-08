namespace MyIntervew.Udemy.DesignPatternCourse.Mediator;

using static Console;

public class ChatRoom
{
    private readonly List<Person> _people = new();

    public class Person
    {
        internal readonly string Name;
        private ChatRoom _room;
        private readonly List<string> _chatLog = new();

        public Person(string name, ChatRoom chatRoom)
        {
            Name = name;
            _room = chatRoom;
        }

        public void Receive(string sender, string message)
        {
            string s = $"{sender}: '{message}'";
            WriteLine($"[{Name}'s chat session] {s}");
            _chatLog.Add(s);
        }

        public void Say(string message)
        {
            _room.Broadcast(Name, message);
        }

        public void PrivateMessage(string who, string message)
        {
            _room.Message(Name, who, message);
        }
    }

    private void Message(string source, string destination, string message)
    {
        _people.FirstOrDefault(p => p.Name == destination)?.Receive(source, message);
    }

    private void Broadcast(string source, string message)
    {
        foreach (var p in _people)
            if (p.Name != source)
                p.Receive(source, message);
    }

    public void Join(Person person)
    {
        _people.Add(person);
    }
}