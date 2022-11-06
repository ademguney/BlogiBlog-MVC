namespace Blogi.Persistence.Repositories.PostRepository
{
    public class PostWriteRepository : WriteRepository<Post, BlogiBlogDbContext>, IPostWriteRepository
    {
        public PostWriteRepository(BlogiBlogDbContext context) : base(context)
        {
        }
    }
}