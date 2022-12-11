using Blogi.Application.Features.Tags.Dtos.Get;
using Blogi.Application.Features.Tags.Dtos.GetTagList;

namespace Blogi.Application.Services.TagService
{
    public interface ITagService
    {
        Task<GetTagOutput> GetAsync(int id);
        Task<List<GetTagOutput>> GetListAsync();       
        Task<List<GetTagListOutput>> GetListAsync(string culture);
    }
}