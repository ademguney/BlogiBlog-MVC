using Blogi.Application.Features.StringResources.Dtos.Get;
using Blogi.Application.Features.StringResources.Dtos.GitList;
using Microsoft.EntityFrameworkCore;

namespace Blogi.Application.Services.StringResourceService
{
    public class StringResourceService : IStringResourceService
    {
        private readonly IStringResourceReadRepository _stringResourceReadRepository;

        public StringResourceService(IStringResourceReadRepository stringResourceReadRepository)
        {
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

        public List<GetListStringResourceOutput> GetList()
        {
            var result = _stringResourceReadRepository.GetAll().Include(x => x.Languages);
            var query = result.Select(x => new GetListStringResourceOutput
            {
                Id = x.Id,
                LanguageId = x.LanguageId,
                Language = x.Languages.Name,
                Key = x.Key,
                Value = x.Value
            }).ToList();
            return query;
        }
    }
}
