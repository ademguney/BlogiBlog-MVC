namespace Blogi.Application.Features.Users.Queries.Get
{
    public class GetUserQueryHandlerValidatior : AbstractValidator<GetUserQuery>
    {
        private readonly IUserReadRepository _userReadRepository;

        public GetUserQueryHandlerValidatior(IUserReadRepository userReadRepository)
        {
            _userReadRepository = userReadRepository;

            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x)
                  .MustAsync(IdIsNotExists)
                  .WithMessage(TagMessages.GetByIdNotExists);
        }
        private async Task<bool> IdIsNotExists(GetUserQuery e, CancellationToken token)
        {
            var result = await _userReadRepository.GetAsync(x => x.Id == e.Id);
            return result != null;
        }
    }
}