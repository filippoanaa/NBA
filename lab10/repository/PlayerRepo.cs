using lab10.domain;

namespace lab10.repository;

public class PlayerRepo : InFileRepository<int, Player>
{
    public PlayerRepo(string filename) : base(filename, Creator.CreatePlayer){}
}