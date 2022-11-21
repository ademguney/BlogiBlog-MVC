namespace Blogi.Persistence.Repositories.LanguageRepository
{
    public class LanguageReadRepository : ReadRepository<Language, BlogiBlogDbContext>, ILanguageReadRepository
    {
        public LanguageReadRepository(BlogiBlogDbContext context) : base(context)
        {
        }
    }
}