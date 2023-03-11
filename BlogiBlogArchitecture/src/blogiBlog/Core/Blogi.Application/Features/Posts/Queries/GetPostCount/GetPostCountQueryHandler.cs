namespace Blogi.Application.Features.Posts.Queries.GetPostCount
{
    public class GetPostCountQueryHandler : IRequestHandler<GetPostCountQuery, BaseCommandResponse<int>>
    {
        private readonly IPostReadRepository _postReadRepository;

        public GetPostCountQueryHandler(IPostReadRepository postReadRepository)
        {
            _postReadRepository = postReadRepository;
        }

        public async Task<BaseCommandResponse<int>> Handle(GetPostCountQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<int>();
            var result = await _postReadRepository.CountAsync();

            response.Data = result;
            response.Success = true;
            response.Errors = null;

            return response;
        }
    }
}