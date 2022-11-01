namespace Blogi.Persistence.Repositories.CategoryRepository
{
    public class CategoryReadRepository : ReadRepository<Category, BlogiBlogDbContext>, ICategoryReadRepository
    {
        public CategoryReadRepository(BlogiBlogDbContext context) : base(context)
        {
        }
    }
}
