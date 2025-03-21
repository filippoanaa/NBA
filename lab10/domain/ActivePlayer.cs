namespace lab10.domain;

public class ActivePlayer : Entity<Tuple<int, int>>
{
    public int PlayerID { get; set; }
    public int GameId { get; set; }
    public int  Score {get; set;}
    public PlayerType PlayerType {get; set;}

    public ActivePlayer(int playerId, int gameId, int  score, PlayerType playerType)
    {
        ID = new Tuple<int, int>(playerId, gameId);
        PlayerID = playerId;
        GameId = gameId;
        Score = score;
        PlayerType = playerType;
    }
    
    public ActivePlayer() {}

    public override string ToString()
    {
        return "PlayerID: " + PlayerID + ", GameID: " + GameId + ", Score: " + Score + ", PlayerType: " + PlayerType;
    }
}