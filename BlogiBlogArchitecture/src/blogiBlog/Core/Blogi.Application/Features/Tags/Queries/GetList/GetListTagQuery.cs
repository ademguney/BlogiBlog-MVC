using Blogi.Application.Features.Tags.Dtos.Get;
using Blogi.Application.Features.Tags.Dtos.GetTagList;

namespace Blogi.Application.Features.Tags.Queries.GetList
{
    public class GetListTagQuery : IRequest<BaseCommandResponse<List<GetTagListOutput>>>
    {
        public string Culture { get; set; }
    }
}