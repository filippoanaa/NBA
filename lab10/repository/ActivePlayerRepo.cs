using lab10.domain;

namespace lab10.repository;

public class ActivePlayerRepo : InFileRepository<Tuple<int, int>, ActivePlayer>
{
    public ActivePlayerRepo(string filename) : base(filename, Creator.CreateActivePlayer){}
}