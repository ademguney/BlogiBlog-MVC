namespace Blogi.Persistence.Repositories.UserRepository
{
    public class UserReadRepository : ReadRepository<User, BlogiBlogDbContext>, IUserReadRepository
    {
        public UserReadRepository(BlogiBlogDbContext context) : base(context)
        {
        }
    }
}