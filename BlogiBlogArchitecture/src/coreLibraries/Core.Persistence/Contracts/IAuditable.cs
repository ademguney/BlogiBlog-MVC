namespace Core.Persistence.Contracts
{
    public interface IAuditable
    {
        int CreatedById { get; set; }
        //int UpdatedById { get; set; }
        DateTime CreationTime { get; set; }
        //DateTime? UpdationTime { get; set; }

    }
}