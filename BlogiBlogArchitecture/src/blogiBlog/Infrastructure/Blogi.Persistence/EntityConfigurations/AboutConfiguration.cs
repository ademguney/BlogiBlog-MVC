namespace Blogi.Persistence.EntityConfigurations
{
    public class AboutConfiguration : IEntityTypeConfiguration<About>
    {
        public void Configure(EntityTypeBuilder<About> builder)
        {
            builder.ToTable("Abouts");
            builder.Property(u => u.LanguageId).IsRequired(true);
            builder.Property(u => u.Content).IsRequired(true);
            builder.Property(u => u.Title).IsRequired(true).HasMaxLength(500);
            builder.Property(u => u.Slug).IsRequired(true).HasMaxLength(500);
            builder.Property(u => u.MetaKeywords).IsRequired(true).HasMaxLength(500);
            builder.Property(u => u.MetaDescription).IsRequired(true).HasMaxLength(500);
            builder.HasOne(u => u.Languages);

            builder.HasData(
                new About
                {
                    Id = 1,
                    LanguageId = 1,
                    Content = "Selamlar, Ben Adem!",
                    Slug = "hakkimda",
                    Title = "Yazilimci :) Adem GUNEY",
                    MetaDescription = "Blogi Blog acik kaynak kodlu cok dil destegi bulunan web blog projesidir.",
                    MetaKeywords = "open source, blogi blog, blogiblog, web project, multi language"

                },
                new About
                {
                    Id = 2,
                    LanguageId = 2,
                    Content = "He, I'm Adem :)",
                    Slug = "about-me",
                    Title = "Senior Software Developer Adem GUNEY",
                    MetaDescription = "Blogi Blog open source multi language web blog project.",
                    MetaKeywords = "open source, blogi blog, blogiblog, web project, multi language"
                }
                );
        }
    }
}