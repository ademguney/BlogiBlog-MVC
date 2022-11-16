using Blogi.Application.Features.Comment.Dtos.GetList;


namespace Blogi.Application.Features.Comment.Queries.GetList
{
    public class GetListCommentQueryHandler : IRequestHandler<GetListCommentQuery, BaseCommandResponse<List<GetListCommentOutput>>>
    {

        private readonly ICommentService _commentService;
        public GetListCommentQueryHandler(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<BaseCommandResponse<List<GetListCommentOutput>>> Handle(GetListCommentQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<List<GetListCommentOutput>>();
            var result = await _commentService.GetListAsync();
            if (!result.Any())
            {
                response.Success = false;
                response.Message = CommentMessages.GetListNotExists;
                response.Errors = null;
                response.Data = new List<GetListCommentOutput>();
            }
            else
            {

                response.Data = result;
                response.Success = true;
                response.Message = CommentMessages.GetListExists;
                response.Errors = null;
            }
            return response;
        }
    }
}