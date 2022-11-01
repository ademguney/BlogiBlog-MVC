using Core.Persistence.Common;

namespace Blogi.Domain.Entities
{
    public class StringResource : BaseDomainEntity
    {
        public StringResource() { }

        public StringResource(int id, int languageId, string key, string value, Language languages) : base(id)
        {
            LanguageId = languageId;
            Key = key;
            Value = value;
            Languages = languages;
        }

        public int LanguageId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        public Language Languages { get; set; }
    }
}
