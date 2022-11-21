namespace Blogi.Persistence.Repositories.ContactRepository
{
    public class ContactWriteRepository : WriteRepository<Contact, BlogiBlogDbContext>, IContactWriteRepository
    {
        public ContactWriteRepository(BlogiBlogDbContext context) : base(context)
        {
        }
    }
}