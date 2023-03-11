namespace Blogi.Application.Features.Comments.Commands.IsPublish
{
    public class IsPublishCommentCommandHandler : IRequestHandler<IsPublishCommentCommand, BaseCommandResponse<bool>>
    {

        private readonly ICommentWriteRepository _commentWriteRepository;
        private readonly ICommentReadRepository _commentReadRepository;

        public IsPublishCommentCommandHandler(ICommentWriteRepository commentWriteRepository, ICommentReadRepository commentReadRepository)
        {
            _commentWriteRepository = commentWriteRepository;
            _commentReadRepository = commentReadRepository;
        }

        public async Task<BaseCommandResponse<bool>> Handle(IsPublishCommentCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<bool>();
            var validator = new IsPublishCommentCommandHandlerValidatior(_commentReadRepository);
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
                var comment = await _commentReadRepository.GetAsync(x => x.Id == request.Id);
                comment.IsPublish = request.IsPublish;
                var result = await _commentWriteRepository.UpdateAsync(comment);

                response.Id = result.Id;
                response.Data = true;
                response.Success = true;
                response.Message = CommentMessages.IsPublishedSuccess;
                response.Errors = null;
            }

            return response;
        }
    }
}
