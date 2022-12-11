using Core.Persistence.Common;

namespace Blogi.Domain.Entities
{
    public class Tag : BaseDomainEntity
    {
        public Tag() { }

        public Tag(int id, int languageId, string name, string slug, Language languages) : base(id)
        {           
            LanguageId = languageId;
            Name = name;
            Slug = slug;
            Languages = languages;
        }

        public int LanguageId { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public Language Languages { get; set; }
        public ICollection<PostTags> PostTags { get; set; }
    }
}