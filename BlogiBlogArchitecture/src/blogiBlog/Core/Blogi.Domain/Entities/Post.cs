using Core.Persistence.Common;
using Core.Persistence.Contracts;

namespace Blogi.Domain.Entities
{
    public class Post : BaseDomainEntity, IAuditable
    {
        public Post() { }

        public Post(int id, int languageId, int categoryId, string title, string content, string slug, byte[] image, int displayCount, bool isPublished, int createdById, DateTime creationTime, User users, Language languages, Category categories, ICollection<Tag> tags) : base(id)
        {
            LanguageId = languageId;
            CategoryId = categoryId;
            Title = title;
            Content = content;
            Slug = slug;
            Image = image;
            DisplayCount = displayCount;
            IsPublished = isPublished;
            CreatedById = createdById;
            CreationTime = creationTime;
            Users = users;
            Languages = languages;
            Categories = categories;
            Tags = tags;
        }

        public int LanguageId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Slug { get; set; }
        public byte[] Image { get; set; }
        public int DisplayCount { get; set; }

        public bool IsPublished { get; set; }
        public int CreatedById { get; set; }
        public DateTime CreationTime { get; set; }


        public User Users { get; set; }
        public Language Languages { get; set; }
        public Category Categories { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
}