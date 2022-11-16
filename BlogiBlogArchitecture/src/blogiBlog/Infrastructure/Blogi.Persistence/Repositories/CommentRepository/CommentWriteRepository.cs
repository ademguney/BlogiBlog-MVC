namespace Blogi.Persistence.Repositories.CommentRepository
{
    public class CommentWriteRepository : WriteRepository<Comment, BlogiBlogDbContext>, ICommentWriteRepository
    {
        public CommentWriteRepository(BlogiBlogDbContext context) : base(context)
        {
        }
    }
}