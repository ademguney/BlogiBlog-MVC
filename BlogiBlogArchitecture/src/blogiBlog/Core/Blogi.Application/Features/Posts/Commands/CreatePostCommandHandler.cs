using Blogi.Application.Features.Posts.Dtos.Get;

namespace Blogi.Application.Features.Posts.Commands
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, BaseCommandResponse<GetPostOutput>>
    {
        private readonly IMapper _mapper;
        private readonly IPostReadRepository _postReadRepository;
        private readonly IPostWriteRepository _postWriteRepository;

        public CreatePostCommandHandler(
            IMapper mapper,
            IPostReadRepository postReadRepository,
            IPostWriteRepository postWriteRepository
            )
        {
            _mapper = mapper;
            _postReadRepository = postReadRepository;
            _postWriteRepository = postWriteRepository;
        }

        public async Task<BaseCommandResponse<GetPostOutput>> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var response= new BaseCommandResponse<GetPostOutput>();
            var validator = new CreatePostCommandHandlerValidatior(_postReadRepository);
            var validatorResult= await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                response.Data = null;
                response.Success = false;
                response.Message = "";
                response.Errors = validatorResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
            else
            {
                var postMapp = _mapper.Map<Post>(request);
                postMapp.CreatedById = request.UserId;
                postMapp.CreationDate = DateTime.UtcNow;

                var result= await _postWriteRepository.AddAsync(postMapp);
                var resultMapp= _mapper.Map<GetPostOutput>(result);

                response.Id = resultMapp.Id;
                response.Data = resultMapp;
                response.Success = true;
                response.Message = PostMessages.CreatedSuccess;
                response.Errors = null;
            }

            return response;
        }
    }
}
