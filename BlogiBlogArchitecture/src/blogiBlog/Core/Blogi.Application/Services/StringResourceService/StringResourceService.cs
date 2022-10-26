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
