using lab10.domain;
using lab10.repository;

namespace lab10.service;

public class PlayerService
{
    private IRepository<int, Player> repository;

    public PlayerService(IRepository<int, Player> repository)
    {
        this.repository = repository;
    }

    public IEnumerable<Player> GetAllPlayers()
    {
        return repository.FindAll();
    }

    public IEnumerable<Player> GetPlayersByTeam(Team team)
    {
        List<Player> players = GetAllPlayers().ToList();
        List<Player> playersByTeam = players.Where(p => p.Team.Name.Equals(team.Name)).ToList();
        if (playersByTeam.Count == 0)
            throw new Exception($"Team {team} does not have any players");
        return playersByTeam;
    }

    public Player GetPlayerById(int id)
    {
        Player player = repository.FindOne(id);
        if(player == null)
            throw new Exception($"Player with id {id} does not exist");
        return player;
    }
}