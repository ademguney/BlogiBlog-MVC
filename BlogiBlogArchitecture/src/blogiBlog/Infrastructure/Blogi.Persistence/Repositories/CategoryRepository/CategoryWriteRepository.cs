namespace Blogi.Persistence.Repositories.CategoryRepository
{
    public class CategoryWriteRepository : WriteRepository<Category, BlogiBlogDbContext>, ICategoryWriteRepository
    {
        public CategoryWriteRepository(BlogiBlogDbContext context) : base(context)
        {
        }
    }
}
