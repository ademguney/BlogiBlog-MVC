using Blogi.Application.Features.StringResources.Dtos.Get;
using Blogi.Application.Features.StringResources.Dtos.GetList;
using Microsoft.EntityFrameworkCore;

namespace Blogi.Application.Services.StringResourceService
{
    public class StringResourceService : IStringResourceService
    {
        private readonly IMapper _mapper;
        private readonly IStringResourceReadRepository _stringResourceReadRepository;

        public StringResourceService(IMapper mapper, IStringResourceReadRepository stringResourceReadRepository)
        {
            _mapper = mapper;
            _stringResourceReadRepository = stringResourceReadRepository;
        }

        public async Task<GetStringResourceOutput> GetAsync(int id)
        {
            return await _stringResourceReadRepository.GetAll(x => x.Id == id).Include(x => x.Languages).Select(x=>new GetStringResourceOutput
            {
                Id = x.Id,
                LanguageId = x.LanguageId,
                Key = x.Key,    
                Value = x.Value,
                Language=x.Languages.Name
                
            }).FirstOrDefaultAsync();
        }

        public async Task<GetStringResourceOutput> GetAsync(string resourceKey, int languageId)
        {
            var result = await _stringResourceReadRepository.GetAsync(x => x.Key.Trim().ToLower() == resourceKey.Trim().ToLower() && x.LanguageId == languageId);
            var resultMapp = _mapper.Map<GetStringResourceOutput>(result);
            return resultMapp;
        }

        public async Task<List<GetListStringResourceOutput>> GetListAsync()
        {
            return await _stringResourceReadRepository.GetAll().Include(x => x.Languages).Select(x => new GetListStringResourceOutput
            {
                Id = x.Id,
                LanguageId = x.LanguageId,
                Key = x.Key,
                Value = x.Value,
                Language = x.Languages.Name

            }).ToListAsync();
        }
    }
}
