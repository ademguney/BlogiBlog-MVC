namespace Blogi.Persistence.EntityConfigurations
{
    public class PostTagConfiguration : IEntityTypeConfiguration<PostTags>
    {
        public void Configure(EntityTypeBuilder<PostTags> builder)
        {
            builder.ToTable("PostTags").HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnName("Id");
            builder.Property(u => u.PostId).HasColumnName("PostId");
            builder.Property(u => u.TagId).HasColumnName("TagId");
            builder.HasOne(u => u.Tags).WithMany().OnDelete(DeleteBehavior.Restrict);
        }
    }
}