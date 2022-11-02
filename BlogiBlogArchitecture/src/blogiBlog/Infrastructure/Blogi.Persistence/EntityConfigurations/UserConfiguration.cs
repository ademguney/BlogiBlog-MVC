using Core.Application.Security.Hashing;

namespace Blogi.Persistence.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.Property(u=>u.Name).IsRequired(true).HasMaxLength(255);
            builder.Property(u => u.Surname).IsRequired(true).HasMaxLength(255);
            builder.Property(u => u.Email).IsRequired(true).HasMaxLength(255);
            builder.Property(u => u.Password).IsRequired(true);
            builder.Property(u => u.Photo).IsRequired(false);

            builder.HasData(
                new User
                {
                    Id =1,
                    Name ="BLOGI",
                    Surname ="BLOG",
                    Email ="blogi@blog.com",
                    Password = EnDecode.Encrypt("..Test_Pass..", StaticParams.PasswordParams),
                });
        }
    }
}
