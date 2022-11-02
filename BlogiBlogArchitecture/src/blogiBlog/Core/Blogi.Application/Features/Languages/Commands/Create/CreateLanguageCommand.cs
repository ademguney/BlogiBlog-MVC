using Blogi.Application.Features.Languages.Dtos.Create;

namespace Blogi.Application.Features.Languages.Commands.Create
{
    public class CreateLanguageCommand : IRequest<BaseCommandResponse<CreateLanguageOutput>>
    {
        public string Name { get; set; }
        public string Culture { get; set; }
    }
}