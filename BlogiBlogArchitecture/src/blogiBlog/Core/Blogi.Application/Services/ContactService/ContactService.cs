using Blogi.Application.Features.Contacts.Dtos.Get;
using Blogi.Application.Features.Contacts.Dtos.GetList;
using Blogi.Application.Repositories.AboutRepository;

namespace Blogi.Application.Services.ContactService
{
    public class ContactService : IContactService
    {
        private readonly IMapper _mapper;
        private readonly IContactReadRepository _contactReadRepository;
        private readonly IContactWriteRepository _contactWriteRepository;
        private readonly IVisitorInformationService _visitorInformationService;

        public ContactService(
            IMapper mapper,
            IContactReadRepository contactReadRepository,
            IContactWriteRepository contactWriteRepository,
            IVisitorInformationService visitorInformationService
            )
        {
            _mapper = mapper;
            _contactReadRepository = contactReadRepository;
            _contactWriteRepository = contactWriteRepository;
            _visitorInformationService = visitorInformationService;
        }

        public async Task<GetContactOutput> GetAsync(int id, string culture)
        {
            var result = new Contact();

            if (id > 0)
                result = await _contactReadRepository.GetAsync(x => x.Id == id);

            if (!string.IsNullOrEmpty(culture))
            {
                result = await _contactReadRepository
                       .GetAll(x => x.Languages.Culture.Trim().ToLower() == culture.Trim().ToLower())
                       .Include(x => x.Languages)
                       .FirstOrDefaultAsync();

                #region Visitor Information

                var ipAddress = GetIpAddress.GetIpAddres();
                var visitor = await _visitorInformationService.GetAsync(ipAddress, result.Slug);
                if (!visitor)
                {
                    result.CountOfView++;
                    _contactWriteRepository.Update(result);
                    await _visitorInformationService.AddAsync(ipAddress, result.Slug);
                }

                #endregion
            }

            var resultMapp = _mapper.Map<GetContactOutput>(result);
            return resultMapp;
        }

        public async Task<List<GetListContactOutput>> GetListAsync()
        {
            return await _contactReadRepository.GetAll().Include(x => x.Languages).Select(x => new GetListContactOutput
            {
                Id = x.Id,
                LanguageName = x.Languages.Name,
                Email = x.Email,
                Phone = x.Phone,
                Location = x.Location,
                Slug = x.Slug
            }).ToListAsync();
        }
    }
}