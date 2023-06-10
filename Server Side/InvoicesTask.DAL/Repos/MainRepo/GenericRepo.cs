namespace InvoicesTask.DAL;

public class GenericRepo<T> : IGenericRepo<T> where T : class
{
    private readonly ApplicationDbContext _context;
    public GenericRepo(ApplicationDbContext context)
    {
        _context = context;
    }
    public T Add(T entity)
    {
        _context.Set<T>().Add(entity);
        return entity;
    }

    public List<T> AddCollection(List<T> entities)
    {
        _context.Set<T>().AddRange(entities);
        return entities;
    }
}
