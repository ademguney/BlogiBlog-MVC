using Core.Persistence.Repositories.Interfaces;

namespace Core.Persistence.Repositories.Abstracts
{
    public class ReadRepository<TEntity, TContext> : IReadRepository<TEntity>
        where TEntity : BaseDomainEntity
        where TContext : DbContext
    {
        protected TContext Context;

        public ReadRepository(TContext context)
        {
            Context = context;
        }

        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            return Context.Set<TEntity>().AnyAsync(predicate);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate = null)
        {
            return Context.Set<TEntity>().FirstOrDefault(predicate);
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate == null)
                return Context.Set<TEntity>().AsQueryable();
            else
                return Context.Set<TEntity>().Where(predicate);
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            return await Context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate == null)
                return Context.Set<TEntity>().ToList();
            else
                return await Context.Set<TEntity>().Where(predicate).ToListAsync();
        }
    }
}

