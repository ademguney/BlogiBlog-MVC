namespace Blogi.Persistence.Repositories.UserRepository
{
    public class UserWriteRepository : WriteRepository<User, BlogiBlogDbContext>, IUserWriteRepository
    {
        public UserWriteRepository(BlogiBlogDbContext context) : base(context)
        {
        }
    }
}