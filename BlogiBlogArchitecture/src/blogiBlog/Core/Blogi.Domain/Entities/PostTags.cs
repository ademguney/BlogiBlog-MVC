using Core.Persistence.Common;

namespace Blogi.Domain.Entities
{
    public class PostTags : BaseDomainEntity
    {
        public PostTags() { }

        public PostTags(int id, int postId, int tagId) : base(id)
        {
            PostId = postId;
            TagId = tagId;
        }

        public int PostId { get; set; }
        public int TagId { get; set; }
        public Tag Tags { get; set; }       
    }
}