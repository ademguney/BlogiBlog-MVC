using Blogi.Application.Features.Contacts.Dtos.GetList;

namespace Blogi.Application.Features.Contacts.Queries.GetList
{
    public class GetListContactQuery : IRequest<BaseCommandResponse<List<GetListContactOutput>>>
    {
    }
}