using Core.Persistence.Common;

namespace Blogi.Domain.Entities
{
    public class Category : BaseDomainEntity
    {
        public Category()
        {
            Posts = new HashSet<Post>();
        }

        public Category(int id, int languageId, string name, string description, string slug) : base(id)
        {
            LanguageId = languageId;
            Name = name;
            Description = description;
            Slug = slug;
        }

        public int LanguageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }

        public Language Languages { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}