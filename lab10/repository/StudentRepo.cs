using lab10.domain;

namespace lab10.repository;

public class StudentRepo : InFileRepository<int, Student>
{
    public StudentRepo(string filename) : base(filename, Creator.CreateStudent){}
}