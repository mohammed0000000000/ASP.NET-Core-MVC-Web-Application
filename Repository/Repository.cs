using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace TechWebApplication.Repository
{
    public class Repository<T, K> : IRepository<T, K> where T : class
    {
        private DbContext context;
        protected DbSet<T> entitySet;  
        public Repository(DbContext context) {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.entitySet = context.Set<T>();
        }
        public async Task<T> Create(T entity) {
            await entitySet.AddAsync(entity);
            await context.SaveChangesAsync();
            context.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public async Task AddRange(List<T> entities) {
            await entitySet.AddRangeAsync(entities);
            await context.SaveChangesAsync();
        }

        public async Task<bool> Delete(T entity) {
            entitySet.Attach(entity);
            entitySet.Remove(entity);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteById(int id) {
            var entity = await entitySet.FindAsync(id);
            if (entity is null)
                return false;
            entitySet.Remove(entity);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<IQueryable<T>> GetAll(bool includeSoftedDeleted = false) {
            return includeSoftedDeleted ? entitySet.AsNoTracking().IgnoreQueryFilters() : entitySet.AsNoTracking();
        }

        public async Task<T> GetbyId(int id) {
            var entity = await entitySet.FindAsync(id);
            if (entity is null) return null;
            context.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public async Task<bool> Update(T entity) {
            entitySet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified; 
            await context.SaveChangesAsync();
            context.Entry(entity).State = EntityState.Detached;
            return true;
        }
    }
}
