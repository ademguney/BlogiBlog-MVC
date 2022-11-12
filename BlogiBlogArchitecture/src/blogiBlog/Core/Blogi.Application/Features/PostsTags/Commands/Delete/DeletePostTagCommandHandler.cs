namespace Blogi.Application.Features.PostsTags.Commands.Delete
{
    public class DeletePostTagCommandHandler : IRequestHandler<DeletePostTagCommand, BaseCommandResponse<int>>
    {
        private readonly IPostReadRepository _postReadRepository;
        private readonly IPostTagService _postTagService;

        public DeletePostTagCommandHandler(
            IPostReadRepository postReadRepository,
            IPostTagService postTagService
            )
        {
            _postReadRepository = postReadRepository;
            _postTagService = postTagService;
        }

        public async Task<BaseCommandResponse<int>> Handle(DeletePostTagCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<int>();
            var validator = new DeletePostTagCommandHandlerValidatior(_postReadRepository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                response.Data = request.PostId;
                response.Success = false;
                response.Message = null;
                response.Errors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                await _postTagService.DeleteAsync(request.PostId);
                response.Id = request.PostId;
                response.Data = request.PostId;
                response.Success = true;
                response.Message = PostTagMessages.DeletedSuccess;
                response.Errors = null;
            }

            return response;
        }
    }
}