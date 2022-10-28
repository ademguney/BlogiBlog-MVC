﻿namespace Blogi.Persistence.Contexts
{
    public class BlogiBlogDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }

        public BlogiBlogDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        public DbSet<Language> Languages { get; set; }
        public DbSet<StringResource> StringResources { get; set; }
        public DbSet<MailSetting> MailSettings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
