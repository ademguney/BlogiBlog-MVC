using Blogi.Application.Features.Tags.Dtos.Get;

namespace Blogi.Application.Features.Tags.Commands.Create
{
    public class CreateTagCommand : IRequest<BaseCommandResponse<GetTagOutput>>
    {
        public int LanguageId { get; set; }
        public string Name { get; set; }
    }
}
