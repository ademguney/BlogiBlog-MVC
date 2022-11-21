namespace Blogi.Persistence.Repositories.ContactRepository
{
    public class ContactReadRepository : ReadRepository<Contact, BlogiBlogDbContext>, IContactReadRepository
    {
        public ContactReadRepository(BlogiBlogDbContext context) : base(context)
        {
        }
    }
}