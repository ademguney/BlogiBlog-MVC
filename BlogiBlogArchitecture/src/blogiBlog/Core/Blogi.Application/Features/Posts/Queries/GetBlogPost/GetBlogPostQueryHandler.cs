using Blogi.Application.Features.Posts.Dtos.GetBlogPost;

namespace Blogi.Application.Features.Posts.Queries.GetBlogPost
{
    public class GetBlogPostQueryHandler : IRequestHandler<GetBlogPostQuery, BaseCommandResponse<GetBlogPostOutput>>
    {
        private readonly IPostService _postService;
        private readonly IPostReadRepository _postReadRepository;

        public GetBlogPostQueryHandler(
            IPostService postService,
            IPostReadRepository postReadRepository
            )
        {
            _postService = postService;
            _postReadRepository = postReadRepository;

        }

        public async Task<BaseCommandResponse<GetBlogPostOutput>> Handle(GetBlogPostQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<GetBlogPostOutput>();
            var validator = new GetBlogPostQueryHandlerValidatior(_postReadRepository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                response.Data = null;
                response.Success = false;
                response.Message = null;
                response.Errors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                var result = await _postService.GetBlogPost(request.Id);
                response.Id = result.Id;
                response.Data = result;
                response.Success = true;
                response.Message = PostMessages.GetByIdExists;
                response.Errors = null;

            }
            return response;
        }
    }
}