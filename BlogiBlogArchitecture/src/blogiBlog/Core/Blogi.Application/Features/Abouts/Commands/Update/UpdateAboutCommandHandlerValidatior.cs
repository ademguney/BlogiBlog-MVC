namespace Blogi.Application.Features.Abouts.Commands.Update
{
    public class UpdateAboutCommandHandlerValidatior : AbstractValidator<UpdateAboutCommand>
    {
        public UpdateAboutCommandHandlerValidatior()
        {
            RuleFor(x => x.Id)
               .NotEmpty()
               .NotNull();

            RuleFor(x => x.LanguageId)
               .NotEmpty()
               .NotNull();

            RuleFor(x => x.Content)
             .NotEmpty()
             .NotNull();

            RuleFor(x => x.Title)
            .MaximumLength(500)
            .NotEmpty()
            .NotNull();

            RuleFor(x => x.Slug)
           .MaximumLength(500)
           .NotEmpty()
           .NotNull();

            RuleFor(x => x.MetaKeywords)
             .MaximumLength(500)
             .NotEmpty()
             .NotNull();

            RuleFor(x => x.MetaDescription)
            .MaximumLength(500)
            .NotEmpty()
            .NotNull();
        }
    }
}