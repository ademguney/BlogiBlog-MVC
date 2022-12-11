namespace Blogi.Persistence.EntityConfigurations
{
    public class PostTagConfiguration : IEntityTypeConfiguration<PostTags>
    {
        public void Configure(EntityTypeBuilder<PostTags> builder)
        {
            builder.ToTable("PostTags");
            builder.Property(u => u.TagId);
            builder.HasOne(u => u.Tags);           
        }
    }
}