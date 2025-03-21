using lab10.domain;
using lab10.repository;

namespace lab10.service;

public class GameService
{
    private IRepository<int, Game> repository;
    public GameService(IRepository<int, Game> repository)
    {
        this.repository = repository;
    }

    public Game GetGameByTeamNames(string firstTeam, string secondTeam)
    {
        List<Game> games = repository.FindAll().ToList();
        
        Game game = games.Where(g => (g.FirstTeam.Name.Equals(firstTeam) && g.SecondTeam.Name.Equals(secondTeam))||
                                     (g.FirstTeam.Equals(secondTeam) && g.SecondTeam.Equals(firstTeam))).FirstOrDefault();
        if (game == null)
        {
            throw new Exception("Game not found");
        }
        return game;
    }


    public IEnumerable<Game> GetAllFromPeriod(DateTime firstDate, DateTime secondDate)
    {
        List<Game> games = repository.FindAll().ToList();
        
        return games.Where(game => game.Date >= firstDate && game.Date <= secondDate);
    }
}