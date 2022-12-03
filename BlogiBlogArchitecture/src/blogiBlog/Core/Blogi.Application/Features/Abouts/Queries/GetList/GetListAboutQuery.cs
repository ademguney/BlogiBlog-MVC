using Blogi.Application.Features.Abouts.Dtos.GetList;

namespace Blogi.Application.Features.Abouts.Queries.GetList
{
    public class GetListAboutQuery : IRequest<BaseCommandResponse<List<GetListAboutOutput>>>
    {
    }
}