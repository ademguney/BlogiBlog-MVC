using Blogi.Application.Features.Tags.Dtos.Get;

namespace Blogi.Application.Features.Tags.Commands.Update
{
    public class UpdateTagCommand : IRequest<BaseCommandResponse<GetTagOutput>>
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public string Name { get; set; }
    }
}
