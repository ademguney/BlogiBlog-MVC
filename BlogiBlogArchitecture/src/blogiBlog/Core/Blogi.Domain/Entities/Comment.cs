using Core.Persistence.Common;

namespace Blogi.Domain.Entities
{
    public class Comment : BaseDomainEntity
    {
        public Comment() { }

        public Comment(int id, int? parentId, int postId, string fullName, string email, string content, bool isPublish, DateTime creationDate):base(id)
        {
            ParentId = parentId;
            PostId = postId;
            FullName = fullName;
            Email = email;
            Content = content;
            IsPublish = isPublish;
            CreationDate = creationDate;
        }

        public int? ParentId { get; set; }
        public int PostId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }
        public bool IsPublish { get; set; }
        public DateTime CreationDate { get; set; }
    }
}