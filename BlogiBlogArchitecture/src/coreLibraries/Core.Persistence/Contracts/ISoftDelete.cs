namespace Core.Persistence.Contracts
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
        DateTime? DeletionTime { get; set; }
    }
}