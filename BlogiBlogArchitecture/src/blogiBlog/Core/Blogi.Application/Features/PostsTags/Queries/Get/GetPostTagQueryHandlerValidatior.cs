namespace Blogi.Application.Features.PostsTags.Queries.Get
{
    public class GetPostTagQueryHandlerValidatior : AbstractValidator<GetPostTagQuery>
    {
        private readonly IPostReadRepository _postReadRepository;

        public GetPostTagQueryHandlerValidatior(IPostReadRepository postReadRepository)
        {
            _postReadRepository = postReadRepository;

            RuleFor(x => x.PostId)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x)
               .MustAsync(IdIsNotExists)
               .WithMessage(PostMessages.GetByIdNotExists);
        }

        private async Task<bool> IdIsNotExists(GetPostTagQuery e, CancellationToken token)
        {
            var result = await _postReadRepository.GetAsync(x => x.Id == e.PostId);
            return result != null;
        }
    }
}