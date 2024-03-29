﻿namespace Blogi.Persistence.EntityConfigurations
{
    public class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {

            builder.ToTable("Languages");
            builder.Property(u => u.Name).IsRequired(true).HasMaxLength(255);
            builder.Property(u => u.Culture).IsRequired(true).HasMaxLength(10);
            builder.HasMany(u => u.StringResources);
           

            builder.HasData(
                new Language { Id = 1, Name = "Turkish", Culture = "tr-TR" },
                new Language { Id = 2, Name = "English", Culture = "en-US" }
                );
        }
    }
}