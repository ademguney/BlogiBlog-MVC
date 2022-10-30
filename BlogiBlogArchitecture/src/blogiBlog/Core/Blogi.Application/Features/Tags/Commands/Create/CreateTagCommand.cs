using Blogi.Application.Features.Tags.Dtos.Get;

namespace Blogi.Application.Features.Tags.Commands.Create
{
    public class CreateTagCommand : IRequest<BaseCommandResponse<GetTagOutput>>
    {
        public string Name { get; set; }
    }
}
