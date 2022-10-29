namespace Blogi.Application.Features.MailSettings.Commands.Update
{
    public class UpdateMailSettingCommandHandlerValidator : AbstractValidator<UpdateMailSettingCommand>
    {
        public UpdateMailSettingCommandHandlerValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Host)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Port)
               .NotEmpty()
               .NotNull();

            RuleFor(x => x.Email)
                .MaximumLength(225)
               .NotEmpty()
               .NotNull();

            RuleFor(x => x.FullName)
                .MaximumLength(500)
               .NotEmpty()
               .NotNull();
        }
    }
}
