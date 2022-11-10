namespace Blogi.Application.Features.PostsTags.Commands.Create
{
    public class CreatePostTagCommandHandler : IRequestHandler<CreatePostTagCommand, BaseCommandResponse<int>>
    {
        private readonly IMapper _mapper;
        private readonly IPostReadRepository _postReadRepository;
        private readonly IPostTagsWriteRepository _postTagsWriteRepository;
        private readonly ITagReadRepository _tagReadRepository;

        public CreatePostTagCommandHandler(
            IMapper mapper,
            IPostReadRepository postReadRepository,
            IPostTagsWriteRepository postTagsWriteRepository,
            ITagReadRepository tagReadRepository
            )
        {
            _mapper = mapper;
            _postReadRepository = postReadRepository;
            _postTagsWriteRepository = postTagsWriteRepository;
            _tagReadRepository = tagReadRepository;
        }

        public async Task<BaseCommandResponse<int>> Handle(CreatePostTagCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<int>();
            var validator = new CreatePostTagCommandHandlerValidatior(_postReadRepository, _tagReadRepository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                response.Data = 0;
                response.Success = false;
                response.Message = "";
                response.Errors = validatorResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
            else
            {
                foreach (var item in request.TagIds)
                {
                    var postTags = new PostTags
                    {
                        PostId = request.PostId,
                        TagId = item
                    };
                    await _postTagsWriteRepository.AddAsync(postTags);
                }

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
