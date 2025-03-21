namespace lab10.domain;

public class Game : Entity<int>
{
    public Team FirstTeam { get; set; }
    public Team SecondTeam { get; set; }
    public DateTime Date { get; set; }

    public Game(int id, Team firstTeam, Team secondTeam, DateTime date)
    {
        ID = id;
        FirstTeam = firstTeam;
        SecondTeam = secondTeam;
        Date = date;
    }
    
    public Game() {}
    public override string ToString()
    {
        return ID + " : " + FirstTeam.Name + " : " + SecondTeam.Name + " : " + Date.ToShortDateString();
    }
}