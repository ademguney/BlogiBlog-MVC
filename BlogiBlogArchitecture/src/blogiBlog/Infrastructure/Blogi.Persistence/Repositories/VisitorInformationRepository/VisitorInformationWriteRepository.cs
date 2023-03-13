namespace Blogi.Persistence.Repositories.VisitorInformationRepository
{
    public class VisitorInformationWriteRepository : WriteRepository<VisitorInformation, BlogiBlogDbContext>, IVisitorInformationWriteRepository
    {
        public VisitorInformationWriteRepository(BlogiBlogDbContext context) : base(context)
        {
        }
    }
}