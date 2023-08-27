using SuperStoreAPI.SQL.Models;
using System.Linq.Expressions;

namespace SuperStoreAPI.SQL.Repositories.Interfaces
{
    public interface IRepository<T> : IDependencyScoped where T : class
    {
        T Add(T entity);
        List<T> AddRange(List<T> entities);
        IQueryable<T> GetAll();
        IQueryable<T> GetAllNoTracking();
        T? GetSingle(Expression<Func<T, bool>> predicate);
        T? GetSingleNoTracking(Expression<Func<T, bool>> predicate);
        T? GetSingle(params object?[]? keyValues);
        public T Update(T entity, T oldEntity);
        T Remove(T entity);
        int SaveChanges();
    }
    public interface IProductsRepository : IRepository<Product>
    {

    }
}
