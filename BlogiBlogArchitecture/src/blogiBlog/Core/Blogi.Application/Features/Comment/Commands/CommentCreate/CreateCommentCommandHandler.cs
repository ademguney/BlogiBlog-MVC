namespace Blogi.Application.Features.Comment.Commands.CommentCreate
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, BaseCommandResponse<bool>>
    {
        private readonly IMapper _mapper;
        private readonly ICommentWriteRepository _commentWriteRepository;

        public CreateCommentCommandHandler(IMapper mapper, ICommentWriteRepository commentWriteRepository)
        {
            _mapper = mapper;
            _commentWriteRepository = commentWriteRepository;
        }

        public async Task<BaseCommandResponse<bool>> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<bool>();
            var validator = new CreateCommentCommandHandlerValidator();
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                response.Data = false;
                response.Success = false;
                response.Message = "";
                response.Errors = validatorResult.Errors.Select(x => x.ErrorMessage).ToList();

            }
            else
            {
                var commentMapp = _mapper.Map<Domain.Entities.Comment>(request);
                commentMapp.CreationDate = DateTime.UtcNow;

                var result = await _commentWriteRepository.AddAsync(commentMapp);
                response.Id = request.PostId;
                response.Data = true;
                response.Success = true;
                response.Message = CommentMessages.CreatedSuccess;
                response.Errors = null;

            }
            return response;
        }
    }
}
