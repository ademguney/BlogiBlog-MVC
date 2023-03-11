namespace Blogi.Application.Features.Comments.Queries.GetCommentCount
{
    public class GetCommentCountQueryHandler : IRequestHandler<GetCommentCountQuery, BaseCommandResponse<int>>
    {
        private readonly ICommentReadRepository _commentReadRepository;

        public GetCommentCountQueryHandler(ICommentReadRepository commentReadRepository)
        {
            _commentReadRepository = commentReadRepository;
        }

        public async Task<BaseCommandResponse<int>> Handle(GetCommentCountQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<int>();
            var result = await _commentReadRepository.CountAsync();

            response.Data = result;
            response.Success = true;
            response.Errors = null;

            return response;
        }
    }
}