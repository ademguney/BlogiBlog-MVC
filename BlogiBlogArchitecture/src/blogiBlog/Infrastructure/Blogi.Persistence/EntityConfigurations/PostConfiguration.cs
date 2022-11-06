namespace Blogi.Persistence.EntityConfigurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts");
            builder.Property(u => u.LanguageId).IsRequired(true);
            builder.Property(u => u.Title).IsRequired(true).HasMaxLength(500);
            builder.Property(u => u.Content).IsRequired(true);
            builder.Property(u => u.Slug).IsRequired(true).HasMaxLength(500);
            builder.Property(u => u.Image).IsRequired(true);
            builder.Property(u => u.DisplayCount);
            builder.Property(u => u.IsPublished).IsRequired(true);

            builder.Property(u => u.CreatedById).IsRequired(true);           
            builder.Property(i => i.CreationTime).IsRequired(true);           
         

            builder.HasOne(u => u.Users);
            builder.HasOne(u => u.Languages);
            builder.HasOne(u => u.Categories);
            builder.HasMany(u => u.Tags);

            builder.HasData(
                new Post
                {
                    Id = 1,
                    LanguageId = 1,
                    CategoryId = 1,
                    Title = "Test_Title",
                    Content = "Test_Content",
                    Slug = "test-content",
                    Image = null,
                    DisplayCount = 0,
                    IsPublished = true,
                    CreatedById = 1,
                    CreationTime = DateTime.UtcNow

                });
        }
    }
}
