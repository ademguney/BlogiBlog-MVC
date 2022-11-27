using Blogi.Application.Features.Tags.Dtos.Get;

namespace Blogi.Application.Features.Tags.Commands.Delete
{
    public class DeleteTagCommand: IRequest<BaseCommandResponse<GetTagOutput>>
    {
        public int Id { get; set; }
    }
}