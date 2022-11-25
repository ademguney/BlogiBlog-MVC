namespace Blogi.Application.Features.Contact.Commands.Update
{
    public class UpdateContactCommandHandlerValidatior : AbstractValidator<UpdateContactCommand>
    {
        public UpdateContactCommandHandlerValidatior()
        {
            RuleFor(x => x.Id)
               .NotEmpty()
               .NotNull();

            RuleFor(x => x.LanguageId)
               .NotEmpty()
               .NotNull();


            RuleFor(x => x.Phone)
                .MaximumLength(30);

            RuleFor(x => x.Email)
                .EmailAddress()
                .MaximumLength(255);

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