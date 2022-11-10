namespace Blogi.Persistence.Repositories.PostTagsRepository
{
    public class PostTagsReadRepository : ReadRepository<PostTags, BlogiBlogDbContext>, IPostTagsReadRepository
    {
        public PostTagsReadRepository(BlogiBlogDbContext context) : base(context)
        {
        }
    }
}