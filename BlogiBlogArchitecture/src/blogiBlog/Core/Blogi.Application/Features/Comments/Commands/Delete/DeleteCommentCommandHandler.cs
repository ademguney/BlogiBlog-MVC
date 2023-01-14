namespace Blogi.Application.Features.Comments.Commands.Delete
{
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, BaseCommandResponse<bool>>
    {
        private readonly IMapper _mapper;
        private readonly ICommentReadRepository _commentReadRepository;
        private readonly ICommentWriteRepository _commentWriteRepository;
        public DeleteCommentCommandHandler(IMapper mapper, ICommentReadRepository commentReadRepository, ICommentWriteRepository commentWriteRepository)
        {
            _mapper = mapper;
            _commentReadRepository = commentReadRepository;
            _commentWriteRepository = commentWriteRepository;
        }

        public async Task<BaseCommandResponse<bool>> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<bool>();
            var validator = new DeleteCommentCommandHandlerValidatior(_commentReadRepository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                response.Data = false;
                response.Success = false;
                response.Message = null;
                response.Errors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                var contactMapp = _mapper.Map<Comment>(request);
                var result = await _commentWriteRepository.DeleteAsync(contactMapp);

                response.Id = result.Id;
                response.Data = true;
                response.Success = true;
                response.Message = CommentMessages.DeletedSuccess;
                response.Errors = null;
            }
            return response;
        }
    }
}
