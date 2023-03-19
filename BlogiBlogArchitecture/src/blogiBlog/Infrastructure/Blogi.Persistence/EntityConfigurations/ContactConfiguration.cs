namespace Blogi.Persistence.EntityConfigurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contacts");
            builder.Property(u => u.LanguageId).IsRequired(true);
            builder.Property(u => u.CountOfView).IsRequired(true);
            builder.Property(u => u.Content).IsRequired(false);
            builder.Property(u => u.Phone).IsRequired(false).HasMaxLength(30);
            builder.Property(u => u.Email).IsRequired(false).HasMaxLength(255);
            builder.Property(u => u.Location).IsRequired(false).HasMaxLength(500);
            builder.Property(u => u.Title).IsRequired(true).HasMaxLength(500);
            builder.Property(u => u.Slug).IsRequired(true).HasMaxLength(500);
            builder.Property(u => u.MetaKeywords).IsRequired(true).HasMaxLength(500);
            builder.Property(u => u.MetaDescription).IsRequired(true).HasMaxLength(500);
            builder.HasOne(u => u.Languages);

            builder.HasData(
                new Contact
                {
                    Id = 1,
                    LanguageId = 1,
                    CountOfView = 1,
                    Content = "iletisim bilgilerim",
                    Phone = "0090 (XXX) 000 00 00",
                    Email = "guneyadem63@gmail.com",
                    Location = "Turkiye",
                    Slug = "iletisim",
                    Title = "Gel Gel Ne Olursan Ol Yine Gel, Mevlana!",
                    MetaDescription = "Blogi Blog acik kaynak kodlu cok dil destegi bulunan web blog projesidir.",
                    MetaKeywords = "open source, blogi blog, blogiblog, web project, multi language",
                },
                  new Contact
                  {
                      Id = 2,
                      LanguageId = 2,
                      CountOfView = 1,
                      Content = "my contact information",
                      Phone = "0090 (XXX) 000 00 00",
                      Email = "guneyadem63@gmail.com",
                      Location = "Turkey",
                      Slug = "contact",
                      Title = "Come, come, whoever you are, Jelaluddin Rumi!",
                      MetaDescription = "Blogi Blog open source multi language web blog project.",
                      MetaKeywords = "open source, blogi blog, blogiblog, web project, multi language"
                  }
                );
        }
    }
}