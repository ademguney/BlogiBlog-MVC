namespace Blogi.Persistence.Repositories.MailSettingRepository
{
    public class MailSettingWriteRepository : WriteRepository<MailSetting, BlogiBlogDbContext>, IMailSettingWriteRepository
    {
        public MailSettingWriteRepository(BlogiBlogDbContext context) : base(context)
        {
        }
    }
}
