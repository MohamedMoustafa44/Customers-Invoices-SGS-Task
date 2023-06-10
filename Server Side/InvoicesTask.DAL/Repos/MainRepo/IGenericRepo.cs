using System.Linq.Expressions;

namespace InvoicesTask.DAL;

public interface IGenericRepo<T> where T : class
{
    public T Add(T entity);
    public List<T> AddCollection(List<T> entities);
}
