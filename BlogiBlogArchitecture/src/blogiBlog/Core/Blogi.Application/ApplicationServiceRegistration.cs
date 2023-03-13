namespace Blogi.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            // Services
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<IAboutService, AboutService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IPostTagService, PostTagService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<IClaimCoreService, ClaimCoreService>();            
            services.AddScoped<IMailFactoryService, MailFactoryService>();
            services.AddScoped<IStringResourceService, StringResourceService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IVisitorInformationService, VisitorInformationService>();

            return services;
        }
    }
}