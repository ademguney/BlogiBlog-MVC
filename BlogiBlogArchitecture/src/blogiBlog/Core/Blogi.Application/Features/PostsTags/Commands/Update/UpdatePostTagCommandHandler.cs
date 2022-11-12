namespace Blogi.Application.Features.PostsTags.Commands.Update
{
    public class UpdatePostTagCommandHandler : IRequestHandler<UpdatePostTagCommand, BaseCommandResponse<List<int>>>
    {
        private readonly IMapper _mapper;
        private readonly IPostTagService _postTagService;
        private readonly IPostReadRepository _postReadRepository;

        public UpdatePostTagCommandHandler(
            IMapper mapper,
            IPostTagService postTagService,
            IPostReadRepository postReadRepository

            )
        {
            _mapper = mapper;
            _postTagService = postTagService;
            _postReadRepository = postReadRepository;

        }

        public async Task<BaseCommandResponse<List<int>>> Handle(UpdatePostTagCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<List<int>>();
            var validator = new UpdatePostTagCommandHandlerValidatior(_postReadRepository);
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
                var result = await _postTagService.UpdateAsync(request.PostId, request.TagIds);
                response.Id = request.PostId;
                response.Data = result;
                response.Success = true;
                response.Message = PostTagMessages.UpdatedSuccess;
                response.Errors = null;
                return response;
            }

            return response;
        }
    }
}