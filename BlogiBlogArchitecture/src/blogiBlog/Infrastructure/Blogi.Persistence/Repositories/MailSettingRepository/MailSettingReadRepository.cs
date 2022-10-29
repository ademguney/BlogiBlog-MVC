namespace Blogi.Persistence.Repositories.MailSettingRepository
{
    public class MailSettingReadRepository : ReadRepository<MailSetting, BlogiBlogDbContext>, IMailSettingReadRepository
    {
        public MailSettingReadRepository(BlogiBlogDbContext context) : base(context)
        {
        }
    }
}
