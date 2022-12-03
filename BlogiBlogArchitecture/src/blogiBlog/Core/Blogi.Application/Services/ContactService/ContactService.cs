using Blogi.Application.Features.Contacts.Dtos.Get;
using Blogi.Application.Features.Contacts.Dtos.GetList;

namespace Blogi.Application.Services.ContactService
{
    public class ContactService : IContactService
    {
        private readonly IMapper _mapper;
        private readonly IContactReadRepository _contactReadRepository;

        public ContactService(IMapper mapper, IContactReadRepository contactReadRepository)
        {
            _mapper = mapper;
            _contactReadRepository = contactReadRepository;
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
