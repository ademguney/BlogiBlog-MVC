namespace Blogi.Application.Features.StringResources.Commands.Create
{
    public class CreateStringResourceCommandHandlerValidator : AbstractValidator<CreateStringResourceCommand>
    {
        public CreateStringResourceCommandHandlerValidator()
        {
            RuleFor(x => x.LanguageId)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Key)
                 .MaximumLength(500)
                 .NotEmpty()
                 .NotNull();

            RuleFor(x => x.Value)
                 .MaximumLength(500)
                 .NotEmpty()
                 .NotNull();
        }
    }
}
