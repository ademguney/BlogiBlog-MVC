using Core.Application.FormAuth.ClaimServices;

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
            services.AddScoped<IClaimService, ClaimService>();
            services.AddScoped<IPostTagService, PostTagService>();
            services.AddScoped<ICategoryService, CategoryService>();            
            services.AddScoped<IStringResourceService, StringResourceService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
           
            return services;
        }
    }
}