namespace Blogi.Persistence.Repositories.TagRepository
{
    public class TagWriteRepository : WriteRepository<Tag, BlogiBlogDbContext>, ITagWriteRepository
    {
        public TagWriteRepository(BlogiBlogDbContext context) : base(context)
        {
        }
    }
}
