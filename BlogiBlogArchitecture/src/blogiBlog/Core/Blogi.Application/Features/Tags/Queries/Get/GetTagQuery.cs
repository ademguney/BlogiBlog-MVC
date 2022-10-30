using Blogi.Application.Features.Tags.Dtos.Get;

namespace Blogi.Application.Features.Tags.Queries.Get
{
    public class GetTagQuery :IRequest<BaseCommandResponse<GetTagOutput>>
    {
        public int Id { get; set; }
    }
}