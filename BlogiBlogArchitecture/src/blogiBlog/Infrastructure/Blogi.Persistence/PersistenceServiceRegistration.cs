namespace Blogi.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BlogiBlogDbContext>(
                opt => opt.UseSqlServer(configuration.GetConnectionString("BlogiBlogConnectionString")));


            // Repositories
           



            return services;
        }
    }
}
