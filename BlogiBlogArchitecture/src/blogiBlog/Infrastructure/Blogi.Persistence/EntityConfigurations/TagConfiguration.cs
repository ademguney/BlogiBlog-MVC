namespace Blogi.Persistence.EntityConfigurations
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("Tags");
            builder.Property(u => u.LanguageId).IsRequired(true);
            builder.Property(u => u.Name).IsRequired(true).HasMaxLength(225);

            builder.HasData(
                new Tag { Id = 1, LanguageId = 2, Name = "C#" },
                new Tag { Id = 2, LanguageId = 2, Name = "Csharp" },
                new Tag { Id = 3, LanguageId = 2, Name = "SQL" },
                new Tag { Id = 4, LanguageId = 2, Name = "JavaScript" },
                new Tag { Id = 5, LanguageId = 2, Name = "Html" },
                new Tag { Id = 6, LanguageId = 2, Name = "Css" },
                new Tag { Id = 7, LanguageId = 2, Name = "Vue" },
                new Tag { Id = 8, LanguageId = 2, Name = "Angular" },
                new Tag { Id = 9, LanguageId = 2, Name = "React" },
                new Tag { Id = 10, LanguageId = 2, Name = "Design Pattern" },

                new Tag { Id = 11, LanguageId = 1, Name = "C#" },
                new Tag { Id = 12, LanguageId = 1, Name = "Csharp" },
                new Tag { Id = 13, LanguageId = 1, Name = "SQL" },
                new Tag { Id = 14, LanguageId = 1, Name = "JavaScript" },
                new Tag { Id = 15, LanguageId = 1, Name = "Html" },
                new Tag { Id = 16, LanguageId = 1, Name = "Css" },
                new Tag { Id = 17, LanguageId = 1, Name = "Vue" },
                new Tag { Id = 18, LanguageId = 1, Name = "Angular" },
                new Tag { Id = 19, LanguageId = 1, Name = "React" },
                new Tag { Id = 20, LanguageId = 1, Name = "Design Pattern" }

                );
        }
    }
}
