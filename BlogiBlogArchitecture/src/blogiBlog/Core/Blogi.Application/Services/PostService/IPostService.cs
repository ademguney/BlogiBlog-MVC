using Blogi.Application.Features.Post.Dtos.GetList;

namespace Blogi.Application.Services.PostService
{
    public interface IPostService
    {
        Task<List<GetListPostOutput>> GetListAsync();
    }
}