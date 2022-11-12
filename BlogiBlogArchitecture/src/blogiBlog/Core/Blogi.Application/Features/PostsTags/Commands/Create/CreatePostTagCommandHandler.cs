namespace Blogi.Application.Features.PostsTags.Commands.Create
{
    public class CreatePostTagCommandHandler : IRequestHandler<CreatePostTagCommand, BaseCommandResponse<int>>
    {
        private readonly IPostReadRepository _postReadRepository;
        private readonly ITagReadRepository _tagReadRepository;
        private readonly IPostTagService _postTagService;

        public CreatePostTagCommandHandler(
            IPostReadRepository postReadRepository,
            ITagReadRepository tagReadRepository,
            IPostTagService postTagService
            )
        {
            _postReadRepository = postReadRepository;
            _tagReadRepository = tagReadRepository;
            _postTagService = postTagService;
        }

        public async Task<BaseCommandResponse<int>> Handle(CreatePostTagCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<int>();
            var validator = new CreatePostTagCommandHandlerValidatior(_postReadRepository, _tagReadRepository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                response.Data = request.PostId;
                response.Success = false;
                response.Message = "";
                response.Errors = validatorResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
            else
            {
                var result = await _postTagService.AddAsync(request.PostId, request.TagIds);
                response.Id = request.PostId;
                response.Data = request.PostId;
                response.Success = true;
                response.Message = null;
                response.Errors = null;
            }
            return response;
        }
    }
}