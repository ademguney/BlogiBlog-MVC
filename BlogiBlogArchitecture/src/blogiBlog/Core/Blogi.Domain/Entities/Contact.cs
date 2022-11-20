using Core.Persistence.Common;

namespace Blogi.Domain.Entities
{
    public class Contact : BaseDomainEntity
    {
        public int LanguageId { get; set; }
        public string Title { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }
        public string Content { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
    }
}