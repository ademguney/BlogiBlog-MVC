using Core.Persistence.Common;

namespace Blogi.Domain.Entities
{
    public class Language : BaseDomainEntity
    {
        public string Name { get; set; }
        public string Culture { get; set; }
    }
}
