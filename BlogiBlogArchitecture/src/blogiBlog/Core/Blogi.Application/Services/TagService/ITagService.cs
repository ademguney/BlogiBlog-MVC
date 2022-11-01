using Blogi.Application.Features.Tags.Dtos.Get;

namespace Blogi.Application.Services.TagService
{
    public interface ITagService
    {
        Task<GetTagOutput> GetAsync(int id);
        Task<List<GetTagOutput>> GetListAsync();
    }
}
