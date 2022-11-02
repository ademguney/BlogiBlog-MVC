using Blogi.Application.Features.Categories.Dtos.Get;

namespace Blogi.Application.Features.Categories.Queries.GetList
{
    public class GetListCategoryQuery : IRequest<BaseCommandResponse<List<GetCategoryOutput>>>
    {
    }
}