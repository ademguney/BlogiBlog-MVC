using Blogi.Application.Features.Comment.Dtos.Get;
using Blogi.Application.Features.Comment.Dtos.GetList;

namespace Blogi.Application.Services.CommentService
{
    public class CommentService : ICommentService
    {
        private readonly ICommentReadRepository _commentReadRepository;

        public CommentService(ICommentReadRepository commentReadRepository)
        {
            _commentReadRepository = commentReadRepository;
        }

        public async Task<GetCommentOutput> GetAsync(int id)
        {

            return await _commentReadRepository.GetAll(x => x.Id == id).Include(x => x.Posts).Select(x => new GetCommentOutput
            {
                Id = x.Id,
                CategoryName = x.Posts.Categories.Name,
                PostName = x.Posts.Title,
                FullName = x.FullName,
                Email = x.Email,
                IsPublish = x.IsPublish,
                CreationDate = x.CreationDate.ToShortDateString()

            }).FirstOrDefaultAsync();
        }

        public async Task<List<GetListCommentOutput>> GetListAsync()
        {
            return await _commentReadRepository.GetAll().Select(x => new GetListCommentOutput
            {
                Id = x.Id,
                FullName = x.FullName,
                Email = x.Email,
                IsPublish = x.IsPublish,
                CreationDate = x.CreationDate.ToShortDateString()

            }).ToListAsync();
        }
    }
}