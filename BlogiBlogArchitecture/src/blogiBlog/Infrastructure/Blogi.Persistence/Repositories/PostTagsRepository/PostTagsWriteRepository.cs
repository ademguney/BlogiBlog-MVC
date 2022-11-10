namespace Blogi.Persistence.Repositories.PostTagsRepository
{
    public class PostTagsWriteRepository : WriteRepository<PostTags, BlogiBlogDbContext>, IPostTagsWriteRepository
    {
        public PostTagsWriteRepository(BlogiBlogDbContext context) : base(context)
        {
        }
    }
}