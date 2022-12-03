using Blogi.Application.Features.Abouts.Dtos.Get;
using Blogi.Application.Features.Abouts.Dtos.GetList;

namespace Blogi.Application.Services.AboutService
{
    public class AboutService : IAboutService
    {
        private readonly IMapper _mapper;
        private readonly IAboutReadRepository _aboutReadRepository;

        public AboutService(IMapper mapper, IAboutReadRepository aboutReadRepository)
        {
            _mapper = mapper;
            _aboutReadRepository = aboutReadRepository;
        }

        public async Task<GetAboutOutput> GetAsync(int id)
        {
            var result = await _aboutReadRepository.GetAsync(x => x.Id == id);
            var resultMapp = _mapper.Map<GetAboutOutput>(result);
            return resultMapp;
        }

        public async Task<List<GetListAboutOutput>> GetListAsync()
        {
            return await _aboutReadRepository.GetAll().Include(x => x.Languages).Select(x => new GetListAboutOutput
            {
                Id = x.Id,
                LanguageName = x.Languages.Name,
                Title = x.Title,
                Slug = x.Slug
            }).ToListAsync();
        }
    }
}