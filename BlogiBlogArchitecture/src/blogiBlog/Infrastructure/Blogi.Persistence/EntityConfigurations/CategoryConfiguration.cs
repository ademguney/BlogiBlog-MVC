namespace Blogi.Persistence.EntityConfigurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.Property(u => u.LanguageId).IsRequired(true);
            builder.Property(u => u.Name).IsRequired(true).HasMaxLength(225);
            builder.Property(u => u.Description).IsRequired(false).HasMaxLength(500);
            builder.Property(u => u.Slug).IsRequired(true).HasMaxLength(500);
            builder.HasOne(u => u.Languages);

            builder.HasData(
                new Category { Id = 1, LanguageId = 1, Name = ".Net Core", Description = "asp.net core mvc", Slug = "net-core" },
                new Category { Id = 2, LanguageId = 2, Name = ".Net Core", Description = "asp.net core mvc", Slug = "net-core" },
                new Category { Id = 3, LanguageId = 1, Name = "Design Pattern", Description = "solid principles", Slug = "design-pattern" },
                new Category { Id = 4, LanguageId = 2, Name = "Design Pattern", Description = "solid principles", Slug = "design-pattern" }

                );
        }
    }
}
