namespace lab10.domain;

public class Team : Entity<int>
{
    public string Name { get; set; }

    public Team(int id, string name)
    {
        ID = id;
        Name = name;
    }

    public Team() { }

    public override string ToString()
    {
        return this.ID + " | " + this.Name;
    }
}