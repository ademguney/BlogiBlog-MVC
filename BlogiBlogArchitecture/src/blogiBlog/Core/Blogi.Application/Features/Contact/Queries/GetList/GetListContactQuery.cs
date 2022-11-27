using Blogi.Application.Features.Contact.Dtos.GetList;

namespace Blogi.Application.Features.Contact.Queries.GetList
{
    public class GetListContactQuery : IRequest<BaseCommandResponse<List<GetListContactOutput>>>
    {
    }
}