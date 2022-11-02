using Blogi.Application.Features.Languages.Dtos.Update;

namespace Blogi.Application.Features.Languages.Commands.Update
{
    public class UpdateLanguageCommand : IRequest<BaseCommandResponse<UpdateLanguageOutput>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Culture { get; set; }
    }
}