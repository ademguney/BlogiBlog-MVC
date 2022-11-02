namespace Blogi.Application.Features.Categories.Commands.Create
{
    public class CreateCategoryCommandHandlerValidatior : AbstractValidator<CreateCategoryCommand>
    {
        private readonly ICategoryReadRepository _categoryReadRepository;

        public CreateCategoryCommandHandlerValidatior(ICategoryReadRepository categoryReadRepository)
        {
            _categoryReadRepository = categoryReadRepository;

            RuleFor(x => x.LanguageId)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Name)
                .MaximumLength(225)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Slug)
                 .MaximumLength(500)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x)
                 .MustAsync(NameCanNotBeDuplicatedWhenInserted)
                 .WithMessage(CategoryMessages.NameExists);
        }
        private async Task<bool> NameCanNotBeDuplicatedWhenInserted(CreateCategoryCommand e, CancellationToken token)
        {
            var result = await _categoryReadRepository.GetAsync(x => x.Name == e.Name && x.LanguageId == e.LanguageId);
            return result == null;
        }
    }
}