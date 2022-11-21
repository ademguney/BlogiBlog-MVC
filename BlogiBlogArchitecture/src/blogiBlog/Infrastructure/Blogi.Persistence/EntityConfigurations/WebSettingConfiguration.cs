namespace Blogi.Persistence.EntityConfigurations
{
    public class WebSettingConfiguration : IEntityTypeConfiguration<WebSetting>
    {
        public void Configure(EntityTypeBuilder<WebSetting> builder)
        {
            builder.ToTable("WebSettings");
            builder.Property(u => u.FacebookUrl).IsRequired(false).HasMaxLength(500);
            builder.Property(u => u.TwitterUrl).IsRequired(false).HasMaxLength(500);
            builder.Property(u => u.InstagramUrl).IsRequired(false).HasMaxLength(500);
            builder.Property(u => u.YouTubeUrl).IsRequired(false).HasMaxLength(500);
            builder.Property(u => u.MediumUrl).IsRequired(false).HasMaxLength(500);
            builder.Property(u => u.GithubUrl).IsRequired(false).HasMaxLength(500);
            builder.Property(u => u.LinkedinUrl).IsRequired(false).HasMaxLength(500);
            builder.Property(u => u.IsDisplayFacebbokUrl);
            builder.Property(u => u.IsDisplayTwitterUrl);
            builder.Property(u => u.IsDisplayInstagramUrl);
            builder.Property(u => u.IsDisplayYouTubeUrl);
            builder.Property(u => u.IsDisplayMediumUrl);
            builder.Property(u => u.IsDisplayGithubUrl);
            builder.Property(u => u.IsDisplayLinkedinUrl);

            builder.Property(u => u.WebSiteUrl).IsRequired(false).HasMaxLength(500);
            builder.Property(u => u.Slogan).IsRequired(false).HasMaxLength(500);
            builder.Property(u => u.Title).IsRequired(false).HasMaxLength(500);
            builder.Property(u => u.Author).IsRequired(false).HasMaxLength(500);
            builder.Property(u => u.MetaKeywords).IsRequired(true).HasMaxLength(500);
            builder.Property(u => u.MetaDescription).IsRequired(true).HasMaxLength(500);

            builder.HasData(
                new WebSetting
                {
                    Id = 1,
                    FacebookUrl = "https://github.com/ademguney/BlogiBlog-MVC",
                    TwitterUrl = "https://twitter.com/AdemGuneyii",
                    InstagramUrl = "https://github.com/ademguney/BlogiBlog-MVC",
                    YouTubeUrl = "https://www.youtube.com/@ademguney",
                    MediumUrl = "https://github.com/ademguney/BlogiBlog-MVC",
                    GithubUrl = "https://github.com/ademguney",
                    LinkedinUrl = "https://www.linkedin.com/in/ademguney/",
                    IsDisplayFacebbokUrl = true,
                    IsDisplayTwitterUrl = true,
                    IsDisplayInstagramUrl = true,
                    IsDisplayYouTubeUrl = true,
                    IsDisplayMediumUrl = true,
                    IsDisplayGithubUrl = true,
                    IsDisplayLinkedinUrl = true,

                    WebSiteUrl = "https://www.guneyadem.com/",
                    Slogan = "SEMICOLON, PRIME SUSPECT;",
                    Author = "Adem Guney",
                    Title = "Senior Software Developer Adem GUNEY",
                    MetaDescription = "Blogi Blog open source multi language web blog project.",
                    MetaKeywords = "open source, blogi blog, blogiblog, web project, multi language"
                }
                );
        }
    }
}