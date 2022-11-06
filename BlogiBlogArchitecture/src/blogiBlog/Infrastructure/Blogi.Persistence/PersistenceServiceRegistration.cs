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
            services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
            services.AddScoped<ILanguageReadRepository, LanguageReadRepository>();
            services.AddScoped<ILanguageWriteRepository, LanguageWriteRepository>();
            services.AddScoped<IMailSettingReadRepository, MailSettingReadRepository>();
            services.AddScoped<IMailSettingWriteRepository, MailSettingWriteRepository>();
            services.AddScoped<IStringResourceReadRepository, StringResourceReadRepository>();
            services.AddScoped<IStringResourceWriteRepository, StringResourceWriteRepository>();

            return services;
        }
    }
}