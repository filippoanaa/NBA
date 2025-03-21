using lab10.domain;

namespace lab10.repository;

public delegate E CreateEntity<E>(string line);

public abstract class InFileRepository<ID, E> : InMemoryRepository<ID, E> where E : Entity<ID>
{
    protected string fileName;
    protected CreateEntity<E> createEntity;


    protected InFileRepository(string fileName, CreateEntity<E> createEntity) 
    {
        this.fileName = fileName;
        this.createEntity = createEntity;
        if (createEntity != null)
        {
            LoadFromFile();
        }
    }

    protected virtual void LoadFromFile()
    {
        List<E> list = new List<E>();
        using (StreamReader sr = new StreamReader(fileName))
        {
            string s;
            while ((s = sr.ReadLine()) != null)
            {
                E entity = createEntity(s);
                list.Add(entity);
            }
        }

        foreach (var x in list)
            entities[x.ID] = x;
    }
}