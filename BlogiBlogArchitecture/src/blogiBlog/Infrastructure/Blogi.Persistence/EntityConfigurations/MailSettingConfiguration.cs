using Core.Application.Security.Hashing;

namespace Blogi.Persistence.EntityConfigurations
{
    public class MailSettingConfiguration : IEntityTypeConfiguration<MailSetting>
    {
        public void Configure(EntityTypeBuilder<MailSetting> builder)
        {
            builder.ToTable("MailConfigs");
            builder.Property(u => u.Host).IsRequired(true).HasMaxLength(255);
            builder.Property(u => u.Port).IsRequired(true);
            builder.Property(u => u.FullName).IsRequired(true).HasMaxLength(500);
            builder.Property(u => u.Email).IsRequired(true).HasMaxLength(255);
            builder.Property(u => u.Password).IsRequired(true);           
            builder.Property(u => u.SslEnabled);
            builder.Property(u => u.UseDefaultCredentials);           

            builder.HasData(
              new MailSetting
              {
                  Id = 1,
                  Host = "smtp.gmail.com",
                  Port = 587,
                  FullName = "BlogiBlog",
                  Email = "blogi@blog.com",
                  Password = EnDecode.Encrypt("..Test_Pass..", StaticParams.PasswordParams),
                  SslEnabled = false,
                  UseDefaultCredentials = false
              });
        }
    }
}
