namespace Core.Persistence.Repositories.Interfaces
{
    public interface IReadRepository<T>  where T : BaseDomainEntity
    {
        T Get(Expression<Func<T, bool>> predicate = null);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate = null);

        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null);
        Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> predicate = null);
    }
}
