namespace Blogi.Persistence.Repositories.LanguageRepository
{
    public class LanguageWriteRepository : WriteRepository<Language, BlogiBlogDbContext>, ILanguageWriteRepository
    {
        public LanguageWriteRepository(BlogiBlogDbContext context) : base(context)
        {
        }
    }
}
