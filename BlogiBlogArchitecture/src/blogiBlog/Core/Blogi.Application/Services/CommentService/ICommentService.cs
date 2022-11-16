using Blogi.Application.Features.Comment.Dtos.Get;
using Blogi.Application.Features.Comment.Dtos.GetList;

namespace Blogi.Application.Services.CommentService
{
    public interface ICommentService
    {
        Task<GetCommentOutput> GetAsync(int id);
        Task<List<GetListCommentOutput>> GetListAsync();
    }
}