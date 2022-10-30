namespace Blogi.Persistence.Repositories.TagRepository
{
    public class TagReadRepository : ReadRepository<Tag, BlogiBlogDbContext>, ITagReadRepository
    {
        public TagReadRepository(BlogiBlogDbContext context) : base(context)
        {
        }
    }
}