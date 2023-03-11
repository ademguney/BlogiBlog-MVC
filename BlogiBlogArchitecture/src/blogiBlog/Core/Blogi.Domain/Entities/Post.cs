using Core.Persistence.Common;
using Core.Persistence.Contracts;

namespace Blogi.Domain.Entities
{
    public class Post : BaseDomainEntity, IAuditable
    {
        public Post()
        {
            PostTags = new HashSet<PostTags>();
            Comments = new HashSet<Comment>();
        }

        public Post(int id, int userId, int languageId, int categoryId, string title, string content, string slug, byte[] image, string imageAlt, string metaKeywords, string metaDescription,int countOfView, bool isPublished, int createdById, DateTime creationTime, DateTime? updationDate, int? updatedById) : base(id)
        {
            UserId = userId;
            LanguageId = languageId;
            CategoryId = categoryId;
            Title = title;
            Content = content;
            Slug = slug;
            Image = image;
            ImageAlt = imageAlt;
            MetaKeywords = metaKeywords;
            MetaDescription = metaDescription;
            CountOfView = countOfView;
            IsPublished = isPublished;
            CreatedById = createdById;
            UpdatedById = updatedById;
            CreationDate = creationTime;
            UpdationDate = updationDate;
        }

        public int UserId { get; set; }
        public int LanguageId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Slug { get; set; }
        public byte[] Image { get; set; }
        public string ImageAlt { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public int CountOfView { get; set; }
        public bool IsPublished { get; set; }
        public int CreatedById { get; set; }
        public int? UpdatedById { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdationDate { get; set; }

        public User Users { get; set; }
        public Language Languages { get; set; }
        public Category Categories { get; set; }
        public ICollection<PostTags> PostTags { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}