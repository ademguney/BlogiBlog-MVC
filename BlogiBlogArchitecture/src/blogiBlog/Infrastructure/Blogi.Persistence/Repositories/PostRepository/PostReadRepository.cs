namespace Blogi.Persistence.Repositories.PostRepository
{
    public class PostReadRepository : ReadRepository<Post, BlogiBlogDbContext>, IPostReadRepository
    {
        public PostReadRepository(BlogiBlogDbContext context) : base(context)
        {
        }
    }
}