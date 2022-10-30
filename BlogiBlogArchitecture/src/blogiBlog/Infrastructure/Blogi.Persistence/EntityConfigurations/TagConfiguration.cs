namespace Blogi.Persistence.EntityConfigurations
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("Tags");
            builder.Property(u => u.Name).IsRequired(true).HasMaxLength(225);

            builder.HasData(
                new Tag { Id = 1, Name = "C#" },
                new Tag { Id = 2, Name = "Csharp" },
                new Tag { Id = 3, Name = "SQL" },
                new Tag { Id = 4, Name = "JavaScript" },
                new Tag { Id = 5, Name = "Html" },
                new Tag { Id = 6, Name = "Css" },
                new Tag { Id = 7, Name = "Vue" },
                new Tag { Id = 8, Name = "Angular" },
                new Tag { Id = 9, Name = "React" },
                new Tag { Id = 10, Name = "Design Pattern" }

                );
        }
    }
}
