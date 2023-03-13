using Core.Persistence.Common;

namespace Blogi.Domain.Entities
{
    public class VisitorInformation : BaseDomainEntity
    {
        public VisitorInformation() { }

        public VisitorInformation(int id, string ipAddress, string path, DateTime creationDate) : base(id)
        {
            IpAddress = ipAddress;
            Path = path;
            CreationDate = creationDate;
        }

        public string IpAddress { get; set; }
        public string Path { get; set; }
        public DateTime CreationDate { get; set; }
    }
}