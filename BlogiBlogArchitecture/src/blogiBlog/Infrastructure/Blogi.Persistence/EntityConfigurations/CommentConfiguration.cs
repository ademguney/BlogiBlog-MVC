namespace Blogi.Persistence.EntityConfigurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");
            builder.Property(u => u.ParentId).IsRequired(false);
            builder.Property(u => u.PostId).IsRequired(true);
            builder.Property(u => u.FullName).IsRequired(true).HasMaxLength(500);
            builder.Property(u => u.Email).IsRequired(true).HasMaxLength(255);
            builder.Property(u => u.Content).IsRequired(true);
            builder.Property(u => u.IsPublish).IsRequired(true);
            builder.Property(i => i.CreationDate).IsRequired(true);
            builder.HasOne(x => x.Posts);
        }
    }
}