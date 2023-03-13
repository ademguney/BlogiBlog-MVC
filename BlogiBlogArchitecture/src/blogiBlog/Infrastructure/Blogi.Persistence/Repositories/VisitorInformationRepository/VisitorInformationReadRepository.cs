namespace Blogi.Persistence.Repositories.VisitorInformationRepository
{
    public class VisitorInformationReadRepository : ReadRepository<VisitorInformation, BlogiBlogDbContext>, IVisitorInformationReadRepository
    {
        public VisitorInformationReadRepository(BlogiBlogDbContext context) : base(context)
        {
        }
    }
}