using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace SuperStoreAPI.SQL.Context.Interfaces
{
    public interface ISuperStoreContext
    {
        public DbSet<T> Set<T>() where T : class;
        public EntityEntry<T> Add<T>(T entity) where T : class;
        public EntityEntry<T> Update<T>(T entity) where T : class;
        public EntityEntry<T> Remove<T>(T entity) where T : class;
        public int SaveChanges();
        public void AddRange(IEnumerable<object> entities);
        public ChangeTracker GetChangeTracker();
    }
}
