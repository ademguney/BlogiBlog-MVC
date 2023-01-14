using Blogi.Application.Features.Comments.Dtos.Get;
using Blogi.Application.Features.Comments.Dtos.GetList;

namespace Blogi.Application.Services.CommentService
{
    public interface ICommentService
    {
        Task<GetCommentOutput> GetAsync(int id);
        Task<List<GetListCommentOutput>> GetListAsync();
    }
}