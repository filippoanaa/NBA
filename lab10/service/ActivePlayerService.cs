using lab10.domain;
using lab10.repository;

namespace lab10.service;

public class ActivePlayerService
{
    private IRepository<Tuple<int, int>, ActivePlayer> activePlayerRepository;
    private IRepository<int, Player> playerRepository;

    public ActivePlayerService(IRepository<Tuple<int, int>, ActivePlayer> activePlayerRepository, IRepository<int, Player> playerRepository)
    {
        this.activePlayerRepository = activePlayerRepository;
        this.playerRepository = playerRepository;
    }

    public IEnumerable<ActivePlayer> GetAllActivePlayers()
    {
        return activePlayerRepository.FindAll();
    }

    public IEnumerable<ActivePlayer> GetActivePlayersByGameAndTeam(Game game, Team team)
    {
        if (!game.FirstTeam.Name.Equals(team.Name) && !game.SecondTeam.Name.Equals(team.Name))
            throw new Exception(team.Name + " doesn't play in this game");

        var allActivePlayers = activePlayerRepository.FindAll(); //toti jucatorii activi 

        var playersFromTeam = playerRepository.FindAll().Where(p => p.Team.ID.Equals(team.ID)); // jucatorii din team
        
        var activePlayersFromGame = allActivePlayers.Where(p => p.GameId.Equals(game.ID)); //jucatorii activi din game

        var activePlayersFromTeam = from activePlayer in activePlayersFromGame 
                                                        join player in playersFromTeam
                                                        on activePlayer.ID.Item1 equals player.ID
                                                        select activePlayer;

        return activePlayersFromTeam;
    }

    public Tuple<int, int>  GetScoreFromAGame(Game game)
    {
        
        Team team1 = game.FirstTeam;
        Team team2 = game.SecondTeam;
        
        var activePlayersFromTeam1 = GetActivePlayersByGameAndTeam(game, team1);
        var activePlayersFromTeam2 = GetActivePlayersByGameAndTeam(game, team2);
        
        var score1 = activePlayersFromTeam1.Sum(p => p.Score);
        var score2 = activePlayersFromTeam2.Sum(p => p.Score);
        
        return new Tuple<int, int>(score1, score2);
        
    }
    
    
}