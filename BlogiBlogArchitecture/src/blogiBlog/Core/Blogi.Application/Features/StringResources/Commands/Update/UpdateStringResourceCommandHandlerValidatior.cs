namespace Blogi.Application.Features.StringResources.Commands.Update
{
    public class UpdateStringResourceCommandHandlerValidatior : AbstractValidator<UpdateStringResourceCommand>
    {
        public UpdateStringResourceCommandHandlerValidatior()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull();

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
