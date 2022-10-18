namespace Core.Persistence.Common
{
    public class BaseDomainEntity
    {
        public BaseDomainEntity() { }

        public BaseDomainEntity(int id) : this() { Id = id; }

        public int Id { get; set; }
    }
}
