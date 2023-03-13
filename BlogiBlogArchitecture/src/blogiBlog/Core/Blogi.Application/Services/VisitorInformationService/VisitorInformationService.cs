namespace Blogi.Application.Services.VisitorInformationService
{
    public class VisitorInformationService : IVisitorInformationService
    {
        public readonly IVisitorInformationReadRepository _visitorInformationReadRepository;
        public readonly IVisitorInformationWriteRepository _visitorInformationWriteRepository;

        public VisitorInformationService(
            IVisitorInformationWriteRepository visitorInformationWriteRepository, 
            IVisitorInformationReadRepository visitorInformationReadRepository
            )
        {
            _visitorInformationWriteRepository = visitorInformationWriteRepository;
            _visitorInformationReadRepository = visitorInformationReadRepository;
        }

        public async Task AddAsync(string ipAddress, string path)
        {
            var visitorInfo = new VisitorInformation
            {
                IpAddress = ipAddress,
                Path = path,
                CreationDate = DateTime.UtcNow.Date,
            };
            await _visitorInformationWriteRepository.AddAsync(visitorInfo);
        }

        public async Task<bool> GetAsync(string ipAddress, string path)
        {
            return await _visitorInformationReadRepository.AnyAsync(x => x.IpAddress == ipAddress && x.Path == path && x.CreationDate == DateTime.UtcNow.Date);
        }
    }
}