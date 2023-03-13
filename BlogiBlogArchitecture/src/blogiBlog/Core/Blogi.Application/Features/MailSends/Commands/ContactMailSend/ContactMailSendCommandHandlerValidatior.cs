namespace Blogi.Application.Features.MailSends.Commands.ContactMailSend
{
    public class ContactMailSendCommandHandlerValidatior : AbstractValidator<ContactMailSendCommand>
    {
        public ContactMailSendCommandHandlerValidatior()
        {
            RuleFor(x => x.Name)
               .MaximumLength(500)
               .NotEmpty()
               .NotNull();

            RuleFor(x => x.Surname)
               .MaximumLength(500)
               .NotEmpty()
               .NotNull();

            RuleFor(x => x.Email)
                .MaximumLength(225)
                .EmailAddress()
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Subject)
               .NotEmpty()
               .NotNull();

            RuleFor(x => x.Body)               
               .NotEmpty()
               .NotNull();
        }
    }
}