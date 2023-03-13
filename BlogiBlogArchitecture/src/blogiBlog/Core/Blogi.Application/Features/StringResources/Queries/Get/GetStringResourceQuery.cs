using Blogi.Application.Features.StringResources.Dtos.Get;

namespace Blogi.Application.Features.StringResources.Queries.Get
{
    public class GetStringResourceQuery : IRequest<BaseCommandResponse<GetStringResourceOutput>>
    {
        public int Id { get; set; }
    }
}