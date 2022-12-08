namespace Blogi.Application.Features.Posts.Queries.GetBlogPost
{
    public class GetBlogPostQueryHandlerValidatior : AbstractValidator<GetBlogPostQuery>
    {
        private readonly IPostReadRepository _postReadRepository;

        public GetBlogPostQueryHandlerValidatior(IPostReadRepository postReadRepository)
        {
            _postReadRepository = postReadRepository;

            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x)
                  .MustAsync(IdIsNotExists)
                  .WithMessage(PostMessages.GetByIdNotExists);
        }
        private async Task<bool> IdIsNotExists(GetBlogPostQuery e, CancellationToken token)
        {
            var result = await _postReadRepository.GetAsync(x => x.Id == e.Id);
            return result != null;
        }
    }
}