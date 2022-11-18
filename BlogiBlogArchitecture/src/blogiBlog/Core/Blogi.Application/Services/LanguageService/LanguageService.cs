using Blogi.Application.Features.Languages.Dtos.Get;
using Blogi.Application.Features.Languages.Dtos.GetList;

namespace Blogi.Application.Services.LanguageService
{
    public class LanguageService : ILanguageService
    {
        private readonly IMapper _mapper;
        private readonly ILanguageReadRepository _languageReadRepository;

        public LanguageService(IMapper mapper, ILanguageReadRepository languageReadRepository)
        {
            _mapper = mapper;
            _languageReadRepository = languageReadRepository;
        }

        public async Task<GetLanguageOutput> GetByCultureAsync(string culture)
        {
            var result = await _languageReadRepository.GetAsync(x => x.Culture.Trim().ToLower() == culture.Trim().ToLower());
            var resultMapp = _mapper.Map<GetLanguageOutput>(result);
            return resultMapp;
        }

        public async Task<List<GetListLanguageOutput>> GetListAsync()
        {
            var result = await _languageReadRepository.GetListAsync();
            var resultMapp = _mapper.Map<List<GetListLanguageOutput>>(result);
            return resultMapp;
        }
    }
}
