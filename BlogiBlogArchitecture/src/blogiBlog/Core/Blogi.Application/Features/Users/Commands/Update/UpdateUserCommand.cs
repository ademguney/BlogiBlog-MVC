using Blogi.Application.Features.Users.Dtos.Get;

namespace Blogi.Application.Features.Users.Commands.Update
{
    public class UpdateUserCommand : IRequest<BaseCommandResponse<GetUserOutput>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public byte[] Photo { get; set; }
    }
}