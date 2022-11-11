namespace Blogi.Application.Features.PostsTags.Commands.Delete
{
    public class DeletePostTagCommandHandler : IRequestHandler<DeletePostTagCommand, BaseCommandResponse<int>>
    {
        private readonly IMapper _mapper;
        private readonly IPostReadRepository _postReadRepository;
        private readonly IPostTagsWriteRepository _postTagsWriteRepository;
        private readonly IPostTagsReadRepository _postTagsReadRepository;

        public DeletePostTagCommandHandler(
            IMapper mapper,
            IPostReadRepository postReadRepository,
            IPostTagsWriteRepository postTagsWriteRepository,
            IPostTagsReadRepository postTagsReadRepository
            )
        {
            _mapper = mapper;
            _postReadRepository = postReadRepository;
            _postTagsWriteRepository = postTagsWriteRepository;
            _postTagsReadRepository = postTagsReadRepository;
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
                var postTag = await _postTagsReadRepository.GetListAsync(x => x.PostId == request.PostId);
                if (postTag is not null)
                {
                    foreach (var item in postTag)
                        await _postTagsWriteRepository.DeleteAsync(item);

                    response.Id = request.PostId;
                    response.Data = request.PostId;
                    response.Success = true;
                    response.Message = PostTagMessages.DeletedSuccess;
                    response.Errors = null;
                }

                response.Id = request.PostId;
                response.Data = request.PostId;
                response.Success = true;
                response.Message = PostTagMessages.GetList;
                response.Errors = null;
            }
            return response;
        }
    }
}
