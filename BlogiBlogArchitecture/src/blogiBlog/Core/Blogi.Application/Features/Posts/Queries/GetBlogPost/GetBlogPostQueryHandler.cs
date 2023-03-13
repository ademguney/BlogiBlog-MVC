using Blogi.Application.Features.Posts.Dtos.GetBlogPost;

namespace Blogi.Application.Features.Posts.Queries.GetBlogPost
{
    public class GetBlogPostQueryHandler : IRequestHandler<GetBlogPostQuery, BaseCommandResponse<GetBlogPostOutput>>
    {
        private readonly IPostService _postService;
        private readonly IPostReadRepository _postReadRepository;
        private readonly IPostWriteRepository _postWriteRepository;
        private readonly IVisitorInformationService _visitorInformationService;

        public GetBlogPostQueryHandler(
            IPostService postService,
            IPostReadRepository postReadRepository,
            IPostWriteRepository postWriteRepository,
            IVisitorInformationService visitorInformationService
            )
        {
            _postService = postService;
            _postReadRepository = postReadRepository;
            _postWriteRepository = postWriteRepository;
            _visitorInformationService = visitorInformationService;
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
                #region Visitor Information

                var ipAddress = GetIpAddress.GetIpAddres();
                var post = await _postReadRepository.GetAsync(x => x.Id == request.Id);
                var visitor = await _visitorInformationService.GetAsync(ipAddress, post.Slug);              

                if (!visitor)
                {
                    post.CountOfView++;
                    _postWriteRepository.Update(post);
                    await _visitorInformationService.AddAsync(ipAddress, post.Slug);
                }

                #endregion

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