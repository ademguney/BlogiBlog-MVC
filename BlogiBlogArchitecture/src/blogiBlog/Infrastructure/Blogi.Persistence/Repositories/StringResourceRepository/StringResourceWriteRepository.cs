namespace Blogi.Persistence.Repositories.StringResourceRepository
{
    public class StringResourceWriteRepository : WriteRepository<StringResource, BlogiBlogDbContext>, IStringResourceWriteRepository
    {
        public StringResourceWriteRepository(BlogiBlogDbContext context) : base(context)
        {
        }
    }
}
