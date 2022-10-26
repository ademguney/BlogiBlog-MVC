using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogi.Persistence.EntityConfigurations
{
    public class StringResourceConfiguration : IEntityTypeConfiguration<StringResource>
    {
        public void Configure(EntityTypeBuilder<StringResource> builder)
        {
            builder.ToTable("StringResources");
            builder.Property(u => u.LanguageId).IsRequired(true);
            builder.Property(u => u.Key).IsRequired(true).HasMaxLength(500);
            builder.Property(u => u.Value).IsRequired(true).HasMaxLength(500);
            builder.HasOne(u => u.Languages);

            builder.HasData(
                new StringResource
                {
                    Id = 1,
                    LanguageId = 1,
                    Key = "page_language_button_create",
                    Value = "Yeni Dil Oluştur"
                },
                 new StringResource
                 {
                     Id = 2,
                     LanguageId = 2,
                     Key = "page_language_button_create",
                     Value = "Create New Language"
                 },
                  new StringResource
                  {
                      Id = 3,
                      LanguageId = 1,
                      Key = "page_language_button_delete",
                      Value = "Sil"
                  },
                  new StringResource
                  {
                      Id = 4,
                      LanguageId = 2,
                      Key = "page_language_button_delete",
                      Value = "Delete"
                  },
                  new StringResource
                  {
                      Id = 5,
                      LanguageId = 1,
                      Key = "page_language_button_update",
                      Value = "Güncelle"
                  },
                  new StringResource
                  {
                      Id = 6,
                      LanguageId = 2,
                      Key = "page_language_button_update",
                      Value = "Update"
                  },
                  new StringResource
                  {
                      Id = 7,
                      LanguageId = 1,
                      Key = "page_language_label_list",
                      Value = "Dil listesi..."
                  },
                  new StringResource
                  {
                      Id = 8,
                      LanguageId = 2,
                      Key = "page_language_label_list",
                      Value = "Language list..."
                  }
                );
        }
    }
}
