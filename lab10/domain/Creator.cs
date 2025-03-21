namespace lab10.domain;

public class Creator
{
    public static Game CreateGame(string line)
    {
        string[] fields = line.Split(';');
        
        int id = int.Parse(fields[0]);
        
        Team firstTea = new Team(int.Parse(fields[1]), fields[2]);

        Team secondTeam = new Team(int.Parse(fields[3]), fields[4]);
            
        DateTime date = DateTime.Parse(fields[5]);
        
        return new Game(id, firstTea, secondTeam, date);
    }

    public static Player CreatePlayer(string line)
    {
        string[] fields = line.Split(';');
       return new Player(int.Parse(fields[0]), fields[1], fields[2], new Team(int.Parse(fields[3]), fields[4]));
        
    }

    public static Student CreateStudent(string line)
    {
        string[] fields = line.Split(';');
        return new Student(int.Parse(fields[0]), fields[1], fields[2]);
    }

    public static Team CreateTeam(string line)
    {
        string[] fields = line.Split(';');
        return new Team(int.Parse(fields[0]), fields[1]);
    }

    public static ActivePlayer CreateActivePlayer(string line)
    {
        string[] fields = line.Split(';');

        PlayerType type;
        if (fields[3] == "Substitute")
            type = PlayerType.Substitute;
        else
            type = PlayerType.Participant;

        ActivePlayer activePlayer = new ActivePlayer()
        {
            ID = new Tuple<int, int>(int.Parse(fields[0]), int.Parse(fields[1])),
            PlayerID = int.Parse(fields[0]),
            GameId = int.Parse(fields[1]),
            Score = int.Parse(fields[2]),
            PlayerType = type
        };
            
        return activePlayer;

    }
    
    
}