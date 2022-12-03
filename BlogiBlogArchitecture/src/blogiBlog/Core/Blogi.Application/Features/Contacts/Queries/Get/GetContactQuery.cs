using Blogi.Application.Features.Contacts.Dtos.Get;

namespace Blogi.Application.Features.Contacts.Queries.Get
{
    public class GetContactQuery : IRequest<BaseCommandResponse<GetContactOutput>>
    {
        public int Id { get; set; }
        public string Culture { get; set; }
    }
}