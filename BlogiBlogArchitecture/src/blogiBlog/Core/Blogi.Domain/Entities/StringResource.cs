using Core.Persistence.Common;

namespace Blogi.Domain.Entities
{
    public class StringResource : BaseDomainEntity
    {
        public int LanguageId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
