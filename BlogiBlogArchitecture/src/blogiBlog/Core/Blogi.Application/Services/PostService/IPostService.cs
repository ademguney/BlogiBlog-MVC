using Blogi.Application.Features.Posts.Dtos.GetList;

namespace Blogi.Application.Services.PostService
{
    public interface IPostService
    {
        Task<List<GetListPostOutput>> GetListAsync();
    }
}