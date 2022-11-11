namespace Blogi.Application.Features.Posts.Commands.Delete
{
    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand, BaseCommandResponse<int>>
    {
        private readonly IMapper _mapper;
        private readonly IPostReadRepository _postReadRepository;
        private readonly IPostWriteRepository _postWriteRepository;

        public DeletePostCommandHandler(
            IMapper mapper, 
            IPostReadRepository postReadRepository, 
            IPostWriteRepository postWriteRepository
            )
        {
            _mapper = mapper;
            _postReadRepository = postReadRepository;
            _postWriteRepository = postWriteRepository;
        }

        public async Task<BaseCommandResponse<int>> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<int>();
            var validator = new DeletePostCommandHandlerValidatior(_postReadRepository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                response.Data = request.Id;
                response.Success = false;
                response.Message = null;
                response.Errors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                var postMapp = _mapper.Map<Post>(request);
                var entity=await _postReadRepository.GetAsync(x=>x.Id == request.Id);
                var result = await _postWriteRepository.DeleteAsync(entity);

                response.Id = result.Id;
                response.Data = result.Id;
                response.Success = true;
                response.Message = PostMessages.DeletedSuccess;
                response.Errors = null;
            }
            return response;
        }
    }
}
