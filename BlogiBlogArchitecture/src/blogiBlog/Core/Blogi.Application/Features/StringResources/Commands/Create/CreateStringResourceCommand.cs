using Blogi.Application.Features.StringResources.Dtos.Create;

namespace Blogi.Application.Features.StringResources.Commands.Create
{
    public class CreateStringResourceCommand : IRequest<BaseCommandResponse<CreateStringResourceOutput>>
    {        
        public int LanguageId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
