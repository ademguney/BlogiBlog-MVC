namespace Core.Persistence.Contracts
{
    public interface IAuditable
    {
        int CreatedById { get; set; }
        int? UpdatedById { get; set; }
        DateTime CreationDate { get; set; }
        DateTime? UpdationDate { get; set; }
    }
}