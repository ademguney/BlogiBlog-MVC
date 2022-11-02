namespace Blogi.Application.Features.Categories.Commands.Update
{
    public class UpdateCategoryCommandHandlerValidatior : AbstractValidator<UpdateCategoryCommand>
    {
        private readonly ICategoryReadRepository _categoryReadRepository;

        public UpdateCategoryCommandHandlerValidatior(ICategoryReadRepository categoryReadRepository)
        {
            _categoryReadRepository = categoryReadRepository;

            RuleFor(x => x.Id)
                  .NotEmpty()
                  .NotNull();

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
                  .MustAsync(IdIsNotExists)
                  .WithMessage(CategoryMessages.GetByIdNotExists);
        }
        private async Task<bool> IdIsNotExists(UpdateCategoryCommand e, CancellationToken token)
        {
            var result = await _categoryReadRepository.GetAsync(x => x.Id == e.Id);
            return result != null;
        }
    }
}