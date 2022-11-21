namespace Blogi.Persistence.Repositories.WebSettingRepository
{
    public class WebSettingReadRepository : ReadRepository<WebSetting, BlogiBlogDbContext>, IWebSettingReadRepository
    {
        public WebSettingReadRepository(BlogiBlogDbContext context) : base(context)
        {
        }
    }
}