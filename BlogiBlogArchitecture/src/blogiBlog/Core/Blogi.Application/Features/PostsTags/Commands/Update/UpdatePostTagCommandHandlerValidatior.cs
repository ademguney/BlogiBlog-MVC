namespace Blogi.Application.Features.PostsTags.Commands.Update
{
    public class UpdatePostTagCommandHandlerValidatior : AbstractValidator<UpdatePostTagCommand>
    {
        private readonly IPostReadRepository _postReadRepository;

        public UpdatePostTagCommandHandlerValidatior(IPostReadRepository postReadRepository)
        {
            _postReadRepository = postReadRepository;

            RuleFor(x => x.PostId)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.TagIds)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x)
                          .MustAsync(PostIdIsNotExists)
                          .WithMessage(PostTagMessages.PostIdIsNotExists);
        }
        private async Task<bool> PostIdIsNotExists(UpdatePostTagCommand e, CancellationToken token)
        {
            var result = await _postReadRepository.GetAsync(x => x.Id == e.PostId);
            return result != null;
        }
    }
}