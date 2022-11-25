namespace Blogi.Application.Features.WebSettings.Commands.Update
{
    public class UpdateWebSettingCommandHandlerValidatior : AbstractValidator<UpdateWebSettingCommand>
    {
        public UpdateWebSettingCommandHandlerValidatior()
        {
            RuleFor(x => x.Id)
               .NotEmpty()
               .NotNull();

            RuleFor(x => x.FacebookUrl)
                .MaximumLength(500);

            RuleFor(x => x.TwitterUrl)
                .MaximumLength(500);

            RuleFor(x => x.InstagramUrl)
                .MaximumLength(500);

            RuleFor(x => x.YouTubeUrl)
               .MaximumLength(500);

            RuleFor(x => x.MediumUrl)
              .MaximumLength(500);

            RuleFor(x => x.GithubUrl)
              .MaximumLength(500);

            RuleFor(x => x.LinkedinUrl)
             .MaximumLength(500);

            RuleFor(x => x.WebSiteUrl)
            .MaximumLength(500)
            .NotEmpty()
            .NotNull();

            RuleFor(x => x.Slogan)
            .MaximumLength(500)
            .NotEmpty()
            .NotNull();

            RuleFor(x => x.Title)
             .MaximumLength(500)
             .NotEmpty()
             .NotNull();

            RuleFor(x => x.Author)
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