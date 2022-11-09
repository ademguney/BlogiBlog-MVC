using Blogi.Application.Features.Posts.Constants;

namespace Blogi.Application.Features.Posts.Queries.Get
{
    public class GetPostQueryHandlerValidatior : AbstractValidator<GetPostQuery>
    {
        private readonly IPostReadRepository _postReadRepository;

        public GetPostQueryHandlerValidatior(IPostReadRepository postReadRepository)
        {
            _postReadRepository = postReadRepository;

            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x)
                   .MustAsync(IdIsNotExists)
                   .WithMessage(PostMessages.GetByIdNotExists);
        }
        private async Task<bool> IdIsNotExists(GetPostQuery e, CancellationToken token)
        {
            var result = await _postReadRepository.GetAsync(x => x.Id == e.Id);
            return result != null;
        }
    }
}