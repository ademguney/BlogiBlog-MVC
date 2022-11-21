namespace Blogi.Persistence.Repositories.AboutRepository
{
    public class AboutReadRepository : ReadRepository<About, BlogiBlogDbContext>, IAboutReadRepository
    {
        public AboutReadRepository(BlogiBlogDbContext context) : base(context)
        {
        }
    }
}