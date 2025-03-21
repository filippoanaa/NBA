using lab10.domain;

namespace lab10.repository;

public class InMemoryRepository<ID, E> : IRepository<ID, E> where E : Entity<ID>
{
    protected IDictionary<ID, E> entities = new Dictionary<ID, E>();

    public InMemoryRepository() { }

    public E FindOne(ID id)
    {
        if (id == null)
            throw new ArgumentNullException("ID must not be null");
        return entities[id];
    }

    public IEnumerable<E> FindAll()
    {
        return entities.Values;
    }

    public E Save(E entity)
    {
        if (entity == null)
            throw new ArgumentNullException("Entity must not be null");

        if (entities.ContainsKey(entity.ID))
            return entities[entity.ID];
        entities.Add(entity.ID, entity);
        return null;
    }

    public E Delete(ID id)
    {
        if (id == null)
            throw new ArgumentNullException("ID must not be null");

        E entity = FindOne(id);
        entities.Remove(id);
        return entity;
    }

    public E Update(E entity)
    {
        if (entity == null)
            throw new ArgumentNullException("entity must not be null");

        if (FindOne(entity.ID) == null)
        {
            return Save(entity);
        }
        else
        {
            entities[entity.ID] = entity;
            return default(E);
        }
    }
}