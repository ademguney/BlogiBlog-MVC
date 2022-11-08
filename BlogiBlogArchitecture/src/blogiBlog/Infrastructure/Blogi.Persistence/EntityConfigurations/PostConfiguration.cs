namespace Blogi.Persistence.EntityConfigurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts");
            builder.Property(u => u.UserId);
            builder.Property(u => u.LanguageId);
            builder.Property(u => u.CategoryId);
            builder.Property(u => u.Title).IsRequired(true).HasMaxLength(500);
            builder.Property(u => u.Content).IsRequired(true);
            builder.Property(u => u.Slug).IsRequired(true).HasMaxLength(500);
            builder.Property(u => u.Image).IsRequired(false);
            builder.Property(u => u.ImageAlt).IsRequired(true).HasMaxLength(255);
            builder.Property(u => u.DisplayCount);
            builder.Property(u => u.IsPublished).IsRequired(true);
            builder.Property(u => u.MetaKeywords).IsRequired(true).HasMaxLength(500);
            builder.Property(u => u.MetaDescription).IsRequired(true).HasMaxLength(500);
            builder.Property(u => u.UpdatedById).IsRequired(false);
            builder.Property(u => u.CreatedById).IsRequired(true);
            builder.Property(i => i.CreationDate).IsRequired(true);
            builder.Property(i => i.UpdationDate).IsRequired(false);


            builder.HasOne(u => u.Users);
            builder.HasOne(u => u.Categories);
            builder.HasOne(u => u.Languages).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(u => u.PostTags).WithOne().OnDelete(DeleteBehavior.NoAction).HasForeignKey(x=>x.PostId);


            builder.HasData(
                new Post
                {
                    Id = 1,
                    LanguageId = 1,
                    CategoryId = 1,
                    UserId = 1,
                    Title = "Multi Language Blogi Blog",
                    Content = "Blogi blog an open source project.",
                    Slug = "test-content",
                    Image = null,
                    ImageAlt = "blogiBlog",
                    DisplayCount = 0,
                    MetaKeywords = "blogiblog,open source, blog project",
                    MetaDescription = "is an open source multi language blog project Blog BLOG",
                    IsPublished = true,
                    CreatedById = 1,
                    CreationDate = DateTime.UtcNow

                });
        }
    }
}
