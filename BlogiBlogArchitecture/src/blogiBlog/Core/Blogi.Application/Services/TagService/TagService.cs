using Blogi.Application.Features.Tags.Dtos.Get;
using Microsoft.EntityFrameworkCore;

namespace Blogi.Application.Services.TagService
{
    public class TagService : ITagService
    {
        private readonly ITagReadRepository _tagReadRepository;

        public TagService(ITagReadRepository tagReadRepository)
        {
            _tagReadRepository = tagReadRepository;
        }

        public async Task<GetTagOutput> GetAsync(int id)
        {
            return await _tagReadRepository.GetAll(x => x.Id == id).Include(x => x.Languages).Select(x => new GetTagOutput
            {
                Id = x.Id,
                LanguageId = x.Languages.Id,
                LanguageName = x.Languages.Name,
                Name = x.Name
            }).FirstOrDefaultAsync();
        }

        public async Task<List<GetTagOutput>> GetListAsync()
        {
            var result = _tagReadRepository.GetAll().Include(x => x.Languages);
            var query = result.Select(x => new GetTagOutput
            {
                Id = x.Id,
                LanguageId = x.Languages.Id,
                LanguageName = x.Languages.Name,
                Name = x.Name
            }).ToListAsync();
            return await query;
        }
    }
}
