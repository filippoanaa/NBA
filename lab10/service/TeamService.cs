using lab10.domain;
using lab10.repository;

namespace lab10.service;

public class TeamService
{
    private IRepository<int, Team> repository;

    public TeamService(IRepository<int, Team> repository)
    {
        this.repository = repository;
    }

    public Team AddTeam(Team team)
    {
        if(repository.FindOne(team.ID) != null)
            throw new Exception("Team with this id already exists");
        
        return repository.Save(team);
            
    }

    public void DeleteTeam(int id)
    {
        Team team = repository.FindOne(id);
        if(team == null)
            throw new Exception("Team with this id does not exist");
        repository.Delete(id);
    }

    public Team GetTeamByName(string name)
    {
        List<Team> teams = repository.FindAll().ToList();
        var result = teams.Where(x => x.Name.Equals(name)).ToList();
        Team team = result.FirstOrDefault();
        if(team == null)
            throw new Exception("Team with this name does not exist");
        return team;
    }

    public IEnumerable<Team> GetAllTeams()
    {
        return repository.FindAll();
    }
    
    
}