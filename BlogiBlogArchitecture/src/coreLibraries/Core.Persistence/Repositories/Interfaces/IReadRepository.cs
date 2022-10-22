namespace Core.Persistence.Repositories.Interfaces
{
    public interface IReadRepository<T>  where T : BaseDomainEntity
    {
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate = null);
        T Get(Expression<Func<T, bool>> predicate = null);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate = null);

        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null);
        Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> predicate = null);
    }
}
