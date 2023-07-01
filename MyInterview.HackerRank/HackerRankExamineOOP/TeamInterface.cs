namespace MyInterview.Test;

public class Team
{
    public Team(string teamName, int noOfPlayers)
    {
        this.teamName = teamName;
        this.noOfPlayers = noOfPlayers;
    }
    
    public string teamName { get; set; }
    public int noOfPlayers { get; set; }

    public void AddPlayer(int count)
    {
        noOfPlayers += count;
    }

    public bool RemovePlayer(int count)
    {
        if (noOfPlayers - count < 0) return false;
        noOfPlayers -= count;
        return true;
    }
}

public class Subteam : Team
{
    public Subteam(string teamName, int noOfPlayers) : base(teamName, noOfPlayers)
    {
    }

    public void ChangeTeamName(string name)
    {
        teamName = name;
    }
}