using Blogi.Application.Features.Comment.Dtos.Get;

namespace Blogi.Application.Features.Comment.Queries.Get
{
    public class GetCommentQueryHandler : IRequestHandler<GetCommentQuery, BaseCommandResponse<GetCommentOutput>>
    {
        private readonly ICommentService _commentService;

        public GetCommentQueryHandler(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<BaseCommandResponse<GetCommentOutput>> Handle(GetCommentQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<GetCommentOutput>();
            var result = await _commentService.GetAsync(request.Id);

           
            response.Data = result;
            response.Success = true;
            response.Message = TagMessages.GetListExists;
            response.Errors = null;

            return response;
        }
    }
}