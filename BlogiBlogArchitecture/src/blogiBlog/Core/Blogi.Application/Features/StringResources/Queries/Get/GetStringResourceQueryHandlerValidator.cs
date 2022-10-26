namespace Blogi.Application.Features.StringResources.Queries.Get
{
    public class GetStringResourceQueryHandlerValidator : AbstractValidator<GetStringResourceQuery>
    {
        private readonly IStringResourceReadRepository _stringResourceReadRepository;

        public GetStringResourceQueryHandlerValidator(IStringResourceReadRepository stringResourceReadRepository)
        {
            _stringResourceReadRepository = stringResourceReadRepository;

            RuleFor(x => x.Id)
               .NotEmpty()
               .NotNull();

            RuleFor(x => x)
                .MustAsync(IdIsNotExists)
                .WithMessage(StringResourceMessages.GetByIdNotExists);

        }

        private async Task<bool> IdIsNotExists(GetStringResourceQuery e, CancellationToken token)
        {
            var result = await _stringResourceReadRepository.GetAsync(x => x.Id == e.Id);
            return result != null;
        }
    }
}
