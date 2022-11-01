using Core.Persistence.Common;

namespace Blogi.Domain.Entities
{
    public class Tag : BaseDomainEntity
    {
        public Tag() { }

        public Tag(int id, int languageId, string name, Language languages) : base(id)
        {           
            LanguageId = languageId;
            Name = name;
            Languages = languages;
        }

        public int LanguageId { get; set; }
        public string Name { get; set; }
        public Language Languages { get; set; }
    }
}
