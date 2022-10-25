namespace Blogi.Persistence.Repositories.StringResourceRepository
{
    public class StringResourceReadRepository : ReadRepository<StringResource, BlogiBlogDbContext>, IStringResourceReadRepository
    {
        public StringResourceReadRepository(BlogiBlogDbContext context) : base(context)
        {
        }
    }
}
