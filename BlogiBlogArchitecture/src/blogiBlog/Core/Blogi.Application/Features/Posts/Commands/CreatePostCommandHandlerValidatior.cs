namespace Blogi.Application.Features.Posts.Commands
{
    public class CreatePostCommandHandlerValidatior : AbstractValidator<CreatePostCommand>
    {
        public CreatePostCommandHandlerValidatior()
        {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.LanguageId)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.CategoryId)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Title)
                .MaximumLength(500)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Content)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Image)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.ImageAlt)
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

            RuleFor(x => x.Slug)
                .MaximumLength(500)
                .NotEmpty()
                .NotNull();
        }
    }
}