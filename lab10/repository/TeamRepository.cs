using lab10.domain;

namespace lab10.repository;

public class TeamRepository : InFileRepository<int, Team>
{
    public TeamRepository(string filename) : base(filename, Creator.CreateTeam){}
}