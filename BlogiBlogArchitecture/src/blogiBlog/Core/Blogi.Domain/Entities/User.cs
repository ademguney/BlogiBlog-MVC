using Core.Persistence.Common;

namespace Blogi.Domain.Entities
{
    public class User : BaseDomainEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public byte[] Photo { get; set; }
    }
}