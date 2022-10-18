namespace Core.Persistence.Contracts
{
    public interface ISoftDelete
    {
        public bool IsDeleted { get; set; }
        public DateTime? DeletionTime { get; set; }        
    }
}