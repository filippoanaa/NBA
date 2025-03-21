using lab10.domain;

namespace lab10.repository;

public class GameRepo : InFileRepository<int, Game>
{
    public GameRepo(string filename) : base(filename, Creator.CreateGame){}
}