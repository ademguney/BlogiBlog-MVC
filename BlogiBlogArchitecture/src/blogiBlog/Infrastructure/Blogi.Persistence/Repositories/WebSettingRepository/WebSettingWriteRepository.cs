namespace Blogi.Persistence.Repositories.WebSettingRepository
{
    public class WebSettingWriteRepository : WriteRepository<WebSetting, BlogiBlogDbContext>, IWebSettingWriteRepository
    {
        public WebSettingWriteRepository(BlogiBlogDbContext context) : base(context)
        {
        }
    }
}