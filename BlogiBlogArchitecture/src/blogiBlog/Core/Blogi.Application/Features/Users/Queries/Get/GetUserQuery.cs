using Blogi.Application.Features.Users.Dtos.Get;

namespace Blogi.Application.Features.Users.Queries.Get
{
    public class GetUserQuery : IRequest<BaseCommandResponse<GetUserOutput>>
    {
        public int Id { get; set; }
    }
}