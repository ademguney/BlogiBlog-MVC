namespace Blogi.Application.Features.Categories.Queries.Get
{
    public class GetCategoryQueryHandlerValidatior : AbstractValidator<GetCategoryQuery>
    {
        private readonly ICategoryReadRepository _categoryReadRepository;

        public GetCategoryQueryHandlerValidatior(ICategoryReadRepository categoryReadRepository)
        {
            _categoryReadRepository = categoryReadRepository;

            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x)
                   .MustAsync(IdIsNotExists)
                   .WithMessage(CategoryMessages.GetByIdNotExists);
        }

        private async Task<bool> IdIsNotExists(GetCategoryQuery e, CancellationToken token)
        {
            var result = await _categoryReadRepository.GetAsync(x => x.Id == e.Id);
            return result != null;
        }
    }
}