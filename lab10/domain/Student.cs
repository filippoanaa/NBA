namespace lab10.domain;

public class Student :Entity<int>
{
    public string Name { get; set; }
    
    public string School { get; set; }

    public Student(int id,string  name, string school)
    {
        ID = id;
        Name = name;
        School = school;
    }

    public Student() {}
    
    public override string ToString()
    {
        return ID + " | " + Name + " | " + School;
    }
}