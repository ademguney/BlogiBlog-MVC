namespace Blogi.Persistence.Repositories.CommentRepository
{
    public class CommentReadRepository : ReadRepository<Comment, BlogiBlogDbContext>, ICommentReadRepository
    {
        public CommentReadRepository(BlogiBlogDbContext context) : base(context)
        {
        }
    }
}