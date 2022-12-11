namespace Blogi.Persistence.EntityConfigurations
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("Tags");
            builder.Property(u => u.LanguageId).IsRequired(true);
            builder.Property(u => u.Name).IsRequired(true).HasMaxLength(225);
            builder.HasOne(u => u.Languages);
            builder.HasMany(u => u.PostTags);

            builder.HasData(
                new Tag { Id = 1, LanguageId = 1, Name = "Csharp", Slug = "c-sharp" },
                new Tag { Id = 2, LanguageId = 2, Name = "Csharp", Slug = "c-sharp" }
                );
        }
    }
}
