using Blogi.Application.Features.Languages.Dtos.GetList;

namespace Blogi.Application.Features.Languages.Queries.GetList
{
    public class GetListLanguageQuery : IRequest<BaseCommandResponse<List<GetListLanguageOutput>>>
    {
    }
}