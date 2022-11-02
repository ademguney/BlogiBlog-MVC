namespace Blogi.Application.Features.Categories.Commands.Delete
{
    public class DeleteCategoryCommandHandlerValidatior : AbstractValidator<DeleteCategoryCommand>
    {
        private readonly ICategoryReadRepository _categoryReadRepository;

        public DeleteCategoryCommandHandlerValidatior(ICategoryReadRepository categoryReadRepository)
        {
            _categoryReadRepository = categoryReadRepository;

            RuleFor(x => x.Id)
                .NotEmpty()
                .Null();

            RuleFor(x => x)
                .MustAsync(IdIsNotExists)
                .WithMessage(CategoryMessages.GetByIdNotExists);
        }

        private async Task<bool> IdIsNotExists(DeleteCategoryCommand e, CancellationToken token)
        {
            var result = await _categoryReadRepository.GetAsync(x => x.Id == e.Id);
            return result != null;
        }
    }
}
