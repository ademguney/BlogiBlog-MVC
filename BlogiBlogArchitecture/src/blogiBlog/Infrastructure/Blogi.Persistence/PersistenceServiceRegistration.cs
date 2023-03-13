namespace Blogi.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BlogiBlogDbContext>(
                opt =>
                {
                    opt.UseSqlServer(configuration.GetConnectionString("BlogiBlogConnectionString"));
                    opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                });


            // Repositories
            services.AddScoped<ITagReadRepository, TagReadRepository>();
            services.AddScoped<ITagWriteRepository, TagWriteRepository>();
            services.AddScoped<IPostReadRepository, PostReadRepository>();
            services.AddScoped<IPostWriteRepository, PostWriteRepository>();
            services.AddScoped<IUserReadRepository, UserReadRepository>();
            services.AddScoped<IUserWriteRepository, UserWriteRepository>();
            services.AddScoped<IAboutReadRepository, AboutReadRepository>();
            services.AddScoped<IAboutWriteRepository, AboutWriteRepository>();
            services.AddScoped<IContactReadRepository, ContactReadRepository>();
            services.AddScoped<IContactWriteRepository, ContactWriteRepository>();
            services.AddScoped<ICommentReadRepository, CommentReadRepository>();
            services.AddScoped<ICommentWriteRepository, CommentWriteRepository>();
            services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
            services.AddScoped<IPostTagsReadRepository, PostTagsReadRepository>();
            services.AddScoped<IPostTagsWriteRepository, PostTagsWriteRepository>();
            services.AddScoped<ILanguageReadRepository, LanguageReadRepository>();
            services.AddScoped<ILanguageWriteRepository, LanguageWriteRepository>();
            services.AddScoped<IWebSettingReadRepository, WebSettingReadRepository>();
            services.AddScoped<IWebSettingWriteRepository, WebSettingWriteRepository>();
            services.AddScoped<IMailSettingReadRepository, MailSettingReadRepository>();
            services.AddScoped<IMailSettingWriteRepository, MailSettingWriteRepository>();
            services.AddScoped<IStringResourceReadRepository, StringResourceReadRepository>();
            services.AddScoped<IStringResourceWriteRepository, StringResourceWriteRepository>();
            services.AddScoped<IVisitorInformationReadRepository, VisitorInformationReadRepository>();
            services.AddScoped<IVisitorInformationWriteRepository, VisitorInformationWriteRepository>();


            return services;
        }
    }
}