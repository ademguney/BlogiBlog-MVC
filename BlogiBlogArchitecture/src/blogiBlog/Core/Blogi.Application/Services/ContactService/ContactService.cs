using Blogi.Application.Features.Contact.Dtos.GetList;
using Blogi.Application.Features.Contract.Dtos.Get;

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

        public async Task<GetContactOutput> GetAsync(int id)
        {
            var result = await _contactReadRepository.GetAsync(x => x.Id == id);
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
