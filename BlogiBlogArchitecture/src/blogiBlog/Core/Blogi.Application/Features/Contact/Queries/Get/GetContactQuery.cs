using Blogi.Application.Features.Contract.Dtos.Get;

namespace Blogi.Application.Features.Contact.Queries.Get
{
    public class GetContactQuery : IRequest<BaseCommandResponse<GetContactOutput>>
    {
        public int Id { get; set; }
    }
}