using Microsoft.EntityFrameworkCore;
using SuperStoreAPI.SQL.Context.Interfaces;
using SuperStoreAPI.SQL.Models;
using SuperStoreAPI.SQL.Repositories.Interfaces;
using System.Linq.Expressions;

namespace SuperStoreAPI.SQL
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        internal ISuperStoreContext superStoreContext;

        public Repository(ISuperStoreContext superStoreContext)
        {
            this.superStoreContext = superStoreContext;
        }
        public IQueryable<T> GetAll()
        {
            return superStoreContext.Set<T>();
        }
        public IQueryable<T> GetAllNoTracking()
        {      
            return superStoreContext.Set<T>().AsNoTracking();
        }
        public T? GetSingle(params object?[]? keyValues)
        {
            return superStoreContext.Set<T>().Find(keyValues);
        }
        public T? GetSingle(Expression<Func<T, bool>> predicate)
        {
            return superStoreContext.Set<T>().FirstOrDefault(predicate);
        }
        public T? GetSingleNoTracking(Expression<Func<T, bool>> predicate)
        {
            return superStoreContext.Set<T>().AsNoTracking().FirstOrDefault(predicate);
        }
        public T Add(T entity)
        {
            superStoreContext.Add(entity);
            return entity;
        }
        public List<T> AddRange(List<T> entities)
        {
            superStoreContext.AddRange(entities);
            return entities;
        }
        public T Update(T entity, T oldEntity)
        {
            oldEntity = entity;
            superStoreContext.Update(oldEntity);
            return oldEntity;
        }
        public T Remove(T entity)
        {
            superStoreContext.Remove(entity);
            return entity;
        }
        public int SaveChanges()
        {
            return superStoreContext.SaveChanges();
        }
    }
    public class ProductRepository : Repository<Product>, IProductsRepository
    {
        public ProductRepository(ISuperStoreContext SuperStoreContext) : base(SuperStoreContext) { }
    }
} 