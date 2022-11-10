namespace Blogi.Application.Features.PostsTags.Commands.Create
{
    public class CreatePostTagCommandHandlerValidatior : AbstractValidator<CreatePostTagCommand>
    {
        private readonly IPostReadRepository _postReadRepository;
        private readonly ITagReadRepository _tagReadRepository;

        public CreatePostTagCommandHandlerValidatior(IPostReadRepository postReadRepository, ITagReadRepository tagReadRepository)
        {
            _postReadRepository = postReadRepository;
            _tagReadRepository = tagReadRepository;

            RuleFor(x => x.PostId)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.TagIds)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x)
               .MustAsync(PostIdIsNotExists)
               .WithMessage(PostTagMessage.PostIdIsNotExists);

            RuleFor(x => x)
               .MustAsync(TagIdsIsNotExists)
               .WithMessage(PostTagMessage.TagIdsIsNotExists);
        }

        private async Task<bool> PostIdIsNotExists(CreatePostTagCommand e, CancellationToken token)
        {
            var result = await _postReadRepository.GetAsync(x => x.Id == e.PostId);
            return result != null;
        }

        private async Task<bool> TagIdsIsNotExists(CreatePostTagCommand e, CancellationToken token)
        {
            var result = await _tagReadRepository.GetAsync(x => e.TagIds.Contains(x.Id));
            return result != null;
        }
    }
}