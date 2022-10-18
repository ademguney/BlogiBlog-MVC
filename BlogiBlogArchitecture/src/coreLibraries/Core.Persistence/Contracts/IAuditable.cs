namespace Core.Persistence.Contracts
{
    public interface IAuditable
    {
        public int CreatedById { get; set; }
        public int UpdatedById { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? UpdationTime { get; set; }
       
    }
}