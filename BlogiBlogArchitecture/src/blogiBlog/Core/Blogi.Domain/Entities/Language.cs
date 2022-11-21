using Core.Persistence.Common;

namespace Blogi.Domain.Entities
{
    public class Language : BaseDomainEntity
    {
        public Language()
        {
            StringResources = new HashSet<StringResource>();
        }

        public Language(int id, string name, string culture) : this()
        {
            Id = id;
            Name = name;
            Culture = culture;            
        }

        public string Name { get; set; }
        public string Culture { get; set; }
        public ICollection<StringResource> StringResources { get; set; }
    }
}