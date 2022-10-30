namespace Blogi.Application.Features.Tags.Queries.Get
{
    public class GetTagQueryHandlerValidatior : AbstractValidator<GetTagQuery>
    {
        private readonly ITagReadRepository _tagReadRepository;
        public GetTagQueryHandlerValidatior(ITagReadRepository tagReadRepository)
        {
            _tagReadRepository = tagReadRepository;

            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x)
               .MustAsync(IdIsNotExists)
               .WithMessage(TagMessages.GetByIdNotExists);
        }

        private async Task<bool> IdIsNotExists(GetTagQuery e, CancellationToken token)
        {
            var result = await _tagReadRepository.GetAsync(x => x.Id == e.Id);
            return result != null;
        }
    }
}
