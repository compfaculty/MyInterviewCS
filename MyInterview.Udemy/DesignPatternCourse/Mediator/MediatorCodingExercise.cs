namespace MyIntervew.Udemy.DesignPatternCourse.Mediator;

public class MediatorCodingExercise
{
    
}
public class Participant
{
    private readonly Mediator _mediator;
    public int Value { get; set; }

    public Participant(Mediator mediator)
    {
        _mediator = mediator;
    }

    public void Say(int n)
    {
        _mediator.Broadcast(this, n);
    }
}

public class Mediator
{
    private readonly List<Participant> _participants = new();
    public void Broadcast(Participant sender, int i)
    {
        foreach (var p in _participants)
        {
            if (sender != p) p.Value = i;
        }
    }

    public void Join(Participant p)
    {
        _participants.Add(p);
    }
}