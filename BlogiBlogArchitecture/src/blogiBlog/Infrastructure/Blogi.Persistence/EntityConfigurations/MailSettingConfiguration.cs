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
            builder.Property(u => u.PasswordHash).IsRequired(true);
            builder.Property(u => u.PasswordSalt).IsRequired(true);
            builder.Property(u => u.SslEnabled);
            builder.Property(u => u.UseDefaultCredentials);

            EnDecode.Encrypt("test_password", out byte[] passwordHash, out byte[] passwordSalt);

            builder.HasData(
              new MailSetting
              {
                  Id = 1,
                  Host = "smtp.gmail.com",
                  Port = 587,
                  FullName = "BlogiBlog",
                  Email = "email_@_adresiniz.com",
                  PasswordHash = passwordHash,
                  PasswordSalt = passwordSalt,
                  SslEnabled = false,
                  UseDefaultCredentials = false
              });
        }
    }
}
