namespace Core.Persistence.Repositories.Interfaces
{
    public interface IWriteRepository<T> where T : BaseDomainEntity
    {
        T Add(T entity);
        Task<T> AddAsync(T entity);

        T Update(T entity);
        Task<T> UpdateAsync(T entity);

        T Delete(T entity);
        Task<T> DeleteAsync(T entity);
    }
}
