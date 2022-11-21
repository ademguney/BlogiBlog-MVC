namespace Blogi.Persistence.Repositories.AboutRepository
{
    public class AboutWriteRepository : WriteRepository<About, BlogiBlogDbContext>, IAboutWriteRepository
    {
        public AboutWriteRepository(BlogiBlogDbContext context) : base(context)
        {
        }
    }
}